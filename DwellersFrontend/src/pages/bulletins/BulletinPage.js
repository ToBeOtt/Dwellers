import { useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import SubMenu from '../../components/layout/SubMenu';
import AddCalendarEvent from '../../components/dwelling/calendar/AddCalendarEvent';
import ViewAllEvents from '../../components/dwelling/calendar/display/ViewAllEvents';
import AddBulletin from '../../components/dwelling/bulletin/add/AddBulletin';
import AllDwellingBulletins from '../../components/dwelling/bulletin/display/AllDwellingBulletins';


export default function BulletinPage(props) {
  //Navigation
  const [activeView, setActiveView] = useState('allDwellingBulletins');
  const navigate = useNavigate();
  const [refreshEvents, setRefreshEvents] = useState(false);

  useEffect(() => {
    localStorage.getItem('token') === null && (
      navigate('/LoginPage')
    );
  })

  const handleShowBulletins = (view) => {
    setActiveView(view);
  };

  const handleEventChanged = () => {
    setRefreshEvents(prev => !prev);
  };
 
return (
<>

<div className="bg-gradient-to-r from-[#A2C3B8] to-[#134840]">
  <section className="grid grid-cols-1 gap-x-10 gap-y-16 px-5 py-8
                      lg:grid-cols-3 lg:mx-0 lg:max-w-none">   
      {/* Second section - Notes */}
      <article className="lg:col-span-2 lg:mx-3 lg:max-w-none">
        {/* Unique bulletin-element */}
          {activeView === 'allDwellingBulletins' ? (
            <AllDwellingBulletins />
          ) : activeView === 'allDwellingBulletins' ? (
            <AllDwellingBulletins />
          ) : activeView === 'allDwellingBulletins' ? (
            <AllDwellingBulletins />
          ) : null}
      </article>
      
      <article className="mt-5 lg:col-span-1 lg:mx-8 lg:max-w-none">
          {/* Create / modify new note */}
          <AddBulletin />    
      </article>

  </section>
</div>
</>

 
);
}


