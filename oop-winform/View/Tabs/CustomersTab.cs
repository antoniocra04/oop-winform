﻿using oop_winform.Models;
using oop_winform.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace oop_winform.View.Tabs
{
    /// <summary>
    /// Вкладка покупателей.
    /// </summary>
    public partial class CustomersTab : UserControl
    {
        /// <summary>
        /// Список покупателей.
        /// </summary>
        private List<Customer> _customers = new List<Customer>();

        /// <summary>
        /// Выбранный покупатель.
        /// </summary>
        private Customer _currentCustomer;

        /// <summary>
        /// Создает экземпляр класса <see cref="CustomersTab"/>.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
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
                if (value != null)
                {
                    UpdateCustomersListBox(CustomersListBox.SelectedIndex);
                }
            }
        }

        /// <summary>
        /// Обновляет данные в CustomerList.
        /// </summary>
        /// /// <param name="selectedIndex">Выбранный элемент.</param>
        private void UpdateCustomersListBox(int selectedIndex)
        {
            CustomersListBox.Items.Clear();
            foreach (var customer in Customers)
            {
                CustomersListBox.Items.Add(customer.FullName);
            }
            CustomersListBox.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Установка корректных данных в тексбоксах.
        /// </summary>
        private void SetValuesTextBoxes()
        {
            var isSelectedIndexCorrect = CustomersListBox.SelectedIndex != -1;
            FullNameTextBox.Enabled = isSelectedIndexCorrect;

            IdTextBox.Text = isSelectedIndexCorrect ? _currentCustomer.Id.ToString() : "";
            FullNameTextBox.Text = isSelectedIndexCorrect ? _currentCustomer.FullName : "";
        }

        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = CustomersListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            _currentCustomer = _customers[index];
            SetValuesTextBoxes();
            FullNameTextBox.Text = _currentCustomer.FullName;
            AddressControl.Address = _currentCustomer.Address;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newCustomer = new Customer("Customer", new Address());
            Customers.Add(newCustomer);
            UpdateCustomersListBox(Customers.Count - 1);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var removeIndex = CustomersListBox.SelectedIndex;

            if (removeIndex >= 0)
            {
                Customers.RemoveAt(removeIndex);
                UpdateCustomersListBox(-1);
            }

            SetValuesTextBoxes();
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var index = CustomersListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                _currentCustomer.FullName = FullNameTextBox.Text;
                UpdateCustomersListBox(CustomersListBox.SelectedIndex);
            }
            catch (ArgumentException exception)
            {
                FullNameTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            FullNameTextBox.BackColor = Constants.CorrectColor;
        }
    }
}
