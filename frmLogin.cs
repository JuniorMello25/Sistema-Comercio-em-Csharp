using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamadaApresentação
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            DataTable Dados = CamadaNegocio.Nfuncionario.Login(txtUsuario.Text, txtSenha.Text);

            if (Dados.Rows.Count == 0)
            {
                MessageBox.Show("Usuário não Existe", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmPrincipal frm = new frmPrincipal();
                frm.Id = Dados.Rows[0][0].ToString();
                frm.Nome = Dados.Rows[0][1].ToString();
                frm.Sobrenome = Dados.Rows[0][2].ToString();
                frm.Acesso = Dados.Rows[0][3].ToString();
                frm.Show();
                this.Hide();
            }
        }
    }
}
