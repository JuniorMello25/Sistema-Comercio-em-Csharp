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
    public partial class frmFornecedor : Form
    {
        DialogResult Opcao;
        private bool eNovo = false;
        private bool eEditar = false;

        public frmFornecedor()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtEmpresa, "Insira o nome da empresa");
        }

        //Metodo mensagem de confirmação
        private void MensagemOk(string mensagem)
        {
            MessageBox.Show(mensagem, "Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Metodo mensagem de erro
        private void MensagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Sitema", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //Metodo Limpar Campos

        private void Limpar()
        {
            this.txtEmpresa.Text = string.Empty;
            this.txtNumDoc.Text = string.Empty;
            this.txtEndereco.Text = string.Empty;
            this.txtTelefone.Text = string.Empty;
            this.txtUrl.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
        }

        //Habilitar txt
        private void Habilitar(bool valor)
        {
            this.txtId.ReadOnly = !valor;
            this.txtEmpresa.ReadOnly = !valor;
            this.txtNumDoc.ReadOnly = !valor;
            this.txtEndereco.ReadOnly = !valor;
            this.txtTelefone.ReadOnly = !valor;
            this.txtUrl.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.cbSetorComercial.Enabled = valor;
            this.cbTipoDoc.Enabled = valor;
        }

        //Habilitar botoes
        private void Botoes()
        {
            if (this.eNovo || this.eEditar)
            {
                this.Habilitar(true);
                this.btnNovo.Enabled = false;
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
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
            this.dataLista.DataSource = Nfornecedor.Mostrar();
            this.OcultarColunas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count);
        }

        //Buscar pela empresa
        private void BuscarEmpresa()
        {
            this.dataLista.DataSource = Nfornecedor.BuscarEmpresa(this.txtBuscar.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count);
        }

        //Buscar pelo documento
        private void BuscarDocumento()
        {
            this.dataLista.DataSource = Nfornecedor.BuscarDocumento(this.txtBuscar.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count);
        }
        private void frmFornecedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botoes();
            this.txtId.Enabled = false;
            this.cbBusca.SelectedIndex = 0;
            this.cbSetorComercial.SelectedIndex = 0;
            this.cbTipoDoc.SelectedIndex = 0;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.cbBusca.Text.Equals("Empresa"))
            {
                this.BuscarEmpresa();
            }
            else
            {
                this.BuscarDocumento();
            }
            
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.eNovo = true;
            this.eEditar = false;
            this.Botoes();
            this.Limpar();
            this.Habilitar(true);
            this.txtEmpresa.Focus();
            this.txtId.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";
                if (this.txtEmpresa.Text == string.Empty)
                {
                    MensagemErro("Preencha os campos");
                    errorIcone.SetError(txtEmpresa, "Insira o nome da empresa");
                }
                else
                {
                    if (this.eNovo)
                    {
                        resp = Nfornecedor.Inserir(this.txtEmpresa.Text.Trim().ToUpper(), this.cbSetorComercial.Text, this.cbTipoDoc.Text, this.txtNumDoc.Text.Trim().ToUpper(), this.txtEndereco.Text, this.txtTelefone.Text, this.txtEmail.Text, this.txtUrl.Text);
                    }
                    else
                    {
                        resp = Nfornecedor.Editar(Convert.ToInt32(this.txtId.Text), this.txtEmpresa.Text.Trim().ToUpper(), this.cbSetorComercial.Text, this.cbTipoDoc.Text, this.txtNumDoc.Text.Trim().ToUpper(), this.txtEndereco.Text, this.txtTelefone.Text, this.txtEmail.Text, this.txtUrl.Text);
                    }

                    if (resp.Equals("OK"))
                    {
                        if (this.eNovo)
                        {
                            this.MensagemOk("Registro salvo com sucesso");
                        }
                        else
                        {
                            this.MensagemOk("Registro editado com sucesso");
                        }
                    }
                    else
                    {
                        this.MensagemErro(resp);
                    }

                    this.eNovo = false;
                    this.eEditar = false;
                    this.Limpar();
                    this.Habilitar(false);
                    this.Botoes();
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataLista_DoubleClick(object sender, EventArgs e)
        {
            this.txtId.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["id"].Value);
            this.txtEmpresa.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["empresa"].Value);
            this.cbSetorComercial.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["setor_comercial"].Value);
            this.cbTipoDoc.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNumDoc.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["num_documento"].Value);
            this.txtEndereco.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["endereco"].Value);
            this.txtTelefone.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["telefone"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["email"].Value);
            this.txtUrl.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["url"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtId.Text.Equals(""))
            {
                this.MensagemErro("Selecione um resgistro para editar");
            }
            else
            {
                this.eEditar = true;
                this.Botoes();
                this.Habilitar(true);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.eNovo = false;
            this.eEditar = false;
            this.Botoes();
            this.Habilitar(false);
            this.Limpar();
        }

        private void chkDeletar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeletar.Checked)
            {
                this.dataLista.Columns[0].Visible = true;

            }
            else
            {
                this.dataLista.Columns[0].Visible = false;
            }
        }

        private void dataLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataLista.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dataLista.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                //verificar o chck do deletar
                if (chkDeletar.Checked == false || Convert.ToBoolean(dataLista.Columns["Deletar"].Selected = false))
                {
                    MessageBox.Show("Selecione pelo menos um registro");
                }
                else
                {
                    Opcao = MessageBox.Show("Realmente deseja apagar os registros?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                if (Opcao == DialogResult.OK)
                {
                    string Codigo;
                    string Resp = "";

                    foreach (DataGridViewRow row in dataLista.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Resp = Nfornecedor.Excluir(Convert.ToInt32(Codigo));

                            if (Resp.Equals("OK"))
                            {
                                this.MensagemOk("Registro excluido com sucesso!");
                            }
                            else
                            {
                                this.MensagemErro(Resp);
                            }
                        }
                    }
                    this.Mostrar();
                    chkDeletar.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void cbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtBuscar.Text = string.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.cbBusca.Text.Equals("Empresa"))
            {
                this.BuscarEmpresa();
            }
            else
            {
                this.BuscarDocumento();
            }
        }
    }
}
