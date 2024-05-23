using oop_winform.Models;
using oop_winform.Models.Enums;
using oop_winform.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        /// Приоритетный заказ. 
        /// </summary>
        private PriorityOrder _priorityOrder;

        /// <summary>
        /// Создает экземпляр класса <see cref="OrdersTab"/>.
        /// </summary>
        public OrdersTab()
        {
            InitializeComponent();
            StatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatusTypes));
            PriorityOptionPanel.Visible = false;
        }

        /// <summary>
        /// Возвращает и задает список покупателей.
        /// </summary>
        public List<Customer> Customers
        {
            get => _customers;
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
            if (OrdersDataGridView.SelectedCells.Count == 0)
            {
                StatusComboBox.SelectedIndex = -1;
                StatusComboBox.Enabled = false;
            }
            else
            {
                StatusComboBox.SelectedItem = Orders[OrdersDataGridView.SelectedCells[0].RowIndex].Status;
                StatusComboBox.Enabled = true;

                if (Orders[OrdersDataGridView.CurrentCell.RowIndex] is PriorityOrder priority)
                {
                    PriorityOptionPanel.Visible = true;
                    _priorityOrder = (PriorityOrder)Orders[OrdersDataGridView.CurrentCell.RowIndex];
                    DeliveryTimeComboBox.SelectedIndex = (int)_priorityOrder.DeliveryTime;
                }
                else
                {
                    PriorityOptionPanel.Visible = false;
                    _priorityOrder = null;
                }
            }

            var cellsCount = OrdersDataGridView.SelectedCells.Count;

            IdTextBox.Text = (cellsCount == 0) ?
                string.Empty :
                Orders[OrdersDataGridView.SelectedCells[0].RowIndex].Id.ToString();

            CreatedTextBox.Text = (cellsCount == 0) ?
                string.Empty :
                Orders[OrdersDataGridView.SelectedCells[0].RowIndex].CreationDate.ToString();

            StatusComboBox.Enabled = (cellsCount == 0) ? false : true;

            AddressControl.Address = (cellsCount == 0) ?
                null :
                Orders[OrdersDataGridView.SelectedCells[0].RowIndex].Address;

            OrderItemsListBox.DataSource = (cellsCount == 0) ?
                new List<string>() :
                ParseItemNames(Orders[OrdersDataGridView.SelectedCells[0].RowIndex].Items);

            AmountLabel.Text = (cellsCount == 0) ?
                string.Empty :
                (Orders[OrdersDataGridView.SelectedCells[0].RowIndex].Amount - Orders[OrdersDataGridView.SelectedCells[0].RowIndex].Discount).ToString();
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

        private void DeliveryTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = OrdersDataGridView.CurrentCell.RowIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            _priorityOrder.DeliveryTime = (OrderTime)DeliveryTimeComboBox.SelectedIndex;
        }
    }
}
