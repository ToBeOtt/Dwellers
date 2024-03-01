import React, { useState, useEffect } from 'react';
import DwellerItemsService from '../dweller-items/DwellerItemsService';
import Modal from 'react-bootstrap/Modal';

const AddDwellerItemModal = ({ isOpen, onClose, }) => {

  const [name, SetName] = useState(null);
  const [description, SetDescription] = useState(null);
  const [itemScope, SetItemScope] = useState(null);
  const [itemPhoto, SetItemPhoto] = useState(null);
  const [error, SetError] = useState(null);

  const handleFileUpload = (event) => {
    const file = event.target.files[0];
    SetItemPhoto(file);
    console.log(file);
  };
  
  const handleSaveItem = async () => {
    const formData = new FormData();
    formData.append('itemPhoto', itemPhoto);
    formData.append('name', name);
    formData.append('description', description);
    formData.append('itemScope', itemScope);

    await DwellerItemsService.addDwellerItem(formData) 
    onClose();
  };


  return (
    isOpen && (
    <Modal show={isOpen} onHide={onClose}>
        <form class="bg-white p-8 m-8 xl:mt-5 text-xs">
          <div className="mb-4">
            <label className="block text-zinc-600 text-sm font-bold mb-2" htmlFor="housename">
              Lägg till nytt föremål för utlån
            </label>
            <input 
              className="shadow-sm appearance-none border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
              id="housename" 
              type="text" 
              placeholder="Föremålets namn" 
              onChange={(e) => SetName(e.target.value)}
            />
          </div>
            
          <div className="mb-6">
            <label
              className="block text-gray-700 text-sm font-bold mb-2"
              htmlFor="desc"
            >
            </label>
            <textarea
              className="shadow-sm border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"
              id="desc"
              placeholder="Beskrivning.."
              rows="7"
              onChange={(e) => SetDescription(e.target.value)}
            />
          </div>
          <div className="flex flex-row space-x-4 mb-4">
            <select
                className="border rounded py-1 px-3 text-gray-400 text-sm leading-tight"
                value={itemScope}
                onChange={(e) => SetItemScope(e.target.value)}
                >
                  <option value={0}>Hushåll</option>
                  <option value={1}>Grannskap</option>
                  <option value={2}>Regionalt</option>
            </select>

            <input
              className="flex flex-row appearance-none py-1 px-3 text-gray-700 text-sm leading-tight focus:outline-none focus:shadow-outline"
              id="photo"
              type="file"
              placeholder="Profilfoto.."
              onChange={handleFileUpload}
            />
          </div>
          

          <div className="flex items-center justify-between">
            <button
              className="bg-hh text-xs hover:bg-hover-n text-gray-300 font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
              type="button"
              onChange={handleFileUpload}
              onClick={handleSaveItem}
              >
            Registrera föremål
          </button>
          </div>
       
        </form>

    </Modal>
  ));
};


export default AddDwellerItemModal;

