using oop_winform.Models;
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
                    UpdateItemsListBox();
                }
            }
        }

        /// <summary>
        /// Установка корректных данных в тексбоксах.
        /// </summary>
        /// <param name="index">Индекс товара.</param>
        private void SetTextBoxes(int selectedIndex)
        {
            var isSelectedIndexCorrect = selectedIndex >= 0;
            CostTextBox.Enabled = isSelectedIndexCorrect;
            NameTextBox.Enabled = isSelectedIndexCorrect;
            DescriptionTextBox.Enabled = isSelectedIndexCorrect;
            if (isSelectedIndexCorrect)
            {
                NameTextBox.Text = Items[ItemsListBox.SelectedIndex].Name;
                CostTextBox.Text = Items[ItemsListBox.SelectedIndex].Cost.ToString();
                IdTextBox.Text = Items[ItemsListBox.SelectedIndex].Id.ToString();
                DescriptionTextBox.Text = Items[ItemsListBox.SelectedIndex].Info;
            }
            else
            {
                NameTextBox.Text = "";
                CostTextBox.Text = "";
                IdTextBox.Text = "";
                DescriptionTextBox.Text = "";
            }
        }

        /// <summary>
        /// Обновляет данные в ItemList.
        /// </summary>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        private void UpdateItemsListBox()
        {
            ItemsListBox.Items.Clear();
            foreach (var item in Items)
            {
                ItemsListBox.Items.Add(item.Name);
            }
        }

        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            _currentItem = _items[index];
            SetTextBoxes(ItemsListBox.SelectedIndex);
            NameTextBox.Text = _currentItem.Name;
            DescriptionTextBox.Text = _currentItem.Info;
            CostTextBox.Text = _currentItem.Cost.ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newItem = new Item();
            newItem.Name = $"Item{newItem.Id}";
            _currentItem = newItem;
            Items.Add(newItem);
            ItemsListBox.Items.Add(newItem.Name);
            ItemsListBox.SelectedIndex = ItemsListBox.Items.Count - 1;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int removeIndex = ItemsListBox.SelectedIndex;

            if (removeIndex >= 0)
            {
                ItemsListBox.Items.RemoveAt(removeIndex);
                _items.RemoveAt(removeIndex);
            }
        }

        private void CostTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                string cost = CostTextBox.Text;
                _currentItem.Cost = float.Parse(cost);
                _items[ItemsListBox.SelectedIndex].Cost = float.Parse(CostTextBox.Text);
            }
            catch
            {
                CostTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            CostTextBox.BackColor = Constants.CorrectColor;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                string name = NameTextBox.Text;
                _currentItem.Name = name;
                _items[ItemsListBox.SelectedIndex].Name = NameTextBox.Text;
                ItemsListBox.Items[ItemsListBox.SelectedIndex] = NameTextBox.Text;
            }
            catch
            {
                CostTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            CostTextBox.BackColor = Constants.CorrectColor;
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = ItemsListBox.SelectedIndex;

            if (index == -1) return;

            try
            {
                string info = DescriptionTextBox.Text;
                _currentItem.Info = info;
                _items[ItemsListBox.SelectedIndex].Info = DescriptionTextBox.Text;
            }
            catch
            {
                CostTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            CostTextBox.BackColor = Constants.CorrectColor;
        }
    }
}
