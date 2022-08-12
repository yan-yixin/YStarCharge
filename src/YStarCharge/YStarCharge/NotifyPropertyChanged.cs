using System.ComponentModel;

namespace YStarCharge
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(object sender ,string propertyName)
        {
            PropertyChanged?.Invoke(sender,new PropertyChangedEventArgs(propertyName));
        }
    }
}
