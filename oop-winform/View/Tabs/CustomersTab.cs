using oop_winform.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                    UpdateCustomersListBox();
                }
            }
        }

        /// <summary>
        /// Обновляет данные в CustomerList.
        /// </summary>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        private void UpdateCustomersListBox()
        {
            CustomersListBox.Items.Clear();
            foreach (var customer in Customers)
            {
                CustomersListBox.Items.Add(customer.FullName);
            }
        }

        /// <summary>
        /// Установка корректных данных в тексбоксах.
        /// </summary>
        /// <param name="index">Индекс покупателя.</param>
        private void SetTextBoxes(int selectedIndex)
        {
            var isSelectedIndexCorrect = selectedIndex >= 0;
            FullNameTextBox.Enabled = isSelectedIndexCorrect;
            AddressTextBox.Enabled = isSelectedIndexCorrect;
            if (isSelectedIndexCorrect)
            {
                IdTextBox.Text = Customers[CustomersListBox.SelectedIndex].Id.ToString();
                FullNameTextBox.Text = Customers[CustomersListBox.SelectedIndex].FullName;
            }
            else
            {
                FullNameTextBox.Text = "";
                IdTextBox.Text = "";
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
            SetTextBoxes(CustomersListBox.SelectedIndex);
            FullNameTextBox.Text = _currentCustomer.FullName;
            AddressTextBox.Text = _currentCustomer.Address;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newCustomer = new Customer();
            newCustomer.FullName = $"Customer{newCustomer.Id}";
            _currentCustomer = newCustomer;
            Customers.Add(newCustomer);
            CustomersListBox.Items.Add(newCustomer.FullName);
            CustomersListBox.SelectedIndex = CustomersListBox.Items.Count - 1;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int removeIndex = CustomersListBox.SelectedIndex;

            if (removeIndex > 0)
            {
                CustomersListBox.Items.RemoveAt(removeIndex);
                _customers.RemoveAt(removeIndex);
            }
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = CustomersListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                string name = FullNameTextBox.Text;
                _currentCustomer.FullName = name;
                Customers[CustomersListBox.SelectedIndex].FullName = FullNameTextBox.Text;
                CustomersListBox.Items[CustomersListBox.SelectedIndex] = FullNameTextBox.Text;
            }
            catch
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
            catch
            {
                AddressTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            AddressTextBox.BackColor = Constants.CorrectColor;
        }
    }
}
