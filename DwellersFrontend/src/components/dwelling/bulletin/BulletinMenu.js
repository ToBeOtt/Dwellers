export default function BulletinMenu() {

    return(
        <SubMenu> 
        <div className="text-xs font-titleFont text-stone-500 rounded border-x-2 border-stone-500 px-5">
            <h1 className="my-1 tracking-wider font-logoText text-stone-400 underline">kategorier</h1>
    
            <button
              className="block p-0.5"
              onClick={() => {
                handleShowBulletins('AllNotes');
              }}
            >
              Alla
            </button>
    
            <button
                className="block p-0.5"
                onClick={() => {
                  handleShowBulletins('meetingNotes'); 
                }}                
                >
                Husmöten
            </button>
        
            <button
                className="block p-0.5"
                onClick={() => {
                  handleShowBulletins('calendarView'); 
                
                  }}                        
                >
                Kalender
            </button>
    
            <button
                className="block p-0.5"
                onClick={() => {
                  handleShowBulletins('projectNotes'); 
     
                  }}              
                >
                Projekt
            </button>
        
            <button
                className="block p-0.5"
                onClick={() => {
                  handleShowBulletins('newNote'); 
                
                  }}                        
                >
                Att göra
            </button>
        </div>
    
        <div className="text-xs font-titleFont text-stone-500 py-2 rounded border-x-2 border-stone-500 px-3">
            <h1 className="my-1 tracking-wider font-logoText text-stone-400 underline">
                anteckningar
            </h1>
    
            
            <button
                className="block p-0.5"
                onClick={() => {
                  handleShowBulletins('newNote');  
            
                  }}           
                    >
                Ny anteckning
            </button>
    
            <button
                className="block p-0.5"
                onClick={() => {
                  handleShowBulletins('newCalendarEvent');
            
                  }}           
                    >
                Ny kalenderhändelse
            </button>
    
            <button
                className="block p-0.5" 
                onClick={() => {
                  handleShowBulletins('newNoteholder'); 
               
                  }}         
                >
                Ny anteckningsbok
            </button>
    
        </div>
    
        <div  className="text-xs font-titleFont text-stone-500 px-3 py-2">        
                <input type="text" 
                    className="pr-2 pl-2 text-sm rounded focus:shadow focus:outline-none 
                    rounded border-x-2 border-stone-500 py-2 h-6" 
                    placeholder="Sök.."/>
             </div>
    </SubMenu>
    )  
}