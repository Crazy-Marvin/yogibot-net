using Avalonia.Controls.ApplicationLifetimes;
using Dascia.YogiClient.API;
using Dascia.YogiClient.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reactive;

namespace Dascia.YogiClient.ViewModels
{
  public class MainWindowViewModel : ViewModelBase
  {
    /// <summary>
    /// The yogi api client
    /// </summary>
    private readonly Yogi _yogi;

    /// <summary>
    /// The current saying received from yogi
    /// </summary>
    private Saying? _saying;

    /// <summary>
    /// The selected languages
    /// </summary>
    private KeyValuePair<string, string> _selectedLanguages;

    /// <summary>
    /// The languages
    /// </summary>
    private Dictionary<string, string> _languages;

    /// <summary>
    /// Gets or sets the saying.
    /// </summary>
    /// <value>The saying.</value>
    public Saying? Saying
    {
      get => _saying;
      set => this.RaiseAndSetIfChanged(ref _saying, value);
    }

    /// <summary>
    /// Gets or sets the selected language.
    /// </summary>
    /// <value>The selected language.</value>
    public KeyValuePair<string, string> SelectedLanguage
    {
      get { return _selectedLanguages; }
      set { _selectedLanguages = this.RaiseAndSetIfChanged(ref _selectedLanguages, value); }
    }


    /// <summary>
    /// Gets or sets the languages.
    /// </summary>
    /// <value>The languages.</value>
    public Dictionary<string, string> Languages 
    { 
      get => _languages;
      set => this.RaiseAndSetIfChanged(ref _languages, value);
    }

