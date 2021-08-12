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

namespace ClearZeroFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private int count = 0;

        private void button1_Click(object sender, EventArgs e)
        {

            int count = 0;

            if (!Directory.Exists(this.input_dir.Text)) {

                MessageBox.Show("输入的目录不存在");
            }

            proc_directory(this.input_dir.Text, this.proc_type.Text);


            MessageBox.Show("请理完成："+count.ToString()+"个文件");
        }


        private void proc_directory(string input_dir, string _proc_type) {


            DirectoryInfo di = new DirectoryInfo(input_dir);


            foreach (FileInfo fi in di.GetFiles(_proc_type)) { 
                if (fi.Length == 0) {
                    fi.Delete();
                    count++;
                } 
            }
            
            
            foreach (DirectoryInfo _di in di.GetDirectories()) {

                proc_directory(_di.FullName, _proc_type);


            }


        
        }

    }
}
