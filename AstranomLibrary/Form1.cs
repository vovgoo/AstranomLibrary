using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace AstranomLibrary
{
    public partial class Form1 : Form
    {
        private Action change_objectss;

        private int selected_index = -1;
        private int selected_index_admin = -1;
        private int selected_index_change_object = -1;
        private int selected_photo = -1;
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=K:\Для программ\source\repos\AstranomLibrary\AstranomLibrary\Database.accdb";

        public Form1()
        {
            InitializeComponent();
            SetRoundShape_Function();
            change_objectss = change_objects;
        }

        // Дизайн

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

        private void SetRoundShape_Function()
        {
            SetRoundedShape(panel6, 20);
            SetRoundedShape(panel7, 20);
            SetRoundedShape(panel8, 20);
            SetRoundedShape(panel3, 10);
            SetRoundedShape(panel5, 10);
            SetRoundedShape(panel9, 10);
            SetRoundedShape(panel10, 20);
            SetRoundedShape(panel11, 20);
            SetRoundedShape(panel12, 10);
            SetRoundedShape(panel13, 20);
            SetRoundedShape(panel14, 20);
            SetRoundedShape(panel15, 20);
            SetRoundedShape(panel16, 20);
            SetRoundedShape(panel17, 20);
            SetRoundedShape(panel18, 20);
            SetRoundedShape(panel19, 20);
            SetRoundedShape(panel20, 20);
            SetRoundedShape(panel21, 20);
            SetRoundedShape(panel22, 20);
            SetRoundedShape(panel23, 20);
            SetRoundedShape(panel24, 20);
            SetRoundedShape(panel25, 20);
            SetRoundedShape(panel26, 20);
            SetRoundedShape(panel27, 20);
            SetRoundedShape(panel28, 20);
            SetRoundedShape(panel29, 20);
            SetRoundedShape(panel30, 20);
            SetRoundedShape(panel31, 20);
            SetRoundedShape(panel32, 20);
            SetRoundedShape(panel33, 20);
            SetRoundedShape(panel34, 20);
            SetRoundedShape(panel35, 20);
            SetRoundedShape(panel36, 20);
            SetRoundedShape(panel37, 20);
            SetRoundedShape(panel38, 20);
            SetRoundedShape(panel39, 20);
            SetRoundedShape(panel40, 20);
            SetRoundedShape(panel41, 20);
            SetRoundedShape(panel42, 20);
            SetRoundedShape(panel43, 20);
            SetRoundedShape(panel44, 20);
            SetRoundedShape(panel45, 20);
        }

        private Int32 get_margin(TableLayoutPanel tableLayoutPanel, int id, double percent)
        {
            return Convert.ToInt32((this.Height * (tableLayoutPanel.RowStyles[id].Height / 100) - (tableLayoutPanel.RowStyles[id].Height / 100 * this.Height * percent)) / 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tabControl1.Location = new Point(-7, -29);
            this.tabControl1.Size = new Size(panel1.Width + 15, panel1.Height + 40);
        }

        private void change_objects()
        {
            try
            {
                this.tabControl1.Size = new Size(panel1.Width + 15, panel1.Height + 40);

                Font currentFont = textBox1.Font;

                this.comboBox1.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox1.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox2.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox3.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox4.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox5.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox6.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox7.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox8.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox9.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox10.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox11.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox12.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox13.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox14.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox15.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox16.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox17.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox18.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox19.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox20.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox21.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox22.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox23.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox24.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox25.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox26.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox27.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox28.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox29.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox30.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox31.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.textBox32.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                

                this.label1.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label2.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label3.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label4.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label5.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label6.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label7.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label8.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 1, FontStyle.Bold);
                this.label9.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label10.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label11.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label12.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label13.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label14.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label15.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label16.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label17.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label18.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label19.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label20.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label21.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label22.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label23.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label24.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label25.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label26.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label27.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label28.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label29.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label30.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label31.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label32.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label33.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label34.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label35.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label36.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label37.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label38.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label39.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label40.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label41.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label42.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label43.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label44.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label45.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label46.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label47.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label48.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label49.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label50.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label51.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label52.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label53.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label54.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label55.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label56.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label57.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label58.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label59.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label60.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label61.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 4, FontStyle.Bold);
                this.label62.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label63.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label64.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label65.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label66.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label67.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label68.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label69.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);
                this.label70.Font = new Font(currentFont.FontFamily, Convert.ToInt32(this.Height / 72) + 2, FontStyle.Bold);


                // Верхнее меню

                this.panel3.Margin = new Padding(get_margin(tableLayoutPanel1, 0, 0.41), get_margin(tableLayoutPanel1, 0, 0.41), get_margin(tableLayoutPanel1, 0, 0.41), get_margin(tableLayoutPanel1, 0, 0.41));
                this.panel5.Margin = new Padding(get_margin(tableLayoutPanel1, 0, 0.41), get_margin(tableLayoutPanel1, 0, 0.41), get_margin(tableLayoutPanel1, 0, 0.41), get_margin(tableLayoutPanel1, 0, 0.41));

                this.panel6.Margin = new Padding(40, get_margin(tableLayoutPanel1, 0, 0.41), 0, get_margin(tableLayoutPanel1, 0, 0.41));
                this.panel6.Padding = new Padding(10, Convert.ToInt32((panel6.Height - textBox1.Height) / 2), 10, 0);
                
                // Авторизация

                this.panel7.Margin = new Padding(60, get_margin(tableLayoutPanel3, 2, 0.85), 60, get_margin(tableLayoutPanel3, 2, 0.85));
                this.panel7.Padding = new Padding(10, Convert.ToInt32((panel7.Height - textBox2.Height) / 2), 10, 0);
                
                this.panel8.Margin = new Padding(60, get_margin(tableLayoutPanel3, 2, 0.85), 60, get_margin(tableLayoutPanel3, 2, 0.85));
                this.panel8.Padding = new Padding(10, Convert.ToInt32((panel8.Height - textBox3.Height) / 2), 10, 0);
                
                // Добавление администратора

                this.panel10.Margin = new Padding(60, get_margin(tableLayoutPanel5, 3, 0.85), 60, get_margin(tableLayoutPanel5, 3, 0.85));
                this.panel10.Padding = new Padding(10, Convert.ToInt32((panel10.Height - textBox4.Height) / 2), 10, 0);
                
                this.panel11.Margin = new Padding(60, get_margin(tableLayoutPanel5, 3, 0.85), 60, get_margin(tableLayoutPanel5, 3, 0.85));
                this.panel11.Padding = new Padding(10, Convert.ToInt32((panel11.Height - textBox5.Height) / 2), 10, 0);
                
                this.panel13.Margin = new Padding(60, get_margin(tableLayoutPanel5, 3, 0.85), 60, get_margin(tableLayoutPanel5, 3, 0.85));
                this.panel13.Padding = new Padding(10, Convert.ToInt32((panel13.Height - textBox6.Height) / 2), 10, 0);

                // Редактирование администратора

                this.panel14.Margin = new Padding(60, get_margin(tableLayoutPanel8, 3, 0.85), 60, get_margin(tableLayoutPanel8, 3, 0.85));
                this.panel14.Padding = new Padding(10, Convert.ToInt32((panel14.Height - textBox7.Height) / 2), 10, 0);

                this.panel15.Margin = new Padding(60, get_margin(tableLayoutPanel8, 3, 0.85), 60, get_margin(tableLayoutPanel8, 3, 0.85));
                this.panel15.Padding = new Padding(10, Convert.ToInt32((panel15.Height - textBox8.Height) / 2), 10, 0);

                this.panel18.Margin = new Padding(60, get_margin(tableLayoutPanel8, 3, 0.85), 60, get_margin(tableLayoutPanel8, 3, 0.85));
                this.panel18.Padding = new Padding(10, Convert.ToInt32((panel18.Height - textBox9.Height) / 2), 10, 0);

                // Добавление информации

                this.panel19.Margin = new Padding(5, get_margin(tableLayoutPanel9, 2, 0.71), 5, get_margin(tableLayoutPanel9, 2, 0.71));
                this.panel19.Padding = new Padding(10, Convert.ToInt32((panel19.Height - comboBox1.Height) / 2), 10, 0);

                this.panel21.Margin = new Padding(5, get_margin(tableLayoutPanel9, 2, 0.71), 5, get_margin(tableLayoutPanel9, 2, 0.71));
                this.panel21.Padding = new Padding(10, Convert.ToInt32((panel21.Height - textBox11.Height) / 2), 10, 0);

                this.panel22.Margin = new Padding(5, get_margin(tableLayoutPanel9, 2, 0.71), 5, get_margin(tableLayoutPanel9, 2, 0.71));
                this.panel22.Padding = new Padding(10, Convert.ToInt32((panel22.Height - textBox12.Height) / 2), 10, 0);

                this.panel23.Margin = new Padding(5, get_margin(tableLayoutPanel9, 2, 0.71), 5, get_margin(tableLayoutPanel9, 2, 0.71));
                this.panel23.Padding = new Padding(10, Convert.ToInt32((panel23.Height - textBox13.Height) / 2), 10, 0);

                this.panel24.Margin = new Padding(5, get_margin(tableLayoutPanel9, 2, 0.71), 5, get_margin(tableLayoutPanel9, 2, 0.71));
                this.panel24.Padding = new Padding(10, Convert.ToInt32((panel24.Height - textBox17.Height) / 2), 10, 0);

                this.panel25.Margin = new Padding(5, get_margin(tableLayoutPanel9, 2, 0.71), 5, get_margin(tableLayoutPanel9, 2, 0.71));
                this.panel25.Padding = new Padding(10, Convert.ToInt32((panel25.Height - textBox16.Height) / 2), 10, 0);

                this.panel26.Margin = new Padding(5, get_margin(tableLayoutPanel9, 2, 0.71), 5, get_margin(tableLayoutPanel9, 2, 0.71));
                this.panel26.Padding = new Padding(10, Convert.ToInt32((panel26.Height - textBox15.Height) / 2), 10, 0);

                this.panel27.Margin = new Padding(5, get_margin(tableLayoutPanel9, 2, 0.71), 5, get_margin(tableLayoutPanel9, 2, 0.71));
                this.panel27.Padding = new Padding(10, Convert.ToInt32((panel27.Height - textBox14.Height) / 2), 10, 0);


                this.panel28.Margin = new Padding(60, get_margin(tableLayoutPanel9, 2, 0.71), 60, get_margin(tableLayoutPanel9, 2, 0.71));


                // Редактирование информации

                this.panel29.Margin = new Padding(5, get_margin(tableLayoutPanel12, 2, 0.71), 5, get_margin(tableLayoutPanel12, 2, 0.71));
                this.panel29.Padding = new Padding(10, Convert.ToInt32((panel29.Height - textBox24.Height) / 2), 10, 0);

                this.panel30.Margin = new Padding(5, get_margin(tableLayoutPanel12, 2, 0.71), 5, get_margin(tableLayoutPanel12, 2, 0.71));
                this.panel30.Padding = new Padding(10, Convert.ToInt32((panel30.Height - textBox10.Height) / 2), 10, 0);

                this.panel31.Margin = new Padding(5, get_margin(tableLayoutPanel12, 2, 0.71), 5, get_margin(tableLayoutPanel12, 2, 0.71));
                this.panel31.Padding = new Padding(10, Convert.ToInt32((panel31.Height - textBox18.Height) / 2), 10, 0);

                this.panel32.Margin = new Padding(5, get_margin(tableLayoutPanel12, 2, 0.71), 5, get_margin(tableLayoutPanel12, 2, 0.71));
                this.panel32.Padding = new Padding(10, Convert.ToInt32((panel32.Height - textBox19.Height) / 2), 10, 0);

                this.panel33.Margin = new Padding(5, get_margin(tableLayoutPanel12, 2, 0.71), 5, get_margin(tableLayoutPanel12, 2, 0.71));
                this.panel33.Padding = new Padding(10, Convert.ToInt32((panel33.Height - textBox20.Height) / 2), 10, 0);

                this.panel34.Margin = new Padding(5, get_margin(tableLayoutPanel12, 2, 0.71), 5, get_margin(tableLayoutPanel12, 2, 0.71));
                this.panel34.Padding = new Padding(10, Convert.ToInt32((panel34.Height - textBox21.Height) / 2), 10, 0);

                this.panel35.Margin = new Padding(5, get_margin(tableLayoutPanel12, 2, 0.71), 5, get_margin(tableLayoutPanel12, 2, 0.71));
                this.panel35.Padding = new Padding(10, Convert.ToInt32((panel35.Height - textBox22.Height) / 2), 10, 0);

                this.panel36.Margin = new Padding(5, get_margin(tableLayoutPanel12, 2, 0.71), 5, get_margin(tableLayoutPanel12, 2, 0.71));
                this.panel36.Padding = new Padding(10, Convert.ToInt32((panel36.Height - textBox23.Height) / 2), 10, 0);

                this.panel37.Margin = new Padding(60, get_margin(tableLayoutPanel12, 2, 0.71), 60, get_margin(tableLayoutPanel12, 2, 0.71));

                // Информаци о объекте

                this.panel38.Margin = new Padding(5, get_margin(tableLayoutPanel4, 2, 0.71), 5, get_margin(tableLayoutPanel4, 2, 0.71));
                this.panel38.Padding = new Padding(10, Convert.ToInt32((panel38.Height - textBox25.Height) / 2), 10, 0);

                this.panel39.Margin = new Padding(5, get_margin(tableLayoutPanel4, 2, 0.71), 5, get_margin(tableLayoutPanel4, 2, 0.71));
                this.panel39.Padding = new Padding(10, Convert.ToInt32((panel39.Height - textBox26.Height) / 2), 10, 0);

                this.panel40.Margin = new Padding(5, get_margin(tableLayoutPanel4, 2, 0.71), 5, get_margin(tableLayoutPanel4, 2, 0.71));
                this.panel40.Padding = new Padding(10, Convert.ToInt32((panel40.Height - textBox27.Height) / 2), 10, 0);

                this.panel41.Margin = new Padding(5, get_margin(tableLayoutPanel4, 2, 0.71), 5, get_margin(tableLayoutPanel4, 2, 0.71));
                this.panel41.Padding = new Padding(10, Convert.ToInt32((panel41.Height - textBox28.Height) / 2), 10, 0);

                this.panel42.Margin = new Padding(5, get_margin(tableLayoutPanel4, 2, 0.71), 5, get_margin(tableLayoutPanel4, 2, 0.71));
                this.panel42.Padding = new Padding(10, Convert.ToInt32((panel42.Height - textBox29.Height) / 2), 10, 0);

                this.panel43.Margin = new Padding(5, get_margin(tableLayoutPanel4, 2, 0.71), 5, get_margin(tableLayoutPanel4, 2, 0.71));
                this.panel43.Padding = new Padding(10, Convert.ToInt32((panel43.Height - textBox30.Height) / 2), 10, 0);

                this.panel44.Margin = new Padding(5, get_margin(tableLayoutPanel4, 2, 0.71), 5, get_margin(tableLayoutPanel4, 2, 0.71));
                this.panel44.Padding = new Padding(10, Convert.ToInt32((panel44.Height - textBox31.Height) / 2), 10, 0);

                this.panel45.Margin = new Padding(5, get_margin(tableLayoutPanel4, 2, 0.71), 5, get_margin(tableLayoutPanel4, 2, 0.71));
                this.panel45.Padding = new Padding(10, Convert.ToInt32((panel45.Height - textBox32.Height) / 2), 10, 0);

                //this.panel9.Margin = new Padding(60, get_margin(tableLayoutPanel3, 2, 0.85), 60, get_margin(tableLayoutPanel3, 2, 0.85));

                SetRoundShape_Function();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            change_objects();
        }
        
        private void panel6_SizeChanged(object sender, EventArgs e)
        {
            this.panel6.Padding = new Padding(20,Convert.ToInt32(this.panel6.Height / 2.4),20,0);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            Label panel = sender as Label;
            panel.BackColor = Color.FromArgb(12, 12, 12);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            Label panel = sender as Label;
            panel.BackColor = Color.FromArgb(35, 36, 41);
        }

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

        private void flowLayoutPanel2_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel2.SuspendLayout();
            foreach (Control ctrl in flowLayoutPanel2.Controls)
            {
                ctrl.Width = flowLayoutPanel2.Width-40;
            }
            flowLayoutPanel2.ResumeLayout();
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.SuspendLayout();
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                ctrl.Width = flowLayoutPanel1.Width - 40;
            }
            flowLayoutPanel1.ResumeLayout();
        }

        private void flowLayoutPanel3_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel3.SuspendLayout();
            foreach (Control ctrl in flowLayoutPanel3.Controls)
            {
                ctrl.Width = flowLayoutPanel3.Width - 40;
            }
            flowLayoutPanel3.ResumeLayout();
        }

        private void flowLayoutPanel4_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel4.SuspendLayout();
            foreach (Control ctrl in flowLayoutPanel4.Controls)
            {
                ctrl.Width = flowLayoutPanel4.Width - 40;
            }
            flowLayoutPanel4.ResumeLayout();
        }

        private void flowLayoutPanel5_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel5.SuspendLayout();
            foreach (Control ctrl in flowLayoutPanel5.Controls)
            {
                ctrl.Width = flowLayoutPanel5.Width - 40;
            }
            flowLayoutPanel5.ResumeLayout();
        }

        private void flowLayoutPanel6_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel6.SuspendLayout();
            foreach (Control ctrl in flowLayoutPanel6.Controls)
            {
                ctrl.Width = flowLayoutPanel6.Width - 40;
            }
            flowLayoutPanel6.ResumeLayout();
        }

        private void flowLayoutPanel7_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel7.SuspendLayout();
            foreach (Control ctrl in flowLayoutPanel7.Controls)
            {
                ctrl.Width = flowLayoutPanel7.Width - 40;
            }
            flowLayoutPanel7.ResumeLayout();
        }

        // Переходы

        private void label63_Click(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                switch (control.Name)
                {
                    case "pictureBox1": // Логотип
                        if (selected_index == -1)
                        {
                            selected_index_admin = -1;
                            selected_index_change_object = -1;
                            tabControl1.SelectedIndex = 0;
                        }
                        else
                        {
                            selected_index_admin = -1;
                            selected_index_change_object = -1;
                            tabControl1.SelectedIndex = 14;
                        }
                        change_objects();
                        break;
                    case "label2": // Информация о звездах
                        Load_List_Object(flowLayoutPanel2, "Звезда", "stars");
                        tabControl1.SelectedIndex = 1;
                        change_objects();
                        break;
                    case "label3": // Информация о планетах
                        Load_List_Object(flowLayoutPanel1, "Планета", "planet");
                        tabControl1.SelectedIndex = 2;
                        change_objects();
                        break;
                    case "label5": // Поиск
                        flowLayoutPanel3.Controls.Clear();
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                string query;
                                if (textBox1.Text == "Введите критерий")
                                {
                                    query = "SELECT id FROM List_Object";
                                }
                                else
                                {
                                    query = "SELECT id FROM List_Object WHERE [Название объекта] LIKE '%" + textBox1.Text + "%'";
                                }
                                using (OleDbCommand command = new OleDbCommand(query, connection))
                                {
                                    using (OleDbDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            int id = reader.GetInt32(0);
                                            Search_List_Object(id);
                                            textBox1.Text = "Введите критерий";
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка: " + ex.Message);
                            }
                        }
                        textBox1.Text = "Введите критерий";
                        tabControl1.SelectedIndex = 3;
                        change_objects();
                        break;
                    case "label6": // Авторизация
                        if (label6.Text == "Войти")
                        {
                            textBox2.Clear();
                            textBox3.Clear();
                            tabControl1.SelectedIndex = 4;
                            panel52.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_open.png");
                            textBox3.PasswordChar = '*';
                        }
                        else
                        {
                            label6.Text = "Войти";
                            selected_index = -1;
                            tabControl1.SelectedIndex = 0;
                        }
                        change_objects();
                        break;
                    case "label12": // Вход в личный кабинет через авторизацию
                        tabControl1.SelectedIndex = 14;
                        change_objects();
                        break;
                    case "label63": // Добавление информации переход
                        tabControl1.SelectedIndex = 10;
                        comboBox1.SelectedIndex = 0;
                        textBox11.Clear();
                        textBox12.Clear();
                        textBox13.Clear();
                        textBox14.Clear();
                        textBox15.Clear();
                        textBox16.Clear();
                        textBox17.Clear();
                        pictureBox3.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");
                        pictureBox3.Tag = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png";
                        change_objects();
                        break;
                    case "label64": // Редактирование информации переход
                        flowLayoutPanel6.Controls.Clear();
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                string query = "SELECT * FROM List_Object";
                                using (OleDbCommand command = new OleDbCommand(query, connection))
                                {
                                    using (OleDbDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            int id = reader.GetInt32(0);
                                            string name = reader.GetString(1);
                                            Change_Object obj = new Change_Object(GetObjectType(id), name, change_objectss, this.tabControl1, 1,id, this, label42, label43, label44, label45, label46, label47, textBox24, textBox10, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, pictureBox4, connectionString);
                                            flowLayoutPanel6.Controls.Add(obj);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка: " + ex.Message);
                            }
                        }
                        tabControl1.SelectedIndex = 11;
                        change_objects();
                        break;
                    case "label65": // Удаление информации переход
                        flowLayoutPanel7.Controls.Clear();
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                string query = "SELECT * FROM List_Object";
                                using (OleDbCommand command = new OleDbCommand(query, connection))
                                {
                                    using (OleDbDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            int id = reader.GetInt32(0);
                                            string name = reader.GetString(1);
                                            Change_Object obj = new Change_Object(GetObjectType(id), name, change_objectss, this.tabControl1, 2, id, this, label42, label43, label44, label45, label46, label47, textBox24, textBox10, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, pictureBox4, connectionString);
                                            flowLayoutPanel7.Controls.Add(obj);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка: " + ex.Message);
                            }
                        }
                        tabControl1.SelectedIndex = 12;
                        change_objects();
                        break;
                    case "label66": // Удалить администратора переход
                        tabControl1.SelectedIndex = 8;
                        flowLayoutPanel5.Controls.Clear();
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                string query = "SELECT * FROM Admins";
                                using (OleDbCommand command = new OleDbCommand(query, connection))
                                {
                                    using (OleDbDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            Admin_Object obj = new Admin_Object(reader.GetInt32(0), reader.GetString(2), tabControl1, connectionString, textBox7, textBox8, textBox9, change_objectss, this, 2);
                                            flowLayoutPanel5.Controls.Add(obj);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка: " + ex.Message);
                            }
                        }
                        change_objects();
                        break;
                    case "label67": // Редактирование администратора переход
                        flowLayoutPanel4.Controls.Clear();
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                string query = "SELECT * FROM Admins";
                                using (OleDbCommand command = new OleDbCommand(query, connection))
                                {
                                    using (OleDbDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            Admin_Object obj = new Admin_Object(reader.GetInt32(0), reader.GetString(2), tabControl1, connectionString, textBox7, textBox8, textBox9, change_objectss, this, 1);
                                            flowLayoutPanel4.Controls.Add(obj);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка: " + ex.Message);
                            }
                        }
                        tabControl1.SelectedIndex = 7;
                        change_objects();
                        break;
                    case "label68": // Добавление администратора переход
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        tabControl1.SelectedIndex = 6;
                        change_objects();
                        break;
                }
            }
        }

        // Функции для бд

        private string Get_Name_By_ID(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM List_Object WHERE id = " + id;
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                String name = reader.GetString(1);
                                return name;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                    return "None";
                }
            }
            return "None";
        }

        private void Load_List_Object(FlowLayoutPanel flowLayoutPanel, string name, string type)
        {
            flowLayoutPanel.Controls.Clear();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id_объекта FROM " + type;
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                Library_Object obj = new Library_Object(flowLayoutPanel, (flowLayoutPanel.Controls.Count + 1).ToString(), name, Get_Name_By_ID(id), id, label51, label52, label53, label54, label55, label56, label57, label58, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, pictureBox5, tabControl1, change_objectss, connectionString);
                                flowLayoutPanel.Controls.Add(obj);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }

            if(flowLayoutPanel.Controls.Count == 0)
            {
                MessageBox.Show("К сожалению ничего не найдено.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Search_List_Object(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM stars WHERE [id_объекта] = " + id;
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id_object_star = reader.GetInt32(0);
                                Library_Object obj = new Library_Object(flowLayoutPanel3, (flowLayoutPanel3.Controls.Count + 1).ToString(), "Звезда", Get_Name_By_ID(id), id_object_star, label51, label52, label53, label54, label55, label56, label57, label58, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, pictureBox5, tabControl1, change_objectss, connectionString);
                                flowLayoutPanel3.Controls.Add(obj);
                            }
                        }
                    }
                    query = "SELECT * FROM planet WHERE [id_объекта] = " + id;
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id_object_planet = reader.GetInt32(0);
                                Library_Object obj = new Library_Object(flowLayoutPanel3, (flowLayoutPanel3.Controls.Count + 1).ToString(), "Планета", Get_Name_By_ID(id), id_object_planet, label51, label52, label53, label54, label55, label56, label57, label58, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, pictureBox5, tabControl1, change_objectss, connectionString);
                                flowLayoutPanel3.Controls.Add(obj);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private int Get_Max_Id_Admin()
        {
            int maxId = -1;
            string selectQuery = "SELECT MAX(id) FROM admins";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }

            return maxId;
        }

        private int Get_Max_Id_Planet()
        {
            int maxId = -1;
            string selectQuery = "SELECT MAX(id) FROM Planet";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }

            return maxId;
        }

        private int Get_Max_Id_Stars()
        {
            int maxId = -1;
            string selectQuery = "SELECT MAX(id) FROM Stars";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }

            return maxId;
        }

        private int Get_Max_Id_List_Object()
        {
            int maxId = -1;
            string selectQuery = "SELECT MAX(id) FROM List_Object";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }

            return maxId;
        }

        static bool IsLoginExists(string login)
        {
            string selectQuery = "SELECT COUNT(*) FROM admins WHERE [Логин администратора] = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("?", login);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                    return false; 
                }
            }
        }

        private string GetAdminLoginById(int id)
        {
            string login = null;
            string selectQuery = "SELECT [Логин администратора] FROM admins WHERE id = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("?", id);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        login = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }

            return login;
        }

        private void InsertAdmin(int id, string adminName, string login, string password)
        {
            string insertQuery = "INSERT INTO admins (id, [Название администратора], [Логин администратора], [Пароль администратора]) VALUES (?, ?, ?, ?)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("?", id);
                    command.Parameters.AddWithValue("?", adminName);
                    command.Parameters.AddWithValue("?", login);
                    command.Parameters.AddWithValue("?", password);
                    int rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void UpdateAdmin(int id, string adminName, string login, string password)
        {
            string updateQuery = "UPDATE admins SET [Название администратора] = ?, [Логин администратора] = ?, [Пароль администратора] = ? WHERE id = ?";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("?", adminName);
                    command.Parameters.AddWithValue("?", login);
                    command.Parameters.AddWithValue("?", password);
                    command.Parameters.AddWithValue("?", id);
                    int rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }
        }

        public void ChangeIndexAdmin(int index)
        {
            this.selected_index_admin = index;
        }

        static void InsertDataIntoTable(int id, int idObject, string planetType, double mass, double size, double distance, double hasAtmosphere, double satellites, string photoFileName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insertSql = "INSERT INTO Planet (id ,id_объекта, [Тип планеты], [Масса], [Размер], [Расстояние от Солнца], [Плотность атмосферы], [Спутники], [Фотография]) VALUES (? ,?, ?, ?, ?, ?, ?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(insertSql, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.Parameters.AddWithValue("id_объекта", idObject);
                        cmd.Parameters.AddWithValue("[Тип планеты]", planetType);
                        cmd.Parameters.AddWithValue("[Масса]", mass);
                        cmd.Parameters.AddWithValue("[Размер]", size);
                        cmd.Parameters.AddWithValue("[Расстояние от Солнца]", distance);
                        cmd.Parameters.AddWithValue("[Плотность атмосферы]", hasAtmosphere);
                        cmd.Parameters.AddWithValue("[Спутники]", satellites);
                        cmd.Parameters.AddWithValue("[Фотография]", photoFileName);
                        cmd.ExecuteNonQuery();

                   }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        static void InsertDataIntoStarsTable(int id, int idObject, string constellation, string starType, double apparentMagnitude, double distanceFromEarth, double rightAscension, double declination, string photoFileName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insertSql = "INSERT INTO Stars (id, id_объекта, [Созвездие], [Тип звезды], [Видимая звездная величина], [Расстояние от Земли], [Прямое восхождение], [Прямое склонение], [Фотография]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(insertSql, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.Parameters.AddWithValue("id_объекта", idObject);
                        cmd.Parameters.AddWithValue("[Созвездие]", constellation);
                        cmd.Parameters.AddWithValue("[Тип звезды]", starType);
                        cmd.Parameters.AddWithValue("[Видимая звездная величина]", apparentMagnitude);
                        cmd.Parameters.AddWithValue("[Расстояние от Земли]", distanceFromEarth);
                        cmd.Parameters.AddWithValue("[Прямое восхождение]", rightAscension);
                        cmd.Parameters.AddWithValue("[Прямое склонение]", declination);
                        cmd.Parameters.AddWithValue("[Фотография]", photoFileName);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Данные успешно добавлены в таблицу.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        static void InsertDataIntoListObjectTable(int idObject, string objectName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insertSql = "INSERT INTO List_Object (id, [Название объекта]) VALUES (?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(insertSql, connection))
                    {
                        cmd.Parameters.AddWithValue("id", idObject);
                        cmd.Parameters.AddWithValue("[Название объекта]", objectName);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Данные успешно добавлены в таблицу.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        static void UpdateDataInPlanetTable(int idObject, string planetType, double mass, double size, double distanceFromSun, double hasAtmosphere, double satellites, string photoFileName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateSql = "UPDATE Planet SET [Тип планеты] = ?, [Масса] = ?, [Размер] = ?, [Расстояние от Солнца] = ?, [Плотность атмосферы] = ?, [Спутники] = ?, [Фотография] = ? WHERE id_объекта = ?";
                    using (OleDbCommand cmd = new OleDbCommand(updateSql, connection))
                    {
                        cmd.Parameters.AddWithValue("[Тип планеты]", planetType);
                        cmd.Parameters.AddWithValue("[Масса]", mass);
                        cmd.Parameters.AddWithValue("[Размер]", size);
                        cmd.Parameters.AddWithValue("[Расстояние от Солнца]", distanceFromSun);
                        cmd.Parameters.AddWithValue("[Плотность атмосферы]", hasAtmosphere);
                        cmd.Parameters.AddWithValue("[Спутники]", satellites);
                        cmd.Parameters.AddWithValue("[Фотография]", photoFileName);
                        cmd.Parameters.AddWithValue("id_объекта", idObject);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Данные успешно обновлены в таблице Planet.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        static void UpdateDataInStarsTable(int idObject, string constellation, string starType, double apparentMagnitude, double distanceFromEarth, double rightAscension, double declination, string photoFileName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateSql = "UPDATE Stars SET [Созвездие] = ?, [Тип звезды] = ?, [Видимая звездная величина] = ?, [Расстояние от Земли] = ?, [Прямое восхождение] = ?, [Прямое склонение] = ?, [Фотография] = ? WHERE id_объекта = ?";
                    using (OleDbCommand cmd = new OleDbCommand(updateSql, connection))
                    {
                        cmd.Parameters.AddWithValue("[Созвездие]", constellation);
                        cmd.Parameters.AddWithValue("[Тип звезды]", starType);
                        cmd.Parameters.AddWithValue("[Видимая звездная величина]", apparentMagnitude);
                        cmd.Parameters.AddWithValue("[Расстояние от Земли]", distanceFromEarth);
                        cmd.Parameters.AddWithValue("[Прямое восхождение]", rightAscension);
                        cmd.Parameters.AddWithValue("[Прямое склонение]", declination);
                        cmd.Parameters.AddWithValue("[Фотография]", photoFileName);
                        cmd.Parameters.AddWithValue("id_объекта", idObject);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Данные успешно обновлены в таблице Stars.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        static void UpdateDataInListObjectTable(int id, string newObjectName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateSql = "UPDATE List_Object SET [Название объекта] = ? WHERE id = ?";
                    using (OleDbCommand cmd = new OleDbCommand(updateSql, connection))
                    {
                        cmd.Parameters.AddWithValue("[Название объекта]", newObjectName);
                        cmd.Parameters.AddWithValue("id", id);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Данные успешно обновлены в таблице List_Object.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        public string GetObjectType(int objectId)
        {
            string queryStars = "SELECT id FROM stars WHERE id_объекта = ?";
            string queryPlanets = "SELECT id FROM planet WHERE id_объекта = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                using (OleDbCommand commandStars = new OleDbCommand(queryStars, connection))
                using (OleDbCommand commandPlanets = new OleDbCommand(queryPlanets, connection))
                {
                    commandStars.Parameters.AddWithValue("@id", objectId);
                    commandPlanets.Parameters.AddWithValue("@id", objectId);

                    bool existsInStars = commandStars.ExecuteScalar() != null;
                    bool existsInPlanets = commandPlanets.ExecuteScalar() != null;

                    if (existsInStars)
                    {
                        return "Звезда";
                    }
                    else if (existsInPlanets)
                    {
                        return "Планета";
                    }
                    else
                    {
                        return "Объект не найден";
                    }
                }
            }
        }

        public void ChangeIndexObject(int index)
        {
            this.selected_index_change_object = index;
        }


        // Обработка кнопок

        private void label12_Click(object sender, EventArgs e) // Авторизация
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id FROM admins WHERE [Логин администратора] = '" + textBox2.Text + "' AND [Пароль администратора] = '" + textBox3.Text + "'";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    selected_index = reader.GetInt32(0);
                                    label6.Text = "Выйти";
                                    tabControl1.SelectedIndex = 14;
                                    MessageBox.Show("Вы успешно авторизованы!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    change_objects();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Проверьте правильность введенных данных!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void label25_Click(object sender, EventArgs e) //  Добавление
        {
            if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Не все поля заполнены. Добавление новой записи невозможно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsLoginExists(textBox5.Text))
            {
                MessageBox.Show("Администратор с данным логином уже существует. Добавление новой записи невозможно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            InsertAdmin(Get_Max_Id_Admin() + 1, textBox4.Text, textBox5.Text, textBox6.Text);
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            MessageBox.Show("Новый администратор успешно добавлен.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
         
        private void label17_Click(object sender, EventArgs e) // Удаление
        {
            if(selected_index_admin == -1)
            {
                MessageBox.Show("Выберите администратора которого хотите удалить.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(selected_index == selected_index_admin)
            {
                MessageBox.Show("Вы не можете удалить самого себя.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectQuery = "DELETE FROM admins WHERE id = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("?", selected_index_admin);
                    var result = command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }

            MessageBox.Show("Администратор был успешно удален.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

            selected_index_admin = -1;
            tabControl1.SelectedIndex = 14;
            change_objects();
        }

        private void label20_Click(object sender, EventArgs e) // Редактировать
        {
            if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Не все поля заполнены. Редактирование записи невозможно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsLoginExists(textBox8.Text) && GetAdminLoginById(selected_index_admin) != textBox8.Text)
            {
                MessageBox.Show("Администратор с данным логином уже существует. Редактирование администратора невозможно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UpdateAdmin(selected_index_admin, textBox7.Text, textBox8.Text, textBox9.Text);
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            MessageBox.Show("Данные успешно обновлены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            selected_index_admin = -1;
            tabControl1.SelectedIndex = 14;
            change_objects();

        }

        private void label38_Click(object sender, EventArgs e) // Добавление информации
        {
            if (comboBox1.SelectedIndex == -1 || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "")
            {
                MessageBox.Show("Вы заполнили не все поля.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string currentDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\image_user");
            Directory.CreateDirectory(folderPath);
            Image image = pictureBox3.BackgroundImage;
            if (image != null)
            {
                string fileName = currentDateTime + ".png";
                string filePath = Path.Combine(folderPath, fileName);
                image.Save(filePath);


                int list_object_id = Get_Max_Id_List_Object() + 1;
                InsertDataIntoListObjectTable(list_object_id, textBox11.Text);
                if (comboBox1.SelectedIndex == 0)
                {
                    InsertDataIntoStarsTable(Get_Max_Id_Stars() + 1, list_object_id, textBox12.Text, textBox13.Text, Convert.ToDouble(textBox17.Text), Convert.ToDouble(textBox16.Text), Convert.ToDouble(textBox15.Text), Convert.ToDouble(textBox14.Text), fileName);
                } else if(comboBox1.SelectedIndex == 1){
                    InsertDataIntoTable(Get_Max_Id_Planet() + 1, list_object_id, textBox12.Text, Convert.ToDouble(textBox13.Text), Convert.ToDouble(textBox17.Text), Convert.ToDouble(textBox16.Text), Convert.ToDouble(textBox15.Text), Convert.ToDouble(textBox14.Text), fileName);
                }
                MessageBox.Show("Новый объект был успешно добавлен.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabControl1.SelectedIndex = 14;
                change_objects();

            } 

        }

        private void label28_Click(object sender, EventArgs e) // Удаление информации
        {
            if (selected_index_change_object == -1)
            {
                MessageBox.Show("Выберите объект который хотите удалить.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string deleteQuery = "DELETE FROM List_Object WHERE id = ?";
            string deleteFromPlanetsQuery = "DELETE FROM planet WHERE id_объекта = ?";
            string deleteFromStarsQuery = "DELETE FROM stars WHERE id_объекта = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
            using (OleDbCommand commandPlanets = new OleDbCommand(deleteFromPlanetsQuery, connection))
            using (OleDbCommand commandStars = new OleDbCommand(deleteFromStarsQuery, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("?", selected_index_change_object);
                    commandPlanets.Parameters.AddWithValue("?", selected_index_change_object);
                    commandStars.Parameters.AddWithValue("?", selected_index_change_object);

                    command.ExecuteNonQuery(); 
                    commandPlanets.ExecuteNonQuery(); 
                    commandStars.ExecuteNonQuery(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }

            MessageBox.Show("Объект был успешно удален.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

            selected_index_change_object = -1;
            tabControl1.SelectedIndex = 14;
            change_objects();
        }

        private void label49_Click(object sender, EventArgs e) // Редактирование информации
        {
            if (textBox24.Text == "" || textBox10.Text == "" || textBox18.Text == "" || textBox19.Text == "" || textBox20.Text == "" || textBox21.Text == "" || textBox22.Text == "" || textBox23.Text == "")
            {
                MessageBox.Show("Не все поля заполнены. Редактирование записи невозможно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            string currentDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\image_user");
            Directory.CreateDirectory(folderPath);
            string fileName = "Null";
            Image image = pictureBox4.BackgroundImage;
            if (image != null)
            {
                fileName = currentDateTime + ".png";
                string filePath = Path.Combine(folderPath, fileName);
                image.Save(filePath);
            }

            if (textBox24.Text == "Звезда")
            {
                UpdateDataInListObjectTable(selected_index_change_object, textBox10.Text);
                UpdateDataInStarsTable(selected_index_change_object, textBox18.Text, textBox19.Text, Convert.ToDouble(textBox20.Text), Convert.ToDouble(textBox21.Text), Convert.ToDouble(textBox22.Text), Convert.ToDouble(textBox23.Text), fileName);
            }
            else if (textBox10.Text == "Планета")
            {
                UpdateDataInListObjectTable(selected_index_change_object, textBox10.Text);
                UpdateDataInPlanetTable(selected_index_change_object, textBox18.Text, Convert.ToDouble(textBox19.Text), Convert.ToDouble(textBox20.Text), Convert.ToDouble(textBox21.Text), Convert.ToDouble(textBox22.Text), Convert.ToDouble(textBox23.Text), fileName);
            }

            MessageBox.Show("Данные успешно обновлены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            selected_index_admin = -1;
            tabControl1.SelectedIndex = 14;
            change_objects();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // Изменение данных в комбобоксе
        {
            if(comboBox1.SelectedIndex == -1) {
                return;
            }
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox13.KeyPress -= OnlyLetters_KeyPress;
            textBox14.KeyPress -= OnlyDouble_KeyPress;
            textBox13.KeyPress -= OnlyDouble_KeyPress;
            textBox14.KeyPress -= OnlyNumbers_KeyPress;
            if (comboBox1.SelectedIndex == 0)
            {
                label31.Text = "Созвездие";
                label32.Text = "Тип звезды";
                label33.Text = "Видимая звездная величина";
                label34.Text = "Расстояние от Земли (А.Е.)";
                label35.Text = "Прямое восхождение (ч.)";
                label36.Text = "Прямое склонение (ч.)";
                textBox13.KeyPress += OnlyLetters_KeyPress;
                textBox14.KeyPress += OnlyDouble_KeyPress;
            } else if (comboBox1.SelectedIndex == 1)
            {
                label31.Text = "Тип планеты";
                label32.Text = "Масса (10^24 км)";
                label33.Text = "Размер (км)";
                label34.Text = "Расстояние от Земли (A.E.)";
                label35.Text = "Плотность атмосферы (кг/м^3)";
                label36.Text = "Кол-во спутников (шт.)";
                textBox13.KeyPress += OnlyDouble_KeyPress;
                textBox14.KeyPress += OnlyNumbers_KeyPress;
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string path = pictureBox3.Tag as string;

            if (path == AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png")
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Изображения|*.jpg;*.png;";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox3.BackgroundImage = new Bitmap(openFileDialog.FileName);
                        pictureBox3.Tag = "";
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Для установление новой фотографии, нужно удалить нынешнюю. Вы хотите удалить нынешнюю фотографию?", "Уведомление", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    pictureBox3.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");
                    pictureBox3.Tag = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png";
                }
            }
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string path = pictureBox4.Tag as string;

            if (path == AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png")
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Изображения|*.jpg;*.png;";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox4.BackgroundImage = new Bitmap(openFileDialog.FileName);
                        pictureBox4.Tag = "";
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Для установление новой фотографии, нужно удалить нынешнюю. Вы хотите удалить нынешнюю фотографию?", "Уведомление", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    pictureBox4.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");
                    pictureBox4.Tag = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png";
                }
            }
        }

        private void panel52_Click(object sender, EventArgs e)
        {
            if(textBox3.PasswordChar == '*')
            {
                panel52.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_close.png");
                textBox3.PasswordChar = '\0';
            }
            else
            {
                panel52.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_open.png");
                textBox3.PasswordChar = '*';
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Введите критерий";
            }
        }

        private void panel53_Click(object sender, EventArgs e)
        {
            if (textBox6.PasswordChar == '*')
            {
                panel53.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_close.png");
                textBox6.PasswordChar = '\0';
            }
            else
            {
                panel53.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_open.png");
                textBox6.PasswordChar = '*';
            }
        }

        private void panel54_Click(object sender, EventArgs e)
        {
            if (textBox9.PasswordChar == '*')
            {
                panel54.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_close.png");
                textBox9.PasswordChar = '\0';
            }
            else
            {
                panel54.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_open.png");
                textBox9.PasswordChar = '*';
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (!(char.IsLetter(key) || key == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (!(char.IsLetter(key) || char.IsDigit(key) || char.IsSymbol(key) || char.IsPunctuation(key) || key == (char)Keys.Back))
            {
                e.Handled = true;
            }

        }

        private void panel55_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            string text = "";
            text += textBox25.Text + "\n";
            text += textBox26.Text + "\n";
            text += textBox27.Text + "\n";
            text += textBox28.Text + "\n";
            text += textBox29.Text + "\n";
            text += textBox30.Text + "\n";
            text += textBox31.Text + "\n";
            text += textBox32.Text + "\n";
            text += textBox32.Text + "\n";
            System.IO.File.WriteAllText(filename, text);
            MessageBox.Show("Файл сохранен");
        }
    }
}
