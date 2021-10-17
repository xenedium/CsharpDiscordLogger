using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;

namespace events_logger.Events
{
    public class EventsHandler
    {
        private DiscordSocketClient Client { get; }
        private ISocketMessageChannel OnReadyChannel { get; set; }
        private ISocketMessageChannel OnChannelCreatedChannel { get; set; }
        private ISocketMessageChannel OnChannelDestroyedChannel { get; set; }
        private ISocketMessageChannel OnChannelUpdatedChannel { get; set; }
        private ISocketMessageChannel OnGuildMemberUpdatedChannel { get; set; }
        private ISocketMessageChannel OnGuildUpdatedChannel { get; set; }
        private ISocketMessageChannel OnInviteCreatedChannel { get; set; }
        private ISocketMessageChannel OnInviteDeletedChannel { get; set; }
        private ISocketMessageChannel OnMessageDeletedChannel { get; set; }
        private ISocketMessageChannel OnMessageBulkDeletedChannel { get; set; }
        private ISocketMessageChannel OnMessageUpdatedChannel { get; set; }
        private ISocketMessageChannel OnReactionAddedChannel { get; set; }
        private ISocketMessageChannel OnReactionRemovedChannel { get; set; }
        private ISocketMessageChannel OnReactionsClearedChannel { get; set; }
        private ISocketMessageChannel OnReactionsRemovedForEmoteChannel { get; set; }
        private ISocketMessageChannel OnRoleCreatedChannel { get; set; }
        private ISocketMessageChannel OnRoleDeletedChannel { get; set; }
        private ISocketMessageChannel OnRoleUpdatedChannel { get; set; }
        private ISocketMessageChannel OnUserBannedChannel { get; set; }
        private ISocketMessageChannel OnUserIsTypingChannel { get; set; }
        private ISocketMessageChannel OnUserJoinedChannel { get; set; }
        private ISocketMessageChannel OnUserLeftChannel { get; set; }
        private ISocketMessageChannel OnUserUnbannedChannel { get; set; }
        private ISocketMessageChannel OnUserUpdatedChannel { get; set; }
        private ISocketMessageChannel OnUserVoiceStateUpdatedChannel { get; set; }
        
        public EventsHandler(IDisposable client)
        {
            Client = client as DiscordSocketClient;
        }

        public async Task OnReady()
        {
            OnReadyChannel = Client.GetChannel(898904606623563797) as ISocketMessageChannel;
            OnChannelCreatedChannel = Client.GetChannel(898911724097396766) as ISocketMessageChannel;
            OnChannelDestroyedChannel = Client.GetChannel(898914599137587230) as ISocketMessageChannel;
            OnChannelUpdatedChannel = Client.GetChannel(898930201818456085) as ISocketMessageChannel;
            OnGuildMemberUpdatedChannel = Client.GetChannel(898930259582390292) as ISocketMessageChannel;
            OnGuildUpdatedChannel = Client.GetChannel(898930311772135424) as ISocketMessageChannel;
            OnInviteCreatedChannel = Client.GetChannel(898930362959413298) as ISocketMessageChannel;
            OnInviteDeletedChannel = Client.GetChannel(898930405716131870) as ISocketMessageChannel;
            OnMessageDeletedChannel = Client.GetChannel(898930458669228032) as ISocketMessageChannel;
            OnMessageBulkDeletedChannel = Client.GetChannel(898930521684463697) as ISocketMessageChannel;
            OnMessageUpdatedChannel = Client.GetChannel(898930568853602314) as ISocketMessageChannel;
            OnReactionAddedChannel = Client.GetChannel(898930614588297246) as ISocketMessageChannel;
            OnReactionRemovedChannel = Client.GetChannel(898930668107624538) as ISocketMessageChannel;
            OnReactionsClearedChannel = Client.GetChannel(898930714525962240) as ISocketMessageChannel;
            OnReactionsRemovedForEmoteChannel = Client.GetChannel(898930776010289152) as ISocketMessageChannel;
            OnRoleCreatedChannel = Client.GetChannel(898930869895585873) as ISocketMessageChannel;
            OnRoleDeletedChannel = Client.GetChannel(898930938937999380) as ISocketMessageChannel;
            OnRoleUpdatedChannel = Client.GetChannel(898930981036232744) as ISocketMessageChannel;
            OnUserBannedChannel = Client.GetChannel(898931022249467944) as ISocketMessageChannel;
            OnUserIsTypingChannel = Client.GetChannel(898931064624529419) as ISocketMessageChannel;
            OnUserJoinedChannel = Client.GetChannel(898931120631078944) as ISocketMessageChannel;
            OnUserLeftChannel = Client.GetChannel(898931159109611590) as ISocketMessageChannel;
            OnUserUnbannedChannel = Client.GetChannel(898931210456301629) as ISocketMessageChannel;
            OnUserUpdatedChannel = Client.GetChannel(898931242903433227) as ISocketMessageChannel;
            OnUserVoiceStateUpdatedChannel = Client.GetChannel(898931281759453265) as ISocketMessageChannel;

            if (OnReadyChannel != null) await OnReadyChannel.SendMessageAsync($"Ready !");
            await Client.SetStatusAsync(UserStatus.Online);
            await Client.SetActivityAsync(new Game("for Master Sorrow", ActivityType.Watching));
        }
        
