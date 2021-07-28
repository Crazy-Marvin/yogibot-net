using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Dascia.YogiClient.Views
{
  public partial class LegalWindow : Window
  {
    public LegalWindow()
    {
      InitializeComponent();
#if DEBUG
      this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
