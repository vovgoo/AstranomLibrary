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
using System.Windows.Forms;

namespace AstranomLibrary
{
    public partial class Library_Object : UserControl
    {
        private FlowLayoutPanel parent_panel;

        Action change_object;
        TabControl tabPage;

        System.Windows.Forms.Label label51;
        System.Windows.Forms.Label label52;
        System.Windows.Forms.Label label53;
        System.Windows.Forms.Label label54;
        System.Windows.Forms.Label label55;
        System.Windows.Forms.Label label56;
        System.Windows.Forms.Label label57;
        System.Windows.Forms.Label label58;
        System.Windows.Forms.TextBox textBox25;
        System.Windows.Forms.TextBox textBox26;
        System.Windows.Forms.TextBox textBox27;
        System.Windows.Forms.TextBox textBox28;
        System.Windows.Forms.TextBox textBox29;
        System.Windows.Forms.TextBox textBox30;
        System.Windows.Forms.TextBox textBox31;
        System.Windows.Forms.TextBox textBox32;
        System.Windows.Forms.PictureBox pictureBox1;
        int object_id;
        string conn;

        public Library_Object(FlowLayoutPanel _parent_panel, String id, String type, String Name, Int32 object_id, System.Windows.Forms.Label label51, System.Windows.Forms.Label label52, System.Windows.Forms.Label label53, System.Windows.Forms.Label label54, System.Windows.Forms.Label label55, System.Windows.Forms.Label label56, System.Windows.Forms.Label label57, System.Windows.Forms.Label label58, TextBox textBox25, TextBox textBox26, TextBox textBox27, TextBox textBox28, TextBox textBox29, TextBox textBox30, TextBox textBox31, TextBox textBox32, PictureBox pictureBox1, TabControl tabPage, Action object_change, string coonection)
        {
            InitializeComponent();
            label1.Text = id;
            label2.Text = type;
            label3.Text = "Название:";
            label4.Text = Name; 

            parent_panel = _parent_panel;
            this.Size = new Size(parent_panel.Width-40, 100);
            this.label51 = label51;
            this.label52 = label52;
            this.label53 = label53;
            this.label54 = label54;
            this.label55 = label55; 
            this.label56 = label56; 
            this.label57 = label57;
            this.label58 = label58;
            this.textBox25 = textBox25;
            this.textBox26 = textBox26;
            this.textBox27 = textBox27;
            this.textBox28 = textBox28;
            this.textBox29 = textBox29;
            this.textBox30 = textBox30;
            this.textBox31 = textBox31;
            this.textBox32 = textBox32;
            this.pictureBox1 = pictureBox1;
            this.tabPage = tabPage;
            this.change_object = object_change;
            this.conn = coonection;
            this.object_id = object_id;
            SetRoundedShape(panel1, 10);
            SetRoundedShape(this, 10);
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

        private void change_objects()
        {
            this.change_object?.Invoke();
        }

        private void Library_Object_SizeChanged(object sender, EventArgs e)
        {
            SetRoundedShape(panel1, 10);
            SetRoundedShape(this, 10);
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is System.Windows.Forms.Label label)
            {
                Panel panel = label.Parent as Panel;
                panel.BackColor = Color.FromArgb(45, 129, 139);
            }
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Label label)
            {
                Panel panel = label.Parent as Panel;
                panel.BackColor = Color.FromArgb(58, 168, 181);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Планета")
            {
                label53.Text = "Тип планеты";
                label54.Text = "Масса";
                label55.Text = "Размер";
                label56.Text = "Расстояние от Земли";
                label57.Text = "Плотность атмосферы";
                label58.Text = "Кол-во спутников";
            }
            else if (label2.Text == "Звезда")
            {
                label53.Text = "Созвездие";
                label54.Text = "Тип звезды";
                label55.Text = "Видимая звездная величина";
                label56.Text = "Расстояние от Земли";
                label57.Text = "Прямое восхождение";
                label58.Text = "Прямое склонение";
            }
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox28.Clear();
            textBox29.Clear();
            textBox30.Clear();
            textBox31.Clear();
            textBox32.Clear();
            pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM planet WHERE id_объекта = " + object_id.ToString();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                textBox25.Text = label2.Text;
                                textBox26.Text = label4.Text;
                                textBox27.Text = reader.GetString(2);
                                textBox28.Text = Convert.ToString(reader.GetDouble(3)) + " 10^24 кг";
                                textBox29.Text = Convert.ToString(reader.GetDouble(4)) + " км";
                                textBox30.Text = Convert.ToString(reader.GetDouble(5)) + " A.E.";
                                textBox31.Text = Convert.ToString(reader.GetDouble(6)) + " кг/м^3";
                                textBox32.Text = reader.GetString(7) + " шт.";


                                pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image_user\\" + reader.GetString(8));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка " + ex.Message);
                    pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");
                }
            }

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM stars WHERE id_объекта = " + object_id.ToString();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                textBox25.Text = label2.Text;
                                textBox26.Text = label4.Text;
                                textBox27.Text = reader.GetString(2);
                                textBox28.Text = reader.GetString(3);
                                textBox29.Text = Convert.ToString(reader.GetDouble(4));
                                textBox30.Text = Convert.ToString(reader.GetDouble(5)) + " А.Е.";
                                textBox31.Text = Convert.ToString(reader.GetDouble(6)) + " ч.";
                                textBox32.Text = Convert.ToString(reader.GetDouble(7)) + " ч.";
                                pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image_user\\" + reader.GetString(8));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка " + ex.Message);
                    pictureBox1.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");
                }
            }
            tabPage.SelectedIndex = 5;
            change_objects();
        }
    }
}
