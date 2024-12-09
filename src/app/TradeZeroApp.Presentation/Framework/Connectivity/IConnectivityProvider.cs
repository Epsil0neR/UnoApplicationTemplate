using System;

namespace TradeZeroApp;

/// <summary>
/// Checks connectivity state and detect changes.
/// </summary>
public interface IConnectivityProvider
{
	/// <summary>
	/// Occurs when network status changes.
	/// </summary>
	event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;

	/// <summary>
	/// Gets current <see cref="TradeZeroApp.NetworkAccess"/>.
	/// </summary>
	NetworkAccess NetworkAccess { get; }
}
