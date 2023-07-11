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

namespace ATM_Software.MVVM.View
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove(); 
            } 
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName_Box.Text != "" && LastName_Box.Text != "" && Username_Box.Text != "" && Password_Box.Password != "" && Password_Box.Password == ReenterPassword_Box.Password)
            {

            }
        }
    }
}
