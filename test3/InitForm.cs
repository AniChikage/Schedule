using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace test3
{
    public partial class InitForm : Form
    {
        public InitForm()
        {
            InitializeComponent(); 
            InitControls();
            //  dataGridView1.AllowUserToAddRows = false;
        }

        private void InitForm_Load(object sender, EventArgs e)
        {
           
        }

        private void InitControls()
        {
            string[] tabC = new string[10];
            TabPage[] Usertabpage = { tabPage1, tabPage2, tabPage3, tabPage4,
                                    tabPage5, tabPage6, tabPage7, tabPage8,tabPage9,tabPage10};
            DataGridView[] UserdataGridView = { dataGridView1, dataGridView2, dataGridView3,dataGridView4,dataGridView5,
                                                  dataGridView6,dataGridView7,dataGridView8,dataGridView9,dataGridView10
                                              };

            string[] path = { "../../conf/tab1.ini","../../conf/tab2.ini", "../../conf/tab3.ini", "../../conf/tab4.ini",
                            "../../conf/tab5.ini","../../conf/tab6.ini","../../conf/tab7.ini","../../conf/tab8.ini",
                            "../../conf/tab9.ini", "../../conf/tab10.ini"};
            int tabCN;

            for (int temp = 0; temp < 10; temp++)
            {
                UserdataGridView[temp].AllowUserToAddRows = false;
            }

            FileStream FS = new FileStream("../../conf/tabC.ini", FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FS, System.Text.Encoding.Default);
            SR.BaseStream.Seek(0, SeekOrigin.Begin);
            string STR = SR.ReadToEnd();
            FS.Close();
            SR.Close();

            tabC = STR.Split('\n');
            tabCN = tabC.Length;

            textBox7.Text = "";
            for (int m = 0; m < tabCN; m++ )
            {
                if(m != (tabCN-1))
                {
                    textBox7.Text = textBox7.Text + tabC[m] + '\n';
                }
                else
                {
                    textBox7.Text = textBox7.Text + tabC[m];
                }
            }

            for (int usertabN = 0; usertabN < 10; usertabN++)
            {
                Usertabpage[usertabN].Parent = tabControl1;
            }
            for (int usertabN = tabCN; usertabN < 10; usertabN++)
            {
                Usertabpage[usertabN].Parent = null;
            }

            for (int usertabN = 0; usertabN < tabCN; usertabN++)
            {
                Usertabpage[usertabN].Text = tabC[usertabN];
                string[] btValue = new string[10];
                string[] btValue1 = new string[6];
                string[][] btValue2 = new string[10][];
                FileStream fs = new FileStream(path[usertabN], FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str1 = sr.ReadToEnd();
                fs.Close();
                sr.Close();

                string str2 = str1.Trim('\n',(char)0);
                string str = str2.Trim('\r', (char)0);
                btValue = str.Split('?');
                int t = btValue.Length;
                for (int i = 0; i < t; i++)
                {
                    btValue1 = btValue[i].Split(',');
                    btValue2[i] = btValue1;

                }
                for (int i = 0; i < t; i++)
                {
                    UserdataGridView[usertabN].Rows.Add();
                    UserdataGridView[usertabN].Rows[i].Cells[0].Value = btValue2[i][0];
                    if (btValue2[i][1] == "1")
                    {
                        UserdataGridView[usertabN].Rows[i].Cells[1].Value = true;
                        UserdataGridView[usertabN].Rows[i].Cells[2].Value = btValue2[i][2];
                    }
                    else
                    {
                        UserdataGridView[usertabN].Rows[i].Cells[1].Value = false;
                        UserdataGridView[usertabN].Rows[i].Cells[2].Value = "";
                    }
                    if (btValue2[i][3] == "1")
                    {
                        UserdataGridView[usertabN].Rows[i].Cells[3].Value = true;
                    }
                    else
                    {
                        UserdataGridView[usertabN].Rows[i].Cells[3].Value = false;
                    }
                    if (btValue2[i][4] == "1")
                    {
                        UserdataGridView[usertabN].Rows[i].Cells[4].Value = true;
                        UserdataGridView[usertabN].Rows[i].Cells[5].Value = btValue2[i][5];
                    }
                    else
                    {
                        UserdataGridView[usertabN].Rows[i].Cells[4].Value = false;
                        UserdataGridView[usertabN].Rows[i].Cells[5].Value = "";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] path = { "../../conf/tab1.ini","../../conf/tab2.ini", "../../conf/tab3.ini", "../../conf/tab4.ini",
                            "../../conf/tab5.ini","../../conf/tab6.ini","../../conf/tab7.ini","../../conf/tab8.ini",
                            "../../conf/tab9.ini", "../../conf/tab10.ini"};
            DataGridView[] UserdataGridView = { dataGridView1, dataGridView2, dataGridView3,dataGridView4,dataGridView5,
                                                  dataGridView6,dataGridView7,dataGridView8,dataGridView9,dataGridView10
                                              };
         
      /*      for (int i = 0; i < 10; i++)
            {
                UserdataGridView[i].Rows.Clear();
            }
            InitControls();*/
            string[] tabC = new string[10];
            int tabCN;
            FileStream FS = new FileStream("../../conf/tabC.ini", FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FS, System.Text.Encoding.Default);
            SR.BaseStream.Seek(0, SeekOrigin.Begin);
            string STR = SR.ReadToEnd();
            FS.Close();
            SR.Close();
            tabC = STR.Split('\n');
            tabCN = tabC.Length;
            for (int loop = 0; loop < tabCN; loop++)
            {
                FileStream txt = File.Open(path[loop], FileMode.OpenOrCreate, FileAccess.Write);
                //     txt.Seek(0, SeekOrigin.Begin);
                txt.SetLength(0);
                StreamWriter sw = new StreamWriter(txt, Encoding.Default);
                //   txt.Close();

                int TxtRows;
                TxtRows = UserdataGridView[loop].Rows.Count;
                for (int i = 0; i < TxtRows; i++)
                {
                    string[] wcells = new string[6];
                    wcells[0] = UserdataGridView[loop].Rows[i].Cells[0].Value.ToString();
                    //    DataGridViewCheckBoxCell chb = dataGridView1.Rows[i].Cells[1] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(UserdataGridView[loop].Rows[i].Cells[1].Value) == true)
                    {
                        wcells[1] = "1";
                        wcells[2] = UserdataGridView[loop].Rows[i].Cells[2].Value.ToString();
                    }
                    else
                    {
                        wcells[1] = "0";
                        wcells[2] = "";
                    }
                    if (Convert.ToBoolean(UserdataGridView[loop].Rows[i].Cells[3].Value) == true)
                    {
                        wcells[3] = "1";
                    }
                    else
                    {
                        wcells[3] = "0";
                    }
                    if (Convert.ToBoolean(UserdataGridView[loop].Rows[i].Cells[4].Value) == true)
                    {
                        wcells[4] = "1";
                        wcells[5] = UserdataGridView[loop].Rows[i].Cells[5].Value.ToString();
                    }
                    else
                    {
                        wcells[4] = "0";
                        wcells[5] = "";
                    }
                    if (i == (TxtRows - 1))
                    {
                        sw.Write(wcells[0] + "," + wcells[1] + "," + wcells[2] + "," + wcells[3] + "," + wcells[4] + "," + wcells[5]);
                    }
                    else
                    {
                        sw.Write(wcells[0] + "," + wcells[1] + "," + wcells[2] + "," + wcells[3] + "," + wcells[4] + ","  +wcells[5] + "?");
                    }

                }

                sw.Flush();
                sw.Close();
                txt.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitForm_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pathC1 = "../../conf\\tabC.ini";
            System.Diagnostics.Process.Start(pathC1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridView[] UserdataGridView = { dataGridView1, dataGridView2, dataGridView3,dataGridView4,dataGridView5,
                                                  dataGridView6,dataGridView7,dataGridView8,dataGridView9,dataGridView10
                                              };
            for (int i = 0; i < 10; i++)
            {
                UserdataGridView[i].Rows.Clear();
            }
            InitControls();
        }

        public void Refresh()
        {
            DataGridView[] UserdataGridView = { dataGridView1, dataGridView2, dataGridView3,dataGridView4,dataGridView5,
                                                  dataGridView6,dataGridView7,dataGridView8,dataGridView9,dataGridView10
                                              };
            for (int i = 0; i < 10; i++)
            {
                UserdataGridView[i].Rows.Clear();
            }
            InitControls();
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            FileStream FS = new FileStream("../../conf/tabC.ini", FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FS, System.Text.Encoding.Default);
            SR.BaseStream.Seek(0, SeekOrigin.Begin);
            string STR = SR.ReadToEnd();
            FS.Close();
            SR.Close();

            string[] tabC = STR.Split('\n');
            int tabCN = tabC.Length;
            if(textBox1.Text == "" )
            {
                MessageBox.Show("请填写标签号！");  
            }
            else
            {
               if (textBox4.Text == "")
               {
                    MessageBox.Show("请填写行号！");
                }
               else
               {
             int delNum = Convert.ToInt32(textBox1.Text);
            int delrnum = Convert.ToInt32(textBox4.Text);
            if (delNum < 1 || delNum > tabCN)
            {
                MessageBox.Show("标签超出索引！");
            }
            else
            {   DataGridView[] UserdataGridView = { dataGridView1, dataGridView2, dataGridView3,dataGridView4,dataGridView5,
                                                  dataGridView6,dataGridView7,dataGridView8,dataGridView9,dataGridView10
                                              };
            if (delrnum > UserdataGridView[delNum-1].RowCount )
            {
                MessageBox.Show("行超出索引！");
            }
            else
            {
                UserdataGridView[delNum - 1].Rows.Remove(UserdataGridView[delNum - 1].Rows[delrnum-1]);
            }
            }
               }
            }
            
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileStream FS = new FileStream("../../conf/tabC.ini", FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FS, System.Text.Encoding.Default);
            SR.BaseStream.Seek(0, SeekOrigin.Begin);
            string STR = SR.ReadToEnd();
            FS.Close();
            SR.Close();
            string[] tabC = STR.Split('\n');
            int tabCN = tabC.Length;
            string btnname = textBox2.Text.ToString();
            int addNum = Convert.ToInt32(textBox5.Text);
            if (addNum < 1 || addNum > tabCN)
            {
                MessageBox.Show("超出索引！");
            }
            else
            {
                if (btnname == "")
                {
                    MessageBox.Show("请填入按钮名!");
                }
                else
                {
                    DataGridView[] UserdataGridView = { dataGridView1, dataGridView2, dataGridView3,dataGridView4,dataGridView5,
                                                  dataGridView6,dataGridView7,dataGridView8,dataGridView9,dataGridView10
                                              };
                    int origin = UserdataGridView[addNum - 1].Rows.Count;
                    UserdataGridView[addNum - 1].Rows.Add();
                    UserdataGridView[addNum - 1].Rows[origin].Cells[0].Value = textBox2.Text.ToString();
                    if(checkBox1.Checked == true)
                    {
                        UserdataGridView[addNum - 1].Rows[origin].Cells[1].Value = true;
                        UserdataGridView[addNum - 1].Rows[origin].Cells[2].Value = textBox6.Text.ToString();
                    }
                    else
                    {
                        UserdataGridView[addNum - 1].Rows[origin].Cells[1].Value = false;
                        UserdataGridView[addNum - 1].Rows[origin].Cells[2].Value = textBox6.Text.ToString();
                    }
                    if (checkBox2.Checked == true)
                    {
                        UserdataGridView[addNum - 1].Rows[origin].Cells[3].Value = true;
                    }
                    else
                    {
                        UserdataGridView[addNum - 1].Rows[origin].Cells[3].Value = false;
                    }
                    if (checkBox3.Checked == true)
                    {
                        UserdataGridView[addNum - 1].Rows[origin].Cells[4].Value = true;
                        UserdataGridView[addNum - 1].Rows[origin].Cells[5].Value = textBox3.Text.ToString();
                    }
                    else
                    {
                        UserdataGridView[addNum - 1].Rows[origin].Cells[4].Value = false;
                        UserdataGridView[addNum - 1].Rows[origin].Cells[5].Value = "";
                    }
                }
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileStream txt = File.Open("../../conf/tabC.ini", FileMode.OpenOrCreate, FileAccess.Write);
            txt.SetLength(0);
            StreamWriter sw = new StreamWriter(txt, Encoding.Default);

            string tabString;
            string[] tabName = new string[10];
            int tabNameNum;
            tabString = textBox7.Text;
            tabName = tabString.Split('\n');
            tabNameNum = tabName.Length;
            if(tabNameNum > 10)
            {
                MessageBox.Show("标签名不能大于10!~");
            }
            else
            {
                for(int i = 0 ; i < tabNameNum ; i++ )
                {
                    sw.Write(tabName[i]);
                    if(i != (tabNameNum-1))
                    {
                        sw.Write('\n');
                    }
                }
            }
            sw.Flush();
            sw.Close();
            txt.Close();
            Refresh();
        }

       
    }
}
