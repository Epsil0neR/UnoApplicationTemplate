using System;
using TradeZeroApp.Business;
using Nventive.View.Converters;

namespace TradeZeroApp.Views;

/// <summary>
/// Use this converter to convert a string .
/// </summary>
public class FiltersConverter : ConverterBase
{
	protected override object Convert(object value, Type targetType, object parameter)
	{
		var param = (PostTypes)Enum.Parse(typeof(PostTypes), (string)parameter, true);
		var val = (PostTypes)value;

		return param == val;
	}

	protected override object ConvertBack(object value, Type targetType, object parameter)
	{
		return (bool)value ? parameter : null;
	}
}
