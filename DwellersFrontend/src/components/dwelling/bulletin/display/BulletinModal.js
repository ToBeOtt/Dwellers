import React, { useState, useEffect } from 'react';
import BulletinService from '../BulletinService';
import { useNavigate } from 'react-router-dom';
import { EditIcon, DeleteIcon } from '../../../layout/svg/FormIcons';

import Modal from 'react-bootstrap/Modal';

const BulletinModal = ({ noteId: bulletinId, isOpen, onClose, }) => {
    const [bulletin, setBulletin] = useState(null);
    const navigate = useNavigate();

    const fetchBulletin = async () => {  
      const data = await BulletinService.getBulletin(bulletinId);
      setBulletin(data);
      if (data != null) {
        navigate('/BulletinPage'); 
      } 
    };

      useEffect(() => {
        if (isOpen) {
          fetchBulletin(); 
        }
      }, [isOpen]); 

      const handleRemoveBulletin = async (bulletinId) => {
        try {
          const result = await BulletinService.removeBulletin(bulletinId);
          if (result) {
            navigate('/BulletinPage');
          } else {
          }
        } catch (error) {
          navigate('/ErrorPage');
        }
      };

  return (
    isOpen && bulletin && (
    <Modal show={isOpen} onHide={onClose}>

          <div className="grid grid-cols-2 items-center m-2">
            <div className="col-span-1 flex flex-row justify-start">
                <h3 className="text-black font-titleFont inline-block ml-5">
                {bulletin.note.name}
                </h3>
            </div>

            <div className="col-span-1 flex flex-row space-x-3 justify-end">
                <button>
                    <EditIcon />
                </button>
                <button
                   onClick={() => handleRemoveBulletin(bulletin.note.noteId)}>
                   <DeleteIcon/> 
               </button>           
            </div>
          </div>

      <Modal.Body className="text-contentText font-contentFont">
        <p className="">{bulletin.note.description}</p>
      </Modal.Body>


      <div className="grid grid-cols-2 items-center m-2">
            <div className="col-span-1 flex flex-row justify-start">
                <p className="font-contentFont text-xs">#Möte, Höst</p>
            </div>

            <div className="col-span-1 flex flex-row space-x-3 justify-end">
            {bulletin.note.noteStatus === 0 ? (
                    <p>Avvakta</p>
                ) : bulletin.note.noteStatus === 1 ? (
                    <p>Beror på</p>
                ) : bulletin.note.noteStatus === 2 ? (
                    <p className="text-yellow-500">Påbörjad</p>
                ) : bulletin.note.noteStatus === 3 ? (
                    <p className="text-green-500">Avslutad</p>
                ): (
                    <p></p> 
                )}
                
                {bulletin.note.notePriority === 0 ? (
                    <p>Ej brådskande</p>
                ) : bulletin.note.noteStatus === 1 ? (
                    <p>Normal</p>
                ) : bulletin.note.noteStatus === 2 ? (
                    <p className="text-red-500">Akut</p>
                ) : (
                    <p></p> 
                )}      
            </div>
        </div>

    </Modal>
  ));
};


export default BulletinModal;

