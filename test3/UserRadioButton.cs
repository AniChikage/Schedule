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
    public partial class UserRadioButton : UserControl
    {
        public UserRadioButton()
        {
            InitializeComponent();
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

        public class ComboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public ComboxItem(string _Text, string _Value)
            {
                Text = _Text;
                Value = _Value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
