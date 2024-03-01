import baseUrl from "../../../config/apiConfig";

const ChatService = {

    persistMessage: async (message, conversationId) => {
        try {
            const response = await fetch(`${baseUrl}/chat/SaveMessage`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('token')}` 
                },
                body: JSON.stringify({
                    message: message, 
                    conversationId: conversationId 
                })
            });

            if (response.ok) {
            const data = await response.json();
            return data;
            } else if (response.status === 401) {
            throw new Error('Unauthorized');
            } else {
            throw new Error('Error persisting message');
            }
            } catch (error) {
                console.error('Error:', error);
                throw error;
            }
        },

        getDwellerData: async () => {
            try {
            const response = await fetch(`${baseUrl}/dweller/GetDwellerDetails`, {
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
                throw new Error('Error fetching conversation');
            }
            } catch (error) {
            console.error('Error:', error);
            throw error;
            }
        },
   

    getDwellingConversation: async () => {
        try {
        const response = await fetch(`${baseUrl}/chat/GetDwellingConversation`, {
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
            throw new Error('Error fetching conversation');
        }
        } catch (error) {
        console.error('Error:', error);
        throw error;
        }
    },
};

export default ChatService;
 