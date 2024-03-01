import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import BulletinModal from './BulletinModal';
import BulletinService from '../BulletinService';
import { useBulletinContext } from '../../../../contexts/BulletinContext';

export default function AllBulletins() {
  const { bulletins, setBulletins } = useBulletinContext();
  const navigate = useNavigate();
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [selectedNoteId, setSelectedNoteId] = useState(null);

  const handleModalOpen = (bulletinId) => {
    console.log(bulletinId);
    setSelectedNoteId(bulletinId);
    setIsModalOpen(true);
  };

  const handleModalClose = () => {
    setIsModalOpen(false);
  };

  useEffect(() => {
    BulletinService.getAllBulletins()
      .then((data) => {
        setBulletins(data.listOfAllBulletins);
        console.log('Data in local storage');
      });
    }, []);

    return (
      <>
        <div className="xl:grid grid-cols-1 xl:gap-5 mt-5">
        <h2 className="col-span-1 text-black text-lg font-titleFont text-left ml-5">
              All Bulletins
          </h2>
           {Array.isArray(bulletins) &&
          bulletins.map((point, index) => (
              <>
              <div className="xl:col-span-1 py-3 px-5 border-1 border-black rounded bg-white shadow-lg mb-3">
                <div className="items-center">
                  <div className="flex flex-row justify-start">
                    <button onClick={() => handleModalOpen(point.id)}>
                      <h3 className="text-black text-sm font-titleFont ml-2">
                          {point.bulletinTitle}
                      </h3>
                    </button>
                  </div>
                </div>
      
            <section className="">
              <p className="text-xs text-stone-600 line-clamp-2 my-2">{point.bulletinText}</p>
            </section>
  
            <div className="col-span-1 flex flex-row justify-start">
                <p className="text-stone-700 text-xs">
                 
                </p>
            </div>
          </div>
              
        </>
            ))}
          <BulletinModal
            eventId={selectedNoteId}
            isOpen={isModalOpen}
            onClose={handleModalClose}
          />
        </div>
      </>
      );
    }