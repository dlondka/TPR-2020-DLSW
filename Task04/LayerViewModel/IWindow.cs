
namespace LayerViewModel
{
    public interface IWindow
    {
        void SetViewModel(ViewModel viewModel);
        void Show();

        void Close();
    }
}
