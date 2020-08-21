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

namespace ColombiaDataManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(442, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(374, 22);
            this.textBox1.TabIndex = 1;
            // 
            // municipiosMenu
            // 
            this.municipiosMenu.FormattingEnabled = true;
            this.municipiosMenu.Location = new System.Drawing.Point(932, 22);
            this.municipiosMenu.Name = "municipiosMenu";
            this.municipiosMenu.Size = new System.Drawing.Size(121, 24);
            this.municipiosMenu.TabIndex = 2;
            // 
            // botonCargar
            // 
            this.botonCargar.Location = new System.Drawing.Point(535, 20);
            this.botonCargar.Name = "botonCargar";
            this.botonCargar.Size = new System.Drawing.Size(116, 26);
            this.botonCargar.TabIndex = 3;
            this.botonCargar.Text = "Load this file";
            this.botonCargar.UseVisualStyleBackColor = true;
            this.botonCargar.Click += new System.EventHandler(this.cargarInfo);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Region,
            this.Dane,
            this.Departamento,
            this.DaneMunicipio,
            this.Municipio});
            this.dataGridView1.Location = new System.Drawing.Point(62, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1033, 369);
            this.dataGridView1.TabIndex = 4;
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
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1169, 586);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.botonCargar);
            this.Controls.Add(this.municipiosMenu);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
            //this.dataGridView1.Rows.Add("hola", "como", "estas", "tu", "hoy?");
            MessageBox.Show(text);

        }

        private void loadFile(string dir)
        {
            if (File.Exists(dir))
            {
                // Read a text file line by line.  
                string[] lines = File.ReadAllLines(dir);
                for(int i = 1; i < lines.Length; i++)
                {
                    string[] aux = lines[i].Split(',');
                    this.dataGridView1.Rows.Add(aux[0], aux[1], aux[2], aux[3], aux[4]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            municipiosMenu.Items.Add("a");
            municipiosMenu.Items.Add("b");
            */
            string[] alph = { "A", "B", "C", "D","F", "G", "H", "I", "J", "K", "A", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y","Z" };
            for (int i=0; i< alph.Length; i++){

                municipiosMenu.Items.Add(alph[i]);
             
            }
        }
    }
}
