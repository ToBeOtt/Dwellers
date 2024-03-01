import { useState, useEffect } from 'react';
import baseUrl from '../../../../config/apiConfig';
import { useNavigate } from 'react-router-dom';
import ReactDatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css'; 

export default function AddBulletin(props) { 

  const [name, setName] = useState(null);
  const [date, setDate] = useState(null);
  const [desc, setDesc] = useState(null);
  const [bulletinStatus, setBulletinStatus] = useState(null);
  const [bulletinPriority, setBulletinPriority] = useState(null);
  const [category, setCategory] = useState(null);
  const [bulletinScope, setBulletinScope] = useState(null);
  const [file, setFile] = useState(null);
  



    const navigate = useNavigate();

    const HandleAddBulletin = async () => {
        try {
          const response = await fetch(`${baseUrl}/Bulletins/AddBulletin`, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
              'Authorization': `Bearer ${localStorage.getItem('token')}` 
            },
            body: JSON.stringify({
                name,
                desc,
                date,
                noteStatus: bulletinStatus,
                notePriority: bulletinPriority,
                category,
                noteScope: bulletinScope,
                file
            }),
          });
      
          if (response.ok) {
            navigate('/bulletinPage?added=true');
    
          } else if(response.status === 401) {
            navigate('/loginPage');
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
    <div className="flex justify-center">
          <form className="rounded pb-8 mb-4 w-full" >
          <h2 className="col-span-3 text-stone-800 text-sm font-titleFont text-left ml-5 mb-3">
              Add new bulletin..
          </h2>
          <div className="flex flex-row">
                  <input 
                      className="mb-2 mr-2 shadow-sm appearance-none border rounded py-1 px-3 text-gray-700 text-sm leading-tight focus:outline-none focus:shadow-outline" 
                      id="title" 
                      type="text" 
                      placeholder="Titel" 
                      value={name}
                      onChange={(e) => setName(e.target.value)}
                      />

                      <ReactDatePicker
                      className="mb-2 mr-2 shadow-sm appearance-none border rounded py-1 px-3 text-gray-700 text-sm leading-tight focus:outline-none focus:shadow-outline"
                      selected={date} // Set the selected date
                      onChange={(date) => setDate(date)} // Handle date changes
                      dateFormat="yyyy-MM-dd" // Specify the date format
                      placeholderText="Välj datum" // Set a placeholder text
                    />
                </div>
        
            <textarea
              className="mb-2 shadow-sm appearance-none border border-red-500 rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"
              id="noteDesc"
              placeholder="Beskrivning"
              value={desc}
              rows="6"
              onChange={(e) => setDesc(e.target.value)}
            />
          <div className="flex flex-row">
              <select
                className="mb-3 mr-2 shadow-sm appearance-none border rounded py-1 px-3 text-gray-400 text-sm leading-tight focus:outline-none focus:shadow-outline"
                id="status"
                value={bulletinStatus === null ? "" : bulletinStatus} // Use an empty string for the placeholder
                onChange={(e) => setBulletinStatus(e.target.value || null)} // Set null if the user selects the empty value
              >
                <option value="" disabled hidden>Status</option>
                <option value={0}>Avvakta</option>
                <option value={1}>Startad</option>
                <option value={2}>Klar</option>
              </select>

              <select
                className="mb-3 mr-2 block shadow-sm appearance-none border rounded py-1 px-3 text-gray-400 text-sm leading-tight focus:outline-none focus:shadow-outline"
                id="prio"
                value={bulletinPriority === null ? "" : bulletinPriority}
                onChange={(e) => setBulletinPriority(e.target.value || null)}
              >
                <option value="" disabled hidden>Prioritet</option>
                <option value={0}>Låg</option>
                <option value={1}>Normal</option>
                <option value={2}>Akut</option>
              </select>
         
              <select
                className="mb-3 mr-2 block shadow-sm appearance-none border rounded py-1 px-3 text-gray-400 text-sm leading-tight focus:outline-none focus:shadow-outline"
                id="category"
                value={category === null ? "" : category}
                onChange={(e) => setCategory(e.target.value || null)}
              >
                  <option value="" disabled hidden>Kategori</option>
                  <option value={0}>Husmöten</option>
                  <option value={1}>Projekt</option>
                  <option value={2}>Att göra</option>
                  <option value={3}>Kalender</option>
              </select>

              <select
                className="mb-3 mr-2 block shadow-sm appearance-none border rounded py-1 px-3 text-gray-400 text-sm leading-tight focus:outline-none focus:shadow-outline"
                value={bulletinScope === null ? "" : bulletinScope}
                onChange={(e) => setBulletinScope(e.target.value || null)}
              >
                  <option value="" disabled hidden>Synlighet</option>
                  <option value={0}>Hushåll</option>
                  <option value={1}>Grannskap</option>
                  <option value={2}>Regionalt</option>
               </select>

              </div>
              <input 
                      className="mb-2 mr-2 shadow-sm appearance-none border rounded py-1 px-3 text-gray-700 text-sm leading-tight focus:outline-none focus:shadow-outline" 
                      id="title" 
                      type="text" 
                      placeholder="Profilfoto.." 
                      value={file}
                      onChange={(e) => setFile(e.target.value)}
                      />
          <div className="flex items-center space-x-5 mt-3">
            <button
                className="bg-teal-900 hover:bg-teal-800 text-dweller-text text-sm font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                type="button"
                onClick={HandleAddBulletin}
                >
              Lägg till anteckning
            </button>
          </div>

        </form>
      </div>
    </>
  );  
}