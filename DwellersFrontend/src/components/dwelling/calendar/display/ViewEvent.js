import React, { useState, useEffect } from 'react';
import CalendarService from '../CalendarServices';
import { useNavigate } from 'react-router-dom';
import { EditIcon, DeleteIcon } from '../../../layout/svg/FormIcons';
import DwellerModal from '../../../layout/DwellerModal'; 
import Modal from 'react-bootstrap/Modal';

const ViewEvent = ({ eventId, isOpen, onClose, onEventDeleted }) => {
  const [event, setEvent] = useState(null);

  const fetchEvent = async () => {
      const data = await CalendarService.getEvent(eventId);
      setEvent(data);
  };

  useEffect(() => {
      if (isOpen) {
          fetchEvent();
      }
  }, [isOpen]);

  const handleRemoveNote = async (eventId) => {
      try {
          await CalendarService.removeEvent(eventId);
          if (onEventDeleted) {
            onEventDeleted();
          }
      } catch (error) {
          console.error('Error:', error);
      }
  };

  const header = event &&(
    <>
    <div className="flex justify-start">
      <h3 className="text-black font-titleFont ml-5">
        {event.eventDate}
      </h3>
    </div>

    <div className="flex justify-end space-x-3">
      <button aria-label="Edit">
        <EditIcon />
      </button>
      <button
        onClick={() => handleRemoveNote(event.id)}
        aria-label="Delete">
        <DeleteIcon/> 
      </button>           
    </div>
    </>
    );

  const body = (
      <>
          <h3 className="text-black font-titleFont mb-2">
              {event?.eventTitle}
          </h3>
          <p className="text-xs">{event?.eventText}</p>
      </>
  );

  const footer = (
      <div className="grid grid-cols-2 items-center m-2">
          <p className="font-contentFont text-xs col-span-1 flex flex-row justify-start">Taggar</p>
          <p className="font-contentFont text-xs col-span-1 flex flex-row justify-end">{event?.eventScope}</p>
      </div>
  );

  return (
      <DwellerModal isOpen={isOpen} onClose={onClose} header={header} body={body} footer={footer} />
  );
};

export default ViewEvent;

