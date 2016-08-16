using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NetCloneFuzzer
{
    [XmlRoot]
    public class FilterContainer : IListSource
    {
        [XmlArray]
        public List<FilterEntry> Filters { get; private set; }

        [XmlIgnore]
        public bool HasFilters
        {
            get
            {
                if (this.Filters == null || this.Filters.Count <= 0) { return false; }
                if (this.Filters.Count == 1 && string.IsNullOrEmpty(this.Filters[0].Regex)) { return false; }
                return true;
            }
        }

        [XmlIgnore]
        public bool ContainsListCollection { get { return false; } }

        public IList GetList()
        {
            return (IList)this.Filters;
        }

        public FilterContainer()
        {
            this.Filters = new List<FilterEntry>();
        }

        public void Save(string filename)
        {
            XmlHelper<FilterContainer>.WriteToFile(this, filename);
        }

        public void Load(string filename)
        {
            FilterContainer newContainer = XmlHelper<FilterContainer>.ReadFromFile(filename);
            this.Filters.Clear();
            foreach (var filter in newContainer.Filters)
            {
                this.Filters.Add(filter);
            }
        }
    }

    public class FilterEntry
    {
        [XmlAttribute]
        public FilterType Type { get; set; }
        [XmlAttribute]
        public string Regex { get; set; }
        [XmlArray]
        public List<FilterMatchGroupManipulation> Manipulations { get; private set; }

        public FilterEntry()
        {
            this.Manipulations = new List<FilterMatchGroupManipulation>();
        }
        public FilterEntry(FilterType type, string regex) : this()
        {
            this.Type = type;
            this.Regex = regex;
        }
    }

    public class FilterMatchGroupManipulation
    {
        private static char[] randomCharBase = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private static Random rnd = new Random();

        [XmlAttribute]
        public string GroupName { get; set; }
        [XmlAttribute]
        public FilterManipulationType ManipulationType { get; set; }
        [XmlAttribute]
        public string Value { get; set; }

        public FilterMatchGroupManipulation() { }
        public FilterMatchGroupManipulation(string groupName, FilterManipulationType type) : this(groupName, type, null) { }
        public FilterMatchGroupManipulation(string groupName, FilterManipulationType type, string value)
        {
            this.GroupName = groupName;
            this.ManipulationType = type;
            this.Value = value;
        }

        public string GetReplacementValue(string baseValue)
        {
            var length = baseValue.Length;

            if (this.ManipulationType == FilterManipulationType.NumberDecrement || this.ManipulationType == FilterManipulationType.NumberIncrement)
            {
                int baseNumber = 0;
                if (!int.TryParse(baseValue, out baseNumber)) { return baseValue; }

                int numberLength = baseValue.Length;

                switch (this.ManipulationType)
                {
                    case FilterManipulationType.NumberIncrement:
                        baseNumber++;
                        break;
                    case FilterManipulationType.NumberDecrement:
                        baseNumber--;
                        if (baseNumber < 0)
                        {
                            baseNumber = int.Parse(new string('9', numberLength));
                        }
                        break;
                }

                string numberValue = baseNumber.ToString();
                if (numberValue.Length < numberLength)
                {
                    numberValue = numberValue.PadLeft(numberLength, '0');
                }
                return numberValue.Substring(numberValue.Length - numberLength);
            }
            else if (this.ManipulationType == FilterManipulationType.RandomCharLowerCase)
            {
                StringBuilder newValue = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                {
                    newValue.Append(randomCharBase[rnd.Next(randomCharBase.GetLowerBound(0), randomCharBase.GetUpperBound(0))].ToString().ToLower());
                }
                return newValue.ToString();
            }
            else if (this.ManipulationType == FilterManipulationType.RandomCharUpperCase)
            {
                StringBuilder newValue = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                {
                    newValue.Append(randomCharBase[rnd.Next(randomCharBase.GetLowerBound(0), randomCharBase.GetUpperBound(0))].ToString().ToUpper());
                }
                return newValue.ToString();
            }
            else if (this.ManipulationType == FilterManipulationType.RandomByte)
            {
                var charArr = new byte[length];
                for (int i = 0; i < length; i++)
                {
                    charArr[i] = (byte)rnd.Next(33, 126);
                }
                return System.Text.Encoding.ASCII.GetString(charArr);
            }
            else if (this.ManipulationType == FilterManipulationType.RandomNumber)
            {
                StringBuilder newValue = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                {
                    newValue.Append(rnd.Next(0, 9).ToString());
                }
                return newValue.ToString();
            }
            else if (this.ManipulationType == FilterManipulationType.StaticText)
            {
                return this.Value;
            }

            return baseValue;
        }
    }

    public enum FilterType
    {
        Header,
        Body,
        HeaderAndBody
    }

    public enum FilterManipulationType
    {
        NumberIncrement,
        NumberDecrement,
        RandomCharLowerCase,
        RandomCharUpperCase,
        RandomByte,
        RandomNumber,
        StaticText
    }
}
