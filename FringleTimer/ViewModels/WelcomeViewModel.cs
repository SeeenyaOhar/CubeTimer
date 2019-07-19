using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using FringleTimer.Model;
using FringleTimer.Tools;
namespace FringleTimer.ViewModels
{
    class WelcomeViewModel : ViewModel
    {
        private ResourceDictionary _langpath;
        public ResourceDictionary LanguagePath {
            get
            {
                return _langpath;

            }
            private set
            {
                _langpath = value;
               
                NotifyChanged(nameof(LanguagePath));
            }
        }
        private RelayCommand _next;
        public RelayCommand NextPage
        {
            get
            {
                if (_next == null)
                    _next = new RelayCommand((obj) => Mediator.Notify("GoLanguageChange"), (obj) => true);

                return _next;
            }
            
        }
        private static Ticker _ticker;
        public WelcomeViewModel()
        {
            if (_ticker != null && !_ticker.IsRunning)
            {
                _ticker = new Ticker(3000);
                GC.KeepAlive(_ticker);

                _ticker.Start(HandlerTick);
            }
            
            Mediator.Subscribe("TickerStop", TickerStop);
            
            
                
            
        }
        private static Int32 CurrentLanguageId = 0;
        private static String LanguagesPath =  Environment.CurrentDirectory + "\\loc\\HelloWindow";
        private static void HandlerTick()
        {


            var files = Directory.GetFiles(LanguagesPath);

            if (CurrentLanguageId < files.Length)
            {

                var temp = files[CurrentLanguageId];
                var splitpath = temp.Split('\\');
                var file = splitpath[splitpath.Length - 1];
                var splitfile = file.Split('.');
                var infivechars = splitfile[1]; // HelloWindow. en-US .xaml
                LocUtil.SwitchLanguageAppAll(infivechars);
                
                CurrentLanguageId++;
            }
            else CurrentLanguageId = 0;


        }
        private static void TickerStop(object state)
        {
            _ticker.Stop();
        }
    }
}
