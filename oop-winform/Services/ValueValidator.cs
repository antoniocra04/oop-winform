using System;

namespace oop_winform.Services
{
    /// <summary>
    /// Осуществляет валидацию входных данных.
    /// </summary>
    public static class ValueValidator
    {
        /// <summary>
        /// Проверка на превышение длинны строки.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <param name="maxLength">Максимальная длина.</param>
        /// <param name="property">Имя свойства класса.</param>
        public static void StringLengthCheck(string value, int maxLength, int minLength, string property)
        {
            if (value.Length > maxLength || value.Length < minLength)
            {
                throw new
                    ArgumentException($"{property} expect to be less than {maxLength} symbols.");
            }
        }

        /// <summary>
        /// Проверка числа на диапазон.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="min">Минимальное число (нижняя граница).</param>
        /// <param name="max">Максимальное число (верхняя граница).</param>
        /// <param name="property">Имя свойства класса.</param>
        public static void FloatLimitCheck(
            float value,
            float min,
            float max,
            string property)
        {
            if (value < min || value > max)
            {
                throw new
                    ArgumentException(
                        $"{property} expected to be from {min} to {max}."
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

        /// <summary>
        /// Проверка числа на вхождение в нижний предел.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="minimum">Минимальное число (нижняя граница).</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void CheckDigitOnLowLimit(int value, int minimum, string propertyName)
        {
            if (value < minimum)
            {
                throw new
                    ArgumentException(
                    $"{propertyName} expect to be less than {minimum}.");
            }
        }

        /// <summary>
        /// Проверка числа на вхождение в заданные границы.
        /// </summary>
        /// <param name="value">Входное значение.</param>
        /// <param name="minimum">Минимальное число.</param>
        /// <param name="maximum">Максимальное число.</param>
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void CheckLimitInInt(
            int value,
            int minimum,
            int maximum,
            string propertyName)
        {
            if (value > maximum || value < minimum)
            {
                throw new
                    ArgumentException(
                    $"{propertyName} less than {minimum} or greater than {maximum}.");
            }
        }
    }
}
