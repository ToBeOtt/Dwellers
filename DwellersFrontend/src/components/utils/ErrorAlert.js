import React, { useEffect, useState } from 'react';

const ErrorAlert = ({ message }) => {
  const [showError, setShowError] = useState(true);

  const handleClose = () => {
    setShowError(false);
  };

  return (
    <>
      {showError && (
        <div className="custom-alert flex items-center text-center justify-between bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded relative" role="alert">
          <span 
            className="absolute top-0 bottom-0 right-0 px-4 py-3" 
            onClick={handleClose}>
            
            <svg className="fill-current h-6 w-6 text-red-500" role="button" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20">
              <title>Close</title>
              <path d="M14.348 14.849a1.2 1.2 0 0 1-1.697 0L10 11.819l-2.651 3.03a1.2 1.2 0 0 1-1.697 0 1.2 1.2 0 0 1 0-1.697L8.303 10 5.652 6.97a1.2 1.2 0 0 1 1.697-1.697L10 8.181l2.651-3.03a1.2 1.2 0 0 1 1.697 1.697L11.697 10l2.651 3.03a1.2 1.2 0 0 1 0 1.82z" />
            </svg>
          </span>
          <p className="">{message}</p>
        </div>
      )}
    </>
  );
};

export default ErrorAlert;
