using System;

namespace oop_winform.Services
{
    /// <summary>
    /// Осуществляет валидацию входных данных.
    /// </summary>
    static internal class ValueValidator
    {
        /// <summary>
        /// Проверка на превышение длинны строки.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <param name="maxLength">Максимальная длина.</param>
        /// <param name="property">Имя свойства класса.</param>
        static public void StringLengthCheck(string value, int maxLength, string property)
        {
            if (value.Length > maxLength)
            {
                throw new 
                    ArgumentException(property + " должно быть меньше " + maxLength + " символов.");
            }
        }
    }
}
