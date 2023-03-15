using BLL.Repositories;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        FilmboxEntities1 db = new FilmboxEntities1();
        YonetmenlerRepository yr = new YonetmenlerRepository();
        string yonetmenAdi;
        string yonetmenSoyadi;
        private void Form2_Load(object sender, EventArgs e)
        {
            label10.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YonetmenleriGetir();
            TemizleInsert();
        }

        private void TemizleInsert()
        {
            textBox1.Text = textBox2.Text = string.Empty;
        }

        private void YonetmenleriGetir()
        {
            dataGridView1.DataSource = yr.GetAll();
            dataGridView1.Columns["Filmlers"].Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                label10.Visible = false;
            }
            else
            {
                label10.Visible = true;
                label10.BackColor = Color.Orange;
                string arananText = (textBox5.Text).ToLower();
                dataGridView1.DataSource = yr.GetAll().Where(a => a.YonetmenAdi.ToLower().Contains(arananText)).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yonetmenAdi = textBox1.Text;
            yonetmenSoyadi = textBox2.Text;
            if (string.IsNullOrEmpty(yonetmenAdi) && string.IsNullOrEmpty(yonetmenSoyadi))
            {
                MessageBox.Show("Yonetmen bilgileri boş geçilemez!!!");
                return;
            }
            yr.Insert(new Yonetmenler { YonetmenAdi = yonetmenAdi, YonetmenSoyadi = yonetmenSoyadi });
            YonetmenleriGetir();
            TemizleInsert();

        }
        Yonetmenler seciliYonetmen;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dataGridView1.SelectedRows.Count > 0)
           {
               int id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
               seciliYonetmen = db.Yonetmenlers.Find(id);
               textBox3.Text = seciliYonetmen.YonetmenAdi;
               textBox4.Text = seciliYonetmen.YonetmenSoyadi;
           }*/
            //--------------------------------------------------------
            var cell = dataGridView1.Rows[e.RowIndex].Cells[0];
            //var cell = dataGridView1.SelectedCells[0];
            if (cell != null)
            {
                MessageBox.Show(cell.Value.ToString());

            }
            //--------------------------------------------------------
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //    seciliYonetmen = yr.GetbyID(id);  //seciliYonetmen = db.Yonetmenlers.Find(id);
            //    textBox3.Text = seciliYonetmen.YonetmenAdi;
            //    textBox4.Text = seciliYonetmen.YonetmenSoyadi;
            //    label7.Text = seciliYonetmen.YonetmenAdi;
            //    label8.Text = seciliYonetmen.YonetmenSoyadi;
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            seciliYonetmen.YonetmenAdi = textBox3.Text;
            seciliYonetmen.YonetmenSoyadi = textBox4.Text;
            yr.Update(seciliYonetmen);
            YonetmenleriGetir();
            TemizleUpdate();
            TemizleDelete();
        }

        private void TemizleUpdate()
        {
            textBox3.Text = textBox4.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedCells[0].Value;
            yr.Delete(id);
            YonetmenleriGetir();
            TemizleDelete();
            TemizleUpdate();
        }

        private void TemizleDelete()
        {
            label7.Text = label8.Text = string.Empty;
        }
    }
}
