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
    public partial class frmCategoria : Form
    {
        DialogResult Opcao;
        private bool eNovo = false;
        private bool eEditar = false;

        public frmCategoria()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtNome, "Insira o nome da categoria");
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
            this.txtNome.Text = string.Empty;
            this.txtIdcategoria.Text = string.Empty;
            this.txtDescricao.Text = string.Empty;
        }

        //Habilitar txt
        private void Habilitar(bool valor)
        {
            this.txtNome.ReadOnly = !valor;
            this.txtIdcategoria.ReadOnly = !valor;
            this.txtDescricao.ReadOnly = !valor;
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
        private void frmCategoria_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botoes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNome();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.eNovo = true;
            this.eEditar = false;
            this.Botoes();
            this.Limpar();
            this.Habilitar(true);
            this.txtNome.Focus();
            this.txtIdcategoria.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";
                if (this.txtNome.Text == string.Empty)
                {
                    MensagemErro("Preencha os campos");
                    errorIcone.SetError(txtNome, "Insira o nome");
                }else
                {
                    if (this.eNovo)
                    {
                        resp = Ncategoria.Inserir(this.txtNome.Text.Trim().ToUpper(), this.txtDescricao.Text.Trim());
                    }
                    else
                    {
                        resp = Ncategoria.Editar(Convert.ToInt32(this.txtIdcategoria.Text), 
                            this.txtNome.Text.Trim().ToUpper(), this.txtDescricao.Text.Trim());
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
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataLista_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdcategoria.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["Idcategoria"].Value);
            this.txtNome.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["nome"].Value);
            this.txtDescricao.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["descricao"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtIdcategoria.Text.Equals(""))
            {
                this.MensagemErro("Selecione um resgistro para inserir");
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
            if(e.ColumnIndex == dataLista.Columns["Deletar"].Index)
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
                            Resp = Ncategoria.Excluir(Convert.ToInt32(Codigo));

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
            }   }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
