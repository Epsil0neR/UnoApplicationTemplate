﻿using System;
using System.Collections.Generic;
using System.Text;
using TradeZeroApp.Business;
using Chinook.DynamicMvvm;

namespace TradeZeroApp.Presentation;

public class DadJokesItemViewModel : ViewModel
{
	public DadJokesItemViewModel(IViewModel parent, DadJokesQuote quote)
	{
		Parent = parent;
		Quote = quote;
	}

	public IViewModel Parent { get; }

	public DadJokesQuote Quote { get; }

	public bool IsFavorite
	{
		get => this.Get(initialValue: Quote.IsFavorite);
		set => this.Set(value);
	}
}
