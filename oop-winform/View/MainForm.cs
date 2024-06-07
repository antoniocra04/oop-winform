using oop_winform.Models;
using oop_winform.View.Tabs;
using System;
using System.Windows.Forms;

namespace oop_winform
{
    /// <summary>
    /// Управляет главным окном программы.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Возвращает и задает объект класса <see cref="Store"/>.
        /// </summary>
        private Store _store = new Store();

        public MainForm()
        {
            InitializeComponent();
            ItemsTab.Items = _store.Items;
            CustomersTab.Customers = _store.Customers;
            CartsTab.Items = _store.Items;
            CartsTab.Customers = _store.Customers;
            OrderTab.Customers = _store.Customers;
            ItemsTab.ItemsChanged += ItemsChanged;
        }

        private void ItemsChanged(object sender, EventArgs e)
        {
            CartsTab.Items = ItemsTab.Items;
            CartsTab.RefreshData();
        }

        private void MainTabControl_TabIndexChanged(object sender, System.EventArgs e)
        {
            OrderTab.Customers = _store.Customers;
            CartsTab.Customers = CustomersTab.Customers;
            CustomersTab.UpdateDiscountsListBox();
            OrderTab.RefreshData();
        }
    }
}
