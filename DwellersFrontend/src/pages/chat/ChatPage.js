import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import SubMenu from '../../components/layout/SubMenu'
import ContentLayout from '../../components/layout/ContentLayout';
import ViewConversation from '../../components/dwelling/chat/ViewConversation';
import signalRService  from '../../config/SignalRService';

export default function ChatPage() { 
    const navigate = useNavigate();

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

  
return (
<>
<SubMenu> 
    <div className="text-xs font-titleFont text-stone-600 rounded border-x-2 border-stone-500 px-3">
        <h1 className="my-1 tracking-wider font-logoText text-stone-400 underline">Konversationer</h1>

        <button
            to="/AddNotePage"
            className="block px-2"         
            >
            + ny konversation
        </button>
      </div>
  </SubMenu>


<main className="mx-auto max-w-7xl px-6 w-full py-8
                    lg:px-8">
      {/* Chat-grid */}
      <section className="grid grid-cols-1 gap-x-10 gap-y-16 
                      lg:grid-cols-2 lg:mx-0 lg:max-w-none">

            <article className="my-5 gap-x-10 col-span-2 gap-y-16 border-r-2 border-stone-100
                                            lg:col-span-1 lg:mr-3 lg:max-w-none lg:pr-10">
                <div className="mx-auto mb-3 pb-3 pl-4 inline-block opacity-50">
                    <h2 className="text-md pl-3 font-logoText tracking-wide text-hh">
                      Dwelling chat
                    </h2>
                </div>
                
                <div className="">
                  <ViewConversation />
                </div>        
            </article>

        {/* Second column - Bulletins */}
        <article className="my-5 gap-x-10 col-span-3 border-r-2 border-stone-100 gap-y-16 ml-10
                        lg:col-span-1 lg:mr-3 lg:max-w-none">
            <div className="mx-auto mb-2 pb-2 pl-4 inline-block opacity-40">
                <h2 className="text-md pl-3 font-logoText tracking-wide text-hh">
                    Other chats etc - Not Implemented
                </h2>
            </div>
        
        {/* Unique bulletin-element */}
 
        </article>

      </section>
    </main>

{/* <div className="">
 
 
  <div className="h-auto mx-auto py-14 2xl:grid grid-cols-6 2xl:w-full 2xl:mt-5">
            <div className="col-span-1"></div>
            <div className="col-span-4">
              <ViewConversation />
            </div>
          
          <div className="col-span-1"></div>
      </div>
    </div>

       */}

   
    </>           
    );
}
