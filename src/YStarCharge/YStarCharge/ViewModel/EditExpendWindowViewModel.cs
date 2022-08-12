using System.ComponentModel;
using System.Windows.Input;
using YStarCharge.Model;

namespace YStarCharge.ViewModel
{
    public sealed class EditExpendWindowViewModel: INotifyPropertyChanged
    {

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if(title == value)
                {
                    return;
                }
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public Expend Expend { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;



        
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
