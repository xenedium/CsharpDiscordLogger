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
            await OnRoleCreatedChannel.SendMessageAsync($"A new role ({createdRole.Name}) has been created !");
        }

        public async Task OnRoleDeleted(SocketRole deletedRole)
        {
            await OnRoleDeletedChannel.SendMessageAsync($"A role ({deletedRole.Name}) has been deleted !");
        }

        public async Task OnRoleUpdated(SocketRole before, SocketRole after)
        {
            var update = new string("-------------------------------\n");
            if (before.Name != after.Name) update += $"Name from {before.Name} to {after.Name}\n";
            else update += $"({before.Name}) was updated!\n";
            if (before.Position != after.Position) update += $"Position from {before.Position} to {after.Position}\n";
            if (before.Color.ToString() != after.Color.ToString())
                update += $"Color from {before.Color.ToString()} to {after.Color.ToString()}\n";
            if (before.Permissions.ToString() != after.Permissions.ToString())
            {
                if (before.Permissions.Administrator ^ after.Permissions.Administrator)
                    update += $"Admin from {before.Permissions.Administrator} to {after.Permissions.Administrator}\n";
                if (before.Permissions.Connect ^ after.Permissions.Connect)
                    update += $"Connect from {before.Permissions.Connect} to {after.Permissions.Connect}\n";
                if (before.Permissions.Speak ^ after.Permissions.Speak)
                    update += $"Speak from {before.Permissions.Speak} to {after.Permissions.Speak}\n";
                if (before.Permissions.Stream ^ after.Permissions.Stream)
                    update += $"Stream from {before.Permissions.Stream} to {after.Permissions.Stream}\n";
                if (before.Permissions.AddReactions ^ after.Permissions.AddReactions)
                    update += $"AddReactions from {before.Permissions.AddReactions} to {after.Permissions.AddReactions}\n";
                if (before.Permissions.AttachFiles ^ after.Permissions.AttachFiles)
                    update += $"AttachFiles from {before.Permissions.AttachFiles} to {after.Permissions.AttachFiles}\n";
                if (before.Permissions.BanMembers ^ after.Permissions.BanMembers)
                    update += $"BanMembers from {before.Permissions.BanMembers} to {after.Permissions.BanMembers}\n";
                if (before.Permissions.ChangeNickname ^ after.Permissions.ChangeNickname)
                    update += $"ChangeNickname from {before.Permissions.ChangeNickname} to {after.Permissions.ChangeNickname}\n";
                if (before.Permissions.DeafenMembers ^ after.Permissions.DeafenMembers)
                    update += $"DeafenMembers from {before.Permissions.DeafenMembers} to {after.Permissions.DeafenMembers}\n";
                if (before.Permissions.EmbedLinks ^ after.Permissions.EmbedLinks)
                    update += $"EmbedLinks from {before.Permissions.EmbedLinks} to {after.Permissions.EmbedLinks}\n";
                if (before.Permissions.KickMembers ^ after.Permissions.KickMembers)
                    update += $"KickMembers from {before.Permissions.KickMembers} to {after.Permissions.KickMembers}\n";
                if (before.Permissions.ManageChannels ^ after.Permissions.ManageChannels)
                    update += $"ManageChannels from {before.Permissions.ManageChannels} to {after.Permissions.ManageChannels}\n";
                if (before.Permissions.ManageEmojis ^ after.Permissions.ManageEmojis)
                    update += $"ManageEmojis from {before.Permissions.ManageEmojis} to {after.Permissions.ManageEmojis}\n";
                if (before.Permissions.ManageGuild ^ after.Permissions.ManageGuild)
                    update += $"ManageGuild from {before.Permissions.ManageGuild} to {after.Permissions.ManageGuild}\n";
                if (before.Permissions.ManageMessages ^ after.Permissions.ManageMessages)
                    update += $"ManageMessages from {before.Permissions.ManageMessages} to {after.Permissions.ManageMessages}\n";
                if (before.Permissions.ManageNicknames ^ after.Permissions.ManageNicknames)
                    update += $"ManageNicknames from {before.Permissions.ManageNicknames} to {after.Permissions.ManageNicknames}\n";
                if (before.Permissions.ManageRoles ^ after.Permissions.ManageRoles)
                    update += $"ManageRoles from {before.Permissions.ManageRoles} to {after.Permissions.ManageRoles}\n";
                if (before.Permissions.ManageWebhooks ^ after.Permissions.ManageWebhooks)
                    update += $"ManageWebhooks from {before.Permissions.ManageWebhooks} to {after.Permissions.ManageWebhooks}\n";
                if (before.Permissions.MentionEveryone ^ after.Permissions.MentionEveryone)
                    update += $"MentionEveryone from {before.Permissions.MentionEveryone} to {after.Permissions.MentionEveryone}\n";
                if (before.Permissions.MoveMembers ^ after.Permissions.MoveMembers)
                    update += $"MoveMembers from {before.Permissions.MoveMembers} to {after.Permissions.MoveMembers}\n";
                if (before.Permissions.MuteMembers ^ after.Permissions.MuteMembers)
                    update += $"MuteMembers from {before.Permissions.MuteMembers} to {after.Permissions.MuteMembers}\n";
                if (before.Permissions.PrioritySpeaker ^ after.Permissions.PrioritySpeaker)
                    update += $"PrioritySpeaker from {before.Permissions.PrioritySpeaker} to {after.Permissions.PrioritySpeaker}\n";
                if (before.Permissions.SendMessages ^ after.Permissions.SendMessages)
                    update += $"SendMessages from {before.Permissions.SendMessages} to {after.Permissions.SendMessages}\n";
                if (before.Permissions.ViewChannel ^ after.Permissions.ViewChannel)
                    update += $"ViewChannel from {before.Permissions.ViewChannel} to {after.Permissions.ViewChannel}\n";
                if (before.Permissions.CreateInstantInvite ^ after.Permissions.CreateInstantInvite)
                    update += $"CreateInstantInvite from {before.Permissions.CreateInstantInvite} to {after.Permissions.CreateInstantInvite}\n";
                if (before.Permissions.ReadMessageHistory ^ after.Permissions.ReadMessageHistory)
                    update += $"ReadMessageHistory from {before.Permissions.ReadMessageHistory} to {after.Permissions.ReadMessageHistory}\n";
                if (before.Permissions.UseExternalEmojis ^ after.Permissions.UseExternalEmojis)
                    update += $"UseExternalEmojis from {before.Permissions.UseExternalEmojis} to {after.Permissions.UseExternalEmojis}\n";
                if (before.Permissions.ViewAuditLog ^ after.Permissions.ViewAuditLog)
                    update += $"ViewAuditLog from {before.Permissions.ViewAuditLog} to {after.Permissions.ViewAuditLog}\n";
                if (before.Permissions.ViewGuildInsights ^ after.Permissions.ViewGuildInsights)
                    update += $"ViewGuildInsights from {before.Permissions.ViewGuildInsights} to {after.Permissions.ViewGuildInsights}\n";
                if (before.Permissions.UseVAD ^ after.Permissions.UseVAD)
                    update += $"UseVAD from {before.Permissions.UseVAD} to {after.Permissions.UseVAD}\n";
                if (before.Permissions.SendTTSMessages ^ after.Permissions.SendTTSMessages)
                    update += $"SendTTSMessages from {before.Permissions.SendTTSMessages} to {after.Permissions.SendTTSMessages}\n";
            }

            await OnRoleUpdatedChannel.SendMessageAsync(update);
        }

        public async Task OnUserBanned(SocketUser bannedUser, SocketGuild guild)
        {
            await OnUserBannedChannel.SendMessageAsync($"A user ({bannedUser}) has been banned in {guild.Name}");
        }

        public async Task OnUserIsTyping(SocketUser user, ISocketMessageChannel channel)
        {
            await OnUserIsTypingChannel.SendMessageAsync(
                $"{user}({user.Id}) is typing a message in {channel.Name}");
        }

        public async Task OnUserJoined(SocketGuildUser joinedUser)
        {
            await OnUserJoinedChannel.SendMessageAsync($"A new user {joinedUser} joined");
        }

        public async Task OnUserLeft(SocketGuildUser leftUser)
        {
            await OnUserLeftChannel.SendMessageAsync($"{leftUser}({leftUser.Id}) left the guild !");
        }

        public async Task OnUserUnbanned(SocketUser unbannedUser, SocketGuild guild)
        {
            await OnUserUnbannedChannel.SendMessageAsync($"{unbannedUser} has been unbanned !");
        }

        public async Task OnUserUpdated(SocketUser before, SocketUser after)
        {
            await OnUserUpdatedChannel.SendMessageAsync($"event fired ?");
        }

        public async Task OnUserVoiceStateUpdated(SocketUser user, SocketVoiceState before, SocketVoiceState after)
        {
            var update = new string($"--------------------------------\n{user}({user.Id}):\n");
            if (before.VoiceChannel == null)
                update += $"Joined {after.VoiceChannel.Name}({after.VoiceChannel.Id})\n";
            else if (after.VoiceChannel == null)
                update += $"Left {before.VoiceChannel.Name}({before.VoiceChannel.Id})\n";

            if (after.VoiceChannel != null && before.VoiceChannel != null && before.VoiceChannel.Id != after.VoiceChannel.Id)
                update += $"Moved from {before.VoiceChannel.Name} to {after.VoiceChannel.Name}";
            
            if (before.IsDeafened ^ after.IsDeafened)
                update += $"ForceDeafened from {before.IsDeafened} to {after.IsDeafened}\n";
            if (before.IsMuted ^ after.IsMuted)
                update += $"ForceMuted from {before.IsMuted} to {after.IsMuted}\n";
            if (before.IsStreaming ^ after.IsStreaming)
                update += $"Streaming from {before.IsStreaming} to {after.IsStreaming}\n";
            if (before.IsSuppressed ^ after.IsSuppressed)
                update += $"Suppressed from {before.IsSuppressed} to {after.IsSuppressed}\n";
            if (before.IsSelfDeafened ^ after.IsSelfDeafened)
                update += $"SelfDeafened from {before.IsSelfDeafened} to {after.IsSelfDeafened}\n";
            if (before.IsSelfMuted ^ after.IsSelfMuted)
                update += $"SelfMuted from {before.IsSelfMuted} to {after.IsSelfMuted}\n";

            await OnUserVoiceStateUpdatedChannel.SendMessageAsync(update);
        }
    }
}
