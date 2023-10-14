namespace App1.Infrastructure.Data.Repositories;

using System.Net.Http.Json;
using Application.Interfaces;
using Application.UseCases.Class1.Models;
using Domain.Entities;

public class Class1Repository(HttpClient httpClient) : IClass1Repository
{
	public async Task<Class1?> Add(Class1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var newClass1 = Class1Dto.From(class1);
		var result = await httpClient.PostAsJsonAsync("/products", newClass1, cancellationToken);
		result.EnsureSuccessStatusCode();
		newClass1 = await result.Content.ReadFromJsonAsync<Class1Dto>(cancellationToken: cancellationToken);
		return Class1Dto.ToDomain(newClass1);
	}

	public async Task<bool> Update(Class1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var class1ToUpdate = Class1Dto.From(class1);
		var result = await httpClient.PutAsJsonAsync("/products", class1ToUpdate, cancellationToken);
		return result.IsSuccessStatusCode;
	}

	public async Task Delete(Class1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var result = await httpClient.DeleteAsync($"/products/{class1.Id}", cancellationToken);
		result.EnsureSuccessStatusCode();
	}

	public async Task<Class1?> GetById(int id, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var class1 = await httpClient.GetFromJsonAsync<Class1Dto>($"/products/{id}", cancellationToken);
		return Class1Dto.ToDomain(class1);
	}

	public async Task<bool> IsExist(string parameter, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var results = await httpClient.GetFromJsonAsync<IEnumerable<Class1Dto>>($"/products?title={parameter}", cancellationToken);
		return results != null && results.Any();
	}

	public async Task<IEnumerable<Class1>> GetAll(CancellationToken cancellationToken)
	{
		var results = await httpClient.GetFromJsonAsync<IEnumerable<Class1Dto>>("/products", cancellationToken);
		return results?.Select(x => Class1Dto.ToDomain(x)!) ?? Enumerable.Empty<Class1>();
	}

	public async Task<Class1?> GetByName(string name, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var results = await httpClient.GetFromJsonAsync<IEnumerable<Class1Dto>>($"/products?title=*{name}*", cancellationToken);
		return Class1Dto.ToDomain(results?.FirstOrDefault());
	}
}