export default function NewMessageBox(props, {children}) {
    return (
        <>
            <section className={`${props.currentUser === props.messageSender ? 
            'border-1 border-red-800 p-3 m-3 flex justify-end w-full 2xl:w-[40vw] rounded'
            : 
            'border-1 border-hh p-3 m-3 flex justify-end w-full 2xl:w-[40vw] rounded'}`}
            >
                {props.children}
            </section>
        </>
    )
};
