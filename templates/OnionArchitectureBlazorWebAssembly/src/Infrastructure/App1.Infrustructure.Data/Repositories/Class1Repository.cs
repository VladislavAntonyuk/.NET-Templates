namespace App1.Infrastructure.Data.Repositories;

using System.Net.Http.Json;
using App1.Application.Interfaces.Repositories;
using AutoMapper;
using Models;
using DomainClass1 = Domain.Entities.Class1;

public class Class1Repository : IClass1Repository
{
	private readonly HttpClient httpClient;
	private readonly IMapper mapper;

	public Class1Repository(HttpClient httpClient, IMapper mapper)
	{
		this.httpClient = httpClient;
		this.mapper = mapper;
	}

	public async Task<DomainClass1> Add(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var newClass1 = mapper.Map<Class1>(class1);
		var result = await httpClient.PostAsJsonAsync("/products", newClass1, cancellationToken);
		result.EnsureSuccessStatusCode();
		newClass1 = await result.Content.ReadFromJsonAsync<Class1>(cancellationToken: cancellationToken);
		return mapper.Map<DomainClass1>(newClass1);
	}

	public async Task<DomainClass1> Update(DomainClass1 class1, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var class1ToUpdate = mapper.Map<Class1>(class1);
		var result = await httpClient.PutAsJsonAsync("/products", class1ToUpdate, cancellationToken);
		result.EnsureSuccessStatusCode();
		class1ToUpdate = await result.Content.ReadFromJsonAsync<Class1>(cancellationToken: cancellationToken);
		return mapper.Map<DomainClass1>(class1ToUpdate);
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
		return mapper.Map<DomainClass1>(class1);
	}

	public async Task<bool> IsExist(string parameter, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var results = await httpClient.GetFromJsonAsync<IEnumerable<Class1>>($"/products?title={parameter}", cancellationToken);
		return results != null && results.Any();
	}

	public async Task<IEnumerable<DomainClass1>> GetAll(CancellationToken cancellationToken)
	{
		var results = await httpClient.GetFromJsonAsync<IEnumerable<Class1>>("/products", cancellationToken);
		return mapper.Map<IEnumerable<DomainClass1>>(results);
	}

	public async Task<DomainClass1?> GetByName(string name, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var results = await httpClient.GetFromJsonAsync<IEnumerable<Class1>>($"/products?title=*{name}*", cancellationToken);
		return mapper.Map<DomainClass1>(results?.SingleOrDefault());
	}
}