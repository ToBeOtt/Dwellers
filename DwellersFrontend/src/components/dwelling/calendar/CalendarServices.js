import baseUrl from "../../../config/apiConfig";

const CalendarServices = {

  
    addEvent: async (title, desc, eventDate, eventScope) => {
          const response = await fetch(`${baseUrl}/events/AddEvent`, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
              'Authorization': `Bearer ${localStorage.getItem('token')}`
            },
            body: JSON.stringify({ title, desc, eventDate, eventScope })
          });
          if (!response.ok) {
            throw new Error('Network response was not ok');
          }
        
          const text = await response.text(); // First, read the response as text
        if (!text) {
          // If the response is empty, handle accordingly
          return {}; // Return an empty object or any other value that suits your application's needs
        }

        return JSON.parse(text); // If the response is not empty, parse it as JSON
      },


      removeEvent: async (eventId) => {
        try {
          const response = await fetch(`${baseUrl}/events/DeleteEvent`, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
              'Authorization': `Bearer ${localStorage.getItem('token')}`
            },
            body: JSON.stringify({ eventId })
          });
    
          if (response.ok) {
          } else if (response.status === 401) {
            throw new Error('Unauthorized');
          } else if (response.status == 400){
            throw new Error('Could not delete event');
          }
        } catch (error) {
          console.error('Error:', error);
          throw error;
        }
      },

      getEvent: async (eventId) => {
        try {

            const response = await fetch(`${baseUrl}/events/GetEvent?eventId=${eventId}`, {
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

    getAllEvents: async () => {
        try {

            const response = await fetch(`${baseUrl}/events/GetAllEvents`, {
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
        const response = await fetch(`${baseUrl}/events/GetUpcomingEvents`, {
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

}

export default CalendarServices;
 