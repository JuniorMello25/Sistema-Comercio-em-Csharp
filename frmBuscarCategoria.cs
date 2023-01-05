using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaNegocio;

namespace CamadaApresentação
{
    public partial class frmBuscarCategoria : Form
    {
        public frmBuscarCategoria()
        {
            InitializeComponent();
        }

        //Ocultar Coluna Grid
        private void OcultarColunas()
        {
            this.dataLista.Columns[0].Visible = false;
            this.dataLista.Columns[1].Visible = false;
        }

        //Mostrar no data grid
        private void Mostrar()
        {
            this.dataLista.DataSource = Ncategoria.Mostrar();
            this.OcultarColunas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count);
        }

        //Buscar pelo nome
        private void BuscarNome()
        {
            this.dataLista.DataSource = Ncategoria.BuscarNome(this.txtBuscar.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count);
        }

        private void frmBuscarCategoria_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void dataLista_DoubleClick(object sender, EventArgs e)
        {
            frmProduto form = frmProduto.GetInstancia();
            string par1, par2;
            par1 =Convert.ToString(dataLista.CurrentRow.Cells["idcategoria"].Value);
            par2 = Convert.ToString(dataLista.CurrentRow.Cells["nome"].Value);
            form.setCategoria(par1, par2);
            this.Hide();
        }
    }
}
