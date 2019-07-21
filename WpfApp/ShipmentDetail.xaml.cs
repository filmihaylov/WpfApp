using Data.Database;
using Data.States;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.DeliveryService;
using WpfApp.DTOs;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ShipmentDetail.xaml
    /// </summary>
    public partial class ShipmentDetail : Window
    {
        private ShipmentDetailDTO shipment;
        private Package selectedPackage;
        private DeliveryServiceClient client = new DeliveryServiceClient();
        public ShipmentDetail(Shipment shipment)
        {
            InitializeComponent();
            this.shipment = new ShipmentDetailDTO(shipment);
            foreach(var package in this.shipment.Packages)
            {
                Button button = new Button();
                button.Content = package.Id.ToString();
                button.Name = "btn"+ package.Id.ToString();
                button.Click += btnPackage_Click;

                stackPanel.Children.Add(button);
            }
        }

        private void btnPackage_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            this.selectedPackage = this.shipment.Packages.Where(p => p.Id == Int32.Parse(Regex.Match(btn.Name, @"\d+").Value)).FirstOrDefault();

            text1.Text = this.selectedPackage.CustomerReceiver.Name;
            text2.Text = this.selectedPackage.CustomerSender.Name;
            text3.ItemsSource = Enum.GetValues(typeof(PackageCondition)).Cast<PackageCondition>();
            text4.ItemsSource = Enum.GetValues(typeof(PackageState)).Cast<PackageState>();
            text5.ItemsSource = Enum.GetValues(typeof(ShipmentState)).Cast<ShipmentState>();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.client.UpdatePackageState((ShipmentState)this.text5.SelectedItem, (PackageCondition)this.text3.SelectedItem, (PackageState)this.text4.SelectedItem, this.notes.Text, this.selectedPackage);
                ((MainWindow)this.Owner).refresh.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                this.Close();
            }
            catch
            {
                MessageBox.Show("Please select a package and fill all comboboxes", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
