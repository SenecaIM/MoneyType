using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinancialTypes
{
    public class Price : INotifyPropertyChanged, ICurrencyInfoBased
    {
        public Price(decimal value, string iso)
        {
            Value = value;
            CurrencyInfo = CurrencyInfoCollection.GetCurrencyInfo(iso);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private decimal mvalue = 0;
        public decimal Value { get => mvalue; set => SetField(ref mvalue, value); }

        private CurrencyInfo currencyinfo;
        public CurrencyInfo CurrencyInfo { get => currencyinfo; set => SetField(ref currencyinfo, value); }

        protected bool SetField<T>(ref T field, T value,
        [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}