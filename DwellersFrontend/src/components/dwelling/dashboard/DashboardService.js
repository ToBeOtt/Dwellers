import baseUrl from "../../../config/apiConfig";

const DashboardService = {

  getDashboardBulletins: async () => {
    try {
      const response = await fetch(`${baseUrl}/dashboard/GetDashboardBulletins`, {
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

  getUpcomingEvents: async () => {
    try {
      const response = await fetch(`${baseUrl}/DwellerEvents/GetUpcomingEvents`, {
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


}

export default DashboardService;
