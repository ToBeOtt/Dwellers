import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import AddConversation from '../../components/dwelling/chat/AddConversation';
import ViewConversation from '../../components/dwelling/chat/ViewConversation';
import signalRService  from '../../config/SignalRService';

export default function ChatPage() { 
    const navigate = useNavigate();
    const [conversationId, setConversationId] = useState();

    useEffect(() => {
      const checkTokenAndConnect = async () => {
        if (localStorage.getItem('token') === null) {
          navigate('/UnauthorizedPage');
        } else {
          await signalRService.startConnection();
        }
      };
  
      checkTokenAndConnect();
    }, [navigate]);

  const handleNewConversationRequest = async (id) => {
    await signalRService.leaveConversationGroup(conversationId);
    setConversationId(id);
  };

  useEffect(() => {

  }, [conversationId]);

  
return (
<>
<main className="mx-auto max-w-7xl px-6 w-full py-8
                    lg:px-8">
      {/* Chat-grid */}
      <section className="grid grid-cols-1 gap-x-10 gap-y-16 
                      lg:grid-cols-3 lg:mx-0 lg:max-w-none">

            <article className="my-5 gap-x-10 col-span-1 gap-y-16 border-r-2 border-stone-100
                                            lg:col-span-2 lg:mr-3 lg:max-w-none lg:pr-10">
                <div className="mx-auto mb-3 pb-3 pl-4 inline-block opacity-75">
                    <h2 className="text-md pl-3 font-logoText tracking-wide text-hh">
                      Dwelling chat
                    </h2>
                </div>
                
                <div className="">
                  <ViewConversation  conversationId={conversationId} />
                </div>        
            </article>

        {/* Second column - Neighbourhood-chats */}
        <article className="my-5 gap-x-10 col-span-1 gap-y-16 ml-10
                        lg:col-span-1 lg:mr-3 lg:max-w-none">
            <div className="mx-auto mb-2 pb-2 pl-4 inline-block opacity-75">
                <h2 className="mx-10 my-2 text-md pl-3 font-logoText tracking-wide text-hh">
                   All chats
                </h2>
                <AddConversation onConversationRequest={handleNewConversationRequest} />
            </div>
          
        </article>

      </section>
    </main>
    </>           
    );
}
