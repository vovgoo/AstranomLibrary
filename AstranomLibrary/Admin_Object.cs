using System;
using System.Drawing;
using System.Windows.Forms;

namespace AstranomLibrary
{
    public partial class Admin_Object : UserControl
    {
        private bool key = false;

        private int id;
        private string name;
        private string login;
        private string password;
        private int objectType;

        private Action changeObject;
        private Form1 form;

        public Admin_Object(int id, string name, string login, string password, Action changeObject, Form1 form, int objectType)
        {
            InitializeComponent();
            form.SetRoundedShape(this, 10);
            label1.Text = name;

            this.id = id;
            this.name = name;
            this.login = login;
            this.password = password;

            this.changeObject = changeObject;
            this.form = form;
            this.objectType = objectType;
        }

        // Дизайн

        //// Адаптивный дизайн

        private void Admin_Object_SizeChanged(object sender, EventArgs e)
        {
            form.SetRoundedShape(this, 10);
        }
        
        private void ChangeObjectsAction()
        {
            changeObject?.Invoke();
        }

        //// Анимация кнопок

        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            tableLayoutPanel1.BackColor = Color.FromArgb(50, 50, 50);
        }

        private void tableLayoutPanel1_MouseLeave(object sender, EventArgs e)
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

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            switch(objectType)
            {
                case 1:
                    form.Controls.Find("textBox7", true)[0].Text = name;
                    form.Controls.Find("textBox8", true)[0].Text = login;
                    form.Controls.Find("textBox9", true)[0].Text = password;
                    form.ChangeIndexAdmin(id);
                    ((TabControl)form.Controls.Find("tabControl1", true)[0]).SelectedIndex = 9;
                    break;
                case 2:
                    form.ChangeIndexAdmin(id);
                    if (Parent is FlowLayoutPanel flowLayoutPanel)
                    {
                        foreach (Admin_Object control in flowLayoutPanel.Controls)
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
