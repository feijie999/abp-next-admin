﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LINGYUN.Abp.IM.Messages
{
    public interface IMessageStore
    {
        /// <summary>
        /// 存储聊天记录
        /// </summary>
        /// <param name="chatMessage"></param>
        /// <param name="formUserId"></param>
        /// <param name="toUserId"></param>
        /// <returns></returns>
        Task StoreMessageAsync(ChatMessage chatMessage);
        /// <summary>
        /// 获取群组聊天记录
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="groupName"></param>
        /// <param name="maxResultCount"></param>
        /// <returns></returns>
        Task<List<ChatMessage>> GetGroupMessageAsync(Guid tenantId, string groupName, int maxResultCount = 10);
        /// <summary>
        /// 获取与某个用户的聊天记录
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="userId"></param>
        /// <param name="maxResultCount"></param>
        /// <returns></returns>
        Task<List<ChatMessage>> GetChatMessageAsync(Guid tenantId, Guid userId, int maxResultCount = 10);
    }
}
