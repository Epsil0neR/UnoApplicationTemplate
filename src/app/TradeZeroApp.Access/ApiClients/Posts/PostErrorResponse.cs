﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TradeZeroApp.DataAccess;

public class PostErrorResponse
{
	public PostData Data { get; }

	public ErrorData Error { get; }
}
