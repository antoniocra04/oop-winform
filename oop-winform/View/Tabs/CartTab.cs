using oop_winform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace oop_winform.View.Tabs
{
    /// <summary>
    /// Вкладка корзины.
    /// </summary>
    public partial class CartTab : UserControl
    {
        /// <summary>
        /// Список товаров.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Список покупателей.
        /// </summary>
        private List<Customer> _customers;

        /// <summary>
        /// Создает экземпляр класса <see cref="CartTab"/>.
        /// </summary>
        public CartTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает и задает список товаров.
        /// </summary>
        public List<Item> Items
        {
            get => _items;
            set
            {
                _items = value;

                if (_items != null)
                {
                    UpdateItemsListBox(-1);
                }
            }
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

                if (_customers != null)
                {
                    UpdateCustomerComboBox();
                }
            }
        }

        /// <summary>
        /// Возвращает и задает выбранного покупателя.
        /// </summary>
        private Customer CurrentCustomer { get; set; }

        /// <summary>
        /// Обновляет данные.
        /// </summary>
        public void RefreshData()
        {
            UpdateItemsListBox(-1);

            CustomerComboBox.Items.Clear();
            foreach (var customer in _customers)
            {
                CustomerComboBox.Items.Add(customer.FullName);
            }

            if (CustomerComboBox.Items.Count > 0)
            {
                CustomerComboBox.SelectedIndex = 0;
            }
            else
            {
                CustomerComboBox.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Обновляет комбобокс с покупателями.
        /// </summary>
        private void UpdateCustomerComboBox()
        {
            foreach (var customer in _customers)
            {
                CustomerComboBox.Items.Add(customer.FullName);
            }
        }

        /// <summary>
        /// Сортирует и обновляет товары.
        /// </summary>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        private void UpdateItemsListBox(int selectedIndex)
        {
            ItemsListBox.Items.Clear();
            var orderedListItems = _items.OrderBy(item => item.Name).ToList();

            foreach (Item item in orderedListItems)
            {
                ItemsListBox.Items.Add(item.Name);
            }

            ItemsListBox.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Сортирует и обновляет корзины.
        /// </summary>
        /// <param name="selectedIndex">выбранный элемент.</param>
        private void UpdateCartListBox(int selectedIndex)
        {
            CartListBox.Items.Clear();
            var orderedListItems = CurrentCustomer.Cart.Items.OrderBy(item => item.Name).ToList();

            foreach (Item item in orderedListItems)
            {
                CartListBox.Items.Add(item.Name);
            }

            CartListBox.SelectedIndex = selectedIndex;

            CreateOrderButton.Enabled = false;
        }

        private void CustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = CustomerComboBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }
            CurrentCustomer = _customers[index];
            if (CurrentCustomer.Cart.Items == null)
            {
                return;
            }
            AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();
            UpdateCartListBox(-1);
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            var indexListBox = ItemsListBox.SelectedIndex;
            var indexComboBox = CustomerComboBox.SelectedIndex;

            if (indexListBox == -1 || indexComboBox == -1)
            {
                return;
            }
            CurrentCustomer.Cart.Items.Add(_items[indexListBox]);
            AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();
            UpdateCartListBox(-1);
            CreateOrderButton.Enabled = true;
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            var indexComboBox = CustomerComboBox.SelectedIndex;
            var indexListBox = CartListBox.SelectedIndex;

            if (indexListBox == -1 || indexComboBox == -1)
            {
                return; 
            }
            CurrentCustomer.Cart.Items.RemoveAt(indexListBox);
            AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();
            UpdateCartListBox(-1);
        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            CurrentCustomer.Cart = new Cart();
            UpdateCartListBox(-1);
            AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();
        }

        private void CreateOrderButton_Click(object sender, EventArgs e)
        {
            Order order = new Order
            {
                Address = CurrentCustomer.Address,
                Items = CurrentCustomer.Cart.Items,
                Status = OrderStatusTypes.New
            };

            CurrentCustomer.Orders.Add(order);

            CurrentCustomer.Cart = new Cart();
            UpdateCartListBox(-1);
            AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();
            CreateOrderButton.Enabled = false;
        }
    }
}
