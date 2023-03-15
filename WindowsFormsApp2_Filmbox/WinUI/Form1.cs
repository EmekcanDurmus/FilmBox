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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Tools -> NuGet Package Manager -> Package Manager Console (içerisine ; Install-Package EntityFramework -version 6.2.0)
        YonetmenlerRepository yr = new YonetmenlerRepository();
        FilmboxEntities1 db = new FilmboxEntities1();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Temizle()
        {
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = yr.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            List<Yonetmenler> list = new List<Yonetmenler>();
            list.Add(yr.GetbyID(id));
            dataGridView1.DataSource = list.Select(c => new { }).ToList();
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string yonetmenAdi = textBox2.Text;
            string yonetmenSoyadi = textBox3.Text;
            if (string.IsNullOrEmpty(yonetmenAdi) && string.IsNullOrEmpty(yonetmenSoyadi))
            {
                MessageBox.Show("Yonetmen Adi ve Yonetmen Soyadi boş bıraklıamaz");
                return;
            }
            yr.Insert(new Yonetmenler { YonetmenAdi = yonetmenAdi, YonetmenSoyadi = yonetmenSoyadi });
            dataGridView1.DataSource = yr.GetAll();
            Temizle();
        }
        Yonetmenler secili;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridView1.SelectedCells.ToString());
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //int id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                //secili = db.Yonetmenlers.Find(id);
                //textBox2.Text = secili.YonetmenAdi;
                //textBox3.Text = secili.YonetmenSoyadi;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string yonetmenAdi = textBox2.Text;
            string yonetmenSoyadi = textBox3.Text;
            if (string.IsNullOrEmpty(yonetmenAdi) && string.IsNullOrEmpty(yonetmenSoyadi))
            {
                MessageBox.Show("Yonetmen Adi ve Yonetmen Soyadi boş bıraklıamaz");
                return;
            }
            secili.YonetmenAdi = yonetmenAdi;
            secili.YonetmenSoyadi = yonetmenSoyadi;
            yr.Update(secili);
            dataGridView1.DataSource = yr.GetAll();
            Temizle();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int id = (int)dataGridView1.SelectedCells[0].Value;
            yr.Delete(id);
            dataGridView1.DataSource = yr.GetAll();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string arananText = textBox4.Text;
            dataGridView1.DataSource = yr.GetAll().Where(a => a.YonetmenAdi.Contains(arananText)).ToList();
        }
    }
}
