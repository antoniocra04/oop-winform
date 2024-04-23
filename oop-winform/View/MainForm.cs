using oop_winform.Models;
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
        }

        private void CustomersTab_Load(object sender, System.EventArgs e)
        {
        }
    }
}
