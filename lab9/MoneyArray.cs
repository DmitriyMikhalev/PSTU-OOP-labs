using System;
using System.Collections.Generic;
using System.Text;

namespace lab9
{
    class MoneyArray
    {
        Money[] _array;
        private const int MaxKopecksValue = 99;

        public int Length { get { return _array.Length; } }

        public MoneyArray() { _array = new Money[0]; }

        public MoneyArray(in int size, in Random random = null)
        {
            if (size < 1) throw new ArgumentException("Некорректный размер");

            _array = new Money[size];
            if (random == null) FillArray();
            else FillArray(random: random);
        }
        public MoneyArray(MoneyArray toCopy)
        {
            _array = new Money[toCopy.Length];
            for (int i = 0; i < toCopy.Length; ++i) { _array[i] = new Money(toCopy: toCopy._array[i]); }
        }

        private void FillArray()
        {
            for (int i = 0; i < _array.Length; ++i)
            {
                _array[i] = new Money(
                    Interface.ReadUInt32(message: $"Введите натуральное значение рублей {i + 1}-го элемента (или 0): "),
                    Interface.ReadUInt32(message: $"Введите натуральное значение копеек {i + 1}-го элемента (или 0; до {MaxKopecksValue}): ", maxValue: MaxKopecksValue)
                );
            }
        }

        private void FillArray(in Random random)
        {
            for (int i = 0; i < _array.Length; ++i)
            {
                _array[i] = new Money(
                    rubles: (uint)random.Next(maxValue: 100),
                    kopecks: (uint)random.Next(maxValue: MaxKopecksValue)
                );
            }
        }

        public Money this[int index]
        {
            get 
            {
                if (index < 0 || index >= _array.Length) throw new IndexOutOfRangeException("Индекс вне диапазона значений.");

                return _array[index];
            }
            set 
            {
                if (index < 0 || index >= _array.Length) throw new IndexOutOfRangeException("Индекс вне диапазона значений.");

                _array[index] = value;
            }
        }
    }
}
