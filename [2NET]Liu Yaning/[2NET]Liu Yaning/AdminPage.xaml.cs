using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _2NET_Liu_Yaning
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        Model1Container context;
        public AdminPage()
        {
            InitializeComponent();
            context = new Model1Container();
            CollapsedAll();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).GoBack();
        }
        private void CollapsedAll()
        {
            Dishes.Visibility = Visibility.Collapsed;
            Waiters.Visibility = Visibility.Collapsed;
            Map.Visibility = Visibility.Collapsed;
            All.Visibility = Visibility.Collapsed;
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            CollapsedAll();
            Dishes.Visibility = Visibility.Visible;
            getDishSource();
;
        }
        public void getDishSource() 
        {
            this.dishesLV.ItemsSource = null;
            List<Dish> dishList = (from s in context.DishSet
                                   select s).ToList<Dish>();
            this.dishesLV.ItemsSource = dishList;
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CollapsedAll();
            Waiters.Visibility = Visibility.Visible;

        }
        public void getWaiterSource()
        {
            this.waiterLV.ItemsSource = null;
            List<Waiter> waiters = (from s in context.WaiterSet
                                   select s).ToList<Waiter>();
            this.waiterLV.ItemsSource = waiters;
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            CollapsedAll();
            Map.Visibility = Visibility.Visible;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            CollapsedAll();
            All.Visibility = Visibility.Visible;
        }

        private void dishesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dish emp = dishesLV.SelectedItem as Dish;
            if (emp != null && emp is Dish)
            {
                new ManageDish(this,emp).ShowDialog();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dish dish = new Dish();
            new ManageDish(this, dish).ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Waiter waiter = new Waiter();
            new ManageWaiter(this, waiter).ShowDialog();
        }
    }
}
