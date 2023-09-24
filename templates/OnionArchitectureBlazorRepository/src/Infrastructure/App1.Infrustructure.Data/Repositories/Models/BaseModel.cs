namespace App1.Infrastructure.Data.Repositories.Models;

public abstract class BaseModel
{
	public int Id { get; set; }
	public DateTime CreatedOn { get; set; }
	public DateTime? ModifiedOn { get; set; }
}