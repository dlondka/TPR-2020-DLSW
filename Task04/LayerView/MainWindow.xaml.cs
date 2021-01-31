using System;
using System.Windows;
using LayerViewModel;


namespace LayerView
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            LayerViewModel.ViewModel viewModel = (LayerViewModel.ViewModel)DataContext;
            viewModel.AddWindow = new Lazy<LayerViewModel.IWindow>(() => new Add());
            viewModel.DetailsWindow = new Lazy<LayerViewModel.IWindow>(() => new Details());
        }
    }
}
