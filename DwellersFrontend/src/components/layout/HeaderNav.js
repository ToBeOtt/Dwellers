import { Link } from 'react-router-dom';
import { useContext } from 'react'; 
import { AuthContext } from '../../App';
import NavHouse from './NavHouse';
import DwellerProfilePhoto from '../dweller/DwellerProfilePhoto';


export default function HeaderNav() {
    const [loggedIn, setLoggedIn] = useContext(AuthContext);

    return (
    <div className="bg-[#313131] py-2 w-full sticky top-0 z-50 
                    bg-gradient-to-r from-[#313131] from-20% via-[#000000] via-60% to-[#134840] to-90%
                    lg:px-16 lg:grid grid-cols-3">   

        {/* Logo */}
        <div className="lg:col-span-1 flex items-center justify-start">
            <h1 className="font-logoText text-4xl text-[#0E7A60] mx-5 my-auto
                           lg:mb-3">
                dwellers
            </h1>
        </div>

        <div className="lg:col-span-1 flex flex-row justify-end my-auto 
                        lg:justify-center lg:space-x-4">
            <NavHouse/>
        </div>

        {/* Logged in / Logged out */}
        <div className="lg:col-span-1 flex justify-center py-1 mx-5 text-stone-400 space-x-5
                        lg:justify-end">
        {loggedIn ? (
                <>
                 <Link
                    to="/" 
                    className="text-sm font-semibold leading-6 no-underline hover:text-white"
                    >
                        <DwellerProfilePhoto/>
                </Link>  
                
                <Link
                    to="/loginPage" 
                    className="flex items-center text-sm font-semibold leading-6 no-underline hover:text-white"
                    onClick={() => {
                    console.log('logging out');
                    setLoggedIn(false);
                    localStorage.clear(); 
                    }}
                    >
                        Log out <span aria-hidden="true">&rarr;</span>
                </Link>  

               
                </> 
            ) : (
                <>
                <Link 
                    to="/loginPage" 
                    className="text-sm font-semibold hover:text-white no-underline">
                    Log in <span aria-hidden="true">&rarr;</span>
                </Link>
                <Link  
                    to="/registerPage" 
                    className="text-sm font-semibold no-underline hover:text-white">
                    Register
                </Link>
                </>
            )}
        </div>
    </div>
    )
}
