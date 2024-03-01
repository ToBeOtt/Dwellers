import baseUrl from "../../config/apiConfig";

const DwellerService = {

  SetProfilePhoto: async (formData) => {
    try {
      const response = await fetch(`${baseUrl}/dweller/SetProfilePhoto`, {
        method: 'POST',
        headers: {
          'Authorization': `Bearer ${localStorage.getItem('token')}`
        },
        body: formData, 
      });

      if (response.ok) {
        const data = await response.json();
        console.log('Profile photo saved successfully!');
        return data;
      } else if (response.status === 401) {
        throw new Error('Unauthorized');
      } else {
        throw new Error('Error saving profile photo to database.');
      }
    } catch (error) {
      console.error('Error:', error);
      throw error;
    }
  },

}

export default DwellerService;
 