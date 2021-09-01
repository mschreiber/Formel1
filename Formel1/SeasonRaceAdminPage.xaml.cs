using Formel1.control;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    /// Page for season and race administration
    /// </summary>
    public partial class SeasonRaceAdminPage : Page
    {
        private readonly Formel1Context _context = new Formel1Context();
        private CollectionViewSource seasonViewSource;
        public SeasonRaceAdminPage()
        {
            InitializeComponent();
            seasonViewSource = (CollectionViewSource)FindResource(nameof(seasonViewSource));

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Season.Load();
            seasonViewSource.Source = _context.Season.Local.ToObservableCollection();
        }

        private void Do_Save(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            seasonsDataGrid.Items.Refresh();
            racesDataGrid.Items.Refresh();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _context.Dispose();
        }
    }
}
