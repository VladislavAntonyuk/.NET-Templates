using App1.ApiService.Infrastructure.Database;
using App1.ApiService.Infrastructure.Results;

namespace App1.ApiService.Application.Module1.Create;

internal sealed class CreateModule1sHandler(Module1sDbContext context)
{
	public async Task<Result<CreateModule1.ResponseContent>> Handle(CreateModule1.Request request, CancellationToken cancellationToken = default)
	{
		var model = new Module1()
		{
			Id = Guid.CreateVersion7(),
			Prop1 = request.Prop1,
		};

		context.Module1s.Add(model);
		await context.SaveChangesAsync(cancellationToken);
		return new CreateModule1.ResponseContent(model.Id, model.Prop1);
	}
}