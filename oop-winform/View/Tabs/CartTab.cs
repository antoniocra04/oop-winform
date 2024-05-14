﻿using oop_winform.Models;
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
        /// Выбранный покупатель.
        /// </summary>
        private Customer _currentCustomer;

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

            foreach (var item in orderedListItems)
            {
                ItemsListBox.Items.Add(item.Name);
            }

            ItemsListBox.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Сортирует и обновляет корзины.
        /// </summary>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        private void UpdateCartListBox(int selectedIndex)
        {
            CartListBox.Items.Clear();
            var orderedListItems = _currentCustomer.Cart.Items.OrderBy(item => item.Name).ToList();

            _currentCustomer.Cart.Items = orderedListItems.ToList();

            foreach (var item in orderedListItems)
            {
                CartListBox.Items.Add(item.Name);
            }

            CartListBox.SelectedIndex = selectedIndex;

            if (CartListBox.Items.Count < 1)
            {
                CreateOrderButton.Enabled = false;
            }

        }

        /// <summary>
        /// Обновляет скидку.
        /// </summary>
        private void UpdateDiscount()
        {
            double discountAmount = 0;
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
            var index = CustomerComboBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }
            _currentCustomer = _customers[index];
            if (_currentCustomer.Cart.Items == null)
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
            AmountLabel.Text = _currentCustomer.Cart.Amount.ToString();
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
            else
            {
                CurrentCustomer.Cart.Items.Add(_items[indexListBox]);

                AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();

                UpdateCartListBox(-1);
                CreateOrderButton.Enabled = true;
            }
            UpdateDiscount();
            _currentCustomer.Cart.Items.Add(_items[indexListBox]);
            AmountLabel.Text = _currentCustomer.Cart.Amount.ToString();
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
            else
            {
                CurrentCustomer.Cart.Items.RemoveAt(indexListBox);
                AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();

                UpdateCartListBox(-1);
            }
            UpdateDiscount();
            _currentCustomer.Cart.Items.RemoveAt(indexListBox);
            AmountLabel.Text = _currentCustomer.Cart.Amount.ToString();
            UpdateCartListBox(-1);
        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            var indexComboBox = CustomerComboBox.SelectedIndex;
            var indexListBox = CartListBox.SelectedIndex;
            if (indexListBox == -1 || indexComboBox == -1)
            {
                return;
            }
            _currentCustomer.Cart = new Cart();
            UpdateCartListBox(-1);
            AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString();
            UpdateDiscount();
        }

        private void CreateOrderButton_Click(object sender, EventArgs e)
        {
            if (CartListBox.Items.Count < 1)
            {
                return;
            }

            var order = _currentCustomer.IsPriority ? new PriorityOrder() : new Order();

            double discountAmount = 0;
            discountAmount = CurrentCustomer.Discounts
                .Where(d => DiscountsCheckedListBox.Items.Contains(d))
                .Sum(d => d.Calculate(CurrentCustomer.Cart.Items)); 

            order.Discount = discountAmount;
            CurrentCustomer.Orders.Add(order);

            foreach (var discount in CurrentCustomer.Discounts)
            {
                if (DiscountsCheckedListBox.Items.Contains(discount))
                {
                    discount.Apply(CurrentCustomer.Cart.Items);
                    discount.Update(CurrentCustomer.Cart.Items);
                }
            }
            UpdateDiscountCheckedListBox();
            order.Address = _currentCustomer.Address;
            order.Items = _currentCustomer.Cart.Items;
            order.Status = OrderStatusTypes.New;

            _currentCustomer.Orders.Add(order);

            _currentCustomer.Cart = new Cart();
            UpdateCartListBox(-1);
            AmountLabel.Text = _currentCustomer.Cart.Amount.ToString();
            CreateOrderButton.Enabled = false;
        }

        private void DiscountsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDiscount();
        }
    }
}
