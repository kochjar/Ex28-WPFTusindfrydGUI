using Ex28_WPFTusindfrydGUI.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ex28_WPFTusindfrydGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvm;
        }
        public void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mvm.UpdateCurrentEmployee();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true && openFileDialog.CheckPathExists == true)
            {
                tbImagePath.Text = openFileDialog.FileName;
            }
        }

        private void NewEmployee_Click(object sender, RoutedEventArgs e)
        {
            mvm.AddEmployee();
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            mvm.DeleteCurrentEmployee();
        }
    }


}
