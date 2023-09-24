namespace App1.Infrastructure.Data.Repositories;

using System.Net.Http.Json;
using Application.Interfaces.Repositories;
using Models;
using DomainClass1 = Domain.Entities.Class1;

public class Class1Repository : IClass1Repository
{
	private readonly HttpClient httpClient;

	public Class1Repository(HttpClient httpClient)
	{
		this.httpClient = httpClient;
	}

	public async Task<DomainClass1> Add(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var newClass1 = From(class1);
		var result = await httpClient.PostAsJsonAsync("/products", newClass1, cancellationToken);
		result.EnsureSuccessStatusCode();
		newClass1 = await result.Content.ReadFromJsonAsync<Class1>(cancellationToken: cancellationToken);
		return From(newClass1);
	}

	public async Task<DomainClass1> Update(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var class1ToUpdate = From(class1);
		var result = await httpClient.PutAsJsonAsync("/products", class1ToUpdate, cancellationToken);
		result.EnsureSuccessStatusCode();
		class1ToUpdate = await result.Content.ReadFromJsonAsync<Class1>(cancellationToken: cancellationToken);
		return From(class1ToUpdate);
	}

	public async Task Delete(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var result = await httpClient.DeleteAsync($"/products/{class1.Id}", cancellationToken);
		result.EnsureSuccessStatusCode();
	}

	public async Task<DomainClass1?> GetById(int id, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var class1 = await httpClient.GetFromJsonAsync<Class1>($"/products/{id}", cancellationToken);
		return From(class1);
	}

	public async Task<bool> IsExist(string parameter, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var results = await httpClient.GetFromJsonAsync<IEnumerable<Class1>>($"/products?title={parameter}", cancellationToken);
		return results != null && results.Any();
	}

	public async Task<IList<DomainClass1>> GetAll(CancellationToken cancellationToken)
	{
		var results = await httpClient.GetFromJsonAsync<IEnumerable<Class1>>("/products", cancellationToken);
		return results?.Select(From).ToList() ?? new List<DomainClass1>();
	}

	private static DomainClass1 From(Class1? class1)
	{
		if (class1 is null)
		{
			return new DomainClass1()
			{
				Name = string.Empty
			};
		}

		return new DomainClass1()
		{
			Id = class1.Id,
			Name = class1.Title
		};
	}

	private static Class1 From(DomainClass1 class1)
	{
		return new Class1()
		{
			Id = class1.Id,
			Title = class1.Name
		};
	}
}