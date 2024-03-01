import './App.css';
import { createContext, useState } from 'react';
import HeaderNav from './components/layout/HeaderNav.js';
import FooterPage from './components/layout/FooterPage.js';
import MainLayout from './components/layout/MainLayout';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import LoginPage from './pages/authentication/LoginPage';
import RegisterPage from './pages/authentication/RegisterPage';
import RegisterDwellingPage from './pages/authentication/RegisterDwellingMemberPage.js';
import RegisterDwellingMemberPage from './pages/authentication/RegisterDwellingMemberPage';
import EditProfilePage from './pages/EditProfilePage';
import BulletinPage from './pages/bulletins/BulletinPage.js';
import EventPage from './pages/events/EventPage.js';
import Dashboard from './pages/dashboard/DashboardPage.js';
import ChatPage from './pages/chat/ChatPage';
import MapPage from './pages/neighbourhood/map/MapPage';
import ErrorPage from './pages/errorhandling/ErrorPage';
import UnauthorizedPage from './pages/errorhandling/UnauthorizedPage';

export const AuthContext = createContext();
function App() {
    
    const [loggedIn, setLoggedIn] = useState(
    localStorage.token ? true : false
    );

    function changeLoggedIn(value) {
      setLoggedIn(value);
      if (value === false) {
          localStorage.clear();
      }
    }

  return (
    <AuthContext.Provider value={[loggedIn, changeLoggedIn]}>
      <BrowserRouter>
      <HeaderNav /> 
      <MainLayout>
          <Routes>
              <Route path='/LoginPage' element={<LoginPage/>} />

              <Route path='/RegisterPage' element={<RegisterPage/>} />

              <Route path='/RegisterDwellingPage' element={<RegisterDwellingPage/>}/>

              <Route path='/RegisterDwellingMemberPage' element={ <RegisterDwellingMemberPage />} />

              <Route path='/EditProfilePage' element={<EditProfilePage/>} />

              <Route path='/DashboardPage' element={<Dashboard/>} />

              <Route path='/BulletinPage' element={ <BulletinPage /> } />

              <Route path='/EventPage' element={ <EventPage /> } />

              <Route path='/ChatPage' element={<ChatPage /> } />
              
              <Route path='/MapPage' element={<MapPage /> } />

              <Route path='/ErrorPage' element={<ErrorPage/>}/>
              <Route path='/UnauthorizedPage' element={<UnauthorizedPage/>}/>
          </Routes>
      </MainLayout>
      <FooterPage/>
      {/* <Footer/> */}
      </BrowserRouter>
      </AuthContext.Provider>
  );
}

export default App;

