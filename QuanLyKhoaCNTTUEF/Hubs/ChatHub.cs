using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;
using System.Collections.Concurrent;

namespace QuanLyKhoaCNTTUEF.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