    // Commands
    public ReactiveCommand<Unit, Unit> RequestSayingCommand { get; set; }
    public ReactiveCommand<Unit, Unit> ShowLegalCommand { get; set; }
    public ReactiveCommand<Unit, Unit> ShowInfoCommand { get; set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    public MainWindowViewModel()
    {
      _yogi = new Yogi();
      RequestSayingCommand = ReactiveCommand.Create(RequestSaying);
      ShowLegalCommand = ReactiveCommand.Create(ShowLegal);
      ShowInfoCommand = ReactiveCommand.Create(ShowInfo);
      Languages = BuildLanguages();
      SelectedLanguage = new KeyValuePair<string, string>("English", "en");
    }

    /// <summary>
    /// Shows the information.
    /// </summary>
    private void ShowInfo()
    {
      if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      {
        new AboutWindow().ShowDialog(desktop.MainWindow);
      }
    }

    /// <summary>
    /// Shows the legal.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void ShowLegal()
    {
      if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      {
        new LegalWindow().ShowDialog(desktop.MainWindow);
      }
    }

    /// <summary>
    /// Requests the saying.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private async void RequestSaying()
    {
      string language = SelectedLanguage.Value ?? CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
      IList<Saying> sayingCollection = await _yogi.GetRandomSaying(language, 1);
      Saying = sayingCollection.SingleOrDefault();
    }

    /// <summary>
    /// Builds the languages.
    /// </summary>
    /// <returns>System.Nullable&lt;Dictionary&lt;System.String, System.String&gt;&gt;.</returns>
    /// <exception cref="NotImplementedException"></exception>
    private Dictionary<string, string> BuildLanguages()
    {
      return new Dictionary<string, string>
      {
        {"English","en"},
        {"German","de"},
        {"Abkhazian","ab"},
        {"Afar","aa"},
        {"Afrikaans","af"},
        {"Akan","ak"},
        {"Albanian","sq"},
        {"Amharic","am"},
        {"Arabic","ar"},
        {"Aragonese","an"},
        {"Armenian","hy"},
        {"Assamese","as"},
        {"Avaric","av"},
        {"Avestan","ae"},
        {"Aymara","ay"},
        {"Azerbaijani","az"},
        {"Bambara","bm"},
        {"Bashkir","ba"},
        {"Basque","eu"},
        {"Belarusian","be"},
        {"Bengali","bn"},
        {"Bislama","bi"},
        {"Bosnian","bs"},
        {"Breton","br"},
        {"Bulgarian","bg"},
        {"Burmese","my"},
        {"Catalan, Valencian","ca"},
        {"Chamorro","ch"},
        {"Chechen","ce"},
        {"Chichewa, Chewa, Nyanja","ny"},
        {"Chinese","zh"},
        {"Chuvash","cv"},
        {"Cornish","kw"},
        {"Corsican","co"},
        {"Cree","cr"},
        {"Croatian","hr"},
        {"Czech","cs"},
        {"Danish","da"},
        {"Divehi, Dhivehi, Maldivian","dv"},
        {"Dutch, Flemish","nl"},
        {"Dzongkha","dz"},
        {"Esperanto","eo"},
        {"Estonian","et"},
        {"Ewe","ee"},
        {"Faroese","fo"},
        {"Fijian","fj"},
        {"Finnish","fi"},
        {"French","fr"},
        {"Fulah","ff"},
        {"Galician","gl"},
        {"Georgian","ka"},
        {"Greek, Modern (1453–)","el"},
        {"Guarani","gn"},
        {"Gujarati","gu"},
        {"Haitian, Haitian Creole","ht"},
        {"Hausa","ha"},
        {"Hebrew","he"},
        {"Herero","hz"},
        {"Hindi","hi"},
        {"Hiri Motu","ho"},
        {"Hungarian","hu"},
        {"Interlingua (International Auxiliary Language Association)","ia"},
        {"Indonesian","id"},
        {"Interlingue, Occidental","ie"},
        {"Irish","ga"},
        {"Igbo","ig"},
        {"Inupiaq","ik"},
        {"Ido","io"},
        {"Icelandic","is"},
        {"Italian","it"},
        {"Inuktitut","iu"},
        {"Japanese","ja"},
        {"Javanese","jv"},
        {"Kalaallisut, Greenlandic","kl"},
        {"Kannada","kn"},
        {"Kanuri","kr"},
        {"Kashmiri","ks"},
        {"Kazakh","kk"},
        {"Central Khmer","km"},
        {"Kikuyu, Gikuyu","ki"},
        {"Kinyarwanda","rw"},
        {"Kirghiz, Kyrgyz","ky"},
        {"Komi","kv"},
        {"Kongo","kg"},
        {"Korean","ko"},
        {"Kurdish","ku"},
        {"Kuanyama, Kwanyama","kj"},
        {"Latin","la"},
        {"Luxembourgish, Letzeburgesch","lb"},
        {"Ganda","lg"},
        {"Limburgan, Limburger, Limburgish","li"},
        {"Lingala","ln"},
        {"Lao","lo"},
        {"Lithuanian","lt"},
        {"Luba-Katanga","lu"},
        {"Latvian","lv"},
        {"Manx","gv"},
        {"Macedonian","mk"},
        {"Malagasy","mg"},
        {"Malay","ms"},
        {"Malayalam","ml"},
        {"Maltese","mt"},
        {"Maori","mi"},
        {"Marathi","mr"},
        {"Marshallese","mh"},
        {"Mongolian","mn"},
        {"Nauru","na"},
        {"Navajo, Navaho","nv"},
        {"North Ndebele","nd"},
        {"Nepali","ne"},
        {"Ndonga","ng"},
        {"Norwegian Bokmål","nb"},
        {"Norwegian Nynorsk","nn"},
        {"Norwegian","no"},
        {"Sichuan Yi, Nuosu","ii"},
        {"South Ndebele","nr"},
        {"Occitan","oc"},
        {"Ojibwa","oj"},
        {"Oromo","om"},
        {"Oriya","or"},
        {"Ossetian, Ossetic","os"},
        {"Punjabi, Panjabi","pa"},
        {"Pali","pi"},
        {"Persian","fa"},
        {"Polish","pl"},
        {"Pashto, Pushto","ps"},
        {"Portuguese","pt"},
        {"Quechua","qu"},
        {"Romansh","rm"},
        {"Rundi","rn"},
        {"Romanian, Moldavian, Moldovan","ro"},
        {"Russian","ru"},
        {"Sanskrit","sa"},
        {"Sardinian","sc"},
        {"Sindhi","sd"},
        {"Northern Sami","se"},
        {"Samoan","sm"},
        {"Sango","sg"},
        {"Serbian","sr"},
        {"Gaelic, Scottish Gaelic","gd"},
        {"Shona","sn"},
        {"Sinhala, Sinhalese","si"},
        {"Slovak","sk"},
        {"Slovenian","sl"},
        {"Somali","so"},
        {"Southern Sotho","st"},
        {"Spanish, Castilian","es"},
        {"Sundanese","su"},
        {"Swahili","sw"},
        {"Swati","ss"},
        {"Swedish","sv"},
        {"Tamil","ta"},
        {"Telugu","te"},
        {"Tajik","tg"},
        {"Thai","th"},
        {"Tigrinya","ti"},
        {"Tibetan","bo"},
        {"Turkmen","tk"},
        {"Tagalog","tl"},
        {"Tswana","tn"},
        {"Tonga (Tonga Islands)","to"},
        {"Turkish","tr"},
        {"Tsonga","ts"},
        {"Tatar","tt"},
        {"Twi","tw"},
        {"Tahitian","ty"},
        {"Uighur, Uyghur","ug"},
        {"Ukrainian","uk"},
        {"Urdu","ur"},
        {"Uzbek","uz"},
        {"Venda","ve"},
        {"Vietnamese","vi"},
        {"Volapük","vo"},
        {"Walloon","wa"},
        {"Welsh","cy"},
        {"Wolof","wo"},
        {"Western Frisian","fy"},
        {"Xhosa","xh"},
        {"Yiddish","yi"},
        {"Yoruba","yo"},
        {"Zhuang, Chuang","za"},
        {"Zulu","zu"}
      };
    }
  }
}
