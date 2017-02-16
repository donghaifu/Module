using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TreeView
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        //初始化绑定默认关键词，此数据源可以从数据库取
        List<string> listOnit = new List<string>();
        //输入key之后，返回的关键词
        List<string> listNew = new List<string>();

        public Form1()
        {
            InitializeComponent();
            //得到数据
            getSaleList();
            //绑定到固定的列表和下面二选一
            //BindComboBoxToList();
            //绑定到数据源
            BindComboBoxToDataTable();
        }


        private void getSaleList()
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.HarvestConnectionString);
            string sql = " SELECT No,AssembleNo,NextLevel,NextLevelName,Remark FROM TempTable WHERE SalesNo ='10001' ";
            //where  AssembleNo LIKE '__0__' AND LevelHigh = '是' ORDER BY AssembleNo 
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);

            cn.Open();
            da.Fill(ds, "SalesList");
            cn.Close();
            dgvSalesList.DataSource = ds.Tables["SalesList"];
            //LeftMatch();
        }

        //从数据源中选择一列做输入匹配，使用combobox自己的匹配功能，只能从左到右进行匹配，不能模糊查询
        private void LeftMatch()
        {
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (DataRow row in ds.Tables["SalesList"].Rows)
            {
                //取第2列数据，从0开始
                stringCol.Add(Convert.ToString(row[2]));
            }
            comboBox1.AutoCompleteCustomSource = stringCol;        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //comboBox1.AutoCompleteCustomSource = ds.Tables["SalesList"].Rows;
            textBox1.Text = comboBox1.Text;
        }

        //绑定列表
        private void BindComboBoxToList()
        {
            listOnit.Add("张三");
            listOnit.Add("三张");
            listOnit.Add("冯张三");
            listOnit.Add("马六");
            listOnit.Add("孙楠");
            listOnit.Add("戚六马");
            listOnit.Add("刘欢");
            listOnit.Add("刘欢欢");
            //注意使用Item.Add(obj)或者Item.AddRange(obj)方式添加
            //如果用DataSource绑定，后面再进行绑定是不行的，即便是Add或者clear也不行
            this.comboBox1.Items.AddRange(listOnit.ToArray());
        }

        //绑定数据源
        private void BindComboBoxToDataTable()
        {

            //去除重复的字段,先筛选"NextLevel"字段
            string[] str = new string[] { "NextLevel"};
            //将DataTable转成DataView
            DataView dw = ds.Tables["SalesList"].DefaultView;
            //先建立一个DataTable
            DataTable DtForBind = dw.ToTable(true,str);
            
            foreach (DataRow row in DtForBind.Rows)
            {
                //取第2列数据，从0开始
                listOnit.Add(Convert.ToString(row[0]));
            }

            //去除重复的字段,再筛选"NextLevelName"字段
            string[] str1 = new string[] { "NextLevelName"};
            DtForBind = dw.ToTable(true, str1);
            foreach (DataRow row in DtForBind.Rows)
            {
                //取第2列数据，从0开始
                listOnit.Add(Convert.ToString(row[0]));
            }

            //最后的listOnit是两个字段的合体，完成件号和汉字双重检索

            //有时间验证一下count数量是否对得上
            this.comboBox1.Items.AddRange(listOnit.ToArray());
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            //清空combobox
            this.comboBox1.Items.Clear();
            //清空ListNew
            listNew.Clear();
            //遍历全部备查数据
            foreach (var item in listOnit)
            {
                if (item.Contains(this.comboBox1.Text))
                {
                    listNew.Add(item);
                }
            }
            //combobox添加已经查到的关键词
            this.comboBox1.Items.AddRange(listNew.ToArray());
            //设置光标位置，否则光标位置始终保持在第一列，造成输入的关键词倒序排列
            this.comboBox1.SelectionStart = this.comboBox1.Text.Length;
            //保持鼠标指针形状，有时鼠标指针会被覆盖，所以要进行一次设置
            Cursor = Cursors.Default;
            //自动弹出下拉框
            this.comboBox1.DroppedDown = true;

        }

    }
}
