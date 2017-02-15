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
            string sql = " SELECT No,AssembleNo,NextLevel,NextLevelName,Remark FROM TempTable WHERE SalesNo ='10001' ";
            //where  AssembleNo LIKE '__0__' AND LevelHigh = '是' ORDER BY AssembleNo 
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);

            cn.Open();
            da.Fill(ds, "SalesList");
            cn.Close();
            dgvSalesList.DataSource = ds.Tables["SalesList"];
            //TreeNodeCollection tnc = treeView1.Nodes;
            //BindTreeViewN(ds.Tables["SalesList"], tnc, "10001", "NextLevel", "AssembleNo", "NextLevelName");

            //以10001为例来展示结构
            TreeNode tn = new TreeNode();
            tn.Name = "10001";
            tn.Text = "4YZ-6型玉米籽粒收获机";
            treeView1.Nodes.Add(tn);//将该节点加入到TreeView中
            BindTreeView(ds.Tables["SalesList"], tn, "NextLevel", "AssembleNo", "NextLevelName","Remark");
            //打开悬停鼠标时提示
            treeView1.ShowNodeToolTips = true;
            this.Controls.Add(treeView1);
        }

        /// <summary>
        /// 绑定TreeView（利用TreeNode）
        /// </summary>
        /// <param name="p_Node">TreeNode（TreeView的一个节点）</param>
        /// <param name="id">数据库 id 字段名</param>
        /// <param name="pid">数据库 父id 字段名</param>
        /// <param name="text">数据库 文本 字段值</param>
        /// 本算法没有使用递归，节省了递归算法层级嵌套耗费的时间，效率非常高。
        /// 本算法强烈依赖于product表生成时使用的递归算法。
        /// product表的一个特点是层级从小到大一直是连续变化的，且一个装配的相关数据都在一起；但层级从大到小有可能产生跳跃
        /// 不能对其进行按组排序（ORDER BY Level），排序后所有组号相同的零件放在一起，打破了装配关系
        protected void BindTreeView(DataTable dt, TreeNode p_Node, string id, string pid, string text, string Remark)
        {
            TreeNode tn;//建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中
            int TempLevel = 0;//当前行的层级数
            int FutureLevel = 0;//下一行的层级数

            //得到DataTable中数据的行数，利用循环每次处理一行数据
            for (int i = 0; i < dt.Rows.Count; i++ )
            {
                tn = new TreeNode();//建立一个新节点（学名叫：一个实例）
                tn.Name = dt.Rows[i]["NextLevel"].ToString();//结点名称
                tn.Text = dt.Rows[i]["NextLevel"].ToString() + dt.Rows[i]["NextLevelName"].ToString();//结点显示内容
                tn.ToolTipText = dt.Rows[i]["Remark"].ToString();//结点在鼠标悬停时显示的内容，就是Remark列的内容
                p_Node.Nodes.Add(tn);//添加节点

                //从下面一直到结束这些代码用来明确在下一个循环开始的父节点p_Node的位置
                TempLevel = (int)dt.Rows[i]["No"];//字段No的值就是当前行的层级数
                if (i != dt.Rows.Count - 1)//如果没有达到表的最后一行，直接取i+1给FutureLevel赋值就行
                {
                    FutureLevel = (int)dt.Rows[i + 1]["No"];
                }
                else
                {
                    FutureLevel = 0;//到达表的最后一行，i+1就会出问题，需要仔细考虑边界问题
                }

                //用本行和下一行的层级关系来决定结点的移动
                if (TempLevel < FutureLevel)//下一行结点是本行结点的子节点
                {
                    p_Node = tn;
                }
                else if (TempLevel == FutureLevel)
                {
                    //下一行结点是本行结点的兄弟结点
                }
                else//等价(TempLevel > FutureLevel)，下一行结点是本行结点的父兄结点，但是有可能从6级一下回到2级
                {
                    int Distance = TempLevel - FutureLevel;//计算层级差距
                    for (int j = 1; j <= Distance; j++)//无论差几级会一直回溯到正确的父结点
                    {
                        p_Node = p_Node.Parent;
                    }
                }
                
            }

        }
        

        /// <summary>
        /// 绑定TreeView（利用TreeNodeCollection）,把经过递归排序的数据从数据库中取出来直接显示
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


    }
}
