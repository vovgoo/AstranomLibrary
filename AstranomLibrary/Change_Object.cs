using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AstranomLibrary
{
    public partial class Change_Object : UserControl
    {
        int id;
        Action change_object;
        TabControl tabPage;
        int type_object;
        Form1 form;
        bool key = false;
        System.Windows.Forms.Label label42;
        System.Windows.Forms.Label label43;
        System.Windows.Forms.Label label44;
        System.Windows.Forms.Label label45;
        System.Windows.Forms.Label label46;
        System.Windows.Forms.Label label47;
        System.Windows.Forms.Label label40;
        System.Windows.Forms.Label label41;
        System.Windows.Forms.TextBox textBox24;
        System.Windows.Forms.TextBox textBox10;
        System.Windows.Forms.TextBox textBox18;
        System.Windows.Forms.TextBox textBox19;
        System.Windows.Forms.TextBox textBox20;
        System.Windows.Forms.TextBox textBox21;
        System.Windows.Forms.TextBox textBox22;
        System.Windows.Forms.TextBox textBox23;
        System.Windows.Forms.PictureBox pictureBox1;
        string conn;

        public Change_Object(string type, string name, Action change_object, TabControl tabPage, int type_object, int id, Form1 form, System.Windows.Forms.Label label42, System.Windows.Forms.Label label43, System.Windows.Forms.Label label44, System.Windows.Forms.Label label45, System.Windows.Forms.Label label46, System.Windows.Forms.Label label47, System.Windows.Forms.TextBox textBox24, System.Windows.Forms.TextBox textBox10, System.Windows.Forms.TextBox textBox18, System.Windows.Forms.TextBox textBox19, System.Windows.Forms.TextBox textBox20, System.Windows.Forms.TextBox textBox21, System.Windows.Forms.TextBox textBox22, System.Windows.Forms.TextBox textBox23, PictureBox pictureBox1, string conn)
        {
            InitializeComponent();
            label2.Text = type;
            label4.Text = name;
            SetRoundedShape(this, 10);
            this.change_object = change_object;
            this.tabPage = tabPage;
            this.type_object = type_object;
            this.id = id;
            this.form = form;
            this.label42 = label42;
            this.label43 = label43;
            this.label44 = label44;
            this.label45 = label45;
            this.label46 = label46;
            this.label47 = label47;
            this.textBox24 = textBox24;
            this.textBox10 = textBox10;
            this.textBox18 = textBox18;
            this.textBox19 = textBox19;
            this.textBox20 = textBox20;
            this.textBox21 = textBox21;
            this.textBox22 = textBox22;
            this.textBox23 = textBox23;
            this.pictureBox1 = pictureBox1;
            this.conn = conn;
        }

        static void SetRoundedShape(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddLine(radius, 0, control.Width - radius, 0);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(control.Width, radius, control.Width, control.Height - radius);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddLine(control.Width - radius, control.Height, radius, control.Height);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, control.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            control.Region = new Region(path);
        }

        private void Change_Object_SizeChanged(object sender, EventArgs e)
        {
            SetRoundedShape(this, 10);
        }

        private void change_objects()
        {
            this.change_object?.Invoke();
        }

        private void TurnedOff()
        {
            key = false;
            label1.BackColor = Color.FromArgb(35, 36, 41);
            label2.BackColor = Color.FromArgb(35, 36, 41);
            label3.BackColor = Color.FromArgb(35, 36, 41);
            label4.BackColor = Color.FromArgb(35, 36, 41);
            tableLayoutPanel1.BackColor = Color.FromArgb(35, 36, 41);
        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            if (type_object == 1)
            {
                if(label2.Text == "Планета")
                {
                    label42.Text = "Тип планеты";
                    label43.Text = "Масса (10^24 кг)";
                    label44.Text = "Размер (км)";
                    label45.Text = "Расстояние от Земли (А.Е.)";
                    label46.Text = "Плотность атмосферы (кг/м^3)";
                    label47.Text = "Кол-во спутников (шт.)";
                } else if (label2.Text == "Звезда")
                {
                    label42.Text = "Созвездие";
                    label43.Text = "Тип звезды";
                    label44.Text = "Видимая звездная величина";
                    label45.Text = "Расстояние от Земли (А.Е.)";
                    label46.Text = "Прямое восхождение (ч.)";
                    label47.Text = "Прямое склонение (ч.)";
                }

                textBox24.Clear();
                textBox10.Clear();
                textBox18.Clear();
                textBox19.Clear();
                textBox20.Clear();
                textBox21.Clear();
                textBox22.Clear();
                textBox23.Clear();
                pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");
                pictureBox1.Tag = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png";

                using (OleDbConnection connection = new OleDbConnection(conn))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT * FROM planet WHERE id_объекта = " + id;
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    textBox24.Text = label2.Text;
                                    textBox10.Text = label4.Text;
                                    textBox18.Text = reader.GetString(2);
                                    textBox19.Text = Convert.ToString(reader.GetDouble(3));
                                    textBox20.Text = Convert.ToString(reader.GetDouble(4));
                                    textBox21.Text = Convert.ToString(reader.GetDouble(5));
                                    textBox22.Text = Convert.ToString(reader.GetDouble(6));
                                    textBox23.Text = reader.GetString(7);
                                    pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image_user\\" + reader.GetString(8));
                                    pictureBox1.Tag = "";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка " + ex.Message);
                        pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");
                        pictureBox1.Tag = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png";
                    }
                }

                using (OleDbConnection connection = new OleDbConnection(conn))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT * FROM stars WHERE id_объекта = " + id;
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    textBox24.Text = label2.Text;
                                    textBox10.Text = label4.Text;
                                    textBox18.Text = reader.GetString(2);
                                    textBox19.Text = reader.GetString(3);
                                    textBox20.Text = Convert.ToString(reader.GetDouble(4));
                                    textBox21.Text = Convert.ToString(reader.GetDouble(5));
                                    textBox22.Text = Convert.ToString(reader.GetDouble(6));
                                    textBox23.Text = Convert.ToString(reader.GetDouble(7));
                                    pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image_user\\" + reader.GetString(8));
                                    pictureBox1.Tag = "";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка " + ex.Message);
                        pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");
                        pictureBox1.Tag = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png";
                    }
                }
                form.ChangeIndexObject(id);
                textBox19.KeyPress -= OnlyLetters_KeyPress;
                textBox23.KeyPress -= OnlyDouble_KeyPress;
                textBox19.KeyPress -= OnlyDouble_KeyPress;
                textBox23.KeyPress -= OnlyNumbers_KeyPress;

                if(textBox24.Text == "Звезда")
                {
                    textBox19.KeyPress += OnlyLetters_KeyPress;
                    textBox23.KeyPress += OnlyDouble_KeyPress;
                } else if(textBox24.Text == "Планета")
                {
                    textBox19.KeyPress += OnlyDouble_KeyPress;
                    textBox23.KeyPress += OnlyNumbers_KeyPress;
                }

                tabPage.SelectedIndex = 13;
                change_objects();
            } else if(type_object == 2)
            {
                form.ChangeIndexObject(id);
                if (this.Parent is FlowLayoutPanel flowLayoutPanel)
                {
                    foreach (Change_Object control in flowLayoutPanel.Controls)
                    {
                        control.TurnedOff();
                    }
                }
                label1.BackColor = Color.FromArgb(50, 50, 50);
                tableLayoutPanel1.BackColor = Color.FromArgb(50, 50, 50);
                key = true;
                change_objects();
            }
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            label1.BackColor = Color.FromArgb(50, 50, 50);
            label2.BackColor = Color.FromArgb(50, 50, 50);
            label3.BackColor = Color.FromArgb(50, 50, 50);
            label4.BackColor = Color.FromArgb(50, 50, 50);
            tableLayoutPanel1.BackColor = Color.FromArgb(50, 50, 50);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            if (key == false)
            {
                label1.BackColor = Color.FromArgb(35, 36, 41);
                label2.BackColor = Color.FromArgb(35, 36, 41);
                label3.BackColor = Color.FromArgb(35, 36, 41);
                label4.BackColor = Color.FromArgb(35, 36, 41);
                tableLayoutPanel1.BackColor = Color.FromArgb(35, 36, 41);
            }
        }

        private void OnlyLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void OnlyDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '-' && textBox.Text.Contains("-"))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && textBox.Text.Contains(","))
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}
