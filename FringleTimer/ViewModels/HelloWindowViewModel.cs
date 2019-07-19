using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FringleTimer.Tools;
using FringleTimer.Views;
namespace FringleTimer.ViewModels
{
    class HelloWindowViewModel : FringleTimer.Tools.ViewModel
    {
        Page _current;
        
        
        public HelloWindowViewModel()
        {
           CurrentPage = new WelcomePage();
            Mediator.Subscribe("GoLanguageChange", GoLanguageChange);
        }

        public RelayCommand GoBack
        {
            get
            {
                var _currenttype = _current.GetType().ToString().Split('.')[2];
                if (_currenttype == nameof(LanguageChange))
                {
                    return new RelayCommand((obj) => CurrentPage = new WelcomePage(), (obj)=>true);
                }
                return null;
            }
           
        }
        Boolean backbuttonvisibility;
        public Visibility BackButtonVisibility
        {
            get
            {
                var _currenttype = _current.GetType().ToString().Split('.')[2];
                if (_currenttype == nameof(LanguageChange))
                {
                    NotifyChanged(nameof(GoBack));
                    return Visibility.Visible;
                }
                else return Visibility.Hidden;
            }
        }
        public Page CurrentPage {
            get
            {
                return _current;
            }
            set
            {
                this._current = value;
                WidthDynamic = value.Width + 20;
                HeightDynamic = value.Height + 20;
                NotifyChanged(nameof(CurrentPage));
                NotifyChanged(nameof(BackButtonVisibility));
            }
        }
        private Double _width = 800;
        public Double WidthDynamic {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                NotifyChanged(nameof(WidthDynamic));
            }
        }
        private Double _height = 600;
        public Double HeightDynamic
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                NotifyChanged(nameof(HeightDynamic));
            }
        }

        public void GoLanguageChange(object state)
        {
            var page = new LanguageChange();
            WidthDynamic = page.Width + 20;
            HeightDynamic = page.Height + 20;
            CurrentPage = page;
        }
        public void GoWelcomePage(object state)
        {
            var page = new WelcomePage();
            WidthDynamic = page.Width + 20;
            HeightDynamic = page.Height + 20;
            CurrentPage = page;
        }

    }
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> execute;
        Func<object, Boolean> canexecute;
        Boolean canexecute_b;
        public bool CanExecute(object parameter)
        {
            var temp = canexecute(parameter);
            if (canexecute_b != temp)
            {
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
            canexecute_b = temp;
            return canexecute_b;
        }

        public void Execute(object parameter)
        {
             execute(parameter);
        }
        public RelayCommand(Action<object> execute, Func<object, Boolean> canexecute)
        {
            this.execute = execute;
            this.canexecute = canexecute;
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
