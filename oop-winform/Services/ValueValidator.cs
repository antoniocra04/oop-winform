using System;

namespace oop_winform.Services
{
    /// <summary>
    /// Осуществляет валидацию входных данных.
    /// </summary>
    public static class ValueValidator
    {
        /// <summary>
        /// Проверка длины строки в определенном диапазоне.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <param name="maxLength">Максимальная длина.</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        /// <param name="minLength">Минимальная длина.</param>
        public static void StringLengthCheck(string value,
                                            int maxLength, 
                                            int minLength, 
                                            string propertyName)
        {
            if (value.Length > maxLength || value.Length < minLength)
            {
                throw new
                    ArgumentException($"{propertyName} expect to be less than {maxLength} symbols or greater than {minLength} symbols.");
            }
        }

        /// <summary>
        /// Проверка числа на диапазон.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="min">Минимальное число (нижняя граница).</param>
        /// <param name="max">Максимальное число (верхняя граница).</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void FloatLimitCheck(
            float value,
            float min,
            float max,
            string propertyName)
        {
            if (value < min || value > max)
            {
                throw new
                    ArgumentException(
                        $"{propertyName} expected to be from {min} to {max}."
                    );
            }
        }

        /// <summary>
        /// Проверка числа на количество цифр.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="digit">Число разрядов.</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void CheckDigitsInInt(int value, int digit, string propertyName)
        {
            if (value.ToString().Length != digit)
            {
                throw new
                    ArgumentException($"{propertyName} expect to contain {digit} digits.");
            }
        }
    }
}
