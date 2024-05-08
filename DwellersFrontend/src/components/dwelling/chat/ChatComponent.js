import React, { useState, useEffect } from 'react';
import ChatService from './ChatService';
import signalRService from '../../../config/SignalRService';
import { ArrowIcon } from '../../layout/svg/NavbarIcons'

export default function ChatComponent(props) {
  const [message, setMessage] = useState("");
  

  const handleKeyDown = (e) => {
    if (e.key === 'Enter') {
      e.preventDefault();
      handleSendMessage();
    }
  };

  useEffect(() => {

  }, [props.conversationId])

  const handleSendMessage = async () => {
    if (message.trim() !== "") {
      const conversationId = props.conversationId;

        try {
          await  signalRService.sendMessage(message, conversationId);
          await ChatService.persistMessage(message, conversationId);
          setMessage("");
        
          props.fetchAndUpdateConversationData(props.conversationId);
          
        } catch (error) {
          console.error("Error while sending message: ", error);
        }
    };
  }

  return (
  <>
<section className="grid grid-cols-10 mt-4 mb-2 bg-white">
  <div className="col-span-9 flex">
    <textarea
      className="w-[75%] py-1 px-3 text-gray-700 
                mb-3 focus:outline-none shadow-md"
      rows="4"
      placeholder="Nytt meddelande.."
      value={message}
      onChange={(e) => setMessage(e.target.value)}
      onKeyDown={handleKeyDown}
    />
    <div className="flex items-center ml-5">
      <button onClick={handleSendMessage}> 
        <ArrowIcon/>
      </button>
    </div>
  </div>
</section>


   
  </>
  );
}