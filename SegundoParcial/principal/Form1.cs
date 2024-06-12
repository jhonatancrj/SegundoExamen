using MySqlConnector;
using System.Data;

namespace _6demayo
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "archivos.jpg | *.jpg";
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            /*
              c = bmp.GetPixel(e.X, e.Y);
              textBox1.Text = c.R.ToString();
              textBox2.Text = c.G.ToString();
              textBox3.Text = c.B.ToString();
              */ // ESTE CODIGO DETECTA EL COLOR POR PIXEL


            //ESTE CODIGO DETECTA EL CODIGO INCREMENTANDO 10 PIXELES
            int sR = 0; int sG = 0; int sB = 0;


            for (int i = e.X; i < e.X + 10; i++)
            {
                for (int j = e.Y; j < e.Y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    sR += c.R;
                    sG += c.G;
                    sB += c.B;
                }
            }

            sR /= 100; sG /= 100; sB /= 100;
            cR = sR;
            cG = sG;
            cB = sB;

            textBox1.Text = sR.ToString();
            textBox2.Text = sG.ToString();
            textBox3.Text = sB.ToString();


            // Parse RGB color from a string
            Color color = Color.FromArgb(sR, sG, sB);

            // Convert RGB to HEX 
            string hexColor = ColorTranslator.ToHtml(color);
            hexColor = hexColor.Substring(1);
            textBox5.Text = hexColor;

        }


        // PIXEL TO PIXEL
        // PIXEL TO PIXEL
        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();

            MySqlConnection conexionBD = AbrirConexion();

            if (conexionBD != null && conexionBD.State == ConnectionState.Open)
            {
                try
                {
                    string query = @"SELECT cR_origen, cG_origen, cB_origen, cR_destino, cG_destino, cB_destino FROM textura";

                    MySqlCommand comando = new MySqlCommand(query, conexionBD);
                    int x = 0;

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int cR_origen = reader.GetInt32("cR_origen");
                                int cG_origen = reader.GetInt32("cG_origen");
                                int cB_origen = reader.GetInt32("cB_origen");
                                int cR_destino = reader.GetInt32("cR_destino");
                                int cG_destino = reader.GetInt32("cG_destino");
                                int cB_destino = reader.GetInt32("cB_destino");

                                for (int i = 0; i < bmp.Width; i++)
                                {
                                    for (int j = 0; j < bmp.Height; j++)
                                    {
                                        c = bmp.GetPixel(i, j);
                                        if (Math.Abs(c.R - cR_origen) <= 30 &&
                                            Math.Abs(c.G - cG_origen) <= 30 &&
                                            Math.Abs(c.B - cB_origen) <= 30)
                                        {
                                            bmp.SetPixel(i, j, Color.FromArgb(cR_destino, cG_destino, cB_destino));
                                            x++;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron filas en la tabla.");
                        }
                    }
                    conexionBD.Close();

                    if (x != 0)
                        MessageBox.Show("Se han realizado cambios en la imagen");
                    else
                        MessageBox.Show("No hay coincidencias en la base de datos");

                    pictureBox1.Image = bmp;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                }
            }
        }






        // POR SECCIONES 
        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);

            MySqlConnection conexionBD = AbrirConexion();

            if (conexionBD != null && conexionBD.State == ConnectionState.Open)
            {
                try
                {
                    string query = @"SELECT cR_origen, cG_origen, cB_origen, cR_destino, cG_destino, cB_destino FROM textura";

                    MySqlCommand comando = new MySqlCommand(query, conexionBD);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int cR_origen = reader.GetInt32("cR_origen");
                                int cG_origen = reader.GetInt32("cG_origen");
                                int cB_origen = reader.GetInt32("cB_origen");
                                int cR_destino = reader.GetInt32("cR_destino");
                                int cG_destino = reader.GetInt32("cG_destino");
                                int cB_destino = reader.GetInt32("cB_destino");

                                for (int i = 0; i < bmp.Width - 10; i = i + 10)
                                {
                                    for (int j = 0; j < bmp.Height - 10; j = j + 10)
                                    {
                                        int sR = 0; int sG = 0; int sB = 0;

                                        for (int ip = i; ip < i + 10; ip++)
                                        {
                                            for (int jp = j; jp < j + 10; jp++)
                                            {
                                                Color pixelColor = bmp.GetPixel(ip, jp);
                                                sR += pixelColor.R;
                                                sG += pixelColor.G;
                                                sB += pixelColor.B;
                                            }
                                        }

                                        sR /= 100; sG /= 100; sB /= 100;

                                        if (((cR_origen - 20 <= sR) && (sR <= cR_origen + 20)) &&
                                            ((cG_origen - 20 <= sG) && (sG <= cG_origen + 20)) &&
                                            ((cB_origen - 20 <= sB) && (sB <= cB_origen + 20)))
                                        {
                                            for (int ip = i; ip < i + 10 && ip < bmp.Width; ip++)
                                            {
                                                for (int jp = j; jp < j + 10 && jp < bmp.Height; jp++)
                                                {
                                                    bmp.SetPixel(ip, jp, Color.FromArgb(cR_destino, cG_destino, cB_destino));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron filas en la tabla.");
                        }
                    }

                    conexionBD.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                }
            }
            pictureBox1.Image = bmp;
        }






        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conexionBD = AbrirConexion();

            try
            {
                if (conexionBD != null && conexionBD.State == ConnectionState.Open)
                {
                    MessageBox.Show("Conexi�n establecida con �xito.");
                    string query = @"SELECT * FROM textura";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexionBD);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    conexionBD.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo abrir la conexi�n a la base de datos.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        private MySqlConnection AbrirConexion()
        {
            string connectionString = "server=localhost;user=root;password=;database=colores";
            MySqlConnection conexionBD = new MySqlConnection(connectionString);

            try
            {
                conexionBD.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }
            return conexionBD;
        }















        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            los pixeles de colores que tengo en la base de datos
            se deben efectuar en la imagen a proyectar
            cuando se da click en el boton de texturas, se deben mostrar las nuevas
            texturas en la base 
             */

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
