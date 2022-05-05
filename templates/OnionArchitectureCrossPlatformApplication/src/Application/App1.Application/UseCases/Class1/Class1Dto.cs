namespace App1.Application.UseCases.Class1;

public class Class1Dto
{
	public int Id { get; set; }

	public string CreatedBy { get; set; } = string.Empty;

	public DateTime CreatedOn { get; set; }

	public string? ModifiedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }
	public string Name { get; set; } = null!;
}