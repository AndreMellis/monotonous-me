using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Net;

namespace monotonous_me
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class IPQuery : Window
    {
        private ArrayList serverList = new ArrayList();
        private ArrayList serverIPPairList = new ArrayList();
        private ArrayList serverIPList = new ArrayList();

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            serverList.AddRange(txtbox_ServerList.Text.Split());
            foreach(string server in serverList)
            {
                string IP = Dns.GetHostEntry(server).AddressList[0].ToString();
                serverIPList.Add(IP);
                serverIPPairList.Add(server+","+IP);
            }
            serverList.Clear(); //cleanup
            serverList.TrimToSize();//cleanup
            foreach (string ip in serverIPList)
            {
                txtbox_IPList.Text += ip+"\n";
            }
        }
        private void menuIPQuery_Click(object sender, RoutedEventArgs e)
        {
            IPQuery querywindow = new IPQuery();
            Visibility = Visibility.Hidden;
            querywindow.Show();
            this.Close();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        public IPQuery()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
}
