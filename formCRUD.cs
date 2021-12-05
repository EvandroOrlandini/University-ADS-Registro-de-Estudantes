using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace formCRUD
{
    public partial class FormEstudante : Form
    {
        // Aqui chamamos o dataTable, o nosso Objeto Estudantes e carregamos o arquivo .txt que guarda os registros
        DataTable dataTable;
        Estudantes estudantes;
        String fileName = "../../estudantes.txt";

        public FormEstudante()
        {
            InitializeComponent();
        }

        // Aqui preenchemos o campo do ID e colocamos foco no Código do Estudante
        private void FormEstudante_Shown(object sender, EventArgs e)
        {
            tbID.Text = getPrimaryKey().ToString();
            tbCodEstudante.Focus();
        }

        // Aquii chamamos a função load() e carregamos os registros dos Estudantes
        private void FormEstudante_Load(object sender, EventArgs e)
        {
            load();
        }

        // Botão - Limpar - Aqui chamamos a função reset() e limpamos os campos de preenchimentos
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            reset();
        }

        // Botão - Incluir - Aqui fazemos as inclusões do Estudantes
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (labelOperacao.Text == "Adição")
            {
                if (validate())
                {
                    estudantes = new Estudantes();
                    estudantes.Id = Convert.ToInt32(tbID.Text);
                    estudantes.CodigoEstudante = Convert.ToInt32(tbCodEstudante.Text);
                    estudantes.Nome = tbNome.Text;
                    estudantes.Email = tbEmail.Text;
                    estudantes.Curso = tbCurso.Text;
                    File.AppendAllText(fileName, estudantes.add());
                    dataTable.Rows.Add(estudantes.read());
                    MessageBox.Show("Estudande Incluído!");
                    reset();
                }
            }
        }

        // Botão - Alterar - Aqui fazemos as alterações nos registros dos Estudantes
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                string[] lines = File.ReadAllLines(fileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] values = lines[i].ToString().Split('/');
                    int id = Convert.ToInt32(values[0]);
                    if (id == Convert.ToInt32(tbID.Text))
                    {
                        estudantes = new Estudantes();
                        estudantes.Id = Convert.ToInt32(tbID.Text);
                        estudantes.CodigoEstudante = Convert.ToInt32(tbCodEstudante.Text);
                        estudantes.Nome = tbNome.Text;
                        estudantes.Email = tbEmail.Text;
                        estudantes.Curso = tbCurso.Text;
                        lines[i] = estudantes.edit();
                        break;
                    }
                }
                File.WriteAllLines(fileName, lines);
                MessageBox.Show("Registro do Estudante Atualizado!");
                reset();
                load();
            }

        }

        // Botão - Excluir - Aqui excluímos os Registros dos Estudantes
        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (labelOperacao.Text == "Edição")
            {
                if (MessageBox.Show("Deseja excluir esse registro?", "Estudante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var file = new List<string>(File.ReadAllLines(fileName));
                    string[] lines = File.ReadAllLines(fileName);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] values = lines[i].ToString().Split('/');
                        estudantes = new Estudantes();
                        estudantes.Id = Convert.ToInt32(tbID.Text);
                        if (estudantes.remove(Convert.ToInt32(values[0])))
                        {
                            file.RemoveAt(i);
                            break;
                        }
                    }
                    MessageBox.Show("Registro do Estudante Excluído!");
                    File.WriteAllLines(fileName, file.ToArray());
                    reset();
                    load();
                }
            }
        }

        // Aqui carregamos os registros do Estudantes no DataGrid
        private void FormEstudante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbID.Text = dataGridViewEstudantes.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbCodEstudante.Text = dataGridViewEstudantes.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbNome.Text = dataGridViewEstudantes.Rows[e.RowIndex].Cells[2].Value.ToString();
                tbEmail.Text = dataGridViewEstudantes.Rows[e.RowIndex].Cells[3].Value.ToString();
                tbCurso.Text = dataGridViewEstudantes.Rows[e.RowIndex].Cells[4].Value.ToString();
                labelOperacao.Text = "Edição";
                buttonExcluir.Enabled = true;
            }
            catch { }
        }

        // Aqui criamos uma função para carregar os registros do Estudantes
        private void load()
        {
            dataTable = new DataTable();
            dataGridViewEstudantes.DataSource = null;
            dataGridViewEstudantes.Rows.Clear();
            dataGridViewEstudantes.Refresh();

            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Cód do Estudante", typeof(int));
            dataTable.Columns.Add("Nome", typeof(string));
            dataTable.Columns.Add("E-mail", typeof(string));
            dataTable.Columns.Add("Curso", typeof(string));

            dataGridViewEstudantes.DataSource = dataTable;

            string[] lines = File.ReadAllLines(fileName);
            string[] values;

            foreach (string line in lines)
            {
                values = line.ToString().Split('/');
                estudantes = new Estudantes();
                estudantes.Id = Convert.ToInt32(values[0]);
                estudantes.CodigoEstudante = Convert.ToInt32(values[1]);
                estudantes.Nome = values[2];
                estudantes.Email = values[3];
                estudantes.Curso = values[4];

                dataTable.Rows.Add(estudantes.read());
            }
        }

        // Aqui tornamos o - ID - em uma chave primaria para ordenar o array
        private int getPrimaryKey()
        {
            int id = 0;
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] values = line.ToString().Split('/');
                id = Convert.ToInt32(values[0]);
            }
            return id + 1;
        }

        // Aqui criamos um função para limpar os campos de preenchimento
        private void reset ()
        {
            tbID.Text = getPrimaryKey().ToString();
            tbCodEstudante.Text = "";
            tbNome.Text = "";
            tbEmail.Text = "";
            tbCurso.Text = "";
            labelOperacao.Text = "Adição";
            buttonExcluir.Enabled = false;
            tbCodEstudante.Focus();
        }

        // Aqui criamos uma função booleana para validar se os campos estão preenchidos
        private Boolean validate()
        {
            if (tbCodEstudante.Text == "")
            {
                MessageBox.Show("Informe o Código do Estudante");
                tbCodEstudante.Focus();
                return false;
            }
            else if (tbNome.Text == "")
            {
                MessageBox.Show("Informe o Nome e Sobrenome do Estudante");
                tbNome.Focus();
                return false;
            }
            else if (tbEmail.Text == "")
            {
                MessageBox.Show("Informe o E-mail do Estudante");
                tbEmail.Focus();
                return false;
            }
            else if (tbCurso.Text == "")
            {
                MessageBox.Show("Informe o Curso do Estudante");
                tbEmail.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        // Botão - Sair - Aqui saimos do CRUD e fechamos o programa
        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair do CRUD?", "Sair", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        // Botão - Voltar - Aqui saimos do CRUD e retornamos ao Formulário de Boas Vindas
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var voltarFormBemVindos = new formBemVindos();
            voltarFormBemVindos.Show();
            this.Hide();
        }
    }
}
