import { useState } from 'react';
import CalendarServices from './CalendarServices';
import ReactDatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css'; 

export default function AddCalendarEvent({ isOpen, onClose, onEventChanged }) { 
  const [title, setTitle] = useState(null);
  const [desc, setDesc] = useState(null);
  const [eventDate, setEventDate] = useState(null);
  const [eventScope, setEventScope] = useState(0);


  const HandleAddEvent = async () => {
    try {
      console.log("AM I FIRING?")
      await CalendarServices.addEvent(title, desc, eventDate, eventScope);
      if (onEventChanged) {
        onEventChanged();}
      } catch (error) {
      console.error('Error:', error);
    }
  };
return (
    <div className="flex justify-center">
    <form className="rounded pb-8 mb-4" >
    <h2 className="col-span-3 text-stone-400 text-sm font-titleFont text-left ml-5 mb-3">
              Add new event..
          </h2>
    <div className="flex flex-row">
            <input 
                className="mb-2 mr-2 shadow-sm appearance-none border rounded py-1 px-3 text-gray-500 text-sm leading-tight focus:outline-none focus:shadow-outline" 
                id="title" 
                type="text" 
                placeholder="Titel" 
                value={title}
                onChange={(e) => setTitle(e.target.value)}
                />

            <ReactDatePicker
                  className="mb-2 mr-2 shadow-sm appearance-none border rounded py-1 px-3 text-gray-500 text-sm leading-tight focus:outline-none focus:shadow-outline"
                  selected={eventDate}
                  onChange={date => setEventDate(date)}
                  showTimeSelect
                  dateFormat="Pp"
                  placeholderText="Select date and time"
                />
          </div>
  
      <textarea
        className="mb-2 shadow-sm appearance-none border border-red-500 rounded w-full py-2 px-3 text-gray-500 mb-3 leading-tight focus:outline-none focus:shadow-outline"
        id="noteDesc"
        placeholder="Beskrivning"
        value={desc}
        rows="6"
        onChange={(e) => setDesc(e.target.value)}
      />
    <div className="flex flex-row">
        <select
          className="mb-3 mr-2 block shadow-sm appearance-none border rounded py-1 px-3 text-gray-400 text-sm leading-tight focus:outline-none focus:shadow-outline"
          value={eventScope === null ? "" : eventScope}
          onChange={(e) => setEventScope(e.target.value || null)}
        >
            <option value={0}>Hushåll</option>
            <option value={1}>Grannskap</option>
            <option value={2}>Regionalt</option>
         </select>

        </div>
        
    <div className="flex items-center space-x-5 mt-1">
      <button
          className="bg-teal-900 hover:bg-teal-800 text-dweller-text text-sm font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
          type="button"
          onClick={HandleAddEvent}
          >
        Lägg till
      </button>
    </div>

  </form>
</div>
  );
}
