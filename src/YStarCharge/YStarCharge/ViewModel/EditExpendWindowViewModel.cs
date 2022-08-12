using System.ComponentModel;
using System.Windows.Input;
using YStarCharge.Model;

namespace YStarCharge.ViewModel
{
    public sealed class EditExpendWindowViewModel: NotifyPropertyChanged
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
                OnPropertyChanged(this,"Title");
            }
        }

        public Expend Expend { get; set; } = new Expend();

    }
}
