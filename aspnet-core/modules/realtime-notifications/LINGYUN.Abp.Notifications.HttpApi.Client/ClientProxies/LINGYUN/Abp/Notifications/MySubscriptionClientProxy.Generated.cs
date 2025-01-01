// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using LINGYUN.Abp.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.ClientProxying;
using Volo.Abp.Http.Modeling;

// ReSharper disable once CheckNamespace
namespace LINGYUN.Abp.Notifications;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IMySubscriptionAppService), typeof(MySubscriptionClientProxy))]
public partial class MySubscriptionClientProxy : ClientProxyBase<IMySubscriptionAppService>, IMySubscriptionAppService
{
    public virtual async Task<ListResultDto<UserSubscreNotificationDto>> GetAllListAsync()
    {
        return await RequestAsync<ListResultDto<UserSubscreNotificationDto>>(nameof(GetAllListAsync));
    }

    public virtual async Task<PagedResultDto<UserSubscreNotificationDto>> GetListAsync(SubscriptionsGetByPagedDto input)
    {
        return await RequestAsync<PagedResultDto<UserSubscreNotificationDto>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SubscriptionsGetByPagedDto), input }
        });
    }

    public virtual async Task<UserSubscriptionsResult> IsSubscribedAsync(SubscriptionsGetByNameDto input)
    {
        return await RequestAsync<UserSubscriptionsResult>(nameof(IsSubscribedAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SubscriptionsGetByNameDto), input }
        });
    }

    public virtual async Task SubscribeAsync(SubscriptionsGetByNameDto input)
    {
        await RequestAsync(nameof(SubscribeAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SubscriptionsGetByNameDto), input }
        });
    }

    public virtual async Task UnSubscribeAsync(SubscriptionsGetByNameDto input)
    {
        await RequestAsync(nameof(UnSubscribeAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SubscriptionsGetByNameDto), input }
        });
    }
}