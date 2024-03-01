import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import baseUrl from '../../../config/apiConfig';

export default function Dashboard() {
  const [userData, setUserData] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    fetchUserData();
  }, []);

  const fetchUserData = async () => {
    try {
      const response = await fetch(`${baseUrl}/dweller/GetDwellerDetails`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${localStorage.getItem('token')}`,
        },
      });

      if (response.ok) {
        const data = await response.json();
        setUserData(data);
      } else if(response.status === 401) {
        navigate('/LoginPage');
    }
      else {
        navigate('/ErrorPage'); 
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };


  return (
   <>
      {userData  ? (
        <>
          <div className="w-full flex flex-col justify-center"> 

                <h4 className="font-serif text-title text-[#279A88]">{userData.user.alias}</h4> 
                <h4 className="font-serif text-[#279A88]">{userData.house.name}</h4> 




          </div>

          </>
      ) : (
        <p>Loading user data...</p>
      )}
    
    </>
        
  );
}