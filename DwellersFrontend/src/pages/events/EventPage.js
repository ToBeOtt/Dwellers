import { useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import AddCalendarEvent from '../../components/dwelling/calendar/AddCalendarEvent';
import ViewAllEvents from '../../components/dwelling/calendar/display/ViewAllEvents';


export default function EventPage(props) {
  const navigate = useNavigate();
  const [refreshEvents, setRefreshEvents] = useState(false);

  useEffect(() => {
    localStorage.getItem('token') === null && (
      navigate('/LoginPage')
    );
  })


  const handleEventChanged = () => {
    setRefreshEvents(prev => !prev);
  };
 
return (
<>

 {/* Event description/greeting */} 

{/* Calendar-grid */}
<div className="border-b-4 border-stone-500">
<section className="grid grid-cols-1 gap-x-10 gap-y-16 px-5 py-8
                    lg:grid-cols-3 lg:mx-0 lg:max-w-none">
                      
      {/* First column - Calendar*/}   
      <article className="w-[90%]
                          lg:col-span-2 lg:mr-3 lg:max-w-none">
          <ViewAllEvents refresh={refreshEvents}/>
      </article>

      <article className="mt-5 lg:col-span-1 lg:mr-8 lg:max-w-none">
        <AddCalendarEvent onEventChanged={handleEventChanged} />
      </article> 
    
  </section>
  </div>
</>

 
);
}


