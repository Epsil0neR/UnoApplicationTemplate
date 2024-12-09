using System;

namespace TradeZeroApp;

public sealed partial class VersionProvider : IVersionProvider
{
	public string VersionString => Version.ToString();
}
