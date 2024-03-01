import { useState, useEffect } from 'react';
import DashboardService from '../DashboardService';

export default function ViewUpcomingEvent() {
    const [upcomingEvents, setUpcomingEvents] = useState(null);

    useEffect(() => {
        DashboardService.getDashboardNotes()
          .then((data) => {
            const eventData = data.events;
            setUpcomingEvents(eventData);
          });
    }, []); 
   

    
    return(
        <>
        {Array.isArray(upcomingEvents) &&
            upcomingEvents.slice(0, 5).map((point, index) => (
     
  
            <article className="flex flex-col items-start justify-between mb-10 pb-4">
            <div className="flex items-center gap-x-4 text-xs">
                    <time 
                        dateTime="2020-03-16" 
                        className="text-stone-500">
                            {point.eventDate}
                    </time>
                    
                    
                    {point.eventScope ? (
                        <a href="#" className="relative z-10 rounded-full bg-stone-50 px-3 py-1.5 font-medium text-gray-600 hover:bg-gray-100">
                            <p className="font-contentFont text-green-700 text-xs"> {point.eventScope}</p>
                        </a>
                        ) : (
                        <div className="hidden"></div>
                        )}
                        
                       
                    
                   
                </div>

                <div className="group relative">
                    <h3 className="mt-3 text-lg font-semibold leading-6 text-stone-900 group-hover:text-stone-600">
                        <a href="#">
                        <span className="absolute inset-0"></span>
                            {point.title}
                        </a>
                    </h3>
                    <p className="mt-3 line-clamp-3 text-sm leading-6 text-stone-600 w-[80%]">
                    {point.description}
                    </p>
                </div>

                <div className="relative mt-8 flex items-center gap-x-4">
                    
                    <div className="text-sm leading-6">
                        <p className="font-semibold text-gray-900">
                            <a href="#">
                            <span className="absolute inset-0"></span>
                                {point.user.alias}
                            </a>
                        </p>
                        <p className="text-gray-600">
                            {/* {point.house.name} */}
                        </p>
                    </div>
                </div>
            </article>  
          ))}
        </>
    )
}


