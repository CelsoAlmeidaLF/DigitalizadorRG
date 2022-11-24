using DigitalizadorRG.Properties;
using System.Data;
using System.Xml.Linq;

namespace DigitalizadorRG
{
    public partial class frmDigitalizador : Form
    {
        public frmDigitalizador()
        {
            InitializeComponent();
        }

        private void txtCaminho_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                string caminho = open.FileName;
                Image imgDoc = new Bitmap(caminho);
                this.imgSection.Image = imgDoc;
                this.txtCaminho.Text = caminho;
            }
        }

        private void btnDigitalizar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCaminho.Text))
            {
                MessageBox.Show("Insira um arquivo de RG para ser digitalizado!", "Aviso!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                var bll = new BLL_BuildImage(this.imgSection.Image);

                bll.AddDictionary("NOME", new Rectangle(62, 120, 490, 32));
                bll.AddDictionary("RG", new Rectangle(130, 52, 190, 38));
                bll.AddDictionary("CPF", new Rectangle(54, 404, 180, 32));
                bll.AddDictionary("DTNASC", new Rectangle(518, 257, 180, 32));

                this.imgSection.Image = bll.ForeachRectangle();
                this.dgvData.DataSource = bll.CarregarImages();
                if (this.dgvData.Rows.Count > 0) StyleBuild();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro na Digitalização do RG", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void StyleBuild()
        {
            this.dgvData.Columns["Data Digitalização"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var bll = new BLL_ImportCSV();
                bll.ExportarDataTableCSV(Settings.Default.TempSaida, $"rg_{DateTime.Now.ToString("yyyyMMdd")}", (DataTable)this.dgvData.DataSource);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("O arquivo foi salvo com sucesso!", "Sucesso de Importação CSV", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}