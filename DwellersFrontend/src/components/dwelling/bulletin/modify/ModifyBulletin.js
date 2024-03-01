import { useNavigate } from "react-router-dom";

export default function ModifyBulletin(props) {
    const navigate = useNavigate();

    const handleClick = async () => {
        navigate('/AddBulletinPage');
    };

    return(
    <>
        <button 
            className="text-hh hover:text-hh font-semibold"
            onClick={handleClick}
            >
            Ändra
        </button>
    </>
    )  
}