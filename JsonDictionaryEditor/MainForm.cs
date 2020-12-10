using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JsonDictionaryEditor
{
    public partial class MainForm : Form
    {
        private JsonDictionary jsonDictionary;

        public MainForm()
        {
            InitializeComponent();
            jsonDictionary = new JsonDictionary();
            jsonDictionary.Words = new Dictionary<string, string>();
        }

        #region Меню

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                jsonDictionary.Open(openFileDialog.FileName);
                FillListBox();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                jsonDictionary.Save(saveFileDialog.FileName);
        }
        #endregion

        #region Кнопки
        private void addWordButton_Click(object sender, EventArgs e)
        {
            var addWordForm = new WordForm();
            DialogResult = addWordForm.ShowDialog();

            var word = addWordForm.Word;
            var description = addWordForm.Description;

            if (DialogResult == DialogResult.OK)
            {
                jsonDictionary.Words.Add(word, description);
                FillListBox();
            }
        }

        private void editWordButton_Click(object sender, EventArgs e)
        {
            var selectedIndexListBox = listBox.SelectedIndex;
            if (selectedIndexListBox == -1)
                return;

            var editWordForm = new WordForm();

            foreach (var word in jsonDictionary.Words)
            {
                var str1 = listBox.SelectedItem.ToString();
                var str2 = word.ToString();
                if (str1 == str2)
                {
                    editWordForm.Word = word.Key;
                    editWordForm.Description = word.Value;

                    DialogResult = editWordForm.ShowDialog();
                    if (DialogResult == DialogResult.OK)
                    {
                        jsonDictionary.Words[word.Key] = editWordForm.Description;
                        FillListBox();
                    }
                    break;
                }
            }
        }

        private void removeWordButton_Click(object sender, EventArgs e)
        {
            var selectedIndexListBox = listBox.SelectedIndex;
            if (selectedIndexListBox == -1)
                return;

            foreach (var word in jsonDictionary.Words)
            {
                var str1 = listBox.SelectedItem.ToString();
                var str2 = word.ToString();
                if (str1 == str2)
                {
                    jsonDictionary.Words.Remove(word.Key);
                    FillListBox();
                    break;
                }
            }
        }
        #endregion

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndexListBox = listBox.SelectedIndex;
            if (selectedIndexListBox == -1)
                return;

            foreach (var word in jsonDictionary.Words)
            {
                var str1 = listBox.SelectedItem.ToString();
                var str2 = word.ToString();
                if (str1 == str2)
                {
                    richTextBox1.Text = word.Key;
                    richTextBox2.Text = word.Value;
                    break;
                }
            }
        }
        private void FillListBox()
        {
            listBox.DataSource = new BindingSource(jsonDictionary.Words, null);
            listBox.DisplayMember = "Key";
            listBox.ValueMember = "Key";
        }
    }
}
