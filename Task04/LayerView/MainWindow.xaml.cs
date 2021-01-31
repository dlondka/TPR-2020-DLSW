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
            ViewModel viewModel = (ViewModel)DataContext;
            //viewModel.AddWindow = new Lazy<IWindow>(() new => Add());
        }
    }
}
