using oop_winform.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace oop_winform.View.Tabs
{
    public partial class CustomersTab : UserControl
    {
        /// <summary>
        /// Список покупателей.
        /// </summary>
        private List<Customer> _customers = new List<Customer>();

        /// <summary>
        /// Инициализация компонента.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
            WrongAddressLabel.Text = string.Empty;
            WrongFullNameLabel.Text = string.Empty;
        }

        /// <summary>
        /// Установка корректных данных в тексбоксах.
        /// </summary>
        /// <param name="index">Индекс покупателя.</param>
        private void SetTextBoxes(int index)
        {
            if (index >= 0)
            {
                IdTextBox.Text = _customers[CustomersListBox.SelectedIndex].Id.ToString();
                AddressTextBox.Text = _customers[CustomersListBox.SelectedIndex].Address;
                FullNameTextBox.Text = _customers[CustomersListBox.SelectedIndex].FullName;
                AddressTextBox.Enabled = true;
                FullNameTextBox.Enabled = true;
            }
            else
            {
                FullNameTextBox.Text = "";
                AddressTextBox.Text = "";
                IdTextBox.Text = "";
                AddressTextBox.Enabled = false;
                FullNameTextBox.Enabled = false;
            }
        }

        /// <summary>
        /// Событие изменения выбора в списке.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextBoxes(CustomersListBox.SelectedIndex);
        }

        /// <summary>
        /// Событие нажатия кнопки добавления покупателя.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer();
            newCustomer.FullName = newCustomer.Id.ToString();
            _customers.Add(newCustomer);
            CustomersListBox.Items.Add(newCustomer.FullName);
            CustomersListBox.SelectedItem = newCustomer.FullName;
        }

        /// <summary>
        /// Событие нажатия кнопки удаления покупателя
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int removeIndex = CustomersListBox.SelectedIndex;

            if (removeIndex > 0)
            {
                CustomersListBox.Items.RemoveAt(removeIndex);
                _customers.RemoveAt(removeIndex);
            }
        }

        /// <summary>
        /// Событие изменения текстбокса имени.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                WrongFullNameLabel.Text = "";
                FullNameTextBox.BackColor = Constants.okColor;
                return;
            }

            if (FullNameTextBox.Text.Length == 0)
            {
                WrongFullNameLabel.Text = "Имя не должно быть пустым";
                AddressTextBox.BackColor = Constants.errorColor;
            }
            else if (FullNameTextBox.Text.Length > 200)
            {
                WrongFullNameLabel.Text = "Имя может быть не больше 200 символов";
                AddressTextBox.BackColor = Constants.errorColor;
            }
            else
            {
                WrongFullNameLabel.Text = "";
                AddressTextBox.BackColor = Constants.okColor;
            }
        }

        /// <summary>
        /// Событие изменения текстбокса адреса.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex < 0)
            {
                WrongAddressLabel.Text = "";
                AddressTextBox.BackColor = Constants.okColor;
                return;
            }

            if (AddressTextBox.Text.Length > 500)
            {
                WrongAddressLabel.Text = "Адрес может быть не больше 500 символов";
                AddressTextBox.BackColor = Constants.errorColor;
            }
            else
            {
                WrongAddressLabel.Text = "";
                AddressTextBox.BackColor = Constants.okColor;
            }

            
        }

        /// <summary>
        /// Событие выхода из текстбокса имени.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void FullNameTextBox_Leave(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex >= 0)
            {
                if (FullNameTextBox.BackColor == Constants.okColor)
                {
                    _customers[CustomersListBox.SelectedIndex].FullName = FullNameTextBox.Text;
                    CustomersListBox.Items[CustomersListBox.SelectedIndex] = FullNameTextBox.Text;
                }
                else
                {
                    FullNameTextBox.Text = _customers[CustomersListBox.SelectedIndex].FullName;
                }
            }
        }

        /// <summary>
        /// Событие выхода из текстбокса адреса.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void AddressTextBox_Leave(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedIndex >= 0)
            {
                if (AddressTextBox.BackColor == Constants.okColor)
                {
                    _customers[CustomersListBox.SelectedIndex].Address = AddressTextBox.Text;
                    CustomersListBox.Items[CustomersListBox.SelectedIndex] = AddressTextBox.Text;
                }
                else
                {
                    AddressTextBox.Text = _customers[CustomersListBox.SelectedIndex].Address;
                }
            }
        }
    }
}
