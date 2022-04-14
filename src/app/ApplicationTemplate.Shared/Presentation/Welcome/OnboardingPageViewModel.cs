﻿using System;
using ApplicationTemplate.Business;
using Chinook.DynamicMvvm;
using Chinook.SectionsNavigation;
using Chinook.StackNavigation;

namespace ApplicationTemplate.Presentation
{
	public partial class OnboardingPageViewModel : ViewModel
	{
		public IDynamicCommand NavigateToLogin => this.GetCommandFromTask(async ct =>
		{
			await this.GetService<IStackNavigator>().NavigateAndClear(ct, () => new LoginPageViewModel(isFirstLogin: true));
			await this.GetService<IApplicationSettingsService>().CompleteOnboarding(ct);
		});

		public OnboardingItemViewModel[] OnboardingItems { get; } = new[]
		{
			new OnboardingItemViewModel("Get your shot of good humor everyday. Read the latest and greatest dad jokes!", "ms-appx:///Assets/Tutorial_FirstScreen_Icon.png"),
			new OnboardingItemViewModel("Get your shot of good humor everyday. Read the latest and greatest dad jokes!", "ms-appx:///Assets/Tutorial_SecondScreen_Icon.png"),
			new OnboardingItemViewModel("Get your shot of good humor everyday. Read the latest and greatest dad jokes!", "ms-appx:///Assets/Tutorial_ThirdScreen_Icon.png"),
		};

		public static implicit operator OnboardingPageViewModel(OnboardingItemViewModel v)
		{
			throw new NotImplementedException();
		}
	}
}