        public async Task OnChannelCreated(SocketChannel channel)
        {
            if (channel is SocketGuildChannel guildChannel)
                await OnChannelCreatedChannel.SendMessageAsync(
                    $"A new {guildChannel.GetType()} channel named '{guildChannel.Name}'({guildChannel.Id}) has been created !\nTime: {guildChannel.CreatedAt}");
        }
        
        public async Task OnChannelDestroyed(SocketChannel channel)
        {
            if (channel is SocketGuildChannel guildChannel)
                await OnChannelDestroyedChannel.SendMessageAsync(
                    $"A {guildChannel.GetType()} channel '{guildChannel.Name}'({guildChannel.Id}) has been deleted !");
        }

        public async Task OnChannelUpdated(SocketChannel before, SocketChannel after)
        {
            if (before is SocketGuildChannel beforeChannel &&
                after is SocketGuildChannel afterChannel)
                switch (beforeChannel)
                {
                    case SocketTextChannel beforeTextChannel when afterChannel is SocketTextChannel afterTextChannel:
                        await OnChannelUpdatedChannel.SendMessageAsync(
                            $"Before: ```" +
                            $"Name: {beforeTextChannel.Name}\n" +
                            $"Position: {beforeTextChannel.Position}\n" +
                            $"Category: {beforeTextChannel.Category.Name}\n" +
                            $"IsNSFW: {beforeTextChannel.IsNsfw}\n" +
                            $"Topic: {beforeTextChannel.Topic}\n```" +
                            $"After: ```" +
                            $"Name: {afterTextChannel.Name}\n" +
                            $"Position: {afterTextChannel.Position}\n" +
                            $"Category: {afterTextChannel.Category.Name}\n" +
                            $"IsNSFW: {afterTextChannel.IsNsfw}\n" +
                            $"Topic: {afterTextChannel.Topic}\n```\n---------------------------------------");
                        break;
                    case SocketVoiceChannel beforeVoiceChannel when afterChannel is SocketVoiceChannel afterVoiceChannel:
                        await OnChannelUpdatedChannel.SendMessageAsync(
                            $"Before: ```" +
                            $"Name: {beforeVoiceChannel.Name}\n" +
                            $"Position: {beforeVoiceChannel.Position}\n" +
                            $"Category: {beforeVoiceChannel.Category.Name}\n" +
                            $"Bitrate: {beforeVoiceChannel.Bitrate}\n" +
                            $"UserLimit: {beforeVoiceChannel.UserLimit}\n```" +
                            $"After: ```" +
                            $"Name: {afterVoiceChannel.Name}\n" +
                            $"Position: {afterVoiceChannel.Position}\n" +
                            $"Category: {afterVoiceChannel.Category.Name}\n" +
                            $"Bitrate: {afterVoiceChannel.Bitrate}\n" +
                            $"UserLimit: {afterVoiceChannel.UserLimit}\n```" +
                            $"\n---------------------------------------"
                            );
                        break;
                }
        }

