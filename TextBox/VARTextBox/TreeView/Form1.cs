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
        //ds.Tables["SalesList"];
        public Form1()
        {
            InitializeComponent();
            getSaleList();
        }

        /*数据库脚本，测试nvarchar能不能保存空格和回车等信息，
         * 实践证明可以，本次软件开发使用nvarchar和TextBox的组合
         * 虽然不能带颜色，字体等格式信息，但是支持全文搜索
         USE Harvest
            CREATE TABLE VARTest
            (
               ID    nvarchar(10)  NOT NULL PRIMARY KEY,  /*产品销售代码由五位阿拉伯数字组成
               rtfContent  nvarchar(1000)  
            )
         * */
        private void getSaleList()
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.HarvestConnectionString);
            string sql = " SELECT ID,rtfContent FROM  VARTest";
            //where  AssembleNo LIKE '__0__' AND LevelHigh = '是' ORDER BY AssembleNo 
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            cn.Open();
            da.Fill(ds, "SalesList");
            cn.Close();
            dgvSalesList.DataSource = ds.Tables["SalesList"];
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.HarvestConnectionString);
            //将TextBox的值插入数据库第一条记录的rtfContent
            string sql1 = " UPDATE VARTest";
            sql1 += " SET rtfContent=@AssembleName1";
            sql1 += " WHERE ID=@AssembleNo1 ";
            SqlCommand cmd1 = new SqlCommand(sql1, cn);
            cmd1.CommandText = sql1;
            cmd1.Parameters.Add("AssembleNo1", SqlDbType.NVarChar, 10).Value = "1";
            cmd1.Parameters.Add("AssembleName1", SqlDbType.NVarChar, 8000).Value = textBox2.Text;

            cn.Open();
            cmd1.ExecuteNonQuery();
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.Tables["SalesList"].Clear();
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.HarvestConnectionString);

            string sql1 = " SELECT ID,rtfContent FROM  VARTest";
            sql1 += " WHERE ID=@AssembleNo1";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
            da1.SelectCommand.Parameters.Add("AssembleNo1", SqlDbType.NVarChar, 20).Value = "1";
            
            cn.Open();
            da1.Fill(ds, "SalesList");
            cn.Close();
            //写入第二个TextBox
            textBox3.Text = ds.Tables["SalesList"].Rows[0][1].ToString();
        }

        
    }
}
