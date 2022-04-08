using CustomerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CustomerApp
{
    public partial class MainPage : UserControl
    {
        private DataManager manager = new DataManager();

        public MainPage()
        {
            InitializeComponent();
            myDataGrid.ItemsSource = manager.Customers;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("The name cannot be empty.");
                return;
            }
            UpdateData();
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            checkBox.IsChecked = false;
            textBox.Text = "";
            UpdateData();
        }

        private void UpdateData()
        {
            manager.UpdateData(textBox.Text, checkBox.IsChecked);
        }
    }
}
