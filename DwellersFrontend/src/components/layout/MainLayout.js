export default function MainLayout({children}) {
    return(
        <div className="grid grid-cols-1 min-h-[50vh] mx-auto bg-[gradient-to-r from-zinc-100 to-zinc-500]">
          {children}
      </div>
    )
}

