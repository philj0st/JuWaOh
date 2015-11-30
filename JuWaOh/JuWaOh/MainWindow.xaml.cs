using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
            elementComboBox.ItemsSource = createOptionsFromSettings();
            //set a default selection
            elementComboBox.SelectedIndex = 0;
        }

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
    }
}
