using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test3
{
    public partial class Form1 : Form
    {
        bool bMouseDown;
        int LifeNum = 5;
        int StudyNum = 3;
        int SportNum = 3;

        public Form1()
        {
            InitializeComponent();

          //  this.groupBox1.AllowDrop = true;
            this.groupBox2.AllowDrop = true;
          //  this.groupBox3.AllowDrop = true;
          //  this.groupBox4.AllowDrop = true;

        //    this.groupBox1.DragEnter += new DragEventHandler(groupBox_DragEnter);
            this.groupBox2.DragEnter += new DragEventHandler(groupBox_DragEnter);
         //   this.groupBox3.DragEnter += new DragEventHandler(groupBox_DragEnter);
         //   this.groupBox4.DragEnter += new DragEventHandler(groupBox_DragEnter);

          //  this.groupBox1.DragOver += new DragEventHandler(groupBox_DragOver);

         //   this.groupBox1.DragDrop += new DragEventHandler(groupBox_DragDrop);
            this.groupBox2.DragDrop += new DragEventHandler(groupBox_DragDrop);
         //   this.groupBox3.DragDrop += new DragEventHandler(groupBox_DragDrop);
        //    this.groupBox4.DragDrop += new DragEventHandler(groupBox_DragDrop);

           //     this.groupBox2.MouseClick += new MouseEventHandler(deleteUserControls);
            //         this.tabPage1.DragDrop += new DragEventHandler(groupBox_DragDrop);
            //         this.tabPage2.DragDrop += new DragEventHandler(groupBox_DragDrop);
            //          this.tabPage3.DragDrop += new DragEventHandler(groupBox_DragDrop);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateControls();     
        }

        private void CreateControls()
        {
            string[] tabC = new string[10];
            TabPage[] Usertabpage = { tabPage1, tabPage2, tabPage3, tabPage4,
                                      tabPage5, tabPage6,tabPage7,tabPage8,tabPage9,tabPage10 };
            GroupBox[] Usergrp = { groupBox1, groupBox3, groupBox4, groupBox5,
                                      groupBox6, groupBox7,groupBox8,groupBox9,groupBox10,groupBox11 };
            string[] path = { "../../conf/tab1.ini",
                            "../../conf/tab2.ini",
                            "../../conf/tab3.ini",
                            "../../conf/tab4.ini",
                            "../../conf/tab5.ini",
                            "../../conf/tab6.ini",
                            "../../conf/tab7.ini",
                            "../../conf/tab8.ini",
                            "../../conf/tab9.ini",
                            "../../conf/tab10.ini"};
            int tabCN;

            FileStream FS = new FileStream("../../conf/tabC.ini", FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FS, System.Text.Encoding.Default);
            SR.BaseStream.Seek(0, SeekOrigin.Begin);
            string STR = SR.ReadToEnd();
            FS.Close();
            SR.Close();

            tabC = STR.Split('\n');
            tabCN = tabC.Length;

            for (int usertabN = 0; usertabN < 10; usertabN++)
            {
                Usertabpage[usertabN].Parent = tabControl1;
            }
            for(int usertabN = tabCN ; usertabN < 10 ; usertabN++)
            {
                Usertabpage[usertabN].Parent = null;
            }

            for(int usertabN = 0 ; usertabN < tabCN ; usertabN++)
            {
                Usertabpage[usertabN].Text = tabC[usertabN];
            int x = 15;
            int y = 15;
            
            string[] btnValue = new string[10];
            string[] btnValue1 = new string[6];
            string[][] btnValue2 = new string[10][];
            FileStream fs = new FileStream(path[usertabN], FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs,System.Text.Encoding.Default);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string strtemp1 = sr.ReadToEnd();
            fs.Close();
            sr.Close();

            string strtemp2 = strtemp1.Trim('\n',(char)0);
            string str = strtemp2.Trim('\r', (char)0);
            btnValue = str.Split('?'); 
            int t = btnValue.Length;
            for (int i = 0; i < t;i++ )
            {
                btnValue1 = btnValue[i].Split(',');
                btnValue2[i] = btnValue1;
                
            }
            for (int i = 0; i < t; i++)
            {
                UserSingleButton btn = new UserSingleButton();
                string[] item = new string[30];
                btn.Left = x;
                btn.Top = y;
                btn.LabelString = btnValue2[i][0];
                string w = btn.LabelString;

                if (btnValue2[i][1] == "1")
                {
                    btn.checkBox1visible = true;
                    btn.textBox1Value = btnValue2[i][2];
                }
                else
                {
                    btn.checkBox1visible = false;
                    btn.textBox1Value = "";
                }
                if (btnValue2[i][3] == "1")
                {
                    btn.nUDvisible = true;
                }
                else
                {
                    btn.nUDvisible = false;
                }
                if (btnValue2[i][4] == "1")
                {
                    btn.cbbvisible = true;
                    item = btnValue2[i][5].Split(';','；');
                    int itemLen = item.Length;
                    for (int j = 0; j < itemLen; j++)
                    {
                        btn.cbb1Item = item[j];
                    }
                }
                else
                {
                    btn.cbbvisible = false;
                }
                btn.Width = 100;
                btn.Height = 50;
                x += btn.Width + 15;
                if (btn.Width > groupBox1.Width - x)
                {
                    x = 15;
                    y += btn.Height + 15;
                }
                btn.AllowDrop = true; // 默认为 false,即不可拖动
                btn.MouseDown += new MouseEventHandler(btn_MouseDown);
                Usergrp[usertabN].Controls.Add(btn);
            }
            }
        }

      
        void groupBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            bMouseDown = true;
            
        }

        void groupBox_DragDrop(object sender, DragEventArgs e)
        {
            if (bMouseDown)
            {
                // 从事件参数 DragEventArgs 中获取被拖动的元素
                UserSingleButton btn = (UserSingleButton)e.Data.GetData(typeof(UserSingleButton));               
                GroupBox grp = (GroupBox)btn.Parent;
                ((GroupBox)sender).Controls.Add(btn);

                RefreshControls(new Control[] {  (GroupBox)sender });
               // RemoveUserCtl(grp);
                    
                if(grp != (GroupBox)sender)
                {
                   grp.Controls.Clear();
                   CreateControls();
                }
                bMouseDown = false;
            }
        }

        void deleteUserControls(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
               // MessageBox.Show("按动鼠标右键！");
                this.groupBox2.DragEnter += new DragEventHandler(del); //(del);
            } 
        }

        void del(object sender, DragEventArgs e)
        {
                UserSingleButton group2btn = (UserSingleButton)e.Data.GetData(typeof(UserSingleButton));
                GroupBox grp2 = (GroupBox)group2btn.Parent;
                grp2.Controls.Remove(group2btn);
        }

        void RemoveUserCtl(GroupBox[] q)
        {
           // q.Controls.Clear();
        }
        void btn_MouseDown(object sender, MouseEventArgs e)
        {
            UserSingleButton btn = (UserSingleButton)sender;
            btn.DoDragDrop(btn, DragDropEffects.Copy );
           
        }
        void Rbtn_MouseDown(object sender, MouseEventArgs e)
        {
            UserRadioButton btn = (UserRadioButton)sender;
            btn.DoDragDrop(btn, DragDropEffects.Copy);

        }

        private void RefreshControls(Control[] p)
        {
            foreach (Control control in p)
            {
                int x = 15;
                int y = 15;
                UserSingleButton btn = null;
                foreach (Control var in control.Controls)
                {
                    btn = var as UserSingleButton;
                    btn.Left = x;
                    btn.Top = y;
                    x += btn.Width + 15;
                    if (btn.Width > control.Width - x)
                    {
                        x = 15;
                        y += btn.Height + 15;
                    }
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (Control ct in groupBox2.Controls)
            {
                UserSingleButton rb = ct as UserSingleButton;
                textBox1.Text = textBox1.Text + rb.LabelString;
                if (rb.checkbox1Value == true)
                {
                    textBox1.Text = textBox1.Text + rb.textBox1Value;
                }
                    if( rb.cbbvisible == true )
                {
                    textBox1.Text = textBox1.Text + rb.cbbValue ;
                }
                if( rb.nUDvisible == true )
                {  
                    textBox1.Text = textBox1.Text + rb.LabelString + rb.Value + "\r\n";
                }
                else
                {
                    textBox1.Text = textBox1.Text + "\r\n";
                }
     
                
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.Filter = "Word文档.doc|*.doc|文本文档.txt|*.txt";
            saveFile1.FilterIndex = 1;
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFile1.FileName, false);
                try
                {
                    sw.WriteLine(textBox1.Text); //只要这里改一下要输出的内容就可以了
                }
                catch
                {
                    throw;
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  textBox2.Text = "sdfsd";
            int DeleteNum = 0;
            int grpNum = 0;
            string DeleteString = "0";

            try
            {
                DeleteString = textBox2.Text;
                DeleteNum = Convert.ToInt32(DeleteString);
                DeleteNum -= 1;
            }
            catch
            {
                 MessageBox.Show("请填写需要删除的组件号！");
            }

            foreach(Control control in groupBox2.Controls)
            {
                grpNum += 1;
            }

            try
            {
                groupBox2.Controls.RemoveAt(DeleteNum);
                RefreshControls(new Control[] { groupBox2 });
            }
            catch
            {
                MessageBox.Show("编号错误！");
            }
            
       //  textBox2.Text = grpNum.ToString();
      //      groupBox2.Controls.RemoveAt(DeleteNum);
       //     RefreshControls(new Control[] { groupBox2 });
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            InitForm form2 = new InitForm();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GroupBox[] Usergrp = { groupBox1, groupBox3, groupBox4, groupBox5,
                                      groupBox6, groupBox7,groupBox8,groupBox9,groupBox10,groupBox11 };
            for (int i = 0; i < 10; i++ )
            {
                Usergrp[i].Controls.Clear();
            }
                CreateControls();
        }

     


    //    private void button2_Click(object sender, EventArgs e)
    //    {
    //        MessageBox.Show(this.numericUpDown1.Value.ToString());
    //    }

  

    }
}
