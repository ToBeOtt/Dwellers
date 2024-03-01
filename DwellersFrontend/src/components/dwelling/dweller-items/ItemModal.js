import React, { useState, useEffect } from 'react';
import DwellerItemsService from '../dweller-items/DwellerItemsService';
import { useNavigate } from 'react-router-dom';
import { EditIcon, DeleteIcon } from '../../layout/svg/FormIcons';
import { formatDate } from '../../utils/FormatTime';

import Modal from 'react-bootstrap/Modal';

const ItemModal = ({ itemId, isOpen, onClose, }) => {
  console.log("FIRE!!")
    const [item, setItem] = useState(null);
    const navigate = useNavigate();

    const fetchItem = async () => {  
 
      const data = await DwellerItemsService.getDwellerItem(itemId);
      setItem(data.dwellerItem);
    };

      useEffect(() => {
        if (isOpen) {
          fetchItem(); 
        }
      }, [isOpen]); 

      const handleRemoveNote = async (itemId) => {
        try {
          const result = await DwellerItemsService.removeDwellerItem(itemId);
          if (result) {
            navigate('/DashboardPage');
          } else {
          }
        } catch (error) {
          navigate('/ErrorPage');
        }
      };

  return (
    isOpen && item && (
    <Modal show={isOpen} onHide={onClose}>

          <div className="grid grid-cols-2 items-center mt-4 mx-4">
            <div className="col-span-1 flex flex-row justify-start">
                <h3 className="text-black text-xl font-titleFont inline-block ml-5">
                  {item.name}
                </h3>
            </div>

            <div className="col-span-1 flex flex-row space-x-3 justify-end">
                <button>
                    <EditIcon />
                </button>
                <button
                   onClick={() => handleRemoveNote(item.Id)}>
                   <DeleteIcon/> 
               </button>           
            </div>
          </div>

      <Modal.Body className="text-xs font-contentFont">

            <div className="m-2">
                <p className="">{item.description}</p>
            </div>
            <div className="p-4">
              <img
                className="w-max h-auto rounded-sm object-cover object-center justify-center"
                src={item.itemPhoto && `data:image/jpeg;base64,${item.itemPhoto}`}
                onError={(e) => {
                  console.error('Error loading image:', e);
                  }}
              />
            </div>
       
      </Modal.Body>


      <div className="grid grid-cols-2 items-center m-2">
            <div className="col-span-1 flex flex-row justify-start">
           
              {item.isAvailable ? (
                 <p className="font-contentFont text-red-500 text-xs">Upptagen</p>
                ) : (
                  <p className="font-contentFont text-green-700 text-xs">Ledig</p>
                )}
              
            </div>
            <div className="col-span-1 flex flex-row justify-end">
                {item.itemScope === 0 ? (
                  <p className="font-contentFont text-green-700 text-xs">Hushåll</p>
                ) : item.itemScope === 1 ? (
                  <p className="font-contentFont text-red-500 text-xs">Grannskap</p>
                ) : item.itemScope === 2 ? (
                  <p className="font-contentFont text-red-500 text-xs">Alla</p>
                ) : (
                  <p className="font-contentFont text-xs">Synlighet</p>
                )}
                
                <p className="font-contentFont text-xs">{item.scope}</p>
            </div>
        </div>

    </Modal>
  ));
};


export default ItemModal;

