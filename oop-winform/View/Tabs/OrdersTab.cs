using oop_winform.Models;
using System;
using System.Collections.Generic;
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
        /// Создает экзепляр класса <see cref="OrdersTab"/>.
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
        /// Приоритетный заказ. 
        /// </summary>
        private PriorityOrder PriorityOrder;

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
            var selectedIndex = OrdersDataGridView.SelectedCells[0].RowIndex;
            if (OrdersDataGridView.SelectedCells.Count == 0)
            {
                StatusComboBox.SelectedIndex = -1;
                StatusComboBox.Enabled = false;
            }
            else
            {
                StatusComboBox.SelectedItem = Orders[OrdersDataGridView.SelectedCells[0].RowIndex].Status;
                StatusComboBox.Enabled = true;
                AddressControl.Address = Orders[selectedIndex].Address;
                OrderItemsListBox.DataSource = ParseItemNames(Orders[selectedIndex].Items);
                AmountLabel.Text = Orders[selectedIndex].Amount.ToString();

                int index = OrdersDataGridView.CurrentCell.RowIndex;

                if (Orders[index] is PriorityOrder priority)
                {
                    PriorityOptionPanel.Visible = true;
                    PriorityOrder = (PriorityOrder)Orders[index];
                }
                else
                {
                    PriorityOptionPanel.Visible = false;
                    PriorityOrder = null;
                }
            }

            IdTextBox.Text = (OrdersDataGridView.SelectedCells.Count == 0) ? 
                string.Empty : 
                Orders[OrdersDataGridView.SelectedCells[0].RowIndex].Id.ToString();
            CreatedTextBox.Text = (OrdersDataGridView.SelectedCells.Count == 0) ? 
                string.Empty : 
                Orders[OrdersDataGridView.SelectedCells[0].RowIndex].CreationDate.ToString();
            StatusComboBox.Enabled = (OrdersDataGridView.SelectedCells.Count == 0) ? false : true;
            AddressControl.Address = (OrdersDataGridView.SelectedCells.Count == 0) ? 
                null : 
                Orders[OrdersDataGridView.SelectedCells[0].RowIndex].Address;
            OrderItemsListBox.DataSource = (OrdersDataGridView.SelectedCells.Count == 0) ? 
                new List<string>() : 
                ParseItemNames(Orders[OrdersDataGridView.SelectedCells[0].RowIndex].Items);
            AmountLabel.Text = (OrdersDataGridView.SelectedCells.Count == 0) ? 
                string.Empty : 
                Orders[OrdersDataGridView.SelectedCells[0].RowIndex].Amount.ToString();
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

            Orders[selectedIndex].Status = (OrderStatusTypes)StatusComboBox.SelectedItem;
            OrdersDataGridView[3, selectedIndex].Value =
                Enum.GetName(typeof(OrderStatusTypes), Orders[selectedIndex].Status);
        }

        private void PriorityOprionPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
