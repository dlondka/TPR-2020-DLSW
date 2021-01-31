

using LayerViewModel;

namespace LayerView
{
    public class Details : LayerViewModel.IWindow
    {
        private DetailsWindow DetailsWindow;
        private static bool _open;

        public Details()
        {
            DetailsWindow = new DetailsWindow();
            _open = false;
        }

        public void Close()
        {
            DetailsWindow.Close();
            DetailsWindow = new DetailsWindow();
            _open = false;
        }

        public void SetViewModel(ViewModel viewModel)
        {
            DetailsWindow.DataContext = viewModel;
        }

        public void Show()
        {
            if (!_open)
            {
                DetailsWindow.Show();
                _open = true;
            }
        }
    }
}
