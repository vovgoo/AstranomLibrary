using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AstranomLibrary
{
    public partial class Form1 : Form
    {
        private Action ChangeObjectsAction;

        private int selectedIndex = -1;
        private int selectedIndexAdmin = -1;
        private int selectedIndexChangeObject = -1;
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=K:\Для программ\source\repos\AstranomLibrary\AstranomLibrary\Database.accdb";
        private DatabaseConnection databaseInstance = DatabaseConnection.Instance;

        public Form1()
        {
            InitializeComponent();
            ChangeObjectsAction = ChangeObjects;
            ChangeObjects();
        }

        // Инициализация формы

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Location = new Point(-7, -29);
            tabControl1.Size = new Size(panel1.Width + 15, panel1.Height + 40);
        }

        // Дизайн

        //// Скругления

        public void SetRoundedShape(Control control, int radius)
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

        //// Адаптивный дизайн
        
        private int GetMargin(TableLayoutPanel tableLayoutPanel, int id, double percent)
        {
            return Convert.ToInt32((Height * (tableLayoutPanel.RowStyles[id].Height / 100) - (tableLayoutPanel.RowStyles[id].Height / 100 * Height * percent)) / 2);
        }
        
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ChangeObjects();
        }

        private void ChangeObjects()
        {
            tabControl1.Size = new Size(panel1.Width + 15, panel1.Height + 40);

            Font currentFont = textBox1.Font;
            float newFontSize = Convert.ToInt32(Height / 72) + 2;
            float newFontSizeForLabels = Convert.ToInt32(Height / 72) + 2;

            var textBoxes = new TextBox[]
            {
                    textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7,
                    textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14,
                    textBox15, textBox16, textBox17, textBox18, textBox19, textBox20, textBox21,
                    textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28,
                    textBox29, textBox30, textBox31, textBox32
            };

            var labelsWithNewFontSize = new Label[]
            {
                    label1, label2, label3, label4, label5, label6, label7, label9, label10,
                    label12, label14, label15, label16, label17, label20, label22, label23,
                    label24, label25, label27, label28, label30, label31, label32, label33,
                    label34, label35, label36, label38, label40, label41, label42, label43,
                    label44, label45, label46, label47, label49, label51, label52, label53,
                    label54, label55, label56, label57, label58, label60, label62, label63,
                    label64, label65, label66, label67, label68, label69, label70
            };

            var labelsWithDifferentFontSize = new (Label, float)[]
            {
                    (label8, newFontSize - 1), (label11, newFontSize + 2), (label13, newFontSize + 2),
                    (label18, newFontSize + 2), (label19, newFontSize + 2), (label21, newFontSize + 2),
                    (label26, newFontSize + 2), (label29, newFontSize + 2), (label37, newFontSize + 2),
                    (label39, newFontSize + 2), (label48, newFontSize + 2), (label50, newFontSize + 2),
                    (label59, newFontSize + 2), (label61, newFontSize + 2)
            };

            foreach (var textBox in textBoxes)
            {
                textBox.Font = new Font(currentFont.FontFamily, newFontSize, FontStyle.Bold);
            }

            foreach (var label in labelsWithNewFontSize)
            {
                label.Font = new Font(currentFont.FontFamily, newFontSizeForLabels, FontStyle.Bold);
            }

            foreach (var (label, fontSize) in labelsWithDifferentFontSize)
            {
                label.Font = new Font(currentFont.FontFamily, fontSize, FontStyle.Bold);
            }

            comboBox1.Font = new Font(currentFont.FontFamily, newFontSize, FontStyle.Bold);

            Panel[] group1 = { panel3, panel5 };
            Panel[] group2 = { panel6, panel7, panel8 };
            Panel[] group3 = { panel10, panel11, panel13 };
            Panel[] group4 = { panel14, panel15, panel18 };
            Panel[] group5 = { panel19, panel21, panel22, panel23, panel24, panel25, panel26, panel27,
                               panel29, panel30, panel31, panel32, panel33, panel34, panel35, panel36 };
            Panel[] group6 = { panel28, panel37 };
            Panel[] group7 = { panel38, panel39, panel40, panel41, panel42, panel43, panel44, panel45 };

            int margin41 = GetMargin(tableLayoutPanel1, 0, 0.41);
            int margin85_3 = GetMargin(tableLayoutPanel5, 3, 0.85);
            int margin85_8 = GetMargin(tableLayoutPanel8, 3, 0.85);
            int margin71_9 = GetMargin(tableLayoutPanel9, 2, 0.71);
            int margin71_12 = GetMargin(tableLayoutPanel12, 2, 0.71);
            int margin71_4 = GetMargin(tableLayoutPanel4, 2, 0.71);

            foreach (Panel panel in group1)
            {
                panel.Margin = new Padding(margin41, margin41, margin41, margin41);
            }

            foreach (Panel panel in group2)
            {
                if (panel == panel6)
                {
                    panel.Margin = new Padding(40, margin41, 0, margin41);
                    panel.Padding = new Padding(10, Convert.ToInt32((panel.Height - textBox1.Height) / 2), 10, 0);
                }
                else
                {
                    panel.Margin = new Padding(60, GetMargin(tableLayoutPanel3, 2, 0.85), 60, GetMargin(tableLayoutPanel3, 2, 0.85));
                    panel.Padding = new Padding(10, Convert.ToInt32((panel.Height - (panel == panel7 ? textBox2.Height : textBox3.Height)) / 2), 10, 0);
                }
            }

            foreach (Panel panel in group3)
            {
                panel.Margin = new Padding(60, margin85_3, 60, margin85_3);
                panel.Padding = new Padding(10, Convert.ToInt32((panel.Height - (panel == panel10 ? textBox4.Height : (panel == panel11 ? textBox5.Height : textBox6.Height))) / 2), 10, 0);
            }

            foreach (Panel panel in group4)
            {
                panel.Margin = new Padding(60, margin85_8, 60, margin85_8);
                panel.Padding = new Padding(10, Convert.ToInt32((panel.Height - (panel == panel14 ? textBox7.Height : textBox8.Height)) / 2), 10, 0);
            }

            foreach (Panel panel in group5)
            {
                panel.Margin = new Padding(5, margin71_9, 5, margin71_9);
                panel.Padding = new Padding(10, Convert.ToInt32((panel.Height - (panel == panel19 ? comboBox1.Height : (panel == panel21 ? textBox11.Height : (panel == panel22 ? textBox12.Height : (panel == panel23 ? textBox13.Height : (panel == panel24 ? textBox17.Height : (panel == panel25 ? textBox16.Height : (panel == panel26 ? textBox15.Height : textBox14.Height)))))))) / 2), 10, 0);
            }

            foreach (Panel panel in group6)
            {
                panel.Margin = new Padding(60, margin71_12, 60, margin71_12);
                panel.Padding = new Padding(10, Convert.ToInt32((panel.Height - (panel == panel29 ? textBox24.Height : (panel == panel30 ? textBox10.Height : (panel == panel31 ? textBox18.Height : (panel == panel32 ? textBox19.Height : (panel == panel33 ? textBox20.Height : (panel == panel34 ? textBox21.Height : (panel == panel35 ? textBox22.Height : textBox23.Height)))))))) / 2), 10, 0);
            }

            foreach (Panel panel in group7)
            {
                panel.Margin = new Padding(5, margin71_4, 5, margin71_4);
                panel.Padding = new Padding(10, Convert.ToInt32((panel.Height - (panel == panel38 ? textBox25.Height : (panel == panel39 ? textBox26.Height : (panel == panel40 ? textBox27.Height : (panel == panel41 ? textBox28.Height : (panel == panel42 ? textBox29.Height : (panel == panel43 ? textBox30.Height : textBox31.Height))))))) / 2), 10, 0);
            }

            // Скругления

            var panels20 = new Control[]
            {
                panel6, panel7, panel8, panel10, panel11, panel13, panel14, panel15,
                panel16, panel17, panel18, panel19, panel20, panel21, panel22, panel23,
                panel24, panel25, panel26, panel27, panel28, panel29, panel30, panel31,
                panel32, panel33, panel34, panel35, panel36, panel37, panel38, panel39,
                panel40, panel41, panel42, panel43, panel44, panel45
            };

            var panels10 = new Control[]
            {
                panel3, panel5, panel9, panel12
            };

            foreach (var panel in panels20)
            {
                SetRoundedShape(panel, 20);
            }

            foreach (var panel in panels10)
            {
                SetRoundedShape(panel, 10);
            };

            var flowLayoutPanels = new FlowLayoutPanel[] { flowLayoutPanel1, flowLayoutPanel2, flowLayoutPanel3, flowLayoutPanel4, flowLayoutPanel5, flowLayoutPanel6, flowLayoutPanel7 };

            foreach (var flowLayoutPanel in flowLayoutPanels)
            {
                UpdateFlowLayoutPanel(flowLayoutPanel);
            }
        }
            
        //// Анимация кнопок

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

        //// Изменение дочерних элементов flowLayoutPnaels

        private void UpdateFlowLayoutPanel(FlowLayoutPanel flowLayoutPanel)
        {
            flowLayoutPanel.SuspendLayout();
            foreach (Control ctrl in flowLayoutPanel.Controls)
            {
                ctrl.Width = flowLayoutPanel.Width - 40;
            }
            flowLayoutPanel.ResumeLayout();
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            if (sender is FlowLayoutPanel flowLayoutPanel)
            {
                UpdateFlowLayoutPanel(flowLayoutPanel);
            }
        }

        //// Плейс холдер поиска

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

        // Ограничение данных

        //// Выборка данный в комбобоксе

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
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
            }
            else if (comboBox1.SelectedIndex == 1)
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

        //// Ограничение ввода только букв

        public void OnlyLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        //// Ограничение ввода только цифр

        public void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        //// Ограничение ввода только цифр с плавающей точкой

        public void OnlyDouble_KeyPress(object sender, KeyPressEventArgs e)
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

        //// Ограниченние ввода для логинов и паролей 

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        //// Добавление фотографий при нажатии на фото

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            if (pictureBox != null)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Изображения|*.jpg;*.png;";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox.BackgroundImage = new Bitmap(openFileDialog.FileName);
                    }
                }
            }
        }

        //// Открытие и скрытие пароля

        private void panel52_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { textBox3, textBox6, textBox9 };
            Panel[] panels = { panel52, panel53, panel54 };

            char newPasswordChar = textBox3.PasswordChar == '*' ? '\0' : '*';
            string newImagePath = textBox3.PasswordChar == '*' ?
                AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_close.png" :
                AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_open.png";

            for (int i = 0; i < textBoxes.Length; i++)
            {
                panels[i].BackgroundImage = Image.FromFile(newImagePath);
                textBoxes[i].PasswordChar = newPasswordChar;
            }
        }

        //// Вывод отчета на печать

        private void panel55_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Тектовый документ|*.txt;";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                File.WriteAllText(filename, "Информация об объекте\n\n"
                    + label51.Text + ": " + textBox25.Text + "\n"
                    + label52.Text + ": " + textBox26.Text + "\n"
                    + label53.Text + ": " + textBox27.Text + "\n"
                    + label54.Text + ": " + textBox28.Text + "\n"
                    + label55.Text + ": " + textBox29.Text + "\n"
                    + label56.Text + ": " + textBox30.Text + "\n"
                    + label57.Text + ": " + textBox31.Text + "\n"
                    + label58.Text + ": " + textBox32.Text + "\n"
                    );
                MessageBox.Show("Справка о данном объекте была успешно сохранена.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Переходы между страница мриложения

        private void label63_Click(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                switch (control.Name)
                {
                    case "pictureBox1": // Логотип
                        tabControl1.SelectedIndex = selectedIndex == -1 ? 0 : 14;
                        selectedIndexAdmin = -1;
                        selectedIndexChangeObject = -1;
                        break;
                    case "label2": // Информация о звездах
                        LoadListObject(flowLayoutPanel2, 1, "stars");
                        tabControl1.SelectedIndex = 1;
                        break;
                    case "label3": // Информация о планетах
                        LoadListObject(flowLayoutPanel1, 2, "planet");
                        tabControl1.SelectedIndex = 2;
                        break;
                    case "label5": // Поиск
                        flowLayoutPanel3.Controls.Clear();
                        SearchListObject(flowLayoutPanel3, 1, "stars", textBox1.Text);
                        SearchListObject(flowLayoutPanel3, 2, "planet", textBox1.Text);
                        textBox1.Text = "Введите критерий";
                        tabControl1.SelectedIndex = 3;
                        if (flowLayoutPanel3.Controls.Count == 0) MessageBox.Show("К сожалению, по вашему запросу ничего не найдено.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "label6": // Авторизация
                        if (label6.Text == "Войти")
                        {
                            textBox2.Clear();
                            textBox3.Clear();
                            tabControl1.SelectedIndex = 4;
                        }
                        else
                        {
                            label6.Text = "Войти";
                            selectedIndex = -1;
                            tabControl1.SelectedIndex = 0;
                        }
                        break;
                    case "label12": // Вход в личный кабинет через авторизацию
                        tabControl1.SelectedIndex = 14;
                        break;
                    case "label63": // Добавление информации переход
                        textBox11.Clear();
                        textBox12.Clear();
                        textBox13.Clear();
                        textBox14.Clear();
                        textBox15.Clear();
                        textBox16.Clear();
                        textBox17.Clear();
                        pictureBox3.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\Non-Image.png");
                        comboBox1.SelectedIndex = 0;
                        tabControl1.SelectedIndex = 10;
                        break;
                    case "label64": // Редактирование информации переход
                        LoadChangeObjects(flowLayoutPanel6, 1);
                        tabControl1.SelectedIndex = 11;
                        break;
                    case "label65": // Удаление информации переход
                        LoadChangeObjects(flowLayoutPanel7, 2);
                        tabControl1.SelectedIndex = 12;
                        break;
                    case "label66": // Удалить администратора переход
                        LoadAdminObjects(flowLayoutPanel5, 2);
                        tabControl1.SelectedIndex = 8;
                        break;
                    case "label67": // Редактирование администратора переход
                        LoadAdminObjects(flowLayoutPanel4, 1);
                        tabControl1.SelectedIndex = 7;
                        break;
                    case "label68": // Добавление администратора переход
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        tabControl1.SelectedIndex = 6;
                        break;
                }

                panel52.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_open.png");
                textBox3.PasswordChar = '*';
                panel53.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_open.png");
                textBox6.PasswordChar = '*';
                panel54.BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\image\\eye_open.png");
                textBox9.PasswordChar = '*';
                ChangeObjects();
            }
        }

        // Функции взаимодействия с Базой Данных

        //// Загрузка объектов администратора

        private void LoadAdminObjects(FlowLayoutPanel flowLayoutPanel, int objectType)
        {
            flowLayoutPanel.Controls.Clear();
            DataTable result = databaseInstance.ExecuteSelectQuery("SELECT * FROM Admins", new OleDbParameter[] { });

            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    Admin_Object obj = new Admin_Object(Convert.ToInt32(row["id"]), row["Название администратора"].ToString(), row["Логин администратора"].ToString(), row["Пароль администратора"].ToString(), ChangeObjectsAction, this, objectType);
                    flowLayoutPanel.Controls.Add(obj);
                }
            }
        }

        //// Загрузка объектов с данными о звездах и планетах для администратора

        private void LoadChangeObjects(FlowLayoutPanel flowLayoutPanel, int objectType)
        {
            flowLayoutPanel.Controls.Clear();
            DataTable result = databaseInstance.ExecuteSelectQuery("SELECT stars.*, list_object.`Название объекта` FROM stars INNER JOIN list_object ON list_object.id = stars.id_объекта ORDER BY stars.id", new OleDbParameter[] { });

            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    Change_Object obj = new Change_Object(Convert.ToInt32(row["id_объекта"]), 1, row["Название объекта"].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), ChangeObjectsAction, this, objectType);
                    flowLayoutPanel.Controls.Add(obj);
                }
            }

            result = databaseInstance.ExecuteSelectQuery("SELECT planet.*, list_object.`Название объекта` FROM planet INNER JOIN list_object ON list_object.id = planet.id_объекта ORDER BY planet.id", new OleDbParameter[] { });

            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    Change_Object obj = new Change_Object(Convert.ToInt32(row["id_объекта"]), 2, row["Название объекта"].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), ChangeObjectsAction, this, objectType);
                    flowLayoutPanel.Controls.Add(obj);
                }
            }
        }

        //// Загрузка объектов с данными о звездах и планетах для администратора

        private void LoadListObject(FlowLayoutPanel flowLayoutPanel, int typeDatabaseObject, string type)
        {
            flowLayoutPanel.Controls.Clear();

            DataTable result = databaseInstance.ExecuteSelectQuery("SELECT " + type + ".*, list_object.`Название объекта` FROM " + type + " INNER JOIN list_object ON list_object.id = " + type + ".id_объекта ORDER BY " + type + ".id", new OleDbParameter[] {});

            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    Library_Object obj = new Library_Object(Convert.ToInt32(row[1]), typeDatabaseObject, row[9].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), ChangeObjectsAction, this);
                    flowLayoutPanel.Controls.Add(obj);
                }
            } 
            else
            {
                MessageBox.Show("К сожалению ничего не найдено.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //// Загрузка объектов поиска с данными о звездах и планетах для администратора

        private void SearchListObject(FlowLayoutPanel flowLayoutPanel, int typeDatabaseObject, string type, string searchText)
        {   
            DataTable result = databaseInstance.ExecuteSelectQuery("SELECT " + type + ".*, list_object.`Название объекта` FROM " + type + " INNER JOIN list_object ON list_object.id = " + type + ".id_объекта WHERE list_object.`Название объекта` LIKE '%" + searchText + "%' ORDER BY " + type + ".id", new OleDbParameter[] { });

            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    Library_Object obj = new Library_Object(Convert.ToInt32(row[1]), typeDatabaseObject, row[9].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), ChangeObjectsAction, this);
                    flowLayoutPanel.Controls.Add(obj);
                }
            }
        }
        
        //// Проверка на существования администратора с определенной почтой 

        private bool IsLoginExists(string login)
        {
            DataTable result = databaseInstance.ExecuteSelectQuery("SELECT COUNT(*) FROM admins WHERE [Логин администратора] = ?", new OleDbParameter[] { new OleDbParameter("?", login) });
            return result.Rows.Count > 0;
        }

        //// Получение логина администратора по определенному идентификатору
        
        private string GetAdminLoginById(int id)
        {
            DataTable result = databaseInstance.ExecuteSelectQuery("SELECT [Логин администратора] FROM admins WHERE id = ?", new OleDbParameter[] { new OleDbParameter("?", id) });
            return result.Rows.Count > 0 ? result.Rows[0][0].ToString() : null;
        }

        // Изменения состояний объектов

        public void ChangeIndexObject(int index)
        {
            selectedIndexChangeObject = index;
        }

        public void ChangeIndexAdmin(int index)
        {
            selectedIndexAdmin = index;
        }

        // Обработка кнопок
        
        //// Авторизация администратора

        private void label12_Click(object sender, EventArgs e) 
        {
            DataTable result = databaseInstance.ExecuteSelectQuery("SELECT id FROM admins WHERE [Логин администратора] = ? AND [Пароль администратора] = ?", new OleDbParameter[]{ new OleDbParameter("?", textBox2.Text), new OleDbParameter("?", textBox3.Text)} );
            if (result.Rows.Count > 0)
            {
                selectedIndex = Convert.ToInt32(result.Rows[0][0]);
                label6.Text = "Выйти";
                tabControl1.SelectedIndex = 14;
                ChangeObjects();
                MessageBox.Show("Вы успешно авторизованы!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //// Добавление администрратора

        private void label25_Click(object sender, EventArgs e) 
        {
            if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Не все поля заполнены. Добавление нового администратора невозможно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsLoginExists(textBox5.Text))
            {
                MessageBox.Show("Администратор с данным логином уже существует. Добавление новой записи невозможно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowsAffected = databaseInstance.ExecuteNonQuery("INSERT INTO admins ([Название администратора], [Логин администратора], [Пароль администратора]) VALUES (?, ?, ?)", new OleDbParameter[] { new OleDbParameter("?", textBox4.Text), new OleDbParameter("?", textBox5.Text), new OleDbParameter("?", textBox6.Text) });
            
            if (rowsAffected > 0)
            {
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                MessageBox.Show("Новый администратор успешно добавлен.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Новый администратор не был добавлен.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //// Редактирование администрратора

        private void label20_Click(object sender, EventArgs e) 
        {
            if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Не все поля заполнены. Редактирование записи невозможно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsLoginExists(textBox8.Text) && GetAdminLoginById(selectedIndexAdmin) != textBox8.Text)
            {
                MessageBox.Show("Администратор с данным логином уже существует. Редактирование администратора невозможно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowsAffected = databaseInstance.ExecuteNonQuery("UPDATE admins SET [Название администратора] = ?, [Логин администратора] = ?, [Пароль администратора] = ? WHERE id = ?", new OleDbParameter[] { new OleDbParameter("?", textBox7.Text), new OleDbParameter("?", textBox8.Text), new OleDbParameter("?", textBox9.Text), new OleDbParameter("?", selectedIndexAdmin)});

            if (rowsAffected > 0)
            {
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                selectedIndexAdmin = -1;
                tabControl1.SelectedIndex = 14;
                ChangeObjects();
                MessageBox.Show("Данные об администраторе успешно обновлены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Данные об администраторе не были обновлены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //// Удаление администрратора

        private void label17_Click(object sender, EventArgs e) 
        {
            if (selectedIndexAdmin == -1)
            {
                MessageBox.Show("Выберите администратора которого хотите удалить.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (selectedIndex == selectedIndexAdmin)
            {
                MessageBox.Show("Вы не можете удалить самого себя.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowsAffected = databaseInstance.ExecuteNonQuery("DELETE FROM admins WHERE id = ?", new OleDbParameter[] { new OleDbParameter("?", selectedIndexAdmin) });

            if (rowsAffected > 0)
            {
                selectedIndexAdmin = -1;
                tabControl1.SelectedIndex = 14;
                ChangeObjects();
                MessageBox.Show("Администратор был успешно удален.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Администратор не был удален.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        //// Добавление информации о звездах и планетах

        private void label38_Click(object sender, EventArgs e) 
        {
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(textBox11.Text) || string.IsNullOrWhiteSpace(textBox12.Text) || string.IsNullOrWhiteSpace(textBox13.Text) || string.IsNullOrWhiteSpace(textBox14.Text) || string.IsNullOrWhiteSpace(textBox15.Text) || string.IsNullOrWhiteSpace(textBox16.Text) || string.IsNullOrWhiteSpace(textBox17.Text))
            {
                MessageBox.Show("Для добавление нового объекта информации, необходимо заполнить все поля.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\image_user");
            Directory.CreateDirectory(folderPath);

            if (pictureBox3.BackgroundImage != null)
            {
                string filePath = Path.Combine(folderPath, fileName);
                pictureBox3.BackgroundImage.Save(filePath);
            }

            DataTable result = databaseInstance.ExecuteSelectQuery("SELECT MAX(id) FROM List_Object", new OleDbParameter[] { });
            int listObjectID = result.Rows.Count > 0 ? Convert.ToInt32(result.Rows[0][0]) + 1 : 0;

            string[] queries = new string[] { "INSERT INTO List_Object (id, [Название объекта]) VALUES (?, ?)", ""};
            OleDbParameter[] parameters1 = new OleDbParameter[] { new OleDbParameter("?", listObjectID), new OleDbParameter("?", textBox11.Text) };
            OleDbParameter[] parameters2 = new OleDbParameter[] { };

            if (comboBox1.SelectedIndex == 0)
            {
                queries[1] = "INSERT INTO Stars (id_объекта, [Созвездие], [Тип звезды], [Видимая звездная величина], [Расстояние от Земли], [Прямое восхождение], [Прямое склонение], [Фотография]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
                parameters2 = new OleDbParameter[] {
                    new OleDbParameter("?", listObjectID),
                    new OleDbParameter("?", textBox12.Text),
                    new OleDbParameter("?", textBox13.Text),
                    new OleDbParameter("?", Convert.ToDouble(textBox17.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox16.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox15.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox14.Text)),
                    new OleDbParameter("?", fileName)
                };
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                queries[1] = "INSERT INTO Planet (id_объекта, [Тип планеты], [Масса], [Размер], [Расстояние от Солнца], [Плотность атмосферы], [Спутники], [Фотография]) VALUES (? ,?, ?, ?, ?, ?, ?, ?)";
                parameters2 = new OleDbParameter[] {
                    new OleDbParameter("?", listObjectID),
                    new OleDbParameter("?", textBox12.Text),
                    new OleDbParameter("?", Convert.ToDouble(textBox13.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox17.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox16.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox15.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox14.Text)),
                    new OleDbParameter("?", fileName)
                };
            }

            int rowsAffected = databaseInstance.ExecuteTransaction(queries, new OleDbParameter[][] { parameters1, parameters2 });

            if (rowsAffected > 0)
            {
                tabControl1.SelectedIndex = 14;
                ChangeObjects();
                MessageBox.Show("Новый объект информации был успешно добавлен.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Новый объект информации не был добавлен.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //// Редактирование информации о звездах и планетах

        private void label49_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox24.Text) || string.IsNullOrWhiteSpace(textBox10.Text) || string.IsNullOrWhiteSpace(textBox18.Text) || string.IsNullOrWhiteSpace(textBox19.Text) || string.IsNullOrWhiteSpace(textBox20.Text) || string.IsNullOrWhiteSpace(textBox21.Text) || string.IsNullOrWhiteSpace(textBox22.Text) || string.IsNullOrWhiteSpace(textBox23.Text))
            {
                MessageBox.Show("Не все поля заполнены. Редактирование объекта данных невозможно.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\image_user");
            Directory.CreateDirectory(folderPath);

            if (pictureBox4.BackgroundImage != null)
            {
                string filePath = Path.Combine(folderPath, fileName);
                pictureBox4.BackgroundImage.Save(filePath);
            }

            string[] queries = new string[] { "UPDATE List_Object SET [Название объекта] = ? WHERE id = ?", "" };
            OleDbParameter[] parameters1 = new OleDbParameter[] { new OleDbParameter("?", textBox10.Text), new OleDbParameter("?", selectedIndexChangeObject) };
            OleDbParameter[] parameters2 = new OleDbParameter[] { };

            if (textBox24.Text.Equals("Звезда"))
            {
                queries[1] = "UPDATE Stars SET [Созвездие] = ?, [Тип звезды] = ?, [Видимая звездная величина] = ?, [Расстояние от Земли] = ?, [Прямое восхождение] = ?, [Прямое склонение] = ?, [Фотография] = ? WHERE id_объекта = ?";
                parameters2 = new OleDbParameter[] {
                    new OleDbParameter("?", textBox18.Text),
                    new OleDbParameter("?", textBox19.Text),
                    new OleDbParameter("?", Convert.ToDouble(textBox20.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox21.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox22.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox23.Text)),
                    new OleDbParameter("?", fileName),
                    new OleDbParameter("?", selectedIndexChangeObject)
                };
            }
            else if (textBox24.Text.Equals("Планета"))
            {
                queries[1] = "UPDATE Planet SET [Тип планеты] = ?, [Масса] = ?, [Размер] = ?, [Расстояние от Солнца] = ?, [Плотность атмосферы] = ?, [Спутники] = ?, [Фотография] = ? WHERE id_объекта = ?";
                parameters2 = new OleDbParameter[] {
                    new OleDbParameter("?", textBox18.Text),
                    new OleDbParameter("?", Convert.ToDouble(textBox19.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox20.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox21.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox22.Text)),
                    new OleDbParameter("?", Convert.ToDouble(textBox23.Text)),
                    new OleDbParameter("?", fileName),
                    new OleDbParameter("?", selectedIndexChangeObject)
                };
            }

            int rowsAffected = databaseInstance.ExecuteTransaction(queries, new OleDbParameter[][] { parameters1, parameters2 });

            if (rowsAffected > 0)
            {
                selectedIndexChangeObject = -1;
                tabControl1.SelectedIndex = 14;
                ChangeObjects();
                MessageBox.Show("Данные об объекте информации были успешно обновлены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Данные об объекте информации не были обновлены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //// Удаление информации о звзедах и планетах

        private void label28_Click(object sender, EventArgs e) 
        {
            if (selectedIndexChangeObject == -1)
            {
                MessageBox.Show("Выберите объект информации который хотите удалить.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OleDbParameter[] parameters = new OleDbParameter[] { new OleDbParameter("?", selectedIndexChangeObject)}; 

            int rowsAffected = databaseInstance.ExecuteTransaction(new string[] { "DELETE FROM stars WHERE id_объекта = ?;", "DELETE FROM planet WHERE id_объекта = ?;", "DELETE FROM List_Object WHERE id = ?;" } , new OleDbParameter[][] { parameters, parameters, parameters });

            if (rowsAffected > 0)
            {
                selectedIndexChangeObject = -1;
                tabControl1.SelectedIndex = 14;
                ChangeObjects();
                MessageBox.Show("Информация о выбранном объекте была успешно удалена.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Информация о выбранном объекте не была удалена.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
