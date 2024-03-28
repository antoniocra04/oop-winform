﻿using System;

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
        public static void StringLengthCheck(string value, int maxLength, string property)
        {
            if (value.Length < 1)
            {
                throw new
                    ArgumentException($"{property} expect to be grate than 0 symbols.");
            }

            if (value.Length > maxLength)
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
        /// <param name="propertyName">Имя свойства класса.</param>
        public static void FloatLimitCheck(float value, float min,
            float max, string propertyName)
        {
            if (value < min || value > max)
            {
                throw new
                    ArgumentException(
                        $"{propertyName} expected to be from {min} to {max}."
                    );
            }
        }
    }
}
