using Formel1.control;
using Formel1.model;
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

namespace Formel1
{
    /// <summary>
    /// This page is responsible for manipulating the results of a race. 
    /// </summary>
    public partial class ResultsPage : Page
    {
        private readonly Formel1Context _context = new Formel1Context();
        private CollectionViewSource seasonViewSource;
        private CollectionViewSource driversViewSource;
        public ResultsPage()
        {
            InitializeComponent();
            seasonViewSource = (CollectionViewSource)FindResource(nameof(seasonViewSource));
            driversViewSource = (CollectionViewSource)FindResource(nameof(driversViewSource));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated(); // TODO: Remove when going "live"
            _context.Season.Load();
            _context.Drivers.Load();
            seasonViewSource.Source = _context.Season.Local.ToObservableCollection();
            driversViewSource.Source = _context.Drivers.Local.ToObservableCollection();
        }

        // Adds the selected items from the drivers grid to the results table
        private void AddResult(object sender, RoutedEventArgs e)
        {
            foreach (Driver driver in driversGrid.SelectedItems)
            {
                Result result = new Result();
                result.Driver = driver;
                result.Position = ((Race)raceCombo.SelectedItem).Results.Count + 1;
                ((Race)raceCombo.SelectedItem).Results.Add(result);
                resultGrid.Items.Refresh();
            }

        }

        private void RemoveResult(object sender, RoutedEventArgs e)
        {
            Result result = (Result)resultGrid.SelectedItem;
            ((Race)raceCombo.SelectedItem).Results.Remove(result);
            raceCombo.Items.Refresh();
            recalculatePosition();
        }
        private void MoveUp(object sender, RoutedEventArgs e)
        {
            int idx = ((Race)raceCombo.SelectedItem).Results.IndexOf((Result)resultGrid.SelectedItem);
            if (idx > 0)
            {
                ((Race)raceCombo.SelectedItem).Results.Remove((Result)resultGrid.SelectedItem);
                ((Race)raceCombo.SelectedItem).Results.Insert(idx - 1, (Result)resultGrid.SelectedItem);
                resultGrid.Items.Refresh();
                recalculatePosition();
                resultGrid.SelectedIndex--;
            }
        }
        private void MoveDown(object sender, RoutedEventArgs e)
        {
            int idx = ((Race)raceCombo.SelectedItem).Results.IndexOf((Result)resultGrid.SelectedItem);
            if (idx < resultGrid.Items.Count - 1)
            {
                ((Race)raceCombo.SelectedItem).Results.Remove((Result)resultGrid.SelectedItem);
                ((Race)raceCombo.SelectedItem).Results.Insert(idx + 1, (Result)resultGrid.SelectedItem);
                resultGrid.Items.Refresh();
                recalculatePosition();
                resultGrid.SelectedIndex++;
            }
        }

        private void recalculatePosition()
        {
            foreach (Result r in ((Race)raceCombo.SelectedItem).Results)
            {
                r.Position = ((Race)raceCombo.SelectedItem).Results.IndexOf(r) + 1;
            }
            resultGrid.Items.Refresh();
        }

        private void Save_Changes(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            resultGrid.Items.Refresh();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _context.Dispose();
        }

        private void ShowHelp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Choose a season and race and then select the drivers from the right list and press the '<' button to add the drivers to the race.\n" +
                "Choose the buttons in the left table to remove the driver from the race or move the driver's ranking up and down.", "Help");
        }
    }


}
