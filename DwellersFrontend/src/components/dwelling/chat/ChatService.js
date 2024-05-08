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
   

    getDwellingConversation: async (conversationId) => {
        try {
        const response = await fetch(`${baseUrl}/chat/GetDwellingConversation`, {
            method: 'POST',
            headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem('token')}`
            },
            body: JSON.stringify({ 
                conversationId: conversationId 
            })
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

    getAllDwellingConversations: async () => {
        try {
        const response = await fetch(`${baseUrl}/chat/GetAllDwellingConversations`, {
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

    addDwellingConversation: async (listOfMemberIds) => {
        try {
            console.log(listOfMemberIds)
            const response = await fetch(`${baseUrl}/chat/AddDwellingConversation`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${localStorage.getItem('token')}` 
                },
                body: JSON.stringify({
                    InvitedConversationMembers: listOfMemberIds 
                })
            });

            if (response.ok) {
            await response.json();
            } 
            else if (response.status === 401) {
            throw new Error('Unauthorized');
            } 
            else if (response.status === 400) {
                const userMessage = await response.json();
                throw new Error(userMessage.errorMessage); 
            } 
            else {
            throw new Error('Error persisting message');
            }
            } catch (error) {
                console.error('Error:', error);
                throw error;
            }
        },
    
};

export default ChatService;
 