import { useEffect, useState } from 'react';
import ChatService from './ChatService';
import signalRService from '../../../config/SignalRService';
import ChatComponent from './ChatComponent';
import MessageBox from './design/MessageBox';
import { formatDate } from '../../utils/FormatTime';

export default function ViewConversation() {
  const [messages, setMessages] = useState([]);
  const [conversationId, setConversationId] = useState('');
  const [currentUser, setCurrentUser] = useState('');
  const [isConnected, setIsConnected] = useState(false);

  const fetchUserData = async () => {
    try {
      const userData = await ChatService.getDwellerData();
      setCurrentUser(userData);
      await signalRService.startConnection();
    } catch (error) {
      console.error('Error fetching userdata:', error);
    }
  };

  useEffect(() => {
    fetchUserData();
  }, []);
  

const fetchAndUpdateConversationData = async () => {
  try {
    console.log("I AM HERE");
    const data = await ChatService.getDwellingConversation();

    console.log("HUPP");
    console.log(data);
    setMessages(data);
    setConversationId(data.conversationId);
    
    await signalRService.startConnection();

    await signalRService.joinConversationGroup(conversationId);
    setIsConnected(true);

  } catch (error) {
    console.error('Error fetching conversation data:', error);
  }
};

useEffect(() => {
  fetchAndUpdateConversationData();
}, [conversationId]);


  return (
    <>
        <ChatComponent
              key={conversationId}
              conversationId={conversationId}
              fetchAndUpdateConversationData={fetchAndUpdateConversationData} 
              signalRService={signalRService} 
        />


        {Array.isArray(messages.messageList) &&
          messages.messageList
            .sort((b, a) => new Date(a.timestamp) - new Date(b.timestamp))
            .map((message) => (
              
                
              <div key={message.id} className="message flex justify-center">
  
              <MessageBox
                    currentUser={currentUser.id}
                    messageSender={message.id}
                >
              
              <section className="post-details my-1 m-3 py-1">
                  <p className="font-contentFont text-stone-900 text-xs m-3">
                      {message.message}
                  </p>
                </section>
              
                
                <section className="grid grid-cols-2 text-xs text-stone-400 mx-4">
                   <div className="col-span-1 flex justify-start">
                    <p className="mr-2">
                        {message.author}
                      </p>
                   </div>
                   
                   <div className="col-span-1 flex justify-end">
                      <p>
                        {formatDate(message.messageDate)}
                      </p>   
                    </div>
                </section>
                </MessageBox>
              
              </div>
              
            ))}
      
    </>
  );
}