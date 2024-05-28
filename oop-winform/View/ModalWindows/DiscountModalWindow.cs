using oop_winform.Models;
using oop_winform.Models.Discounts;
using oop_winform.Models.Enums;
using System;
using System.Linq;
using System.Windows.Forms;

namespace oop_winform.View.ModalWindows
{
    /// <summary>
    /// Модальное окно для добавления новой процентной скидки покупателю.
    /// </summary>
    public partial class DiscountModalWindow : Form
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="DiscountModalWindow"/>.
        /// </summary>
        /// /// <param name="customer">Текущий покупатель.</param>
        public DiscountModalWindow(Customer customer)
        {
            InitializeComponent();
            Customer = customer;
            UpdateCategoryComboBox();
        }

        /// <summary>
        /// Возвращает и задает категорию товара скидки.
        /// </summary>
        public CategoryTypes Category { get; set; }

        /// <summary>
        /// Возвращает покупателя.
        /// </summary>
        public Customer Customer { get; }

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
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OkButton.Enabled = CategoryComboBox.SelectedIndex >= 0;
        }
    }
}
