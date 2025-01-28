namespace App1.Common.Presentation.Endpoints;

using Microsoft.AspNetCore.Routing;

public interface IEndpoint
{
	void MapEndpoint(IEndpointRouteBuilder app);
}