export default function ServiceRow(props) {
    return (
        <>
         <section class="lg:flex lg:items-center lg:justify-between py-2 border-b border-stone-300">
            <div class="min-w-0 flex-1 pr-5">           
                <div class="mt-1 flex flex-col sm:mt-0 sm:flex-row sm:flex-wrap sm:space-x-6 
                text-sm text-text-zinc-800 font-contentFont tracking-wider">
                    <div class="mt-2 flex items-center font-bold">
                        {props.ServiceName}
                    </div>

                    <div class="mt-2 flex items-center">
                        {props.ServiceAvailable}
                    </div>
                </div>
            </div>
        
            <div class="flex lg:ml-4 lg:mt-0 text-xs text-stone-200 font-contentFont font-bold"> 
                <span class="sm:ml-3">
                <button type="button" class="inline-flex items-center rounded-md tracking-wider bg-stone-700 px-3 py-2 hover:bg-yellow-700 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-stone-600">
                        Ändra
                    </button>
                </span>

                <span class="sm:ml-3">
                <button type="button" class="inline-flex items-center rounded-md tracking-wider bg-stone-700 px-3 py-2 hover:bg-red-900 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-stone-600">
                        Ta bort
                    </button>
                </span>
            </div>  
        </section>
        </>
    )
} 
                   