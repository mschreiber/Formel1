using Formel1.control;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Formel1.model;

namespace Formel1
{
    /// <summary>
    /// The main window that handels the different pages
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Switch to the race and season admin page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAdminRaceSeasionPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new SeasonRaceAdminPage();
        }

        private void ShowResultsPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ResultsPage();
        }

        private void ShowTeamsDriverAdminPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new TeamsDriversAdminPage();
        }
    }
}
