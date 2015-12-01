using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml;

namespace JuWaOh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {


            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            //instantiate the main card
            this.card = new Card();

            //root scope for bindings
            this.DataContext = this.card;
            //add options to dropdowns
            elementComboBox.ItemsSource = LoadElementOptionsFromSettings();
            cardTypeComboBox.ItemsSource = LoadCardTypeOptionsFromSettings();
            //set default selections
            elementComboBox.SelectedIndex = 0;
            cardTypeComboBox.SelectedIndex = 0;
        }

        //what is better? IEnumerable or List<ComboBoxItem>
        private IEnumerable LoadCardTypeOptionsFromSettings()
        {
            List<ComboBoxItem> options = new List<ComboBoxItem>();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(Properties.Settings.Default.cardtypes);
            XmlNodeList cardtypes = xml.SelectNodes("cardtypes/cardtype");
            //create ComboBoxItems for every <cardtype> node
            foreach (XmlNode cardtype in cardtypes)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = cardtype.InnerText;
                item.Tag = cardtype.Attributes["imgPath"];
                options.Add(item);
            }
            return options;
        }

        private Card card;

        //creates ComboBoxItem List from XmlNodes in Settings
        private List<ComboBoxItem> LoadElementOptionsFromSettings()
        {
            List<ComboBoxItem> options = new List<ComboBoxItem>();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(Properties.Settings.Default.elements);
            XmlNodeList elements = xml.SelectNodes("elements/element");
            //create ComboBoxItems for every <element> node
            foreach (XmlNode element in elements)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = element.InnerText;
                item.Tag = element.Attributes["imgPath"];
                options.Add(item);
            }
            return options;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void loadPictureBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //update the Card.imgSource with the filepath provided by the fileDialog
                this.card.ImagePath = fileDialog.FileName;
            }
        }

        //The Card Background gets updated using the image path stored in the ComboBoxItem's Tag property.
        private void cardTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //no e.AddedItems[0].Tag.Value in C#?
            ComboBoxItem senderItem = e.AddedItems[0] as ComboBoxItem;
            XmlAttribute senderItemAttribute = senderItem.Tag as XmlAttribute;
            card.CardTypeImgPath = senderItemAttribute.Value;
        }

        private void elementComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem senderItem = e.AddedItems[0] as ComboBoxItem;
            XmlAttribute senderItemAttribute = senderItem.Tag as XmlAttribute;
            card.ElementImgPath = senderItemAttribute.Value;
        }
    }
}
