using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test3
{
    public partial class UserSingleButton : UserControl
    {
        public UserSingleButton()
        {
            InitializeComponent();
            //comboBox1.Items.Clear();
       //     comboBox1.Items.Add("32");
           // xianshi();
        }
        public decimal Value             //  @1
        {
            get
            {
                return numericUpDown1.Value;
            }
            set
            {
                numericUpDown1.Value = value;
            }
        }

        public class ComboxItem
        {
            public string cbbText { get; set; }
            public string cbbValue { get; set; }

            public ComboxItem(string _Text, string _Value)
            {
                cbbText = _Text;
                cbbValue = _Value;
            }

            public override string ToString()
            {
                return cbbText;
            }
        }
        public string cbbValue        //  @2
        {
            get
            {
                return comboBox1.Text;
            }
            set
            {
                comboBox1.Text = value;
            }
        }
        public string textBox1Value        //  @2
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
        public string cbb1Item        //  @2
        {      
            set
            {
                comboBox1.Items.Add(value);
            }
        }
      
        
       
        public bool checkbox1Value
        {
            get
            {
                return checkBox1.Checked;
            }
            set
            {
                checkBox1.Checked = value;
            }

        }

        public string checkBox1Text
        {
            get
            {
                return checkBox1.Text;
            }
            set
            {
                checkBox1.Text = value;
            }
        }

        public bool nUDvisible
        {
            get
            {
                return numericUpDown1.Visible ;
            }
            set
            {
                numericUpDown1.Visible = value;
            }
        }

        public bool cbbvisible
        {
            get
            {
                return comboBox1.Visible;
            }
            set
            {
                comboBox1.Visible = value;
            }
        }

    

        public bool checkBox1visible
        {
            get
            {
                return checkBox1.Visible;
            }
            set
            {
                checkBox1.Visible = value;
            }
        }
        public bool textBox1vs
        {
            get
            {
                return textBox1.Visible;
            }
            set
            {
                textBox1.Visible = value;
            }
        }

        public string LabelString
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        public void xianshi()
        {
            if (label1.Text == LabelString)
                numericUpDown1.Visible = false;
        }
        public void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserSingleButton_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
