using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CotacaoDolar
{
    public partial class FrmCotacaoDolar : Form
    {
        public FrmCotacaoDolar()
        {
            InitializeComponent();
            btnSearch.FlatStyle = FlatStyle.Flat;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                    string strURL = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,USD&key=4b3742b2";

                    try
                    {
                        HttpResponseMessage resposta = client.GetAsync(strURL).Result;

                        if (resposta.IsSuccessStatusCode)
                        {
                            var result = resposta.Content.ReadAsStringAsync().Result;

                            Mercado mercado = JsonConvert.DeserializeObject<Mercado>(result);

                            lblBuy.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", mercado.Cotacao.Buy);
                            lblSell.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", mercado.Cotacao.Sell);
                            lblVar.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:P}", mercado.Cotacao.Var / 100);
                        }
                        else
                        {
                            lblBuy.Text = "Error";
                            lblSell.Text = "Error";
                            lblVar.Text = "Error";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblBuy.Text = "Error";
                        lblSell.Text = "Error";
                        lblVar.Text = "Error";
                        MessageBox.Show(ex.Message);
                    }
            }
        }   
    }
}
