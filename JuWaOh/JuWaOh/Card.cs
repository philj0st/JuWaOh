using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuWaOh
{
    //implements INotifyPropertyChanged to get Bindings working for custom classes
    public class Card : INotifyPropertyChanged
    {
        private String _title;
        private String _principle;
        private Int16 _tribute;
        private String _imagePath;
        private String _description;
        private Int32 _atk;
        private Int32 _def;

        public event PropertyChangedEventHandler PropertyChanged;

        public String Title
        {
            get { return _title; }
            set { _title = value;
                OnPropertyChanged("Title");
            }
        }

        public String Principle
        {
            get { return _principle; }
            set
            {
                _principle = value;
                OnPropertyChanged("Principle");
            }
        }

        public Int16 Tribute
        {
            get { return _tribute; }
            set
            {
                _tribute = value;
                OnPropertyChanged("Tribute");
            }
        }

        public String ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
        public String Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        public Int32 Atk
        {
            get { return _atk; }
            set
            {
                _atk = value;
                OnPropertyChanged("Atk");
            }
        }
        public Int32 Def
        {
            get { return _def; }
            set
            {
                _def = value;
                OnPropertyChanged("Def");
            }
        }

        public Card() { }
        public Card(String title, String principle, String imagePath, String description, Int32 atk, Int32 def)
        {
            this.Title = title;
            this.Principle = principle;
            this.ImagePath = imagePath;
            this.Description = description;
            this.Atk = atk;
            this.Def = def;
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
