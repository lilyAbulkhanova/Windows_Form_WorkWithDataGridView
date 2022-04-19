using System;
using System.ComponentModel;

using System.IO;

using System.Text;

using System.Windows.Forms;
using System.Text.Json;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();
        private BindingList<TableRowData> dataList = new BindingList<TableRowData>();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataList;
            dataList.Add(new TableRowData(1, "Alina", "Abulkhanova", true, '6',3.4));
            dataList.Add(new TableRowData(2, "Lily", "Abulkhanova", false,'7',5.0));
            dataList.Add(new TableRowData(3, "Yana", "Klimchuk", true,'6',2.0));
        }

       

        

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f2 = new EditForm();
            if (f2.ShowDialog(this) == DialogResult.OK)
            {
                dataList.Add(f2.UserData);
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f2 = new EditForm(dataList[dataGridView1.SelectedRows[0].Index]);
            f2.ShowDialog(this);
        }


        private void contextMenu1_Popup(object sender, EventArgs e)
        {
          
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                var filename = saveFileDialog1.FileName;
                using var fs = new FileStream(filename, FileMode.Create);
                JsonSerializer.Serialize(fs, dataList);
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows.RemoveAt(i);
            }
            catch
            {
                MessageBox.Show("Выбери строку для удаления", "Ошибка!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}