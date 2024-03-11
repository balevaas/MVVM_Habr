using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MVVM_Habr.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private int _clicks;
        public int Clicks
        {
            get { return _clicks; }
            set { 
                _clicks = value;
                OnPropertyChanged();
            }
        }

        //public MainViewModel()
        //{
        //    Task.Factory.StartNew(() =>
        //    {
        //        while (true)
        //        {
        //            Task.Delay(1000).Wait();
        //            Clicks++;
        //        }
        //    });
        //}

        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand((obj) => {
                    Clicks++;
                },(obj) => Clicks < 10);
            }
        }
    }
}
