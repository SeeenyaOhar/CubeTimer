using FringleTimer.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FringleTimer.ViewModels
{
    class LanguageChangeViewModel : ViewModel
    {
        private ObservableCollection<String> languages = new ObservableCollection<String>();
        public ObservableCollection<String> Languages
        {
            get
            {
                if (languages.Count == 0)
                {
                    languages = (ObservableCollection<String>)LocUtil.GetLanguagesNames();
                }
                return languages;
            }
        }
        private String sel_lang;
        public String SelectedLanguage
        {
            get => sel_lang;
            set
            {
                sel_lang = value;
                NotifyChanged(nameof(SelectedLanguage));
            }


        }

        private RelayCommand save_com;
        public RelayCommand Save {
            get
            {
                if (save_com == null)
                {
                    save_com = new RelayCommand((obj) =>
                    {
                        var infivechars = LocUtil.GetLanguageInFiveChars(SelectedLanguage);
                        Mediator.Notify("TickerStop");
                        LocUtil.SwitchLanguageAppAll(infivechars);
                    },
                    (obj) =>
                    {
                        return !String.IsNullOrWhiteSpace(SelectedLanguage);
                    });
                }
                return save_com;
            }
        }
    }
}
