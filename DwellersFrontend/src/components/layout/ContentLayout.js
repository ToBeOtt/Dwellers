export default function ContentLayout({children}) {
    return(

        <div className="h-auto mx-auto py-14 2xl:grid grid-cols-6 2xl:w-full 2xl:mt-5">
            <div className="col-span-1"></div>
            <div className="col-span-4">
                {children}
            </div>
          
          <div className="col-span-1"></div>
      </div>
    )
}
