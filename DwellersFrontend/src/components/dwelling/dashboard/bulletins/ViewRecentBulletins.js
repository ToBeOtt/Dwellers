import { useState, useEffect } from 'react';
import DashboardService from '../DashboardService';

export default function ViewRecentBulletins(props) {
    const [latestBulletins, setLatestBulletins] = useState(null);

    useEffect(() => {
    }, [latestBulletins]);
    

    useEffect(() => {
        DashboardService.getDashboardBulletins()
        .then((data) => {
            const latestBulletinsData = data.data.listOfBulletinsForDashboard;
            setLatestBulletins(latestBulletinsData);
        });
    
    }, []); 
   
    return(
        <>
        {Array.isArray(latestBulletins) &&
            latestBulletins.slice(0, 5).map((point, index) => (
     
  
                <article className="flex flex-col items-start justify-between mt-3 mb-1 relative border-r-2 border-red-100">
                <h3 className="text-black text-sm font-titleFont mb-2 ml-3">
                    {point.bulletinTitle}
                </h3>
                <p className="text-xs text-stone-600 line-clamp-2">
                    {point.bulletinText}
                </p>
        
            
                <div className="relative mt-2 flex items-center gap-x-4">
                    <div className="text-xs leading-6 mb-4">
                        <p className="font-light text-gray-900 mt-3 ml-3">
                            <a href="#">
                                <span className="absolute inset-0"></span>
                                {point.author}
                            </a>
                        </p>
                    </div>
                </div>
            </article>
            
          ))}
        </>
    )
}