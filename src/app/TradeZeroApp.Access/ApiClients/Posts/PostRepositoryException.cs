﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TradeZeroApp.DataAccess;

public class PostRepositoryException : Exception
{
	public PostRepositoryException()
	{
	}

	public PostRepositoryException(string message)
		: base(message)
	{
	}

	public PostRepositoryException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public PostRepositoryException(PostErrorResponse errorResponse)
	{
	}
}
