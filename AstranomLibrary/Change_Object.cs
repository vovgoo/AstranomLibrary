using System;
using System.Drawing;
using System.Windows.Forms;

namespace AstranomLibrary
{
    public partial class Change_Object : UserControl
    {
        private bool key = false;

        private int idListObject;
        private int typeDatabaseObject;
        private string name;
        private string value1;
        private string value2;
        private string value3;
        private string value4;
        private string value5;
        private string value6;  
        private string photoPath;
        private int objectType;

        private Action changeObject;
        private Form1 form;

        public Change_Object(int idListObject, int typeDatabaseObject, string name, string value1, string value2, string value3, string value4, string value5, string value6, string photoPath, Action changeObject, Form1 form, int objectType)
        {
            InitializeComponent();
            form.SetRoundedShape(this, 10);
            label2.Text = typeDatabaseObject == 1 ? "Звезда" : "Планета";
            label4.Text = name;

            this.idListObject = idListObject;
            this.typeDatabaseObject = typeDatabaseObject;
            this.name = name;
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.value4 = value4;
            this.value5 = value5;
            this.value6 = value6;
            this.photoPath = photoPath;

            this.changeObject = changeObject;
            this.form = form;
            this.objectType = objectType;
        }

        // Дизайн

        //// Адаптивный дизайн

        private void Change_Object_SizeChanged(object sender, EventArgs e)
        {
            form.SetRoundedShape(this, 10);
        }

        private void ChangeObjectsAction()
        {
            changeObject?.Invoke();
        }

        //// Анимация кнопок
        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            tableLayoutPanel1.BackColor = Color.FromArgb(50, 50, 50);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            if (key == false)
            {
                tableLayoutPanel1.BackColor = Color.FromArgb(35, 36, 41);
            }
        }

        //// Изменения состоянии кнопки на выключенное
     
        private void TurnedOff()
        {
            key = false;
            tableLayoutPanel1.BackColor = Color.FromArgb(35, 36, 41);
        }

        // Обработка кнопок

        //// Обработка действия для изменения данных об администраторе
      
        private void label4_DoubleClick(object sender, EventArgs e)
        {
            switch (objectType)
            {
                case 1:
                    form.Controls.Find("textBox24", true)[0].Text = typeDatabaseObject == 1 ? "Звезда" : "Планета";
                    form.Controls.Find("textBox10", true)[0].Text = name;
                    form.Controls.Find("textBox18", true)[0].Text = value1;
                    form.Controls.Find("textBox19", true)[0].Text = value2;
                    form.Controls.Find("textBox20", true)[0].Text = value3;
                    form.Controls.Find("textBox21", true)[0].Text = value4;
                    form.Controls.Find("textBox22", true)[0].Text = value5;
                    form.Controls.Find("textBox23", true)[0].Text = value6;

                    try
                    {
                        form.Controls.Find("pictureBox4", true)[0].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image_user\\" + photoPath);
                    }
                    catch
                    {
                        form.Controls.Find("pictureBox4", true)[0].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");
                    }

                    form.Controls.Find("textBox19", true)[0].KeyPress -= form.OnlyLetters_KeyPress;
                    form.Controls.Find("textBox19", true)[0].KeyPress -= form.OnlyDouble_KeyPress;
                    form.Controls.Find("textBox23", true)[0].KeyPress -= form.OnlyDouble_KeyPress;
                    form.Controls.Find("textBox23", true)[0].KeyPress -= form.OnlyNumbers_KeyPress;

                    switch (typeDatabaseObject)
                    {
                        case 1:
                            form.Controls.Find("label42", true)[0].Text = "Созвездие";
                            form.Controls.Find("label43", true)[0].Text = "Тип звезды";
                            form.Controls.Find("label44", true)[0].Text = "Видимая звездная величина";
                            form.Controls.Find("label45", true)[0].Text = "Расстояние от Земли (А.Е.)";
                            form.Controls.Find("label46", true)[0].Text = "Прямое восхождение (ч.)";
                            form.Controls.Find("label47", true)[0].Text = "Прямое склонение (ч.)";
                            form.Controls.Find("textBox19", true)[0].KeyPress += form.OnlyLetters_KeyPress;
                            form.Controls.Find("textBox23", true)[0].KeyPress += form.OnlyDouble_KeyPress;
                            break;
                        case 2:
                            form.Controls.Find("label42", true)[0].Text = "Тип планеты";
                            form.Controls.Find("label43", true)[0].Text = "Масса (10^24 кг)";
                            form.Controls.Find("label44", true)[0].Text = "Размер (км)";
                            form.Controls.Find("label45", true)[0].Text = "Расстояние от Земли (А.Е.)";
                            form.Controls.Find("label46", true)[0].Text = "Плотность атмосферы (кг/м^3)";
                            form.Controls.Find("label47", true)[0].Text = "Кол-во спутников (шт.)";
                            form.Controls.Find("textBox19", true)[0].KeyPress += form.OnlyDouble_KeyPress;
                            form.Controls.Find("textBox23", true)[0].KeyPress += form.OnlyNumbers_KeyPress;
                            break;
                    }

                    form.ChangeIndexObject(idListObject);
                    ((TabControl)form.Controls.Find("tabControl1", true)[0]).SelectedIndex = 13;
                    break;
                case 2:
                    form.ChangeIndexObject(idListObject);
                    if (Parent is FlowLayoutPanel flowLayoutPanel)
                    {
                        foreach (Change_Object control in flowLayoutPanel.Controls)
                        {
                            control.TurnedOff();
                        }
                    }
                    key = true;
                    tableLayoutPanel1.BackColor = Color.FromArgb(50, 50, 50);
                    break;
            }
            ChangeObjectsAction();
        }
    }
}
