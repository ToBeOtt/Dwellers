import { Link } from 'react-router-dom';
import { ChatIcon, HouseholdIcon, NeighbourhoodIcon, EventIcon } from './svg/NavbarIcons';
import {BulletinIcon} from './svg/FormIcons';

export default function NavHouse({ children }) {

  return (
         <>
          <div>
              <Link 
                to="/DashboardPage"
                className="flex justify-center text-hh hover:text-stone-400 no-underline mr-6">
                  <HouseholdIcon />
               </Link>
          </div>

          <div>
              
              <Link 
                to="/ChatPage"
                className="flex justify-center text-hh hover:text-stone-400 no-underline mr-6">
                  <ChatIcon />
               </Link>

          </div>

          <div>
              
              <Link 
                to="/BulletinPage"
                className="flex justify-center text-hh hover:text-stone-400 no-underline mr-6">
                  <BulletinIcon />
               </Link>

          </div>

          <div>
              
              <Link 
                to="/EventPage"
                className="flex justify-center text-hh hover:text-stone-400 no-underline mr-6">
                  <EventIcon />
               </Link>

          </div>

          <div>
              

              <Link 
                  to="/MapPage" 
                  className="flex justify-center text-hh hover:text-stone-400 no-underline mr-6">
                    <NeighbourhoodIcon />
               </Link>

          </div>
          </>
  );
}
