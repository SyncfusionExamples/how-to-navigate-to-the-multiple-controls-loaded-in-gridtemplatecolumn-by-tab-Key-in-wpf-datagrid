using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingDemo
{
    public class Product : INotifyPropertyChanged
    {
        private string productId;
        public string ProductId
        {
            get { return productId; }
            set { productId = value; OnPropertyChanged("ProductId"); }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged("ProductName"); }
        }

        private int salesID;
        public int SalesID
        {
            get { return salesID; }
            set { salesID = value; OnPropertyChanged("SalesID"); }
        }

        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; OnPropertyChanged("CustomerName"); }
        }

        private string customerId;
        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; OnPropertyChanged("CustomerId"); }
        }

        private string customerBranch;
        public string CustomerBranch
        {
            get { return customerBranch; }
            set { customerBranch = value; OnPropertyChanged("CustomerBranch"); }
        }

        private int Id;
        public int ID
        {
            get { return Id; }
            set { Id = value; OnPropertyChanged("ID"); }
        }

        private string shipmentdetails;
        public string ShipmentDetails
        {
            get { return shipmentdetails; }
            set { shipmentdetails = value; OnPropertyChanged("ShipmentDetails"); }
        }

        private string shipmentplace;
        public string ShipmentPlace
        {
            get { return shipmentplace; }
            set { shipmentplace = value; OnPropertyChanged("ShipmentPlace"); }
        }

        public Product(string productId, string productName, int salesID, string customerName, string customerId, string customerBranch, int Id, string shipmentdetails, string shipmentplace)
        {
            this.productId = productId;
            this.productName = productName;
            this.salesID = salesID;
            this.customerName = customerName;
            this.customerId = customerId;
            this.customerBranch = customerBranch;
            this.Id = Id;
            this.shipmentdetails = shipmentdetails;
            this.shipmentplace = shipmentplace;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
