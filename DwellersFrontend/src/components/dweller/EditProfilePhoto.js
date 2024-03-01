import { useState } from 'react';
import DwellerService from './DwellerService';


function EditProfilePhoto() {
  const [selectedFile, setSelectedFile] = useState(null);

  const handleFileUpload = (event) => {
    const file = event.target.files[0];
    setSelectedFile(file);
    console.log(file);
  };
  
  const handleSaveProfile = async () => {
      const formData = new FormData();
      formData.append('profilePhoto', selectedFile);
      console.log(formData);
      await DwellerService.SetProfilePhoto(formData) 
  };

  return (
    <div>
      <input type="file" accept="image/*" onChange={handleFileUpload} />
      <button onClick={handleSaveProfile}>Save Profile</button>

      <img src="/api/getProfilePhoto" alt="Profile" />
    </div>
  );
}

export default EditProfilePhoto;
