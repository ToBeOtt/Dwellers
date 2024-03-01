import MapView from '../../../components/neighbourhood/map/MapView';

export default function MapPage() { 
  
  
return (
    <>
    <main className="mx-auto max-w-7xl px-6 w-full py-8
                    lg:px-8">

      {/* Dashboard-grid */}
      <section className="grid grid-cols-1 gap-x-10 gap-y-16 
                      lg:grid-cols-3 lg:mx-0 lg:max-w-none">

            <article className="my-5 gap-x-10 col-span-2 gap-y-16 border-r-2 border-stone-100
                                            lg:col-span-1 lg:mr-3 lg:max-w-none lg:pr-10">
                <div className="mx-auto mb-3 pb-3 pl-4 inline-block opacity-50">
                    <h2 className="text-md pl-3 font-logoText tracking-wide text-hh">
                    Locate other dwellings
                    </h2>
                </div>
                
                <div className="opacity-50">
                    <MapView />
                </div>        
            </article>

        {/* Second column - Bulletins */}
        <article className="my-5 gap-x-10 col-span-3 border-r-2 border-stone-100 gap-y-16 ml-10
                        lg:col-span-1 lg:mr-3 lg:max-w-none">
            <div className="mx-auto mb-2 pb-2 pl-4 inline-block opacity-40">
                <h2 className="text-md pl-3 font-logoText tracking-wide text-hh">
                    Coming neightbourhood events
                </h2>
            </div>
        
        {/* Unique bulletin-element */}
 
        </article>

        <article className="my-5 gap-x-10 col-span-3 gap-y-16 ml-10
                        lg:col-span-1 lg:mr-3 lg:max-w-none">
            <div className="mx-auto mb-2 pb-2 pl-4 inline-block opacity-40">
                <h2 className="text-md pl-3 font-logoText tracking-wide text-hh">
                        Recent neightbourhood bulletins
                    </h2>
            </div>
        
        {/* Unique bulletin-element */}
 
        </article>
      </section>
    </main>

</>








    
   

)}