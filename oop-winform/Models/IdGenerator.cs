namespace oop_winform.Models
{
    /// <summary>
    /// Класс генератора id.
    /// </summary>
    public static class IdGenerator
    {
        /// <summary>
        /// Статический счетчик.
        /// </summary>
        private static int _id;

        /// <summary>
        /// Генерирует id.
        /// </summary>
        /// <returns>id.</returns>
        public static int GetId()
        {
            _id++;
            return _id;
        }
    }
}
