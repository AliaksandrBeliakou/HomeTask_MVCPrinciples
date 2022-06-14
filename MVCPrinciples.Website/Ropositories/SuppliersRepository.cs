using MVCPrinciples.Website.Data;
using MVCPrinciples.Website.Data.Entities;
using MVCPrinciples.Website.Ropositories.Interfaces;

namespace MVCPrinciples.Website.Ropositories
{
	public class SuppliersRepository : ISuppliersRepository
	{
		private readonly NorthwindContext context;
		public SuppliersRepository(NorthwindContext context)
		{
			this.context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<Supplier> GetAll()
		{
			return context.Suppliers;
		}
	}
}
