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
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

namespace ColombiaDataManagement
{
    public partial class Form1 : Form
    {
        DataTable tabla;
        public Form1()
        {
            InitializeComponent();
            iniciar();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.municipiosMenu = new System.Windows.Forms.ComboBox();
            this.botonCargar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaneMunicipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Municipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonFiltrar = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Seleccionar Archivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(374, 22);
            this.textBox1.TabIndex = 1;
            // 
            // municipiosMenu
            // 
            this.municipiosMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.municipiosMenu.FormattingEnabled = true;
            this.municipiosMenu.Location = new System.Drawing.Point(454, 21);
            this.municipiosMenu.Name = "municipiosMenu";
            this.municipiosMenu.Size = new System.Drawing.Size(89, 24);
            this.municipiosMenu.TabIndex = 2;
            // 
            // botonCargar
            // 
            this.botonCargar.Location = new System.Drawing.Point(230, 57);
            this.botonCargar.Name = "botonCargar";
            this.botonCargar.Size = new System.Drawing.Size(116, 26);
            this.botonCargar.TabIndex = 3;
            this.botonCargar.Text = "cargar archivo";
            this.botonCargar.UseVisualStyleBackColor = true;
            this.botonCargar.Click += new System.EventHandler(this.cargarInfo);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 100;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(720, 369);
            this.dataGridView1.TabIndex = 5;
            // 
            // Region
            // 
            this.Region.HeaderText = "Region";
            this.Region.MinimumWidth = 6;
            this.Region.Name = "Region";
            this.Region.Width = 280;
            // 
            // Dane
            // 
            this.Dane.HeaderText = "Codigo Dane Departamento";
            this.Dane.MinimumWidth = 6;
            this.Dane.Name = "Dane";
            this.Dane.Width = 125;
            // 
            // Departamento
            // 
            this.Departamento.HeaderText = "Departamento";
            this.Departamento.MinimumWidth = 6;
            this.Departamento.Name = "Departamento";
            this.Departamento.Width = 200;
            // 
            // DaneMunicipio
            // 
            this.DaneMunicipio.HeaderText = "Codigo Dane Municipio";
            this.DaneMunicipio.MinimumWidth = 6;
            this.DaneMunicipio.Name = "DaneMunicipio";
            this.DaneMunicipio.Width = 125;
            // 
            // Municipio
            // 
            this.Municipio.HeaderText = "Municipio";
            this.Municipio.MinimumWidth = 6;
            this.Municipio.Name = "Municipio";
            this.Municipio.Width = 250;
            // 
            // botonFiltrar
            // 
            this.botonFiltrar.Location = new System.Drawing.Point(454, 60);
            this.botonFiltrar.Name = "botonFiltrar";
            this.botonFiltrar.Size = new System.Drawing.Size(89, 23);
            this.botonFiltrar.TabIndex = 5;
            this.botonFiltrar.Text = "filtrar datos";
            this.botonFiltrar.UseVisualStyleBackColor = true;
            this.botonFiltrar.Click += new System.EventHandler(this.filterInformation);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Silver;
            this.chart1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Left;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(747, 89);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(604, 369);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1387, 522);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.botonFiltrar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.botonCargar);
            this.Controls.Add(this.municipiosMenu);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        //Este método se encarga de cargar la informacion del .CSV a la tabla
        //cuando se oprime el botón "cargar"
        private void cargarInfo(object sender, EventArgs e)
        {
           
            string text = textBox1.Text;
            loadFile(text);
            
            //chart1_Click(sender, e);


        }

        private void iniciar() {
            tabla = new DataTable();
            tabla.Columns.Add("Region");
            tabla.Columns.Add("Codigo DANE departamento");
            tabla.Columns.Add("Departamento");
            tabla.Columns.Add("Codigo DANE municipio");
            tabla.Columns.Add("Municipio");

            dataGridView1.DataSource = tabla;

        }

        private void loadFile(string dir)
        {
            List<string> regions = new List<string>();
            ArrayList dep = new ArrayList();
            List<int> depCount = new List<int>();
            if (File.Exists(dir))
            {
                // Read a text file line by line.  
                string[] lines = File.ReadAllLines(dir);
                for (int i = 1; i < lines.Length; i++)
                {
                    //going per line

                    //split the line by ","
                    string[] aux = lines[i].Split(',');
                    DataRow fila = tabla.NewRow();
                    fila[0] = aux[0];
                    fila[1] = aux[1];
                    fila[2] = aux[2];
                    fila[3] = aux[3];
                    fila[4] = aux[4];
                    tabla.Rows.Add(fila);
                    if (!regions.Contains(aux[0]))
                    {
                        regions.Add(aux[0]);
                        depCount.Add(0);
                    }

                    if (!dep.Contains(aux[2]))
                    {
                        for (int j = 0; j < regions.Count; j++)
                        {
                            if (aux[0].Equals(regions[j])){
                                depCount[j] ++;
                            }
                            
                        }
                    }



                    

                }


                this.chart1.Titles.Clear();
                this.chart1.Titles.Add("Departamentos por region");

                for(int i = 0; i < regions.Count; i++)
                {
                    Series s = this.chart1.Series.Add(regions[i]);
                    s.Points.Add(depCount[i]);
                }

                //Series s = this.chart1.Series.Add("hola");
                //s.Points.Add(10);
                /*
                this.chart1.Series["Series1"].XValueMember = "Regiones";
                this.chart1.Series["Series1"].YValueMembers = "Departamentos";
                this.chart1.DataSource = dataGridView1;
                this.chart1.DataBind();
                */
                MessageBox.Show("Archivo cargado exitosamente.");

                this.botonCargar.Enabled = false;
               
            }
            else {
                MessageBox.Show("por favor seleccione un archivo para cargar");
            }

        }

        private void filterInformation(object sender, EventArgs e) {

          
            
            tabla.DefaultView.RowFilter = $"Municipio LIKE '{municipiosMenu.Text}%'";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
          
            
             string[] alph = { "A", "B", "C", "D", "E","F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z" };
          //  string[] alph = {"Antioquia","Santander","Cundinamarca"};
            for (int i=0; i< alph.Length; i++){

                municipiosMenu.Items.Add(alph[i]);
             
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            //this.chart1.Series["Series1"].ChartType = SeriesChartType.Bar;
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("Departamentos por region");
            Series s = this.chart1.Series.Add("hola");
            s.Points.Add(10);

            
        }
    }
}
