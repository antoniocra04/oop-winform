using oop_winform.Models;
using oop_winform.Services;
using oop_winform.View.Controls;
using oop_winform.View.ModalWindows;
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
        /// Обновляет данные в списке скидок покупателя.
        /// </summary>
        public void UpdateDiscountsListBox()
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                return;
            }

            UpdateDiscountsListBox(Customers[CustomersListBox.SelectedIndex]);
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
        /// Обновляет данные в списке скидок покупателя.
        /// </summary>
        /// <param name="customer">Текущий покупатель.</param>
        private void UpdateDiscountsListBox(Customer customer)
        {
            DiscountsListBox.Items.Clear();

            foreach (var discount in customer.Discounts)
            {
                DiscountsListBox.Items.Add(discount.Info);
            }
        }

        /// <summary>
        /// Установка корректных данных в тексбоксах.
        /// </summary>
        private void SetValuesTextBoxes()
        {
            var isSelectedIndexCorrect = CustomersListBox.SelectedIndex != -1;
            FullNameTextBox.Enabled = isSelectedIndexCorrect;
            DiscountsListBox.Enabled = isSelectedIndexCorrect;
            AddDiscountButton.Enabled = isSelectedIndexCorrect;
            IsPriorityCheckBox.Enabled = isSelectedIndexCorrect;

            if (isSelectedIndexCorrect)
            {
                IdTextBox.Text = _currentCustomer.Id.ToString();
                FullNameTextBox.Text = _currentCustomer.FullName;
                IsPriorityCheckBox.Checked = Customers[CustomersListBox.SelectedIndex].IsPriority;
                UpdateDiscountsListBox(Customers[CustomersListBox.SelectedIndex]);
            }
            else
            {
                IdTextBox.Text = "";
                FullNameTextBox.Text = "";
                addressControl1.Address = null;
                IsPriorityCheckBox.Checked = false;
                DiscountsListBox.Items.Clear();
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
            SetValuesTextBoxes();
            FullNameTextBox.Text = _currentCustomer.FullName;
            addressControl1.Address = _currentCustomer.Address;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newCustomer = new Customer("Customer", new Address());
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

            SetValuesTextBoxes();
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

        private void IsPriorityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _currentCustomer.IsPriority = IsPriorityCheckBox.Checked;
        }

        private void AddDiscountButton_Click(object sender, EventArgs e)
        {
            var addDiscountPopUp = new DiscountModalWindow(Customers[CustomersListBox.SelectedIndex]);

            if (addDiscountPopUp.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var discount = new PercentDiscount(addDiscountPopUp.Category);
            Customers[CustomersListBox.SelectedIndex].Discounts.Add(discount);
            UpdateDiscountsListBox(Customers[CustomersListBox.SelectedIndex]);
        }

        private void RemoveDiscountButton_Click(object sender, EventArgs e)
        {
            var removedIndex = DiscountsListBox.SelectedIndex;
            Customers[CustomersListBox.SelectedIndex].Discounts.RemoveAt(
                DiscountsListBox.SelectedIndex);
            UpdateDiscountsListBox(Customers[CustomersListBox.SelectedIndex]);

            if (removedIndex >= DiscountsListBox.Items.Count)
            {
                DiscountsListBox.SelectedIndex = removedIndex - 1;
            }
            else
            {
                DiscountsListBox.SelectedIndex = removedIndex;
            }
        }

        private void DiscountsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveDiscountButton.Enabled = DiscountsListBox.SelectedIndex > 0;
        }
    }
}
