using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using src.Interface;

namespace src.Core
{
    public class LineParser : ILineParser
    {
        const string ImportedText = "imported";
        const string StartOfPriceText = "at";
        readonly List<string> _text = new List<string>();
        readonly bool _imported = false;
        readonly string _name;
        readonly string _fullName;
        
        public LineParser(string text)
        {
            _text = text.Split(' ').ToList();
            _imported = text.Contains(ImportedText);
            _name = ExtractFullName( true );
            _fullName = ExtractFullName( false );
        }

        public int GetAmount()
        {
            int amount = 0;
            if ( int.TryParse( _text[0], out amount) )
            {
                return amount;
            }
            throw new ArgumentException("invalid input for amount value");
        }

        public string ExtractFullName( bool removeImported )
        {
            var sb = new StringBuilder();
            int i = 1;
            while( i < _text.Count && _text[i] != StartOfPriceText)
            {
                sb.Append(_text[i]);
                sb.Append(" ");
                i++;
            }

            string name = sb.ToString();
            if (removeImported)
            {
                if ( IsImport() )
                {
                    // remove imported first
                    int idx = name.IndexOf(ImportedText);
                    name = name.Remove( idx, ImportedText.Length+1);
                }
            }
            return name.Trim();
        }

        public string GetName()
        {
            
            return _name;
        }

        public string GetFullName()
        {
            
            return _fullName;
        }

        public decimal GetPrice()
        {
            int i = 1;
            while( i < _text.Count && _text[i] != StartOfPriceText )
            {
                i++;
            }

            if ( _text[i] == StartOfPriceText)
            {
                decimal price = 0;
                if ( decimal.TryParse( _text[i+1].Trim(), out price) )
                {
                    return price;
                }
            }
            throw new ArgumentException("invalid input for price value");
        }

        public bool IsImport()
        {
            return _imported;
        }
    }
}
