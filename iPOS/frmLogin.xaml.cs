using iPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace iPOS
{
    /// <summary>
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        FileManager fileManager = new FileManager();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userName = txtUsername.Text;
                string password = txtPassword.Password;

                Admin admin = fileManager.Read<Admin>("admin");
                if (admin != null && userName == admin.userName && password == admin.password)
                {
                    frmMain frmMain = new frmMain();
                    this.Close();
                    frmMain.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username or Password incorrect!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
