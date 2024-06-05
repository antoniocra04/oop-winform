using oop_winform.Models;
using oop_winform.Models.Enums;
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
        /// Список фильтрованных товаров.
        /// </summary>
        private List<Item> _displayedItems;

        /// <summary>
        /// Возвращает и задает делегат критерия фильтрации.
        /// </summary>
        private Predicate<Item> FilterСriterion{ get; set; }

        /// <summary>
        /// Возвращает и задает делегат критерия сортировки.
        /// </summary>
        private DataTools.CompareCriteria SortСriterion { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="ItemsTab"/>.
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();
            ItemsListBox.DisplayMember = "Name";
            CategoryComboBox.DataSource = Enum.GetValues(typeof(CategoryTypes));
            OrderByComboBox.SelectedIndex = 0;
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
                _displayedItems = value;
                if (value != null)
                {
                    UpdateItemsListBox(_displayedItems, -1);
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
        /// Обновить список товаров, который будет выведен на экран.
        /// </summary>
        private void UpdateDisplayedItems()
        {
            var displayedItems = Items;

            if (FilterСriterion != null)
            {
                displayedItems = DataTools.FilterItems(displayedItems, FilterСriterion);
            }

            if (SortСriterion != null)
            {
                displayedItems = DataTools.SortItems(displayedItems, SortСriterion);
            }

            _displayedItems = displayedItems;
            UpdateItemsListBox(_displayedItems, -1);
        }

        /// <summary>
        /// Обновляет данные в ItemList.
        /// </summary>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        private void UpdateItemsListBox(List<Item> currentListItems, int selectedIndex)
        {
            ItemsListBox.Items.Clear();
            foreach (var item in currentListItems)
            {
                ItemsListBox.Items.Add(item);
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

            _currentItem = _displayedItems[index];
            SetValuesTextBoxes();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newItem = new Item("Item", "info", 1, CategoryTypes.Cloths);
            Items.Add(newItem);
            _displayedItems = Items;
            ItemsListBox.Items.Add(newItem);
            UpdateDisplayedItems();
            ItemsListBox.SelectedItem = newItem;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var removeIndex = ItemsListBox.SelectedIndex;

            if (removeIndex >= 0)
            {
                Items.RemoveAt(removeIndex);
                _displayedItems = Items;
                UpdateItemsListBox(_displayedItems, -1);
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
                UpdateItemsListBox(_displayedItems, ItemsListBox.SelectedIndex);

            }
            catch (ArgumentException exception)
            {
                CostTextBox.BackColor = Constants.ErrorColor;
                return;
            }
            catch (FormatException exception)
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
                UpdateItemsListBox(_displayedItems, ItemsListBox.SelectedIndex);
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
                UpdateItemsListBox(_displayedItems, ItemsListBox.SelectedIndex);
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
            UpdateItemsListBox(_displayedItems, ItemsListBox.SelectedIndex);
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FindTextBox.Text.Length == 0)
            {
                FilterСriterion = null;
            }
            else
            {
                FilterСriterion = (item) => { return item.Name.Contains(FindTextBox.Text); };
            }

            UpdateDisplayedItems();
        }

        private void OrderByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (OrderByComboBox.SelectedIndex)
            {
                case 0:
                    SortСriterion = (first, second) =>
                    {
                        return first.Name.CompareTo(second.Name) < 0;
                    };
                    break;
                case 1:
                    SortСriterion = (first, second) =>
                    {
                        return first.Cost.CompareTo(second.Cost) < 0;
                    };
                    break;
                case 2:
                    SortСriterion = (first, second) =>
                    {
                        return first.Cost.CompareTo(second.Cost) > 0;
                    };
                    break;
            }

            var selectedItem = ItemsListBox.SelectedItem;
            _displayedItems = _items;
            UpdateDisplayedItems();
            ItemsListBox.SelectedItem = selectedItem;
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            var selectedItem = ItemsListBox.SelectedItem;
            UpdateDisplayedItems();
            ItemsListBox.SelectedItem = selectedItem;
        }
    }
}
