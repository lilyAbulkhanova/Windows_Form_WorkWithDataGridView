using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EditForm : Form
    {
        public TableRowData UserData { get; }
        private readonly TableRowData _userBackupData;
        private BindingException _bindingException;
        public EditForm(TableRowData ud = null)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            // Если переданые данные из главной формы...
            if (ud != null)
                UserData = ud; // сохраняем их в свойстве с данными
            else UserData = new TableRowData(); // ... иначе - создаем новое свойство с данными

            // Делаем резервную копию исходно переданных данных на случай отмены радактирования
            _userBackupData = UserData.Copy();

            // Производим связывание данных между графическими элементами и свойством с хранимой информацией об объекте
            numericUpDown1.DataBindings.Add("Value", UserData, "Id");
            textBox1.DataBindings.Add("Text", UserData, "Names");
            var v2Binding = textBox2.DataBindings.Add("Text", UserData, "Surnames");
            // Включаем поддержку форматирования ввода
            // (обеспечивает контроль ошибок при вводе данных)
            v2Binding.FormattingEnabled = true; // !!!!
            // Назначаем метод, который будет вызываться для анализа
            // введенных в проверяемое поле данных
            
            checkBox1.DataBindings.Add("Checked", UserData, "IsChecked");
            textBox3.DataBindings.Add("Text", UserData, "Number");
            textBox4.DataBindings.Add("Text", UserData, "Average");
        }
       

        private void EditForm_Load(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

       

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Если пользователь редактирует неверное поле, убираем подсветку,
            // сигнализирующую об ошибке. 
            textBox2.BackColor = Color.White;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            // Кнопка "Сохранить"

            //Если было исключение при заполнении значений
            if (_bindingException is not null)
            {
                // Выводим сообщение об ошибке
                MessageBox.Show(
                    _bindingException.Message,
                    _bindingException.ErrorField,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            
                // и не даем окну закрыться. 
                return;
            }

            // Сюда попадем только если ошибок нет и данные можно сохранять
            // Установим результат работы с диалоговым окном
            DialogResult = DialogResult.OK;
        
            // И закроем окно.
            Close();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            // Кнопка "Отменить".

            // Восстанавливаем данные об объекте из резервной копии, чтобы
            // отменить возможные изменения, которые успел сделать пользователь
            _userBackupData.CopyTo(UserData);
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}