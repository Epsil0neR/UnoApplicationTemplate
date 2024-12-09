using System;
using System.Threading.Tasks;
using TradeZeroApp.Presentation;
using Chinook.DynamicMvvm;
using Chinook.SectionsNavigation;
using Chinook.StackNavigation;
using MallardMessageHandlers;

namespace TradeZeroApp.Presentation;

public partial class WelcomePageViewModel : ViewModel
{
	public IDynamicCommand NavigateToOnboarding => this.GetCommandFromTask(async ct =>
	{
		await this.GetService<ISectionsNavigator>().Navigate(ct, () => new OnboardingPageViewModel());
	});
}
