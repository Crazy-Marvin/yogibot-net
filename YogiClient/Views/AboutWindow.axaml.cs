using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Dascia.YogiClient.ViewModels;

namespace Dascia.YogiClient.Views
{
  public partial class AboutWindow : Window
  {
    public AboutWindow()
    {
      InitializeComponent();
#if DEBUG
      this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
      DataContext = new AboutWindowViewModel();
    }
  }
}
