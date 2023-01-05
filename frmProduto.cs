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
    public partial class frmProduto : Form
    {
        DialogResult Opcao;
        private bool eNovo = false;
        private bool eEditar = false;
        private static frmProduto _Intancia;

        public static frmProduto GetInstancia()
        {
            if (_Intancia == null)
            {
                _Intancia = new frmProduto();
            }
            return _Intancia;
        }

        public void setCategoria(string idCategoria, string Nome)
        {
            this.txtIdcategoria.Text = idCategoria;
            this.txtcategoria.Text = Nome;
        }

        public frmProduto()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtNome, "Insira o nome do produto");
            this.ttMensagem.SetToolTip(this.pxImagem, "Insira a imagem para o produto");
            this.ttMensagem.SetToolTip(this.cbApresentacao, "Selecione uma apresentação do produto");
            this.ttMensagem.SetToolTip(this.txtcategoria, "Selecione uma categoria do produto");
            this.txtIdcategoria.Enabled = false;
            this.txtcategoria.Enabled = false;
            this.txtId.Enabled = false;
            this.ComboApresentacao();
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
            this.txtId.Text = string.Empty;
            this.txtDescricao.Text = string.Empty;
            this.txtCodigo.Text = string.Empty;
            this.txtIdcategoria.Text = string.Empty;
            this.txtcategoria.Text = string.Empty;
            this.pxImagem.Image = global::CamadaApresentação.Properties.Resources.semimagem;
        }

        //Habilitar txt
        private void Habilitar(bool valor)
        {
            this.txtNome.ReadOnly = !valor;
            this.txtId.ReadOnly = !valor;
            this.txtDescricao.ReadOnly = !valor;
            this.txtCodigo.ReadOnly = !valor;
            this.cbApresentacao.Enabled = valor;
            this.btnBuscar.Enabled = valor;
            this.btnCarregar.Enabled = valor;
            this.btnLimpar.Enabled = valor;

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
                this.btnBuscarCategoria.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
                this.btnBuscarCategoria.Enabled = false;
            }
        }

        //Ocultar Coluna Grid
        private void OcultarColunas()
        {
            this.dataLista.Columns[0].Visible = false;
            this.dataLista.Columns[1].Visible = false;
            this.dataLista.Columns[5].Visible = false;
            this.dataLista.Columns[6].Visible = false;
            this.dataLista.Columns[8].Visible = false;
        }

        //Mostrar no data grid
        private void Mostrar()
        {
            this.dataLista.DataSource = Nproduto.Mostrar();
            this.OcultarColunas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count);
        }

        //Buscar pelo nome
        private void BuscarNome()
        {
            this.dataLista.DataSource = Nproduto.BuscarNome(this.txtBuscar.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count);
        }

        private void ComboApresentacao()
        {
            cbApresentacao.DataSource = Napresentacao.Mostrar();
            cbApresentacao.ValueMember = "IdApresentacao";
            cbApresentacao.DisplayMember = "nome";
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botoes();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagem.Image = Image.FromFile(dialog.FileName);

            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.pxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagem.Image = global::CamadaApresentação.Properties.Resources.semimagem;
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
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";
                if (this.txtNome.Text == string.Empty || this.txtIdcategoria.Text == string.Empty || this.txtCodigo.Text == string.Empty)
                {
                    MensagemErro("Preencha os campos");
                    errorIcone.SetError(txtNome, "Insira o nome");
                    errorIcone.SetError(txtIdcategoria, "Insira a Categoria");
                    errorIcone.SetError(txtCodigo, "Insira o código do Produto");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagem.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imagem = ms.GetBuffer();

                    if (this.eNovo)
                    {
                        resp = Nproduto.Inserir(this.txtCodigo.Text, this.txtNome.Text.Trim().ToUpper(), this.txtDescricao.Text.Trim(), imagem, Convert.ToInt32(this.txtIdcategoria.Text),Convert.ToInt32(cbApresentacao.SelectedValue));
                    }
                    else
                    {
                        resp = Nproduto.Editar(Convert.ToInt32(this.txtId.Text), this.txtCodigo.Text, this.txtNome.Text.Trim().ToUpper(), this.txtDescricao.Text.Trim(), imagem, Convert.ToInt32(this.txtIdcategoria.Text), Convert.ToInt32(cbApresentacao.SelectedValue));
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

        private void dataLista_DoubleClick(object sender, EventArgs e)
        {
            this.txtId.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["idproduto"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["codigo"].Value);
            this.txtNome.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["nome"].Value);
            this.txtDescricao.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["descricao"].Value);

            byte[] imagenBuffer = (Byte[])this.dataLista.CurrentRow.Cells["imagem"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            this.pxImagem.Image = Image.FromStream(ms);
            this.pxImagem.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdcategoria.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["Idcategoria"].Value);
            this.txtcategoria.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["categoria"].Value);
            this.cbApresentacao.SelectedValue = Convert.ToString(this.dataLista.CurrentRow.Cells["Idapresentacao"].Value);


            this.tabControl1.SelectedIndex = 1;
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

                if (chkDeletar.Checked == false || Convert.ToBoolean(dataLista.Columns[0].Selected = false))
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
                            Resp = Nproduto.Excluir(Convert.ToInt32(Codigo));

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

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            frmBuscarCategoria form = new frmBuscarCategoria();
            form.ShowDialog();
        }
    }
}
