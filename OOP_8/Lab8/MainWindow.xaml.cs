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
using Lab8.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Lab8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AirportDB db;
        public MainWindow()
        {
            InitializeComponent();

            db = new AirportDB();
            db.Planes.Load(); // загружаем данные
            PlanesGrid.ItemsSource = db.Planes.Local.ToBindingList(); // устанавливаем привязку к кэшу
            //db.Planes.
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlanesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < PlanesGrid.SelectedItems.Count; i++)
                {
                    Plane Plane = PlanesGrid.SelectedItems[i] as Plane;
                    if (Plane != null)
                    {
                        db.Planes.Remove(Plane);
                    }
                }
            }
            db.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            IQueryable<Plane> res = db.Planes
                .Where( entity => entity.Year == 2005
            );

            MessageBox.Show(res.ToString());
            
            /*
            Entity Framework -это ORM, т.е.взаимодейтсвие с бд ведется через объекты.
            LINQ TO SQL - механизм, для извлечения данных из бд
            */
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Database.ExecuteSqlCommand(@"UPDATE Planes SET Year = Year + 1 WHERE Id = 1");
                    db.Planes.Add(new Plane
                    {
                        Id = 2,
                        Title = "Прототип" + 1,
                        Company = "Incognita",
                        Year = 2018
                    });
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
