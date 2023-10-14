namespace App1.Application.UseCases.Class1.Models;

using Domain.Entities;

public class Class1Dto
{
	public int Id { get; set; }

	public DateTime CreatedOn { get; set; }

	public DateTime? ModifiedOn { get; set; }
	public required string Name { get; set; }

	public static Class1Dto From(Class1 class1)
	{
		return new Class1Dto
		{
			Id = class1.Id,
			Name = class1.Name,
			CreatedOn = class1.CreatedOn,
			ModifiedOn = class1.ModifiedOn
		};
	}
}