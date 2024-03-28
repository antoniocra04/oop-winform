using oop_winform.Models;
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
        private void SetTextBoxes()
        {
            var isSelectedIndexCorrect = CustomersListBox.SelectedIndex != -1;
            FullNameTextBox.Enabled = isSelectedIndexCorrect;
            AddressTextBox.Enabled = isSelectedIndexCorrect;
            if (isSelectedIndexCorrect)
            {
                IdTextBox.Text = Customers[CustomersListBox.SelectedIndex].Id.ToString();
                FullNameTextBox.Text = Customers[CustomersListBox.SelectedIndex].FullName;
                AddressTextBox.Text = Customers[CustomersListBox.SelectedIndex].Address;
            }
            else
            {
                IdTextBox.Text = "";
                FullNameTextBox.Text = "";
                AddressTextBox.Text = "";
            }
        }

        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CustomersListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            _currentCustomer = _customers[index];
            SetTextBoxes();
            FullNameTextBox.Text = _currentCustomer.FullName;
            AddressTextBox.Text = _currentCustomer.Address;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newCustomer = new Customer("Customer", "address");
            Customers.Add(newCustomer);
            UpdateCustomersListBox(Customers.Count - 1);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int removeIndex = CustomersListBox.SelectedIndex;

            if (removeIndex >= 0)
            {
                Customers.RemoveAt(removeIndex);
                UpdateCustomersListBox(-1);
            }

            SetTextBoxes();
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = CustomersListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                _currentCustomer.FullName = FullNameTextBox.Text;
                UpdateCustomersListBox(CustomersListBox.SelectedIndex);
            }
            catch(ArgumentException exception)
            {
                FullNameTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            FullNameTextBox.BackColor = Constants.CorrectColor;
        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = CustomersListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                string address = AddressTextBox.Text;
                _currentCustomer.Address = address;
                Customers[CustomersListBox.SelectedIndex].Address = AddressTextBox.Text;
            }
            catch(ArgumentException exception)
            {
                AddressTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            AddressTextBox.BackColor = Constants.CorrectColor;
        }
    }
}