        public async Task OnGuildMemberUpdated(SocketGuildUser before, SocketGuildUser after)
        {
            var userIds = new ulong[]
            {
                000000000000000000, 111111111111111111, 222222222222222222, 33333333333333333, 44444444444444444,
                555555555555555555, 666666666666666666, 777777777777777777
            };  //Just don't ask me why please....
            
            if (userIds.Contains(before.Id))
                await OnGuildMemberUpdatedChannel.SendMessageAsync($"Before: ```" +
                                                             $"Nickname: {before.Nickname}\n" +
                                                             $"Username: {before.Username}\n" +
                                                             $"Id: {before.Id}\n" +
                                                             $"IsDeafened: {before.IsDeafened}\n" +
                                                             $"IsMuted: {before.IsMuted}\n" +
                                                             $"IsSelfDeafened: {before.IsSelfDeafened}\n" +
                                                             $"IsSelfMuted: {before.IsSelfMuted}\n" +
                                                             $"IsStreaming: {before.IsStreaming}\n" +
                                                             $"RoleCount: {before.Roles.Count}\n" +
                                                             $"VoiceChannel: {before.VoiceChannel?.Name}\n" +
                                                             $"Status: {before.Status.ToString()}\n" +
                                                             $"ActivityType: {before.Activity.Type.ToString()}\n" +
                                                             $"ActivityName: {before.Activity.Name}\n" +
                                                             $"ActivityDetails: {before.Activity.Details}\n```" +
                                                             $"After: ```" +
                                                             $"Nickname: {after.Nickname}\n" +
                                                             $"Username: {after.Username}\n" +
                                                             $"Id: {after.Id}\n" +
                                                             $"IsDeafened: {after.IsDeafened}\n" +
                                                             $"IsMuted: {after.IsMuted}\n" +
                                                             $"IsSelfDeafened: {after.IsSelfDeafened}\n" +
                                                             $"IsSelfMuted: {after.IsSelfMuted}\n" +
                                                             $"IsStreaming: {after.IsStreaming}\n" +
                                                             $"RoleCount: {after.Roles.Count}\n" +
                                                             $"VoiceChannel: {after.VoiceChannel?.Name}\n" +
                                                             $"Status: {after.Status.ToString()}\n" +
                                                             $"ActivityType: {after.Activity.Type.ToString()}\n" +
                                                             $"ActivityName: {after.Activity.Name}\n" +
                                                             $"ActivityDetails: {after.Activity.Details}\n```" +
                                                             $"\n---------------------------------------"
                                                             );
        }

        public async Task OnGuildUpdated(SocketGuild before, SocketGuild after)
        {
            await OnGuildUpdatedChannel.SendMessageAsync($"Before: ```" +
                                                         $"Name: {before.Name}\n" +
                                                         $"AFKChannel: {before.AFKChannel.Name}\n" +
                                                         $"AFKTimeout: {before.AFKTimeout}\n" +
                                                         $"Description: {before.Description}\n" +
                                                         $"EmotesCount: {before.Emotes.Count}\n" +
                                                         $"ExplicitContentFilterLevel: {before.ExplicitContentFilter.ToString()}\n" +
                                                         $"```" +
                                                         $"After: ```" +
                                                         $"Name: {after.Name}\n" +
                                                         $"AFKChannel: {after.AFKChannel.Name}\n" +
                                                         $"AFKTimeout: {after.AFKTimeout}\n" +
                                                         $"Description: {after.Description}\n" +
                                                         $"EmotesCount: {after.Emotes.Count}\n" +
                                                         $"ExplicitContentFilterLevel: {after.ExplicitContentFilter.ToString()}\n" +
                                                         $"```\n---------------------------------------------\n");
        }

        public async Task OnInviteCreated(SocketInvite createdInvite)
        {
            await OnInviteCreatedChannel.SendMessageAsync(
                $"'{createdInvite.Inviter}({createdInvite.Inviter.Id}) created an invite link ({createdInvite.Code}) to ({createdInvite.Channel.Name})!'");
        }

        public async Task OnInviteDeleted(SocketGuildChannel deletedInviteChannel, string code)
        {
            await OnInviteDeletedChannel.SendMessageAsync($"The invite ({code}) to ({deletedInviteChannel.Name}) has been deleted!");
        }

        public async Task OnMessageDeleted(Cacheable<IMessage, ulong> cachedMessage, ISocketMessageChannel channel)
        {
            if (!cachedMessage.HasValue) await Task.CompletedTask;
            await OnMessageDeletedChannel.SendMessageAsync(
                $"A message sent by '{cachedMessage.Value.Author}'({cachedMessage.Value.Author.Id}) in {channel.Name}({channel.Id}) has been deleted!\n" +
                $"{cachedMessage.Value.Content}\n------------------------------");
        }

