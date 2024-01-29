using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookmark_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string searchLine = ">Панель закладок</H3>";
                string additionalText = " PERSONAL_TOOLBAR_FOLDER=\"true\">Панель закладок</H3>";
                string file = "Bookmarks.html";

                string[] lines = File.ReadAllLines(file);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchLine) && !lines[i].Contains(additionalText))
                    {
                        lines[i] = lines[i].Replace(searchLine, "") + additionalText;
                    }
                }
                File.WriteAllLines(file, lines);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Файл не найден");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
