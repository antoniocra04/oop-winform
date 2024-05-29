namespace oop_winform.Models.Enums
{
    /// <summary>
    /// Статус заказа.
    /// </summary>
    public enum OrderStatusTypes
    {
        /// <summary>
        /// Новый.
        /// </summary>
        New,
        /// <summary>
        /// В процессе.
        /// </summary>
        Processing,
        /// <summary>
        /// В сборке.
        /// </summary>
        Assembly,
        /// <summary>
        /// Отправлен.
        /// </summary>
        Sent,
        /// <summary>
        /// Доставлен.
        /// </summary>
        Delivered,
        /// <summary>
        /// Возвращен.
        /// </summary>
        Returned,
        /// <summary>
        /// Отклонен.
        /// </summary>
        Abandoned
    }
}
