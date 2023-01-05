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
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;
        public string Id = "";
        public string Nome = "";
        public string Sobrenome = "";
        public string Acesso = "";

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria frm = new frmCategoria();
            frm.MdiParent = this;
            frm.Show();
        }

        private void apresentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApresentacao frm = new frmApresentacao();
            frm.MdiParent = this;
            frm.Show();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProduto frm = frmProduto.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            GestaoUsuario();
            tsUsuario.Text = Nome;
            tsAcesso.Text = Acesso;
        }

        private void GestaoUsuario()
        {
            if (Acesso == "Administrador")
            {
                menuProdutos.Enabled = true;
                menuVendas.Enabled = true;
                menuCompras.Enabled = true;
                menuConsultas.Enabled = true;
                menuFerramentas.Enabled = true;
                menuConfiguracoes.Enabled = true;
                menuExibir.Enabled = true;
                menuJanelas.Enabled = true;
                menuSistema.Enabled = true;
            }
            else if (Acesso == "Gerente")
            {
                menuProdutos.Enabled = true;
                menuVendas.Enabled = true;
                menuCompras.Enabled = true;
                menuConsultas.Enabled = true;
                menuFerramentas.Enabled = false;
                menuConfiguracoes.Enabled = true;
                menuExibir.Enabled = true;
                menuJanelas.Enabled = true;
                menuSistema.Enabled = true;
            }
            else
            {
                menuProdutos.Enabled = true;
                menuVendas.Enabled = true;
                menuCompras.Enabled = false;
                menuConsultas.Enabled = true;
                menuFerramentas.Enabled = false;
                menuConfiguracoes.Enabled = false;
                menuExibir.Enabled = true;
                menuJanelas.Enabled = true;
                menuSistema.Enabled = true;
            }
        }
    }
}
