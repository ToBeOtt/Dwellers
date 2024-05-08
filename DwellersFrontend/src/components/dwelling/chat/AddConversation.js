import { useEffect, useState } from 'react';
import DwellingService from '../DwellingService';
import ChatService from '../chat/ChatService';

export default function AddConversation({ onConversationRequest }) {
  const [listOfMembersInConversation, setlistOfMembersInConversation] = useState([]);
  const [listOfSelectedMembers, setListOfSelectedMembers] = useState([]);
  const [selectedMember, setSelectedMember] = useState(""); 
  const [listOfMemberIds, setListOfMemberIds] = useState([]);
  const [activeConversations, setActiveConversations] = useState([]);
  const [userInfo, setUserInfo] = useState("");

  const getAllConnectedDwellings = async () => {
    const response = await DwellingService.getConnectedDwellings();
    
    // Convert dictionary to an array of objects
    const membersArray = Object.entries(response.data.connectedDwellings).map(([id, name]) => ({ id, name }));
    setlistOfMembersInConversation(membersArray);
  };

  const getAllCurrentConversations = async () => {
    const response = await ChatService.getAllDwellingConversations();
    setActiveConversations(response.conversations)
  };

  const handleSelectChange = (e) => {
    setSelectedMember(e.target.value);
    const selectedMemberId = e.target.value; 

    if (!listOfMemberIds.includes(selectedMemberId)) {
      const selectedMemberName = e.target.options[e.target.selectedIndex].text;
      setListOfSelectedMembers([...listOfSelectedMembers, selectedMemberName]);
      setListOfMemberIds([...listOfMemberIds, selectedMemberId]);
    }
  };

  const handleClearMembersForConversation = (e) => {
    setSelectedMember('');
    setListOfSelectedMembers([]);
    setListOfMemberIds([]);
  };

  
  const handleConversationRequest = async () => {
    try {
      await ChatService.addDwellingConversation(listOfMemberIds);
    } catch (error) {
      setUserInfo(error.message);
      setTimeout(() => {
        setUserInfo(""); 
      }, 2000);
    }
  };
  
  const HandleFetchNewConversation = async (e) => {
    const id = e.target.value;
    onConversationRequest(id);
  };
  
    useEffect(() => {
       getAllConnectedDwellings(); 
       getAllCurrentConversations(); 
    }, [] ); 

    return (
        <>
            {userInfo && userInfo.length > 0 && (
              <p className="text-red-700 text-sm">
                {userInfo}
              </p>
            )}
      
   
            <section className="flex dir-hor m-3">

              <select
                  className="bg-white hover:bg-hh mr-4 hover:bg-hover-n shadow-sm border rounded p-2 text-gray-400 text-md focus:outline-none focus:shadow-outline"
                  id="status"
                  value={selectedMember}
                  onChange={handleSelectChange}
                  >
                   <option value="" disabled hidden>New conversation..</option>
                    {listOfMembersInConversation.map(member => (
                      <option key={member.id} value={member.id}>
                        {member.name}
                      </option>
                    ))}
              </select>

              <button
                className="bg-hh mr-2 text-xs font-titleFont text-zinc-300 tracking-wider font-bold rounded focus:outline-none focus:shadow-outline
                hover:bg-hover-hh p-2 hover:text-white"
                type="button"
                onClick={handleConversationRequest}
                >
              Create
              </button>

              {listOfSelectedMembers.length > 0 && (
              <button
                className="p-2 bg-red-500 text-xs font-titleFont text-zinc-200 font-bold border-1 border-black rounded focus:outline-none focus:shadow-outline
                hover:bg-red-700 hover:text-white "
                type="button"
                onClick={handleClearMembersForConversation}
                >
              Clear
              </button>
            )}
            </section>
            
            <section className="flex dir-hor m-3">
              
              {listOfSelectedMembers.map((member, index) => (
                <div 
                className="p-2 m-2 border-1 text-xs rounded border-hh bg-zinc-300"
                key={index}>{member}
                </div>
              ))}
            </section>
      
        {activeConversations.length > 0 && (
          <article>
          {activeConversations.map(conversation => (
            <div key={conversation.id} className="text-center m-10 flex dir-hor">

                <div className="rounded-full overflow-hidden border-2 border-white shadow-md w-14 h-14">
                  <div className="w-full h-full bg-gray-300 "></div>
                </div>
             
              <div className="mt-2 text-xs ml-3 flex items-center font-titleFont text-dweller-pink">
                <button
                  className="hover:text-zinc-600"
                  onClick={HandleFetchNewConversation}
                  value={conversation.id}>
                  {conversation.name}
                  </button>
              </div>
            </div>
          ))}
        </article>
        )}

        </>
    )
  }
