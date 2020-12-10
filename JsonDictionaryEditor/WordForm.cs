using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonDictionaryEditor
{
    public partial class WordForm : Form
    {
        private string _word;
        private string _description;
        public WordForm()
        {
            InitializeComponent();
        }

        public string Word
        {
            get
            {
                if (DialogResult == DialogResult.OK)
                    return _word;

                return null;
            }
            set
            {
                _word = value;
                richTextBox1.Text = _word;
            }
        }

        public string Description
        {
            get
            {
                if (DialogResult == DialogResult.OK)
                    return _description;

                return null;
            }
            set
            {
                _description = value;
                richTextBox2.Text = _description;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            _word = richTextBox1.Text;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            _description = richTextBox2.Text;
        }
    }
}
