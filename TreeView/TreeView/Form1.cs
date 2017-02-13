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

        private void getSaleList()
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.HarvestConnectionString);
            string sql = " SELECT No,AssembleNo,NextLevel,NextLevelName FROM TempTable WHERE SalesNo ='10001' ORDER BY LEVEL";
            //where  AssembleNo LIKE '__0__' AND LevelHigh = '是' ORDER BY AssembleNo 
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);

            cn.Open();
            da.Fill(ds, "SalesList");
            cn.Close();
            dgvSalesList.DataSource = ds.Tables["SalesList"];
            //treeView1.Nodes
            TreeNodeCollection tnc = treeView1.Nodes;
            BindTreeViewN(ds.Tables["SalesList"], tnc, "10001", "NextLevel", "AssembleNo", "NextLevelName");
            //BindTreeView(ds.Tables["SalesList"], tnc, 1, "No" ,"NextLevel", "AssembleNo", "NextLevelName");
        }

        /// <summary>
        /// 绑定TreeView（利用TreeNodeCollection）,把“没有规律”的链接关系从数据库中取出来后自己进行递归排序
        /// </summary>
        /// <param name="tnc">TreeNodeCollection（TreeView的节点集合）</param>
        /// <param name="pid_val">父id的字段值,最初输入的值是树根的值，比如10001</param>
        /// <param name="id">数据库 id 字段名</param>
        /// <param name="pid">数据库 父id 字段名</param>
        /// <param name="text">数据库 文本 字段值</param>
        private void BindTreeViewN(DataTable dt, TreeNodeCollection tnc, string pid_val, string id, string pid, string text)
        {
            DataView dv = new DataView(dt);//将DataTable存到DataView中，以便于筛选数据
            TreeNode tn;//建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中
            //以下为三元运算符，如果父id为空，则为构建“父id字段 is null”的查询条件，否则构建“父id字段=父id字段值”的查询条件
            string filter = string.IsNullOrEmpty(pid_val) ? pid + " is null" : string.Format(pid + "='{0}'", pid_val);
            dv.RowFilter = filter;//利用DataView将数据进行筛选，选出相同 父id值 的数据
            foreach (DataRowView drv in dv)
            {
                tn = new TreeNode();//建立一个新节点（学名叫：一个实例）
                tn.Name = drv[id].ToString();//节点的Value值，一般为数据库的id值
                tn.Text = drv[id].ToString() + drv[text].ToString();//节点的Text，节点的文本显示，修改了一下把结点的id也加了进去
                tnc.Add(tn);//将该节点加入到TreeNodeCollection（节点集合）中
                BindTreeViewN(dt, tn.Nodes, tn.Name, id, pid, text);//递归（反复调用这个方法，直到把数据取完为止）
            }
        }

        /// <summary>
        /// 绑定TreeView（利用TreeNodeCollection）,把“有规律”的链接关系从数据库中取出来后自己进行递归排序
        /// </summary>
        /// <param name="tnc">TreeNodeCollection（TreeView的节点集合）</param>
        /// <param name="no">数据库 no 字段名,表示层级关系</param>
        /// <param name="pid_val">父id的字段值,最初输入的值是树根的值，比如10001</param>
        /// <param name="id">数据库 id 字段名</param>
        /// <param name="pid">数据库 父id 字段名</param>
        /// <param name="text">数据库 文本 字段值</param>
        private void BindTreeView(DataTable dt, TreeNodeCollection tnc, int No_val, string No, string id, string pid, string text)
        {
            DataView dv = new DataView(dt);//将DataTable存到DataView中，以便于筛选数据
            TreeNode tn;//建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中
            //以下为三元运算符，如果父id为空，则为构建“父id字段 is null”的查询条件，否则构建“父id字段=父id字段值”的查询条件
            //string filter = string.IsNullOrEmpty(No_val) ? No + " is null" : string.Format(No + "='{0}'", No_val);
            //if(No_val)
            string filter = string.Format(No + "='{0}'", No_val);
     
            No_val ++;
            dv.RowFilter = filter;//利用DataView将数据进行筛选，选出相同 层级 的数据
            foreach (DataRowView drv in dv)
            {
                tn = new TreeNode();//建立一个新节点（学名叫：一个实例）
                tn.Name = drv[id].ToString();//节点的Value值，一般为数据库的id值
                tn.Text = drv[id].ToString() + drv[text].ToString();//节点的Text，节点的文本显示，修改了一下把结点的id也加了进去
                tnc.Add(tn);//将该节点加入到TreeNodeCollection（节点集合）中

                BindTreeView(dt, tn.Nodes, No_val, No, id, pid, text);//递归（反复调用这个方法，直到把数据取完为止）
            }
        }




    }
}
