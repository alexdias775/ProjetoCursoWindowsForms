using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoWindowsForms
{
    public partial class Frm_Agencia : Form
    {
        public Frm_Agencia()
        {
            InitializeComponent();
            Tls_Principal.Items[0].ToolTipText = "Fechar a caixa de diálogo";
        }

        private void ApagatoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Agencia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'byteBankDataSet.TB_Agencia' table. You can move, or remove it, as needed.
            this.tB_AgenciaTableAdapter.Fill(this.byteBankDataSet.TB_Agencia);
            // TODO: This line of code loads data into the 'byteBankDataSet.TB_Agencia' table. You can move, or remove it, as needed.
            this.tB_AgenciaTableAdapter.Fill(this.byteBankDataSet.TB_Agencia);

        }

        private void tB_AgenciaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tB_AgenciaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.byteBankDataSet);

        }
    }
}
