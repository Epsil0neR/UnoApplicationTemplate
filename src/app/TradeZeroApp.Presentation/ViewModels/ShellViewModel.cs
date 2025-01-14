﻿using Chinook.DynamicMvvm;

namespace TradeZeroApp.Presentation;

public class ShellViewModel : ViewModel
{
	public DiagnosticsOverlayViewModel DiagnosticsOverlay => this.GetChild<DiagnosticsOverlayViewModel>();

	public MenuViewModel Menu => this.GetChild<MenuViewModel>();
}
