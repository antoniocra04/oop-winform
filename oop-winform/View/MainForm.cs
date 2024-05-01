using oop_winform.Models;
using oop_winform.View.Tabs;
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
            ordersTab1.Customers = _store.Customers;
        }

        private void MainTabControl_TabIndexChanged(object sender, System.EventArgs e)
        {
            CartsTab.Items = ItemsTab.Items;
            CartsTab.Customers = CustomersTab.Customers;
            CartsTab.RefreshData();
            ordersTab1.Customers = _store.Customers;
            ordersTab1.RefreshData();
        }
    }
}
