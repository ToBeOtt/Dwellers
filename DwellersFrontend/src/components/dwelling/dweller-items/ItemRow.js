import DwellerItemsService from "../dweller-items/DwellerItemsService";
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import ItemModal from './ItemModal';

export default function ItemRow() {
    const [items, setItems] = useState(null);
    const navigate = useNavigate();
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedItemId, setSelectedItemId] = useState(null);
  
    const handleModalOpen = (itemId) => {
      setSelectedItemId(itemId);
      setIsModalOpen(true);
    };
  
    const handleModalClose = () => {
      setIsModalOpen(false);
    };

    const handleDeleteItem = async (userId) => {
    try {
            const result = await DwellerItemsService.removeDwellerItem(userId);
            if (result) {
                window.location.reload(); 
            } else {
        }
    } catch (error) {
        navigate('/ErrorPage');
    }
    };

    useEffect(() => {
            DwellerItemsService.getAllDwellerItems()
            .then((data) => {
                const itemData = data.listOfItems;
                setItems(itemData);
            });
        }, []); 

    
        return (
        <>
         {Array.isArray(items) && items.slice(0, 5).map((point, index) => (            
            <section  key={index} className="lg:flex lg:items-center lg:justify-between py-2 border-b border-stone-300">
                <div className="min-w-0 flex-1 pr-5">           
                    <div className="mt-1 flex flex-col sm:mt-0 sm:flex-row sm:flex-wrap sm:space-x-6 text-sm text-stone-200 font-contentFont tracking-wider">
                        <div className="mt-2 flex items-center font-bold">
                            <button 
                                onClick={() => handleModalOpen(point.id)}>
                                    {point.name}
                            </button>
                            
                        </div>
                    </div>
                </div>
                <div className="flex lg:ml-4 lg:mt-0 text-xs text-stone-200 font-contentFont font-bold"> 
                    <span className="sm:mr-3 self-center">
                        {point.isAvailable ? 
                        <p className="text-stone-500">N/A</p>
                        : 
                        <p className="text-green-700">Available</p> }
                    </span>
                
                    <span className="sm:ml-3">
                        <button
                            type="button"
                            className="inline-flex items-center rounded-md tracking-wider bg-stone-700 px-3 py-2 hover:bg-yellow-700 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-stone-600"
                        >
                            Ändra
                        </button>
                    </span>

                    <span className="sm:ml-3">
                        <button
                            type="button"
                            className="inline-flex items-center rounded-md tracking-wider bg-stone-700 px-3 py-2 hover:bg-red-900 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-stone-600"
                            onClick={() => handleDeleteItem(point.id)}
                        >
                            Ta bort
                        </button>
                    </span>
                </div>  
            </section>
          ))}
        
          <ItemModal
            itemId={selectedItemId}
            isOpen={isModalOpen}
            onClose={handleModalClose}/> 
       </>     
    );
} 

    
            