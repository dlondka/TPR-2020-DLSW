using LayerViewModel;

namespace LayerView
{
    class Add : LayerViewModel.IWindow
    {
        private AddWindow AddWindow;
        private static bool _open;

        public Add()
        {
            AddWindow = new AddWindow();
            _open = false;
        }

        public void Close()
        {
            AddWindow.Close();
            AddWindow = new AddWindow();
            _open = false;
        }

        public void SetViewModel(ViewModel viewModel)
        {
            AddWindow.DataContext = viewModel;
        }

        public void Show()
        {
            if (!_open)
            {
                AddWindow.Show();
                _open = true;
            }
        }
    }
}
