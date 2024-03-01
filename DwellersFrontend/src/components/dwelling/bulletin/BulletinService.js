import baseUrl from "../../../config/apiConfig";

const BulletinService = {

  getBulletins: async (noteCategory) => {
    try {

      let apiUrl = `${baseUrl}/bulletin/GetDwellingBulletins`;

    if (noteCategory !== null) {
      apiUrl += `?noteCategory=${noteCategory}`;
    }

      const response = await fetch(apiUrl, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${localStorage.getItem('token')}`
        },
      });

      if (response.ok) {
        const data = await response.json();
        return data;
      } else if (response.status === 401) {
        throw new Error('Unauthorized');
      } else {
        throw new Error('Error fetching notes');
      }
    } catch (error) {
      console.error('Error:', error);
      throw error;
    }
  },

  getAllBulletins: async () => {
    try {

      let apiUrl = `${baseUrl}/bulletin/GetAllBulletins`;

      const response = await fetch(apiUrl, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${localStorage.getItem('token')}`
        },
      });

      if (response.ok) {
        const data = await response.json();
        return data;
      } else if (response.status === 401) {
        throw new Error('Unauthorized');
      } else {
        throw new Error('Error fetching notes');
      }
    } catch (error) {
      console.error('Error:', error);
      throw error;
    }
  },

  getBulletin: async (noteId) => {
    try {
      const response = await fetch(`${baseUrl}/notes/GetNote?noteId=${noteId}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${localStorage.getItem('token')}`
        },
      });
  
      if (response.ok) {
        const data = await response.json();
        console.log('Note Received:', data);
        return data;
      } else if (response.status === 401) {
        throw new Error('Unauthorized');
      } else {
        throw new Error('Error fetching notes');
      }
    } catch (error) {
      console.error('Error:', error);
      throw error;
    }
  },

  removeBulletin: async (noteId) => {
    try {
      const response = await fetch(`${baseUrl}/notes/RemoveNote`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${localStorage.getItem('token')}`
        },
        body: JSON.stringify({
          noteId }),
      });

      if (response.ok) {
        const data = await response.json();
        return data;
      } else if (response.status === 401) {
        throw new Error('Unauthorized');
      } else {
        throw new Error('Error deleting note');
      }
    } catch (error) {
      console.error('Error:', error);
      throw error;
    }
  },

}
    export default BulletinService;
 