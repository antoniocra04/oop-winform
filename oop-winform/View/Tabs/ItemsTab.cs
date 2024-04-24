using oop_winform.Models;
using oop_winform.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace oop_winform.View.Tabs
{
    /// <summary>
    /// Вкладка продуктов.
    /// </summary>
    public partial class ItemsTab : UserControl
    {
        /// <summary>
        /// Список товаров.
        /// </summary>
        private List<Item> _items = new List<Item>();

        /// <summary>
        /// Выбранный продукт.
        /// </summary>
        private Item _currentItem;

        /// <summary>
        /// Создает экземпляр класса <see cref="ItemsTab"/>.
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();
            CategoryComboBox.DataSource = Enum.GetValues(typeof(CategoryTypes));
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
                if (value != null)
                {
                    UpdateItemsListBox(ItemsListBox.SelectedIndex);
                }
            }
        }

        /// <summary>
        /// Установка корректных данных в тексбоксах.
        /// </summary>
        private void SetValuesTextBoxes()
        {
            var isSelectedIndexCorrect = ItemsListBox.SelectedIndex != -1;
            CostTextBox.Enabled = isSelectedIndexCorrect;
            NameTextBox.Enabled = isSelectedIndexCorrect;
            DescriptionTextBox.Enabled = isSelectedIndexCorrect;
            CategoryComboBox.Enabled = isSelectedIndexCorrect;

            NameTextBox.Text = isSelectedIndexCorrect ? _currentItem.Name : "";
            CostTextBox.Text = isSelectedIndexCorrect ? _currentItem.Cost.ToString() : "";
            IdTextBox.Text = isSelectedIndexCorrect ? _currentItem.Id.ToString() : "";
            DescriptionTextBox.Text = isSelectedIndexCorrect ? _currentItem.Info : "";
            CategoryComboBox.Text = isSelectedIndexCorrect ? _currentItem.Category.ToString() : "";
        }

        /// <summary>
        /// Обновляет данные в ItemList.
        /// </summary>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        private void UpdateItemsListBox(int selectedIndex)
        {
            ItemsListBox.Items.Clear();
            foreach (var item in Items)
            {
                ItemsListBox.Items.Add(item.Name);
            }
            ItemsListBox.SelectedIndex = selectedIndex;
        }

        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ItemsListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            _currentItem = _items[index];
            SetValuesTextBoxes();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newItem = new Item("Item", "info", 1, CategoryTypes.Cloths);
            Items.Add(newItem);
            UpdateItemsListBox(Items.Count - 1);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var removeIndex = ItemsListBox.SelectedIndex;

            if (removeIndex >= 0)
            {
                Items.RemoveAt(removeIndex);
                UpdateItemsListBox(-1);
            }

            SetValuesTextBoxes();
        }

        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            var index = ItemsListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                var cost = CostTextBox.Text;
                _currentItem.Cost = float.Parse(cost);
                UpdateItemsListBox(ItemsListBox.SelectedIndex);

            }
            catch (ArgumentException exception)
            {
                CostTextBox.BackColor = Constants.ErrorColor;
                return;
            }
            catch (Exception exception)
            {
                CostTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            CostTextBox.BackColor = Constants.CorrectColor;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            var index = ItemsListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                _currentItem.Name = NameTextBox.Text;
                UpdateItemsListBox(ItemsListBox.SelectedIndex);
            }
            catch (ArgumentException exception)
            {
                NameTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            NameTextBox.BackColor = Constants.CorrectColor;
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            var index = ItemsListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                var info = DescriptionTextBox.Text;
                _currentItem.Info = info;
                UpdateItemsListBox(ItemsListBox.SelectedIndex);
            }
            catch (ArgumentException exception)
            {
                DescriptionTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            DescriptionTextBox.BackColor = Constants.CorrectColor;
        }

        private void CategoryComboBox_TextChanged(object sender, EventArgs e)
        {
            var index = ItemsListBox.SelectedIndex;

            if (index == -1) return;

            _currentItem.Category = (CategoryTypes) CategoryComboBox.SelectedItem;
            UpdateItemsListBox(ItemsListBox.SelectedIndex);
        }
    }
}
