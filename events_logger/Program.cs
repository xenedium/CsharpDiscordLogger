using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using events_logger.Events;

namespace events_logger
{
     public static class Program
    {
        private static DiscordSocketClient _client;
        
        private static void Main(string[] args) => Program.EntryPoint().GetAwaiter().GetResult();

        private static async Task EntryPoint()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig {MessageCacheSize = 50000});

            await _client.LoginAsync(TokenType.Bot, TOKEN);
            await _client.StartAsync();

            var events = new EventsHandler(_client);

            _client.Ready += events.OnReady;
            _client.ChannelCreated += events.OnChannelCreated;
            _client.ChannelDestroyed += events.OnChannelDestroyed;
            _client.ChannelUpdated += events.OnChannelUpdated;
            _client.GuildMemberUpdated += events.OnGuildMemberUpdated;
            _client.GuildUpdated += events.OnGuildUpdated;
            _client.InviteCreated += events.OnInviteCreated;
            _client.InviteDeleted += events.OnInviteDeleted;
            _client.MessageDeleted += events.OnMessageDeleted;
            _client.MessagesBulkDeleted += events.OnMessageBulkDeleted;
            _client.MessageUpdated += events.OnMessageUpdated;
            _client.ReactionAdded += events.OnReactionAdded;
            _client.ReactionRemoved += events.OnReactionRemoved;
            _client.ReactionsCleared += events.OnReactionsCleared;
            _client.ReactionsRemovedForEmote += events.OnReactionsRemovedForEmote;
            _client.RoleCreated += events.OnRoleCreated;
            _client.RoleDeleted += events.OnRoleDeleted;
            _client.RoleUpdated += events.OnRoleUpdated;
            _client.UserBanned += events.OnUserBanned;
            _client.UserIsTyping += events.OnUserIsTyping;
            _client.UserJoined += events.OnUserJoined;
            _client.UserLeft += events.OnUserLeft;
            _client.UserUnbanned += events.OnUserUnbanned;
            _client.UserUpdated += events.OnUserUpdated;
            _client.UserVoiceStateUpdated += events.OnUserVoiceStateUpdated;

            await Task.Delay(-1);
        }
        
    }
}
