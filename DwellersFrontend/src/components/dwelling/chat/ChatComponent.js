import React, { useState, useEffect } from 'react';
import ChatService from './ChatService';
import { ArrowIcon } from '../../layout/svg/NavbarIcons'

export default function ChatComponent(props) {
  const [message, setMessage] = useState("");
  

    const handleSendMessage = async () => {
      if (message.trim() !== "") {
        const conversationId = props.conversationId;
        console.log(props.conversationId);
          try {
            console.log("ConversationID:" + conversationId);
            console.log("Message:" + message);
            await  props.signalRService.sendMessage(message, conversationId);
            await ChatService.persistMessage(message, conversationId);
            console.log('Message persisted');
            setMessage("");
            if (props.fetchAndUpdateConversationData) {
              props.fetchAndUpdateConversationData();
            }
          } catch (error) {
            console.error("Error while sending message: ", error);
          }
      };
    }

  return (
  <>
    <section className="grid grid-cols-10 mt-4 mb-2 bg-white">
      <div className="col-span-9">
        <textarea
              className="w-full py-1 px-3 text-gray-700
                        mb-3 focus:outline-none shadow-md"
              rows="4"
              placeholder="Nytt meddelande.."
              value={message}
              onChange={(e) => setMessage(e.target.value)}
              />
      </div>
      <div className="col-span-1 flex items-center ml-5">
      <div className="">
            <button 
              onClick={handleSendMessage}
              > 
             <span> <ArrowIcon/></span>
            </button>
        </div>
      </div>
    </section>


   
  </>
  );
}