import { useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import baseUrl from '../../config/apiConfig'; 

export default function RegisterDwelling() {
  const location  = useLocation();
  const email = new URLSearchParams(location.search).get('Email'); 

  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const navigate = useNavigate();
  const [error, SetError] = useState(null);

  const handleRegister = async () => {
    try {
      console.log(email);
      const response = await fetch(`${baseUrl}/auth/RegisterDwellingForDweller`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          name,
          description,
          email,
        }),
      });
  
      if (response.ok) {
        navigate('/loginPage');
      } if (response.status === 401) {
        navigate('RegisterPage');
       }
       if (response.status === 400) {
         navigate('/ErrorPage');
        }
       if (response.status === 500) {
         const errorData = await response.json();
         const errorMessages = errorData.message.split(/\r?\n/);
         SetError(errorMessages);
       }
     } catch (error) {
       console.error('Error:', error);
     }
   };


  return (
    <>
    <div className="mx-auto l:w-3/5  l:w-3/5 xl:w-2/5">
        <form class="bg-white border-t-8 border-n shadow rounded p-10 m-10 xl:mt-5">
          <div className="mb-4">
            <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="dwellingname">
              Name of dwelling
            </label>
            <input 
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
              id="dwellingname" 
              type="text" 
              placeholder="Name of dwelling" 
              value={name}
              onChange={(e) => setName(e.target.value)}
            />
          </div>
            
          <div className="mb-6">
            <label
              className="block text-gray-700 text-sm font-bold mb-2"
              htmlFor="desc"
            >
              Beskrivning:
            </label>
            <textarea
              className="shadow appearance-none border border-red-500 rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"
              id="desc"
              placeholder="optional"
              rows="7"
              value={description}
              onChange={(e) => setDescription(e.target.value)}
            />
          </div>

          {error && (
                <div className="text-red-500 text-xs italic">
                  {error.map((errorMessage, index) => (
                    <p key={index}>{errorMessage}</p>
                  ))}
                </div>
              )}

          <div className="flex items-center justify-between">
            <button
              className="bg-n hover:bg-hover-n text-gray-700 font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
              type="button"
              onClick={handleRegister}
              >
            Register dwelling
          </button>
          </div>
        </form>
      </div>
    </>
  );
}
