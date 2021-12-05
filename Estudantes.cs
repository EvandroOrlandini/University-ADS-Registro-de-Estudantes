using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formCRUD
{
    // Aqui criamos o Objeto Estudante e declaramos ele como public class
    public class Estudantes
    {
        public int Id { get; set; }
        public int CodigoEstudante { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }

        //Aqui lemos as Strings e adicionamos elas nas fileiras
        public string[] read()
        {
            string[] row = new string[5];
            row[0] = Id.ToString();
            row[1] = CodigoEstudante.ToString();
            row[2] = Nome;
            row[3] = Email;
            row[4] = Curso;

            return row;
        }

        // Aqui adicionamos os dados e os separamos por "/"
        public string add()
        {
            string row = Id.ToString() + "/";
            row += CodigoEstudante.ToString() + "/";
            row += Nome + "/";
            row += Email + "/";
            row += Curso + "/";

            return row;
        }

        // Aqui editamos os dados recebidos pela função edit() e os separamos por "/"
        public string edit()
        {
            string row = Id.ToString() + "/";
            row += CodigoEstudante.ToString() + "/";
            row += Nome + "/";
            row += Email + "/";
            row += Curso + "/";

            return row;
        }

        // Aqui utilizamos a função remove() com o ID que utilizamos como chave primária
        public Boolean remove(int id)
        {
            if(id == Id)
            {
                return true;
            }
            return false;
        }
    }
}
