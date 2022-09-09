using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ContextMenuBoomBoom
{
    public partial class Form1 : Form
    {
        int limit;
        Point location;

        public Form1()
        {
            InitializeComponent();

            limit = 3;
            buttonToolStripMenuItem.Text = $"{buttonToolStripMenuItem.Text} ({limit})";
            textBoxToolStripMenuItem.Text = $"{textBoxToolStripMenuItem.Text} ({limit})";
            checkBoxToolStripMenuItem.Text = $"{checkBoxToolStripMenuItem.Text} ({limit})";
        }

        void CreateControl(ToolStripMenuItem item, Control toCreate)
        {
            location.X -= Location.X + toCreate.Width / 2;
            location.Y -= Location.Y + this.Height - this.ClientRectangle.Height;
            toCreate.Location = location;
            Controls.Add(toCreate);

            int count = int.Parse(Regex.Match(item.Text, @"\d+").Value);
            count--;
            item.Text = Regex.Replace(item.Text, @"\d+", count.ToString());

            if (count == 0)
                contextMenuStrip1.Items.Remove(item);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            location = Control.MousePosition;
        }

        private void buttonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControl(sender as ToolStripMenuItem, new Button());
        }

        private void textBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControl(sender as ToolStripMenuItem, new TextBox());
        }

        private void checkBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateControl(sender as ToolStripMenuItem, new CheckBox());
        }
    }
}
