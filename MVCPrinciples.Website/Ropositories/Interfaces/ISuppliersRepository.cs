using MVCPrinciples.Website.Data.Entities;

namespace MVCPrinciples.Website.Ropositories.Interfaces
{
	public interface ISuppliersRepository
	{
		IEnumerable<Supplier> GetAll();
	}
}
