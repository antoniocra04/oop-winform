using oop_winform.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace oop_winform.View.ModalWindows
{
    public partial class DiscountModalWindow : Form
    {
        /// <summary>
        /// Возвращает категорию товара скидки.
        /// </summary>
        public CategoryTypes Category { get; set; }

        /// <summary>
        /// Возвращает покупателя.
        /// </summary>
        public Customer Customer { get; }

        public DiscountModalWindow(Customer customer)
        {
            InitializeComponent();
            Customer = customer;
            UpdateCategoryComboBox();
        }

        /// <summary>
        /// Обновляет данные выпадающего списка категорий товара.
        /// </summary>
        private void UpdateCategoryComboBox()
        {
            var customerCategories = Customer.Discounts
                .OfType<PercentDiscount>()
                .Select(discount => discount.Category)
                .Distinct()
                .ToList();

            var dataCategories = Enum.GetValues(typeof(CategoryTypes))
                .Cast<CategoryTypes>()
                .ToList()
                .Except(customerCategories)
                .ToList();

            CategoryComboBox.DataSource = dataCategories;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Category = (CategoryTypes)Enum.Parse(
                typeof(CategoryTypes),
                CategoryComboBox.SelectedItem.ToString());
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OkButton.Enabled = CategoryComboBox.SelectedIndex >= 0;
        }
    }
}
