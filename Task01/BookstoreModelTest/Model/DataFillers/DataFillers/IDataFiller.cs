using BookstoreLibrary.Model;

namespace BookstoreLibrary.Filler
{
	public interface IDataFiller
	{
		DataContext Fill(DataContext dataContext);
	}
}
