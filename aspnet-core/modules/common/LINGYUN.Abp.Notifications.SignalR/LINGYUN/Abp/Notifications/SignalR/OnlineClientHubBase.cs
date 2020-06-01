﻿using LINGYUN.Abp.RealTime.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.SignalR;

namespace LINGYUN.Abp.Notifications.SignalR
{
    public abstract class OnlineClientHubBase : AbpHub
    {
        private IOnlineClientManager _onlineClientManager;
        protected IOnlineClientManager OnlineClientManager => LazyGetRequiredService(ref _onlineClientManager);

        private IHttpContextAccessor _httpContextAccessor;
        protected IHttpContextAccessor HttpContextAccessor => LazyGetRequiredService(ref _httpContextAccessor);

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            IOnlineClient onlineClient = CreateClientForCurrentConnection();
            Logger.LogDebug("A client is connected: " + onlineClient.ToString());
            OnlineClientManager.Add(onlineClient);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            Logger.LogDebug("A client is disconnected: " + Context.ConnectionId);
            try
            {
                // 从通讯组移除
                var onlineClient = OnlineClientManager.GetByConnectionIdOrNull(Context.ConnectionId);
                if(onlineClient != null)
                {
                    // 移除在线客户端
                    OnlineClientManager.Remove(Context.ConnectionId);
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex.ToString(), ex);
            }
        }

        protected virtual IOnlineClient CreateClientForCurrentConnection()
        {
            return new OnlineClient(Context.ConnectionId, GetClientIpAddress(),
                CurrentTenant.Id, CurrentUser.Id)
            {
                ConnectTime = Clock.Now
            };
        }

        protected virtual string GetClientIpAddress()
        {
            try
            {
                return HttpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, LogLevel.Warning);
                return null;
            }
        }
    }
}
