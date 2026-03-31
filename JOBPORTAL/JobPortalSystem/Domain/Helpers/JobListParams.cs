using Domain.Helpers;

namespace Domain.Helpers
{
	public class JobListParams: PaginationParams
	{

		public string JobTitle { get; set; } = null!;

	}
}
