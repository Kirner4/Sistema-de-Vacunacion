using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema_de_Vacunacion
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("server=DESKTOP-B0ALQ78;database=Sistema_vacunacion;integrated security=true");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection("server=DESKTOP-B0ALQ78;database=Sistema_vacunacion;integrated security=true"))
            {
                try
                {
                    SqlCommand comando = new SqlCommand("Insertar_Registros", conexion);
                    comando.Parameters.AddWithValue("nombre", Nombre.Text);
                    comando.Parameters.AddWithValue("correo", Correo.Text);
                    comando.Parameters.AddWithValue("telefono", int.Parse(textBox3.Text));
                    comando.Parameters.AddWithValue("edad", int.Parse(textBox2.Text));
                    comando.Parameters.AddWithValue("vacunado", Vacunado.Text);
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    limpiarcampos();
                    MessageBox.Show("Los registros se guardaron exitosamente");
                }

                catch (Exception ex) { MessageBox.Show($"Hubo un error en la base de datos{ex}"); }
            }

        }
        private void Guardar_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
        }
        private void limpiarcampos()
        {
            Nombre.Text = "";
            Correo.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            Vacunado.Text = "";
        }

        private void Consulta_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection("server=DESKTOP-B0ALQ78;database=Sistema_vacunacion;integrated security=true"))
                try
                {
                    
                    SqlCommand comando = new SqlCommand("Buscar_Registro", conexion);
                    comando.Parameters.AddWithValue("idusuario",int.Parse (Buscar.Text));
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    DataTable reader = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    adapter.Fill(reader);
                    dataGridView1.DataSource = reader;
                }
                catch(Exception ex) { MessageBox.Show($"Hubo un error en la base de datos{ex}"); }

        }

    }
}
