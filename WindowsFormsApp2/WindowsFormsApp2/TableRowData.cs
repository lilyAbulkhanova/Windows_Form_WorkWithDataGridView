using System.ComponentModel;
using System.Runtime.CompilerServices;
using WindowsFormsApp2.Annotations;

namespace WindowsFormsApp2
{
    public class TableRowData : INotifyPropertyChanged
    {
        private int _id;
        private string Name;
        private string Surname;
        private bool Activity;
        private char Number_Group;
        private double Average_Mark;

        [DisplayName("Идентификатор_Студента")]
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Имя Студента")]
        public string Names
        {
            get => Name;
            set
            {
                Name = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Фамилия")]
        public string Surnames
        {
            get => Surname;
            set
            {
                if (value.Trim().Length == 0)
                    throw new BindingException("Значение 2", "Строка не должна быть пустой");
                Surname = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Учавствует ли студент в мероприятиях?")]
        public bool IsChecked
        {
            get => Activity;
            set
            {
                Activity = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Номер_Группы")]
        public char Number
        {
            get => Number_Group;
            set
            {
                Number_Group = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Средний балл")]
        public double Average
        {
            get => Average_Mark;
            set
            {
                Average_Mark = value;
                OnPropertyChanged();
            }
        }

        public TableRowData(int _id, string Name, string Surname, bool Activity, char Number_Group, double Average_Mark)
        {
            this._id = _id;
            this.Name = Name;
            this.Surname = Surname;
            this.Activity = Activity;
            this.Number_Group = Number_Group;
            this.Average_Mark = Average_Mark;
        }

        // Конструктор по умолчанию удобно использовать для создания новых значений
        public TableRowData()
        {
            // В нем необходимо предусмотреть, чтобы все свойства имели допустимые значения
            Surname= "-";
        }

        // Метод для копирования объекта
        public TableRowData Copy() => new TableRowData(Id, Name,Surnames , IsChecked, Number,Average);
        // Метод копирования данного объекта в другой, указанный в параметре
        // (можно использовать для восстановления данных из резервной копии
        // при отказе пользователя от сохранения сделанных изменений)
        public void CopyTo(TableRowData trd)
        {
            if (trd != null)
            {
                trd.Id = Id;
                trd.Names = Names;
                trd.Surnames = Surnames;
                trd.IsChecked = IsChecked;
                trd.Number = Number;
                trd.Average = Average;
            }
        }

        // Для автоматического обновления таблицы с данными


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}