using oop_winform.Models;
using oop_winform.View.Tabs;
using System.Windows.Forms;

namespace oop_winform
{
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
            cartTab1.Items = _store.Items;
            cartTab1.Customers = _store.Customers;
            ordersTab1.Customers = _store.Customers;
        }

        private void MainTabControl_TabIndexChanged(object sender, System.EventArgs e)
        {
            cartTab1.Items = ItemsTab.Items;
            cartTab1.Customers = CustomersTab.Customers;
            cartTab1.RefreshData();
            ordersTab1.Customers = _store.Customers;
            ordersTab1.RefreshData();
        }
    }
}
