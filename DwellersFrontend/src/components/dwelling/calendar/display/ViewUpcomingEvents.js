import { useState, useEffect } from 'react';
import ViewEvent from '../display/ViewEvent';
import CalendarService from '../CalendarServices';
import AddCalendarEvent from '../AddCalendarEvent';
import DwellerModal from '../../../layout/DwellerModal';

export default function ViewUpcomingEvents() {
  const [events, setEvents] = useState(null);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedEventId, setSelectedEventId] = useState(null);
  const [refreshEvents, setRefreshEvents] = useState(false);

  const [isAddModalOpen, setIsAddModalOpen] = useState(false);

  // Array-slice
  const maxLimit = 4;

  const handleEventChanged = () => {
    setIsModalOpen(false); 
    setIsAddModalOpen(false); 
    setRefreshEvents(prev => !prev);
  };

    const handleOpenAddModal = () => {
      setIsAddModalOpen(true);
    };
    
    const handleCloseAddModal = () => {
      console.log("Closing modal");
      setIsAddModalOpen(false);
  };


  const handleModalOpen = (eventId) => {
    setSelectedEventId(eventId);
    setIsModalOpen(true);
  };

  const handleModalClose = () => {
    setIsModalOpen(false);
  };

  useEffect(() => {
    CalendarService.getUpcomingEvents()
      .then((data) => {
        setEvents(data.listOfEvents); 
      }) .catch((error) => {
        console.error("Failed to fetch events:", error);
      });
  }, [refreshEvents]);

  return (
    <div className="grid gap-2">
     
       {Array.isArray(events) &&
      events.slice(0, maxLimit).map((point, index) => (
          <>
          <div className="grid grid-cols-2 items-center mt-3 mb-1">
            <div className="col-span-1 flex flex-row justify-start">
              <button onClick={() => handleModalOpen(point.id)}>
                <h3 className="text-black text-sm font-titleFont">
                    {point.eventTitle}
                </h3>
              </button>
            </div>

            <div className="col-span-1 flex flex-row justify-start">
                <p className="text-stone-300 text-xs font-titleFont">
                  {point.eventDate}
                </p>
            </div>
          </div>

      <section className="">
        <p className="text-xs text-stone-600 line-clamp-2 mb-4">{point.eventText}</p>
      </section >
    </>
    
    
        ))}
      <ViewEvent
        eventId={selectedEventId}
        isOpen={isModalOpen}
        onClose={handleModalClose}
        onEventChanged={handleEventChanged}
      />

    <div>
   
    </div>
   
    </div>
    
  );
}

     
// <div>
// <button
//     className="text-xl text-stone-600 flex flex-justify-start mt-4 text-black"
//     onClick={handleOpenAddModal}
//     >
//     +
//     </button>

//     {isAddModalOpen && (
//     <DwellerModal
//       isOpen={isAddModalOpen}
//       onClose={handleCloseAddModal}
//       body={<AddCalendarEvent isOpen={isAddModalOpen} onClose={handleCloseAddModal} onEventChanged={handleEventChanged} />}

//     />
//     )}
// </div>