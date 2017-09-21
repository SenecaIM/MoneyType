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
            CurrencyInfo reportingcurrency = CurrencyInfoCollection.GetCurrencyInfo("GBP");

            InstrumentCollection icoll = new InstrumentCollection();
            icoll.Fill(DateTime.Now.Date, reportingcurrency);
             
            List<Transaction> transvod = new List<Transaction>();
            transvod.Add(new Transaction(new Quantity(100), DateTime.Now.AddDays(-1000)));
            transvod.Add(new Transaction(new Quantity(2100), DateTime.Now.AddDays(-100)));
            transvod.Add(new Transaction(new Quantity(80), DateTime.Now.AddDays(-10)));

            Holding hvod = new Holding(icoll.GetInstrument(1), transvod);

            List<Transaction> transapl = new List<Transaction>();
            transapl.Add(new Transaction(new Quantity(45), DateTime.Now.AddDays(-2000)));
            transapl.Add(new Transaction(new Quantity(200), DateTime.Now.AddDays(-222)));
            transapl.Add(new Transaction(new Quantity(70), DateTime.Now.AddDays(-22)));

            Holding hapl = new Holding(icoll.GetInstrument(2), transapl);

            Valuation v = new Valuation(CurrencyInfoCollection.GetCurrencyInfo("GBP"));
            v.Items.Add(hapl);
            v.Items.Add(hvod);

            //MessageBox.Show(hvod.ReportingValue.ToCurrency());
            //hvod.ReportingValue.Value = 5;
            //MessageBox.Show(hvod.ReportingValue.ToDetailedCurrency());

            //MessageBox.Show("local " + v.ExposureToLocal(CurrencyInfoCollection.GetCurrencyInfo("USD")).ToCurrency() +", reporting " + v.ExposureToReporting(CurrencyInfoCollection.GetCurrencyInfo("USD")).ToCurrency());// .ToDetailedCurrency());
            //MessageBox.Show(v.BookValue().ToDetailedCurrency());
        }

        private void price_Changed(object sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show(e.PropertyName);

            DataSet ds = new DataSet();

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Value", typeof(string)));

            ds.Tables.Add(dt);

            DataRow dr = dt.NewRow();
            dr["ID"] = 1;
            dr["Value"] = "Test";

            dt.Rows.Add(dr);
        }
    }
}
