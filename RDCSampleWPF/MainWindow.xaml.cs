using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.Integration;
using AxMSTSCLib;

namespace RDCSampleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AxMsRdpClient8NotSafeForScripting rdClient;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            // Create the host and the ActiveX control
            WindowsFormsHost host = new WindowsFormsHost();
            rdClient = new AxMsRdpClient8NotSafeForScripting();

            // Add the ActiveX control to the host, and the host to the WPF panel
            host.Child = rdClient;
            tiGrid0.Children.Add(host);

            

            rdClient.Server = txtServer.Text.Trim();
            rdClient.DesktopWidth = rdClient.Width = (int)TabControl1.Width;
            rdClient.DesktopHeight = rdClient.Height = (int)TabControl1.Height;
            //rdClient.AdvancedSettings8.ClearTextPassword = "QPF!ATfZ#xg3r&";
            rdClient.AdvancedSettings8.EnableCredSspSupport = true;
            rpcConnect();
        }

        private void rpcConnect()
        {
            try
            {
                rdClient.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }
}
