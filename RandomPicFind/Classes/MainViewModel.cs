using System.ComponentModel;

namespace RandomPicFind.Classes
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string imageUrl = "https://c.tenor.com/4k4PssZTZTAAAAAC/finding-nemo-darla.gif";
        private bool webmBtnEnable = false;

        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                imageUrl = value;
                RaisePropertyChanged("ImageUrl");
            }
        }

        public bool WebmBtnEnable
        {
            get { return webmBtnEnable; }
            set
            {
                webmBtnEnable = value;
                RaisePropertyChanged("WebmBtnEnable");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
