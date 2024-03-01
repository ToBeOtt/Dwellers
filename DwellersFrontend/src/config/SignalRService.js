import { HubConnectionBuilder, HubConnectionState, HttpTransportType } from '@microsoft/signalr';
import baseUrl from './apiConfig';

class SignalRService {
  constructor(baseUrl) {
    this.connection = new HubConnectionBuilder()
      .withUrl(`${baseUrl}/dwellersHub`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets
      })
      .withAutomaticReconnect()
      .build();

    // Set up event handlers here if needed.
  }


  startConnection = async () => {
    try {
      if (this.connection.state === HubConnectionState.Disconnected) {
        await this.connection.start();
        console.log("SignalR Connected");
      }
    } catch (error) {
      console.error("Error starting SignalR connection:", error);
    }
  };

  joinConversationGroup = async (conversationId) => {
    try {
      console.log(`Testing joining conversation group: ${conversationId}`);
      if (this.connection.state === HubConnectionState.Connected) {
        await this.connection.invoke("JoinConversationGroup", conversationId);
        console.log(`Joined conversation group: ${conversationId}`);
      } else {
        console.error("Cannot join group: SignalR connection is not in the 'Connected' state.");
      }
    } catch (error) {
      console.error(`Error joining conversation group: ${error}`);
    }
  };

  leaveConversationGroup = async (conversationId) => {
    try {
      if (this.connection.state === HubConnectionState.Connected) {
        await this.connection.invoke("LeaveConversationGroup", conversationId);
        console.log(`Left conversation group: ${conversationId}`);
      } else {
        console.error("Cannot leave group: SignalR connection is not in the 'Connected' state.");
      }
    } catch (error) {
      console.error(`Error leaving conversation group: ${error}`);
    }
  };


  sendMessage = async (message, conversationID) => {
    try {
      if (this.connection.state === HubConnectionState.Connected) {
        await this.connection.invoke("NewMessage", message, conversationID);
        console.log("Message sent:", message);
      } else {
        console.error("Cannot send message: SignalR connection is not in the 'Connected' state.");
      }
    } catch (error) {
      console.error("Error sending message:", error);
    }
  };
}

const signalRService = new SignalRService(baseUrl);

export default signalRService;
