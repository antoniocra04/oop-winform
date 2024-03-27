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
        private void SetTextBoxes()
        {
            var isSelectedIndexCorrect = ItemsListBox.SelectedIndex >= 0;
            CostTextBox.Enabled = isSelectedIndexCorrect;
            NameTextBox.Enabled = isSelectedIndexCorrect;
            DescriptionTextBox.Enabled = isSelectedIndexCorrect;
            NameTextBox.Text = Items[ItemsListBox.SelectedIndex].Name;
            CostTextBox.Text = Items[ItemsListBox.SelectedIndex].Cost.ToString();
            IdTextBox.Text = Items[ItemsListBox.SelectedIndex].Id.ToString();
            DescriptionTextBox.Text = Items[ItemsListBox.SelectedIndex].Info;
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
            int index = ItemsListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            _currentItem = _items[index];
            SetTextBoxes();
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
            UpdateItemsListBox(Items.Count - 1);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int removeIndex = ItemsListBox.SelectedIndex;

            if (removeIndex >= 0)
            {
                Items.RemoveAt(removeIndex);
                UpdateItemsListBox(-1);
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
            catch(ArgumentException exception)
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
                _currentItem.Name = NameTextBox.Text;
                UpdateItemsListBox(ItemsListBox.SelectedIndex);
            }
            catch(ArgumentException exception)
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
            catch(ArgumentException exception)
            {
                CostTextBox.BackColor = Constants.ErrorColor;
                return;
            }

            CostTextBox.BackColor = Constants.CorrectColor;
        }

        private void SelectedItemPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
