import { createContext, useContext, useState } from 'react';

const BulletinContext = createContext();

export function BulletinProvider({ children }) {
  const [bulletins, setBulletins] = useState([]);

  return (
    <BulletinContext.Provider value={{ bulletins: bulletins, setBulletins: setBulletins }}>
      {children}
    </BulletinContext.Provider>
  );
}

export function useBulletinContext() {
  return useContext(BulletinContext);
}