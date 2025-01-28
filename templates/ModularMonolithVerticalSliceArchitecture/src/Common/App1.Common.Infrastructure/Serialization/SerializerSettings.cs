namespace App1.Common.Infrastructure.Serialization;

using System.Text.Json;
using System.Text.Json.Serialization;
using Application.EventBus;
using Domain;

public static class SerializerSettings
{
	public static readonly JsonSerializerOptions Instance = new(JsonSerializerDefaults.Web)
	{
		NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
		Converters = { new InterfaceConverter<IDomainEvent>(), new InterfaceConverter<IIntegrationEvent>() }
	};

	public static void ConfigureJsonSerializerOptionsInstance(IList<JsonConverter> converters)
	{
		foreach (var converter in converters)
		{
			Instance.Converters.Add(converter);
		}
	}
}