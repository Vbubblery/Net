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
using System.Windows.Shapes;

namespace _2NET_Liu_Yaning
{
    /// <summary>
    /// ManageDish.xaml 的交互逻辑
    /// </summary>
    public partial class ManageDish : Window
    {
        Model1Container context;
        Dish _dish;
        AdminPage _admin;
        public ManageDish(AdminPage admin,Dish dish)
        {
            InitializeComponent();
            context = new Model1Container();
            _dish = dish;
            DishName.Text = _dish.Name;
            DishPrice.Text = _dish.Price.ToString();
            _admin = admin;
            if (_dish.Id==0)
                Delete.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_dish.Id == 0)
            {
                _dish.Name = DishName.Text;
                try
                {
                    _dish.Price = Convert.ToDouble(DishPrice.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Add error!");
                }
                
                context.DishSet.Add(_dish);
            }
            else
            {
                context.DishSet.Attach(_dish);
                _dish.Name = DishName.Text;
                try
                {
                    _dish.Price = Convert.ToDouble(DishPrice.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Add error!");
                }
                
            }
            context.SaveChanges();
            _admin.getDishSource();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            context.DishSet.Attach(_dish);
            context.DishSet.Remove(_dish);
            context.SaveChanges();
            _admin.getDishSource();
            this.Close();
        }
        
    }
}
