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
    /// The page that handels the administration of teams and drivers. 
    /// For now the teams can have more than 2 drivers. This is a TODO for later to prefent
    /// adding more than 2 driver per Team
    /// </summary>
    public partial class TeamsDriversAdminPage : Page
    {
        private readonly Formel1Context _context = new Formel1Context();
        private CollectionViewSource teamsViewSource;
        public TeamsDriversAdminPage()
        {
            InitializeComponent();
            teamsViewSource = (CollectionViewSource)FindResource(nameof(teamsViewSource));

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Teams.Load();
            teamsViewSource.Source = _context.Teams.Local.ToObservableCollection();
        }

        private void Do_Save(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            teamsDataGrid.Items.Refresh();
            driversDataGrid.Items.Refresh();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _context.Dispose();
        }
    }
}
