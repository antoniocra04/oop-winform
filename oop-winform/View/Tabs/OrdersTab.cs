using oop_winform.Models;
using oop_winform.View.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace oop_winform.View.Tabs
{
    /// <summary>
    /// Вкладка заказов.
    /// </summary>
    public partial class OrdersTab : UserControl
    {
        /// <summary>
        /// Список покупателей.
        /// </summary>
        private List<Customer> _customers;

        /// <summary>
        /// Возвращает и задает список покупателей.
        /// </summary>
        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;

                if (_customers != null) UpdateOrders();
            }
        }

        /// <summary>
        /// Возвращает и задает список заказов.
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// Создает экзепмляр класса <see cref="OrdersTab"/>.
        /// </summary>
        public OrdersTab()
        {
            InitializeComponent();
            StatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatusTypes));
        }

        /// <summary>
        /// Обновляет данные вкладки заказов.
        /// </summary>
        public void RefreshData()
        {
            OrdersDataGridView.Rows.Clear();
            Orders = new List<Order>();
            UpdateOrders();
        }

        /// <summary>
        /// Обновляет данные таблицы заказов.
        /// </summary>
        private void UpdateOrders()
        {
            Orders.Clear();
            OrdersDataGridView.Rows.Clear();

            foreach (var customer in Customers)
            {
                var address = $"{customer.Address.Country}, {customer.Address.City}, ";
                address += $"{customer.Address.Street} {customer.Address.Building}, ";
                address += $"{customer.Address.Apartment}";

                foreach (var order in customer.Orders)
                {
                    Orders.Add(order);
                    OrdersDataGridView.Rows.Add(
                        order.Id, order.CreationDate, order.Status, customer.FullName,
                        address, order.Amount);
                }
            }
        }

        /// <summary>
        /// Возвращает список названий товаров.
        /// </summary>
        /// <param name="items">Список товаров.</param>
        /// <returns>Список именований товаров <see cref="List{string}"/>.</returns>
        private List<string> ParseItemNames(List<Item> items)
        {
            var itemNames = items.Select(item => item.Name).ToList();
            return itemNames;
        }

        private void OrdersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var selectedCells = OrdersDataGridView.SelectedCells.Count;
            var selectedIndex = OrdersDataGridView.SelectedCells[0].RowIndex;

            if (OrdersDataGridView.SelectedCells.Count == 0)
            {
                StatusComboBox.SelectedIndex = -1;
            }
            else
            {
                StatusComboBox.SelectedItem = Orders[selectedIndex].Status;
            }

            IdTextBox.Text = selectedCells == 0 ? "" : Orders[selectedIndex].Id.ToString();
            CreatedTextBox.Text = selectedCells == 0 ? "" : Orders[selectedIndex].CreationDate.ToString();
            StatusComboBox.Enabled = selectedCells == 0 ? false : true;
            AddressControl.Address = selectedCells == 0 ? null : Orders[selectedIndex].Address;
            OrderItemsListBox.DataSource = selectedCells == 0 ? new List<string>() : ParseItemNames(Orders[selectedIndex].Items);
            AmountLabel.Text = selectedCells == 0 ? "" :Orders[selectedIndex].Amount.ToString();
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrdersDataGridView.SelectedCells.Count == 0)
            {
                return;
            }
            var selectedIndex = OrdersDataGridView.SelectedCells[0].RowIndex;
            Orders[selectedIndex].Status = (OrderStatusTypes)StatusComboBox.SelectedItem;
            OrdersDataGridView[2, selectedIndex].Value = Enum.GetName(
                                                                    typeof(OrderStatusTypes), 
                                                                    Orders[selectedIndex].Status);
        }
    }
}
