import { Link } from 'react-router-dom';

export default function UnauthorizedPage() {

  return (
    <div className="bg-red-200 pt-10">
      <h1 className="text-red-700 text-3xl text-center font-logoText mb-2">
          Inloggning krävs!
      </h1>
      <p className="text-red-500 text-sm text-center font-contentFont">
          Du måste registrera dig eller logga in för att komma åt den här sidan.
      </p>
      <div className="pt-10">
        <Link 
            to="/LoginPage"
            className="flex justify-center font-bold text-stone-500 hover:text-hover-hh no-underline mr-6 my-1">
              Logga in
        </Link>
        <Link 
            to="/RegisterPage"
            className="flex justify-center font-bold text-stone-500 hover:text-hover-hh no-underline mr-6 my-1">
              Registrering
        </Link>
      </div>
    </div>


  );
}

