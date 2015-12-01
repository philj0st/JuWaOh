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
        private String _cardTypeImgPath;
        private String _title;
        private String _elementImgPath;
        private Int16 _level;
        private String _imagePath;
        private String _description;
        private Int32 _atk;
        private Int32 _def;

        public event PropertyChangedEventHandler PropertyChanged;

        public String CardTypeImgPath
        {
            get { return _cardTypeImgPath; }
            set
            {
                _cardTypeImgPath = value;
                OnPropertyChanged("CardTypeImgPath");
            }
        }

        public String Title
        {
            get { return _title; }
            set { _title = value;
                OnPropertyChanged("Title");
            }
        }

        public String ElementImgPath
        {
            get { return _elementImgPath; }
            set
            {
                _elementImgPath = value;
                OnPropertyChanged("ElementImgPath");
            }
        }

        public Int16 Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");
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
        public Card(String cardType, String title, String principle, String imagePath, String description, Int32 atk, Int32 def)
        {
            this.CardTypeImgPath = cardType;
            this.Title = title;
            this.ElementImgPath = principle;
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
