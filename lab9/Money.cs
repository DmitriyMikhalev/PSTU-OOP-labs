﻿using System;
using System.Collections.Generic;
using System.Text;

namespace lab9
{
    class Money
    {
        private uint _rubles;
        private uint _kopecks;
        public static uint Count;
        private const uint _MaxKopecksValue = 99;
        private const uint _KopecksInRuble = 100;
        public uint Rubles
        {
            get { return _rubles; }
            set { _rubles = value; }
        }
        public uint Kopecks
        {
            get { return _kopecks; }
            set
            {
                if (value > _MaxKopecksValue) _kopecks = _MaxKopecksValue;
                else _kopecks = value;
            }
        }
        public Money() { Count++; }
        public Money(in uint kopecks)
        {
            if (kopecks > _MaxKopecksValue) _rubles = kopecks / _KopecksInRuble;
            _kopecks = kopecks - _rubles * _KopecksInRuble;
            Count++;
        }

        public Money(in uint rubles, in uint kopecks) : this(kopecks) { _rubles = rubles; }

        public Money(Money toCopy)
        {
            _rubles = toCopy._rubles;
            _kopecks = toCopy._kopecks;
            Count++;
        }

        public static Money operator+(in Money prev, in uint additionalKopecks)
        {
            return new Money(kopecks: prev.ToKopecks() + additionalKopecks);
        }

        public static Money operator+(in Money objLeft, in Money objRight)
        {
            return new Money(objLeft.ToKopecks() + objRight.ToKopecks());
        }

        public static Money operator-(in Money objLeft, in Money objRight)
        {
            if (objRight.ToKopecks() > objLeft.ToKopecks()) throw new ArgumentException("Invalid values for the difference.");

            return new Money(objLeft.ToKopecks() - objRight.ToKopecks());
        }

        public static Money operator++(in Money obj)
        {
            return new Money(kopecks: obj.ToKopecks() + 1);
        }
        public static Money operator--(in Money obj)
        {
            return new Money(kopecks: obj.ToKopecks() - 1);
        }

        public static explicit operator int(in Money obj)
        {
            return (int)obj._rubles;
        }

        public static implicit operator double(in Money obj)
        {
            return ((double)(obj._kopecks)) / _KopecksInRuble;
        }
        public Money AddCopecks(in uint additionalKopecks)
        {
            return new Money(kopecks: this.ToKopecks() + additionalKopecks);
        }
        public static Money AddCopecks(in Money obj, in uint additionalKopecks)
        {
            return new Money(kopecks: obj.ToKopecks() + additionalKopecks);
        }
        public string GetInfo() { return $"{_rubles} руб. {_kopecks} коп."; }

        public uint ToKopecks() { return _kopecks + _KopecksInRuble * _rubles; }
    }
}
