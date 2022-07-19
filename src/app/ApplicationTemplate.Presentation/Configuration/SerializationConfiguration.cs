﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ApplicationTemplate;
using ApplicationTemplate.Business;
using ApplicationTemplate.Client;
using Microsoft.Extensions.DependencyInjection;
using Nventive.Persistence;

namespace ApplicationTemplate
{
	[JsonSerializable(typeof(AuthenticationToken))]
	[JsonSerializable(typeof(AuthenticationData))]
	[JsonSerializable(typeof(ApplicationSettings))]
	[JsonSerializable(typeof(Refit.ProblemDetails))]
	[JsonSerializable(typeof(PostData))]
	[JsonSerializable(typeof(PostData[]))]
	[JsonSerializable(typeof(DadJokesResponse))]
	[JsonSerializable(typeof(DadJokesErrorResponse))]
	[JsonSerializable(typeof(UserProfileData))]
	[JsonSerializable(typeof(DadJokesData))]
	[JsonSerializable(typeof(DadJokeChildData))]
	[JsonSerializable(typeof(DadJokeContentData))]
	public partial class JsonContext : JsonSerializerContext
	{
	}

	/// <summary>
	/// This class is used for serialization configuration.
	/// - Configures the serializers.
	/// </summary>
	public static class SerializationConfiguration
	{
		/// <summary>
		/// Adds the serialization services to the <see cref="IServiceCollection"/>.
		/// </summary>
		/// <param name="services">Service collection.</param>
		/// <returns><see cref="IServiceCollection"/>.</returns>
		public static IServiceCollection AddSerialization(this IServiceCollection services)
		{
			// These options allow some more cases than just the default.
			var options = new JsonSerializerOptions
			{
				AllowTrailingCommas = true,
				NumberHandling = JsonNumberHandling.AllowReadingFromString,
				PropertyNameCaseInsensitive = true,
			};
			options.AddContext<JsonContext>();

			services
				.AddSingleton(options)
				.AddSingleton<ISettingsSerializer>(c => new JsonSerializerToSettingsSerializerAdapter(options));

			return services;
		}
	}
}
