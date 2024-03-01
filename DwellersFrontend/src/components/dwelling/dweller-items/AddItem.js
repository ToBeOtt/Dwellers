import { useState } from 'react';
import AddDwellerItemModal from './AddDwellerItemModal';

export default function AddItem(props) {
const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedEventId, setSelectedEventId] = useState(null);

  const handleModalOpen = (eventId) => {
    console.log(eventId);
    setSelectedEventId(eventId);
    setIsModalOpen(true);
  };

  const handleModalClose = () => {
    setIsModalOpen(false);
  };
    
    return (
        <>
            <section>
                <button 
                    type="button" 
                    className="font-titleFont text-zinc-400 text-4xl px-16 py-2 hover:text-white"
                    onClick={() => handleModalOpen()}>
                    +
                </button>
            </section>
            <AddDwellerItemModal
                isOpen={isModalOpen}
                onClose={handleModalClose}
            />
        </>
    )
} 