using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AstranomLibrary
{
    public partial class Admin_Object : UserControl
    {
        int id;
        TabControl tabPage;
        string connections;
        System.Windows.Forms.TextBox textBox7;
        System.Windows.Forms.TextBox textBox8;
        System.Windows.Forms.TextBox textBox9;
        Action change_object;
        int selected_index;
        Form1 form;
        int type_object;
        bool key = false;

        public Admin_Object(int _id, string name, TabControl tabPage1, string conn, System.Windows.Forms.TextBox _textBox7, System.Windows.Forms.TextBox _textBox8, System.Windows.Forms.TextBox _textBox9, Action change_object, Form1 form1, int type)
        {
            InitializeComponent();
            id = _id;
            label1.Text = name;
            tabPage = tabPage1;
            connections = conn;
            textBox7 = _textBox7;
            textBox8 = _textBox8;
            textBox9 = _textBox9;
            SetRoundedShape(this, 10);
            this.change_object = change_object;
            form = form1;
            type_object = type;
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

        private void Admin_Object_SizeChanged(object sender, EventArgs e)
        {
            SetRoundedShape(this, 10);
        }

        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.BackColor = Color.FromArgb(50,50,50);
            tableLayoutPanel1.BackColor = Color.FromArgb(50, 50, 50);
        }

        private void tableLayoutPanel1_MouseLeave(object sender, EventArgs e)
        {
            if (key == false)
            {
                label1.BackColor = Color.FromArgb(35, 36, 41);
                tableLayoutPanel1.BackColor = Color.FromArgb(35, 36, 41);
            }
        }

        private void change_objects()
        {
            this.change_object?.Invoke();
        }

        private void TurnedOff()
        {
            key = false;
            label1.BackColor = Color.FromArgb(35, 36, 41);
            tableLayoutPanel1.BackColor = Color.FromArgb(35, 36, 41);
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            if (type_object == 1)
            {
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                using (OleDbConnection connection = new OleDbConnection(connections))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT * FROM Admins WHERE id = " + id;
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    textBox7.Text = reader.GetString(1);
                                    textBox8.Text = reader.GetString(2);
                                    textBox9.Text = reader.GetString(3);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
                form.ChangeIndexAdmin(id);
                tabPage.SelectedIndex = 9;
                change_objects();
            } 
            else if(type_object == 2)
            {
                form.ChangeIndexAdmin(id);
                if (this.Parent is FlowLayoutPanel flowLayoutPanel)
                {
                    foreach (Admin_Object control in flowLayoutPanel.Controls)
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
    }
}
