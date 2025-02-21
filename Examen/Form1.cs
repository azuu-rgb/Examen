namespace Examen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string sexo (string texto)
        {
            if (texto.Substring(11, 1) == "M")
            {
                return "MUJER";
            }
            else
            {
                return "HOMBRE";
            }
        }

        public string edad (string texto)
        {
            int año =Convert.ToInt16(texto.Substring (4, 2));
            int mes = Convert.ToInt16(texto.Substring(6, 2));
            int dia = Convert.ToInt16(texto.Substring(7, 2));

            if (año<= 25)
            {
                año = año + 2000;
            }
            else
            {
                año = año + 1900;
            }

            int edadC= DateTime.Now.Year-año;
            if (mes > DateTime.Now.Month)
            {
                edadC--;
            }
            else if (dia>DateTime.Now.Day) 
            {
                edadC--;
            }
            return edadC+"";
        }
        private void buttAbrir_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                char[] delimitadores = { ',', '\n' };
                int cont = 0;

                string nombreArch = openFileDialog1.FileName;
                string texto = File.ReadAllText(nombreArch);

                string[] lineas = texto.Split('\n');
                string[][] datos = new string[lineas.Length][];
                

                for (int i = 0; i < lineas.Length; i++)
                {
                    datos[i] = lineas[i].Split(delimitadores);
                }

                for (int i = 0; i < datos.Length; i++)
                {
                    for (int j = 0; j < datos[i].Length; j++)
                    {
                        
                        string[] filas = datos[i];
                        dataGridView1.Rows.Add(filas);

                    }
                }

                for (int i = 0; i < lineas.Length; i++)
                {
                    string curp = datos[i][0].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = edad(curp);
                    dataGridView1.Rows[i].Cells[3].Value = sexo(curp);
                }
                
            }
        }
    }
}