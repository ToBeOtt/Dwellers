export default function MessageBox(props, {children}) {
    return (
        <>
            <section className={`${props.currentUser === props.messageSender ? 
            'mr-10 pb-1 py-2 my-2 w-full xl:w-[25vw] font-style: italic border-2 border-stone-500'
            : 
            'ml-10 pb-1 py-2 my-2 w-full 2xl:w-[25vw] font-style: italic border-b-2 border-stone-100'}`}
            >
                {props.children}
            </section>
        </>
    )
};
