using ReactiveUI;
using System;
using System.Diagnostics;
using System.Reactive;
using System.Runtime.InteropServices;

namespace Dascia.YogiClient.ViewModels
{
  public class AboutWindowViewModel : ViewModelBase
  {
    private const string DonateUri = "https://poopjournal.rocks/blog/donate/";

    // Commands
    public ReactiveCommand<Unit, Unit> DonateCommand { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AboutWindowViewModel"/> class.
    /// </summary>
    public AboutWindowViewModel()
    {
      DonateCommand = ReactiveCommand.Create(Donate);
    }

    /// <summary>
    /// Donates this instance.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void Donate()
    {
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        Process.Start(new ProcessStartInfo("cmd", $"/c start {DonateUri}") { CreateNoWindow = true });
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
      {
        Process.Start("xdg-open", DonateUri);
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
      {
        Process.Start("open", DonateUri);
      }
    }
  }
}