        public async Task OnMessageBulkDeleted(IReadOnlyCollection<Cacheable<IMessage, ulong>> cachedMessages,
            ISocketMessageChannel channel)
        {
            var messages = cachedMessages.Aggregate("", (current, cachedMessage) => current + $"{cachedMessage.Value.Author}({cachedMessage.Value.Author.Id}): {cachedMessage.Value.Content}\n");

            await OnMessageBulkDeletedChannel.SendMessageAsync(
                $"{cachedMessages.Count} messages were deleted in {channel.Name}({channel.Id})\n{messages}\n-----------------------------------");
        }

        public async Task OnMessageUpdated(Cacheable<IMessage, ulong> cachedMessage, SocketMessage updatedMessage,
            ISocketMessageChannel channel)
        {
            await OnMessageUpdatedChannel.SendMessageAsync(
                $"A message sent by '{cachedMessage.Value.Author}'({cachedMessage.Value.Author.Id}) in '{channel.Name}'({channel.Id}) was updated!\n" +
                $"Before: {cachedMessage.Value.Content}\n" +
                $"After: {updatedMessage.Content}\n----------------------------");
        }

        public async Task OnReactionAdded(Cacheable<IUserMessage, ulong> cachedMessage, ISocketMessageChannel channel,
            SocketReaction reaction)
        {
            await OnReactionAddedChannel.SendMessageAsync(
                $"A new reaction ({reaction.Emote.Name}) had been added " +
                $"by '{reaction.User.Value}'({reaction.User.Value.Id}) " +
                $"in '{channel.Name}'({channel.Id}) " +
                $"to '{cachedMessage.Value.Content}'");
        }

        public async Task OnReactionRemoved(Cacheable<IUserMessage, ulong> cachedMessage, ISocketMessageChannel channel,
            SocketReaction reaction)
        {
            await OnReactionRemovedChannel.SendMessageAsync($"A reaction ({reaction.Emote.Name}) has been removed " +
                                                            $"sent by {reaction.User.Value}({reaction.User.Value.Id}) " +
                                                            $"in {channel.Name}({channel.Id}) " +
                                                            $"to {cachedMessage.Value.Content}");
        }

        public async Task OnReactionsCleared(Cacheable<IUserMessage, ulong> cachedMessage, ISocketMessageChannel channel)
        {
            await OnReactionsClearedChannel.SendMessageAsync($"All reactions were deleted in {channel.Name}({channel.Id}) " +
                                                             $"to {cachedMessage.Value.Content}");
        }

        public async Task OnReactionsRemovedForEmote(Cacheable<IUserMessage, ulong> cachedMessage,
            ISocketMessageChannel channel, IEmote emote)
        {
            await OnReactionsRemovedForEmoteChannel.SendMessageAsync($"All {emote.Name} were deleted in {channel.Name}({channel.Id}) " +
                                                                     $"for {cachedMessage.Value.Content}");
        }

        public async Task OnRoleCreated(SocketRole createdRole)
        {
            await Task.CompletedTask;
        }

        public async Task OnRoleDeleted(SocketRole deletedRole)
        {
            await Task.CompletedTask;
        }

        public async Task OnRoleUpdated(SocketRole before, SocketRole after)
        {
            await Task.CompletedTask;
        }

        public async Task OnUserBanned(SocketUser bannedUser, SocketGuild guild)
        {
            await Task.CompletedTask;
        }

        public async Task OnUserIsTyping(SocketUser user, ISocketMessageChannel channel)
        {
            await Task.CompletedTask;
        }

        public async Task OnUserJoined(SocketGuildUser joinedUser)
        {
            await Task.CompletedTask;
        }

        public async Task OnUserLeft(SocketGuildUser leftUser)
        {
            await Task.CompletedTask;
        }

        public async Task OnUserUnbanned(SocketUser unbannedUser, SocketGuild guild)
        {
            await Task.CompletedTask;
        }

        public async Task OnUserUpdated(SocketUser before, SocketUser after)
        {
            await Task.CompletedTask;
        }

        public async Task OnUserVoiceStateUpdated(SocketUser user, SocketVoiceState before, SocketVoiceState after)
        {
            await Task.CompletedTask;
        }
    }
}
