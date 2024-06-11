using oop_winform.Models;
using oop_winform.Models.Enums;
using oop_winform.Models.Orders;
using System;
using System.Collections.Generic;
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
        /// Событие при создании заказа.
        /// </summary>
        public event EventHandler<EventArgs> OrderCreated;

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
            get
            {
                return _items;
            }
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
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;

                if (_customers != null)
                {
                    foreach (var customer in _customers)
                    {
                        CustomerComboBox.Items.Add(customer.FullName);
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает и задает выбранного покупателя.
        /// </summary>
        private Customer CurrentCustomer { get; set; }

        /// <summary>
        /// Возвращает и задает размер скидки.
        /// </summary>
        public double DiscountAmount { get; set; }

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
                UpdateDiscount();
            }
            else
            {
                CustomerComboBox.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Обновляет скидки покупателя.
        /// </summary>
        private void UpdateCustomerDiscounts()
        {
            for (int i = 0; i < DiscountsCheckedListBox.Items.Count; i++)
            {
                if (DiscountsCheckedListBox.GetItemChecked(i))
                {
                    CurrentCustomer.Discounts[i].Apply(CurrentCustomer.Cart.Items);
                }
                CurrentCustomer.Discounts[i].Update(CurrentCustomer.Cart.Items);
            }
        }

        /// <summary>
        /// Сортирует и обновляет товары.
        /// </summary>
        /// <param name="selectedIndex">Выбраный элемент.</param>
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
        /// <param name="selectedIndex">Выбраный элемент.</param>
        private void UpdateCartListBox(int selectedIndex)
        {
            CartListBox.Items.Clear();

            var orderedListItems = CurrentCustomer.Cart.Items.OrderBy(item => item.Name).ToList();

            foreach (Item item in orderedListItems)
            {
                CartListBox.Items.Add(item.Name);
            }

            CartListBox.SelectedIndex = selectedIndex;

            if(CartListBox.Items.Count == 0)
            {
                CreateOrderButton.Enabled = false;
            }
        }

        /// <summary>
        /// Обновляет скидку.
        /// </summary>
        private void UpdateDiscount()
        {
            var discountAmount = 0.0;
            for (int i = 0; i < DiscountsCheckedListBox.Items.Count; i++)
            {
                if (DiscountsCheckedListBox.GetItemChecked(i))
                {
                    discountAmount += CurrentCustomer.Discounts[i].Calculate(CurrentCustomer.Cart.Items);
                }
            }
            DiscountAmountLabel.Text = discountAmount.ToString();
            if (CurrentCustomer.Cart.Amount == 0)
            {
                TotalLabel.Text = CurrentCustomer.Cart.Amount.ToString();
                return;
            }
            TotalLabel.Text = (CurrentCustomer.Cart.Amount - discountAmount).ToString();
        }

        /// <summary>
        /// Обновляет чекбоксы скидок.
        /// </summary>
        private void UpdateDiscountCheckedListBox()
        {
            DiscountsCheckedListBox.Items.Clear();
            foreach (var discount in CurrentCustomer.Discounts)
            {
                DiscountsCheckedListBox.Items.Add(discount.Info, true);
            }
        }

        private void CustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CustomerComboBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }
            else
            {
                CurrentCustomer = _customers[index];

                if (CurrentCustomer.Cart.Items == null)
                {
                    return;
                }
                else
                {
                    AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();
                    UpdateCartListBox(-1);
                }
                UpdateDiscountCheckedListBox();
            }
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            int indexListBox = ItemsListBox.SelectedIndex;
            int indexComboBox = CustomerComboBox.SelectedIndex;

            if (indexListBox == -1 || indexComboBox == -1)
            {
                return;
            }
            else
            {
                CurrentCustomer.Cart.Items.Add(_items[indexListBox]);

                AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();

                UpdateCartListBox(-1);
                CreateOrderButton.Enabled = true;
            }
            UpdateDiscount();
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            int indexComboBox = CustomerComboBox.SelectedIndex;
            int indexListBox = CartListBox.SelectedIndex;

            if (indexListBox == -1 || indexComboBox == -1)
            {
                return;
            }
            else
            {
                CurrentCustomer.Cart.Items.RemoveAt(indexListBox);
                AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();

                UpdateCartListBox(-1);
            }
            UpdateDiscount();
        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            CurrentCustomer.Cart = new Cart();
            UpdateCartListBox(-1);
            AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();
            UpdateDiscount();
        }

        private void CreateOrderButton_Click(object sender, EventArgs e)
        {
            var order = CurrentCustomer.IsPriority ? new PriorityOrder() : new Order();

            order.Address = CurrentCustomer.Address;
            order.Items = CurrentCustomer.Cart.Items;
            order.Status = OrderStatusTypes.New;

            var discountAmount = 0.0;
            discountAmount = CurrentCustomer.Discounts
                .Sum(d => d.Calculate(CurrentCustomer.Cart.Items));

            order.Discount = discountAmount;

            UpdateCustomerDiscounts();
            UpdateDiscountCheckedListBox();

            CurrentCustomer.Orders.Add(order);

            CurrentCustomer.Cart = new Cart();
            UpdateCartListBox(-1);
            AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();
            TotalLabel.Text = "0";
            DiscountAmountLabel.Text = "0";
            CreateOrderButton.Enabled = false;
            OrderCreated?.Invoke(this, EventArgs.Empty);
        }

        private void DiscountsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDiscount();
        }
    }
}
