﻿using System;
using System.Reactive.Concurrency;
using ApplicationTemplate.Client;
using Chinook.DynamicMvvm;
using MessageDialogService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Dispatching;
using ReviewService;
using ReviewService.Abstractions;

namespace ApplicationTemplate.Views;

/// <summary>
/// This class is used for view services.
/// - Configures view services.
/// </summary>
public static class ViewServicesConfiguration
{
	public static IServiceCollection AddViewServices(this IServiceCollection services)
	{
		return services
			.AddSingleton(s => App.Instance.NavigationMultiFrame.DispatcherQueue)
			.AddSingleton(s => Shell.Instance.ExtendedSplashScreen)
			.AddSingleton<IDispatcherScheduler>(s => new MainDispatcherScheduler(
				s.GetRequiredService<DispatcherQueue>(),
				DispatcherQueuePriority.Normal
			))
			.AddSingleton<IDispatcherFactory, DispatcherFactory>()
			.AddSingleton<IDiagnosticsService, DiagnosticsService>()
			.AddSingleton<ILauncherService>(s => new LauncherService(s.GetRequiredService<DispatcherQueue>()))
			.AddSingleton<IVersionProvider, VersionProvider>()
			.AddSingleton<IDeviceInformationProvider, DeviceInformationProvider>()
			.AddSingleton<IExtendedSplashscreenController, ExtendedSplashscreenController>(s => new ExtendedSplashscreenController(Shell.Instance.DispatcherQueue))
			.AddSingleton<IConnectivityProvider, ConnectivityProvider>()
			.AddSingleton<IEmailService, EmailService>()
			.AddSingleton<IMemoryProvider, MemoryProvider>()
			.AddSingleton<IReviewPrompter, ReviewPrompter>()
			.AddSingleton<IReviewSettingsSource<ReviewSettingsCustom>, ReviewSettingsSource>()
			.AddMessageDialog()
			.AddReviewService();
	}

	private static IServiceCollection AddMessageDialog(this IServiceCollection services)
	{
		return services.AddSingleton<IMessageDialogService>(s =>
//-:cnd:noEmit
#if __WINDOWS__ || __IOS__ || __ANDROID__
			new MessageDialogService.MessageDialogService(
				s.GetRequiredService<DispatcherQueue>(),
//-:cnd:noEmit
#if __WINDOWS__
				new MessageDialogBuilderDelegate(
					key => s.GetRequiredService<IStringLocalizer>()[key],
					WinRT.Interop.WindowNative.GetWindowHandle(App.Instance.CurrentWindow)
				)
#else
				new MessageDialogBuilderDelegate(
					key => s.GetRequiredService<IStringLocalizer>()[key]
				)
#endif
//+:cnd:noEmit
			)
#else
			new AcceptOrDefaultMessageDialogService()
#endif
//+:cnd:noEmit
		);
	}

	private static IServiceCollection AddReviewService(this IServiceCollection services)
	{
		return services.AddSingleton<IReviewService<ReviewSettingsCustom>>(s =>
		{
			return new ReviewService<ReviewSettingsCustom>(
				s.GetRequiredService<ILogger<ReviewService<ReviewSettingsCustom>>>(),
				s.GetRequiredService<IReviewPrompter>(),
				s.GetRequiredService<IReviewSettingsSource<ReviewSettingsCustom>>(),
				new ReviewConditionCallback<ReviewSettingsCustom>[]
				{
					ReviewCondition.PrimaryActionCompletedAtLeast<ReviewSettingsCustom>(1),
					ReviewCondition.SecondaryActionCompletedAtLeast<ReviewSettingsCustom>(1),
					ReviewCondition.ApplicationLaunchedAtLeast<ReviewSettingsCustom>(1),
				}
			);
		});
	}
}
