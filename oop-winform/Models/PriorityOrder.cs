using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_winform.Models
{
    public class PriorityOrder : Order
    {
        /// <summary>
        /// Возвращает и задает дату доставки.
        /// </summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Возвращает и задает время доставки.
        /// </summary>
        public OrderTime DeliveryTime { get; set; }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="PriorityOrder"/>.
        /// </summary>
        public PriorityOrder(){}

        /// <summary>
        /// Создаёт экземпляр класса <see cref="PriorityOrder"/>.
        /// </summary>
        /// <param name="status">Статус заказа.</param>
        /// <param name="address">Адрес.</param>
        /// <param name="items">Товары заказа.</param>
        /// <param name="deliveryDate">Дата доставки.</param>
        /// <param name="deliveryTime">Время доставки.</param>
        public PriorityOrder(
            OrderStatusTypes status,
            Address address,
            List<Item> items,
            DateTime deliveryDate,
            OrderTime deliveryTime
            ) : base(status, address, items)
        {
            DeliveryDate = deliveryDate;
            DeliveryTime = deliveryTime;
        }
    }
}
