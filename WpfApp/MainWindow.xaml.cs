﻿using Data;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using WpfApp.DeliveryService;
using WpfApp.DTOs;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DeliveryServiceClient client = new DeliveryServiceClient();
        private List<Shipment> displayedShipments;
        private ShipmentDetail window;
        private int _skip;
        private int _take;
        public MainWindow()
        {
            InitializeComponent();
            this.shipmentListGrid.ItemsSource = GetShipments(0, 25, 1);
            this._skip = 0;
            this._take = 25;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DbOpp db = new DbOpp();
            await Task.Run(() =>
            {
                db.CreateDummyData(1);
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //method for testing
            var a = client.GetShipments(new Truck() { Id = 1 }, 0, 25);
            var t = "fdfdf";

            var b = client.GetPackages(new Shipment() { Id = 1 });
            var z = "fdfdf";
        }

        private void shipmentListGrid_CellClicked(object sender, MouseButtonEventArgs e)
        {
            DataGrid castedSender =  (DataGrid)sender;
            var selectedShipmentIdentifier = (ShipmentListDTO)castedSender.SelectedValue;
            int shipmentID = selectedShipmentIdentifier.Indentifier;
            this.window = new ShipmentDetail(displayedShipments.Where(x=>x.Id == shipmentID).FirstOrDefault());
            this.window.Owner = this;
            this.window.Show();
        }

        private List<ShipmentListDTO> GetShipments(int skip, int take, int truckId =1)
        {
            var shipments = client.GetShipments(new Truck() { Id = 1 }, skip, take);
            this.displayedShipments = null;
            displayedShipments = shipments.ToList();
            List<ShipmentListDTO> shipmentDtos = new List<ShipmentListDTO>();
            for(int i=0; i<shipments.Length; i++)
            {
                var packages = client.GetPackages(shipments[i]);
                shipmentDtos.Add(new ShipmentListDTO(shipments[i], packages.ToList()));
                displayedShipments[i].Packages = packages.ToList();
            }

            return shipmentDtos;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.shipmentListGrid.ItemsSource = GetShipments(0, 25, 1);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this._skip -= 25;
            this._take -= 25;
            this.shipmentListGrid.ItemsSource = GetShipments(this._skip, this._take, 1);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            this._skip += 25;
            this._take += 25;
            this.shipmentListGrid.ItemsSource = GetShipments(this._skip, this._take, 1);
        }
    }
}
