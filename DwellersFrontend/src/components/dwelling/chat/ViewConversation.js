import { useEffect, useState } from 'react';
import ChatService from './ChatService';
import signalRService from '../../../config/SignalRService';
import ChatComponent from './ChatComponent';
import MessageBox from './design/MessageBox';
import { formatDate } from '../../utils/FormatTime';

export default function ViewConversation(props) {
  const [messages, setMessages] = useState([]);
  const [conversationId, setConversationId] = useState(null);
  const [currentUser, setCurrentUser] = useState('');
  const [isConnected, setIsConnected] = useState(false);

  // Set user in order to get the right sender from the message-box
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
    if (props.conversationId) {
      fetchAndUpdateConversationData(props.conversationId);
    } else {
      fetchAndUpdateConversationData();
    }
  }, [props.conversationId]);

  const fetchAndUpdateConversationData = async (conversationId) => {
    try {
      console.log('I FIRE!')
      let data;
      if (conversationId) {
        data = await ChatService.getDwellingConversation(conversationId);
      } else {
        data = await ChatService.getDwellingConversation();
      }
      setMessages(data);
      setConversationId(data.conversationId);

      if (conversationId) {
        await signalRService.startConnection();
        await signalRService.joinConversationGroup(conversationId);
        setIsConnected(true);
      }
    } catch (error) {
      console.error('Error fetching conversation data:', error);
    }
  };

  return (
    <>
      <ChatComponent
        key={conversationId}
        conversationId={conversationId}
        fetchAndUpdateConversationData={fetchAndUpdateConversationData}
      />

      {Array.isArray(messages.messageList) &&
        messages.messageList
          .sort((b, a) => new Date(a.messageDate) - new Date(b.messageDate))
          .map((message) => (
            <div key={message.id} className="message flex justify-start">
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
                    <p className="mr-2">{message.author}</p>
                  </div>
                  <div className="col-span-1 flex justify-end">
                    <p>{formatDate(message.messageDate)}</p>
                  </div>
                </section>
              </MessageBox>
            </div>
          ))}
    </>
  );
}
