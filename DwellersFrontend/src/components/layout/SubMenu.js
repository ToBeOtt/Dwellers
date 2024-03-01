import React, { useState } from 'react';

export default function SubMenu({ children }) {
  const [isOpen, setIsOpen] = useState(false);

  const toggleMenu = () => {
    setIsOpen(!isOpen);
  };

  return (
    <>
      <section className="w-full">
        {isOpen ? (
          <button
            className="fixed text-xl w-full text-zinc-400 font-black px-2 py-1 h-10 w-10
            bg-gradient-to-r from-[#313131] from-20% via-[#000000] via-60% to-[#134840] to-90%"
            onClick={toggleMenu}
          >
            ☰
          </button>
        ) : (
          <div className="flex justify-center">
            <button
              className="fixed block text-xl text-black font-black px-2 py-1 h-10 w-10"
              onClick={toggleMenu}
            >
              ☰
            </button>
          </div>
        )}

        {/* Dropdown content */}
        {isOpen && (
          <div
            className="fixed w-[100%] h-[30%]
            bg-gradient-to-r from-[#313131] from-20% via-[#000000] via-60% to-[#134840] to-90%"
            onClick={toggleMenu}
          >
            <div className="m-5 space-x-10">
              <div className="flex xl:justify-center xl:flex-row xl:space-x-10">
                {children}
              </div>
            </div>
          </div>
        )}
      </section>
    </>
  );
}
