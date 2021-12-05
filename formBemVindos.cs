using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formCRUD
{
    public partial class formBemVindos : Form
    {
        public formBemVindos()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var abrirFormEstudante = new FormEstudante();
            abrirFormEstudante.Show();
            this.Hide();
        }

        private void formBemVindos_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair do Programa?", "Sair", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            var abrirFormAlunos = new formAlunos();
            abrirFormAlunos.Show();
            this.Hide();
        }
    }
}
