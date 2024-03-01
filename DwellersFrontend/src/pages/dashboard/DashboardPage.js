import React, { useEffect } from 'react';
import {useNavigate} from 'react-router-dom';
import ViewUpcomingEvents from '../../components/dwelling/calendar/display/ViewUpcomingEvents';
import ViewRecentBulletins from '../../components/dwelling/dashboard/bulletins/ViewRecentBulletins';
import ServiceRow from '../../components/dwelling/dweller-services/ServiceRow';
import AddService from '../../components/dwelling/dweller-services/AddService';
import ItemRow from '../../components/dwelling/dweller-items/ItemRow'; 
import AddItem from '../../components/dwelling/dweller-items/AddItem';

export default function DashboardPage() {
  const navigate = useNavigate();
  
  useEffect(() => {
    localStorage.getItem('token') === null && (
      navigate('/LoginPage')
    );
  })


  // Anrop som behöver skrivas:                 
    // AddService
    // GetHouseServices
   
  return (
    <>
        <main className="mx-auto max-w-7xl px-6 w-full py-8
                        lg:px-8">

          {/* Dashboard-grid */}
          <section className="grid grid-cols-1 gap-x-10 gap-y-16 
                          lg:grid-cols-2 lg:mx-0 lg:max-w-none">

            {/* First column - Events*/}
            <article className="mt-5 gap-x-10 col-span-3 gap-y-16 border-r-2 border-stone-100
                            lg:col-span-1 lg:mr-3 lg:max-w-none lg:pr-10">
                <div className="mx-auto mb-2 pb-2 pl-4 inline-block opacity-50">
                    <h2 className="text-md pl-3 font-logoText tracking-wide text-hh">Upcoming events</h2>
                </div>
                

                {/* Unique event-element */}
                 <ViewUpcomingEvents /> 

            </article>

            {/* Second column - Bulletins */}
            <article className="mt-5 gap-x-10 col-span-3 gap-y-16 ml-10
                            lg:col-span-1 lg:mr-3 lg:max-w-none">
                <div className="mx-auto mb-2 pb-2 pl-4 inline-block opacity-40">
                    <h2 className="text-md pl-3 font-logoText tracking-wide text-hh">Lastest on bulletin..</h2>
                </div>
            
            {/* Unique bulletin-element */}
                <ViewRecentBulletins /> 
            </article>
          </section>
        </main>

        {/* Skills/Items - Grid */}
        <footer className="grid grid-cols-2 space-x-16 px-5 py-8 bg-gradient-to-r from-[#B77580] to-[#3B1319] 
                           lg:grid grid-cols-1"> 

            {/* Skill-container*/}
           <section className="w-full my-12 col-span-1
                                lg:w-[80%] lg:mr-3 ">
                <h2 className="ml-6 text-md font-logoText mb-2 pb-2 tracking-wide leading-7 text-zinc-800 sm:truncate">
                    provided services
                </h2>

                <section className="grid grid-cols-1 lg:grid lg:grid-cols-8">
                  
                  <article className="lg:grid col-span-7">
                    <ServiceRow  ServiceName={'Beskära äpplen'} ServiceAvailable={'True'}  />
                    <ServiceRow  ServiceName={'Kör lastbil'} ServiceAvailable={'False'}  /> 
                  </article>

                  <div className="grid col-span-1 items-top">
                    <AddService/> 
                  </div>

                </section>
               
              
            </section>

            {/* Item-container*/}
            <section className="col-span-1 w-full my-12 
                                lg:mr-3 lg:w-[80%]">
                <h2 className=" ml-6 text-md font-logoText mb-2 pb-2 tracking-wide leading-7 text-gray-300 
                                sm:truncate">
                   Items for loan
                </h2>

                <section className="grid grid-cols-1 lg:grid lg:grid-cols-8">

                  <article className="lg:grid col-span-7">
                    <ItemRow />
                  </article>

                  <div className="grid col-span-1 items-top">
                    <AddItem /> 
                  </div>
                  
                </section>
                   
                   
            </section>

        </footer>
    </>
    );
}


