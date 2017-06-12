using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialTypes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Price p = new Price(1.234m, "GBP");
            Quantity q = new Quantity(25);
            Money m = new Money(p, q);

            List<Transaction> transvod = new List<Transaction>();
            transvod.Add(new Transaction(new Quantity(100)));
            transvod.Add(new Transaction(new Quantity(2100)));
            transvod.Add(new Transaction(new Quantity(80)));

            Holding hvod = new Holding(new FinancialTypes.Instrument(234, "GBP"), transvod);

            List<Transaction> transapl = new List<Transaction>();
            transapl.Add(new Transaction(new Quantity(100)));
            transapl.Add(new Transaction(new Quantity(2100)));
            transapl.Add(new Transaction(new Quantity(80)));

            Holding hapl = new Holding(new FinancialTypes.Instrument(444, "USD", 300, "GBP"), transapl);

            Valuation v = new Valuation(CurrencyInfoCollection.GetCurrencyInfo("GBP"));
            v.Items.Add(hapl);
            v.Items.Add(hvod);
            
             

            //MessageBox.Show(m.ToNumber());
            //MessageBox.Show(m.ToCurrency());

            MessageBox.Show(hvod.ReportingValue.ToCurrency());
            MessageBox.Show(hvod.ReportingValue.ToDetailedCurrency());

            MessageBox.Show("local " + v.ExposureToLocal(CurrencyInfoCollection.GetCurrencyInfo("USD")).ToCurrency() +", reporting " + v.ExposureToReporting(CurrencyInfoCollection.GetCurrencyInfo("USD")).ToCurrency());// .ToDetailedCurrency());
            MessageBox.Show(v.BookValue().ToDetailedCurrency());
        }
    }
}
