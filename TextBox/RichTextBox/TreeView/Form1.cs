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

        /*
         这个例子测试richTextBox和数据库的ntext组合，主要使用richTextBox1.Rtf，其实质是一个带有格式的字符串
         * 虽然也能正常读写，但是无法全文检索汉字。字母可以检索，但是要转换，效率也会下降
         * 检索代码：select * from RTFTest where CONVERT(NVARCHAR(MAX),rtfContent)LIKE '%08200%'
         * 
         USE Harvest
         CREATE TABLE VARTest
         (
            ID    nvarchar(10)  NOT NULL PRIMARY KEY,/*产品销售代码由五位阿拉伯数字组成
            rtfContent  ntext  
         )
         * 以后如果需要还可以进一步验证
       */
        /*一段rtf文本
{\rtf1\fbidis\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fnil\fprq2\fcharset134 \'cb\'ce\'cc\'e5;}{\f1\froman\fprq2\fcharset0 Times New Roman;}{\f2\fswiss\fprq2\fcharset0 Arial;}{\f3\fnil\fcharset134 \'cb\'ce\'cc\'e5;}}
{\colortbl ;\red255\green0\blue0;}
\viewkind4\uc1\pard\ltrpar\nowidctlpar\lang2052\f0\fs18\'b8\'b6\'b6\'ab\'ba\'a3\'a1\'a1\f1\par
\par
\f2\fs52 nihao\par
\f1\fs18\par
\par
\cf1\f2 AYT08200 \f0\'c2\'dd\'cb\'a8\f1\par
\pard\ltrpar\cf0\f3\par
}
*/



        private void getSaleList()
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.HarvestConnectionString);
            string sql = " SELECT ID,rtfContent FROM  RTFTest";
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
            //richTextBox更新到数据库 rtfContent字段
            string sql1 = " UPDATE RTFTest";
            sql1 += " SET rtfContent=@AssembleName1";
            sql1 += " WHERE ID=@AssembleNo1 ";
            SqlCommand cmd1 = new SqlCommand(sql1, cn);
            cmd1.CommandText = sql1;
            cmd1.Parameters.Add("AssembleNo1", SqlDbType.NVarChar, 10).Value = "1";
            cmd1.Parameters.Add("AssembleName1", SqlDbType.NText, 8000).Value = richTextBox1.Rtf;

            cn.Open();
            cmd1.ExecuteNonQuery();
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.Tables["SalesList"].Clear();
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.HarvestConnectionString);

            string sql1 = " SELECT ID,rtfContent FROM  RTFTest";
            sql1 += " WHERE ID=@AssembleNo1";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
            da1.SelectCommand.Parameters.Add("AssembleNo1", SqlDbType.NVarChar, 20).Value = "1";
            //读取数据库
            cn.Open();
            da1.Fill(ds, "SalesList");
            cn.Close();
            richTextBox1.Rtf = ds.Tables["SalesList"].Rows[0][1].ToString();
        }

        
    }
}
