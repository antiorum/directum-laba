namespace Task8
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Поддерживает простой перебор элементов коллекции строк.
    /// </summary>
    public class StringVaultEnum : IEnumerator<string>
    {
        /// <summary>
        /// Внутреннее хранилище строк.
        /// </summary>
        private List<string> strings;

        /// <summary>
        /// Позиция перечислителя.
        /// </summary>
        private int position = -1;

        /// <summary>
        /// Конструктор, который заполняет внутренее хранилище.
        /// </summary>
        /// <param name="strings">Список строк.</param>
        public StringVaultEnum(List<string> strings)
        {
            this.strings = strings;
        }

        /// <summary>
        /// Текущий элемент, соответствующий позиции перечислителя.
        /// </summary>
        public string Current
        {
            get
            {
                try
                {
                    return this.strings[this.position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Текущий элемент, соответствующий позиции перечислителя.
        /// </summary>
        object IEnumerator.Current => this.Current;

        /// <summary>
        /// Пустая реализация, так как нет неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Двигает указатель на одну позицию вперед.
        /// </summary>
        /// <returns>Достиг ли указатель конца коллекции.</returns>
        public bool MoveNext()
        {
            this.position++;
            return this.position < this.strings.Count;
        }

        /// <summary>
        /// Сбрасывает указатель на начальное состояние.
        /// </summary>
        public void Reset()
        {
            this.position = -1;
        }  
    }
}
