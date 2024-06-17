using System;
using System.Drawing;
using System.Windows.Forms;

namespace AstranomLibrary
{
    public partial class Library_Object : UserControl
    {
        private Action changeObject;
        private Form1 form;

        private int typeDatabaseObject;
        private string name;
        private string value1;
        private string value2;
        private string value3;
        private string value4;
        private string value5;
        private string value6;
        private string photoPath;

        public Library_Object(int idListObject, int typeDatabaseObject, string name, string value1, string value2, string value3, string value4, string value5, string value6, string photoPath, Action changeObject, Form1 form)
        {
            InitializeComponent();
            form.SetRoundedShape(panel1, 10);
            form.SetRoundedShape(this, 10);
            label1.Text = idListObject.ToString();
            label2.Text = typeDatabaseObject == 1 ? "Звезда" : "Планета";
            label4.Text = name;

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
        }

        // Дизайн

        //// Адаптивный дизайн

        private void Library_Object_SizeChanged(object sender, EventArgs e)
        {
            form.SetRoundedShape(panel1, 10);
            form.SetRoundedShape(this, 10);
        }

        private void ChangeObjectsAction()
        {
            changeObject?.Invoke();
        }

        //// Анимация кнопок

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Label label)
            {
                Panel panel = label.Parent as Panel;
                panel.BackColor = Color.FromArgb(45, 129, 139);
            }
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                Panel panel = label.Parent as Panel;
                panel.BackColor = Color.FromArgb(58, 168, 181);
            }
        }


        // Обработка кнопок

        //// Переход на старницу просмотра информации об объекте

        private void label5_Click(object sender, EventArgs e)
        {
            form.Controls.Find("textBox25", true)[0].Text = typeDatabaseObject == 1 ? "Звезда" : "Планета";
            form.Controls.Find("textBox26", true)[0].Text = name;
            form.Controls.Find("textBox27", true)[0].Text = value1;
            form.Controls.Find("textBox28", true)[0].Text = value2;
            form.Controls.Find("textBox29", true)[0].Text = value3;
            form.Controls.Find("textBox30", true)[0].Text = value4;
            form.Controls.Find("textBox31", true)[0].Text = value5;
            form.Controls.Find("textBox32", true)[0].Text = value6;

            try
            {
                form.Controls.Find("pictureBox5", true)[0].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image_user\\" + photoPath);
            }
            catch
            {
                form.Controls.Find("pictureBox5", true)[0].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");
            }

            switch (typeDatabaseObject)
            {
                case 1:
                    form.Controls.Find("label53", true)[0].Text = "Созвездие";
                    form.Controls.Find("label54", true)[0].Text = "Тип звезды";
                    form.Controls.Find("label55", true)[0].Text = "Видимая звездная величина";
                    form.Controls.Find("label56", true)[0].Text = "Расстояние от Земли";
                    form.Controls.Find("label57", true)[0].Text = "Прямое восхождение";
                    form.Controls.Find("label58", true)[0].Text = "Прямое склонение";
                    break;
                case 2:
                    form.Controls.Find("label53", true)[0].Text = "Тип планеты";
                    form.Controls.Find("label54", true)[0].Text = "Масса";
                    form.Controls.Find("label55", true)[0].Text = "Размер";
                    form.Controls.Find("label56", true)[0].Text = "Расстояние от Земли";
                    form.Controls.Find("label57", true)[0].Text = "Плотность атмосферы";
                    form.Controls.Find("label58", true)[0].Text = "Кол-во спутников";
                    break;
            }

            ((TabControl)form.Controls.Find("tabControl1", true)[0]).SelectedIndex = 5;
            ChangeObjectsAction();
        }
    }
}
