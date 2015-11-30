using System;
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
            //instantiate before drawing the window because of Bindings
            this.card = new Card();

            InitializeComponent();

            //root scope for bindings
            this.DataContext = this.card;
            elementComboBox.ItemsSource = createOptionsFromSettings();
            //set a default selection
            elementComboBox.SelectedIndex = 0;
        }

        private Card card;

        private List<ComboBoxItem> createOptionsFromSettings()
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
                //update the Card.imgSource
                this.card.ImagePath = fileDialog.FileName;
            }
        }
    }
}
