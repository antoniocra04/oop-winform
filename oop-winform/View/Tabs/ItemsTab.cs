using oop_winform.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace oop_winform.View.Tabs
{
    public partial class ItemsTab : UserControl
    {
        /// <summary>
        /// Список товаров.
        /// </summary>
        private List<Item> _items = new List<Item>();

        /// <summary>
        /// Инициализация компонента.
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();
            WrongCostLabel.Text = string.Empty;
            WrongNameLabel.Text = string.Empty;
            WrongDescriptionLabel.Text = string.Empty;
        }

        /// <summary>
        /// Установка корректных данных в тексбоксах.
        /// </summary>
        /// <param name="index">Индекс товара.</param>
        private void SetTextBoxes(int index)
        {

            if (index >= 0)
            {
                NameTextBox.Text = _items[ItemsListBox.SelectedIndex].Name;
                CostTextBox.Text = _items[ItemsListBox.SelectedIndex].Cost.ToString();
                IdTextBox.Text = _items[ItemsListBox.SelectedIndex].Id.ToString();
                DescriptionTextBox.Text = _items[ItemsListBox.SelectedIndex].Info;
                CostTextBox.Enabled = true;
                NameTextBox.Enabled = true;
                DescriptionTextBox.Enabled = true;
            }
            else
            {
                NameTextBox.Text = "";
                CostTextBox.Text = "";
                IdTextBox.Text = "";
                DescriptionTextBox.Text = "";
                CostTextBox.Enabled = false;
                NameTextBox.Enabled = false;
                DescriptionTextBox.Enabled = false;
            }
        }

        /// <summary>
        /// Событие изменения выбора в списке.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextBoxes(ItemsListBox.SelectedIndex);
        }

        /// <summary>
        /// Событие нажатия кнопки добавления товара.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            Item newItem = new Item();
            newItem.Name = newItem.Id.ToString();
            _items.Add(newItem);
            ItemsListBox.Items.Add(newItem.Name);
            ItemsListBox.SelectedItem = newItem.Name;
        }

        /// <summary>
        /// Событие нажатия кнопки удаления продукта
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int removeIndex = ItemsListBox.SelectedIndex;

            if (removeIndex >= 0)
            {
                ItemsListBox.Items.RemoveAt(removeIndex);
                _items.RemoveAt(removeIndex);
            }
        }

        /// <summary>
        /// Событие изменения текстбокса стоимости.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongCostLabel.Text = "";
                CostTextBox.BackColor = Constants.okColor;
                return;
            }

            float getParse = 0;
            if (!float.TryParse(CostTextBox.Text, out getParse))
            {
                WrongCostLabel.Text = "Стоимость должна быть числом";
                CostTextBox.BackColor = Constants.errorColor;
            }
            else if (getParse <= 0)
            {
                WrongCostLabel.Text = "Стоимость должна быть больше 0.";
                CostTextBox.BackColor = Constants.errorColor;
            }
            else if (getParse > 100000)
            {
                WrongCostLabel.Text = "Стоимость должна быть меньше 1000000.";
                CostTextBox.BackColor = Constants.errorColor;
            }
            else
            {
                WrongCostLabel.Text = "";
                CostTextBox.BackColor = Constants.okColor;
            }

        }

        /// <summary>
        /// Событие изменения текстбокса имени.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongNameLabel.Text = "";
                NameTextBox.BackColor = Constants.okColor;
                return;
            }

            if (NameTextBox.Text.Length == 0)
            {
                WrongNameLabel.Text = "Имя не должно быть пустым.";
                NameTextBox.BackColor = Constants.errorColor;
            }
            else if (NameTextBox.Text.Length > 200)
            {
                WrongNameLabel.Text = "Имя должно быть меньше 200 символов.";
                NameTextBox.BackColor = Constants.errorColor;
            }
            else
            {
                WrongNameLabel.Text = "";
                NameTextBox.BackColor = Constants.okColor;
            }

        }

        /// <summary>
        /// Событие изменения текстбокса описания.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex < 0)
            {
                WrongDescriptionLabel.Text = "";
                DescriptionTextBox.BackColor = Constants.okColor;
                return;
            }

            if (DescriptionTextBox.Text.Length > 1000)
            {
                WrongDescriptionLabel.Text = "Описание должно быть меньше 1000 символов";
                DescriptionTextBox.BackColor = Constants.errorColor;
            }
            else
            {
                WrongDescriptionLabel.Text = String.Empty;
                DescriptionTextBox.BackColor = Constants.okColor;
            }
        }

        /// <summary>
        /// Событие выхода из текстбокса имени.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex >= 0)
            {
                if (NameTextBox.BackColor == Constants.okColor)
                {
                    _items[ItemsListBox.SelectedIndex].Name = NameTextBox.Text;
                    ItemsListBox.Items[ItemsListBox.SelectedIndex] = NameTextBox.Text;
                }
                else
                {
                    NameTextBox.Text = _items[ItemsListBox.SelectedIndex].Name;
                }
            }
        }

        /// <summary>
        /// Событие выхода из текстбокса стоимости.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void CostTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex >= 0)
            {
                if (CostTextBox.BackColor == Constants.okColor)
                {
                    _items[ItemsListBox.SelectedIndex].Cost = float.Parse(CostTextBox.Text);
                }
            }

            CostTextBox.Text = _items[ItemsListBox.SelectedIndex].Cost.ToString();
        }

        /// <summary>
        /// Событие выхода из текстбокса описания.
        /// </summary>
        /// <param name="sender">Обьект вызвавший событие.</param>
        /// <param name="e">Событие.</param>
        private void DescriptionTextBox_Leave(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedIndex >= 0)
            {
                if (DescriptionTextBox.BackColor == Constants.okColor)
                {
                    _items[ItemsListBox.SelectedIndex].Info = DescriptionTextBox.Text;
                }
                else
                {
                    DescriptionTextBox.Text = _items[ItemsListBox.SelectedIndex].Info;
                }
            }

        }
    }
}
