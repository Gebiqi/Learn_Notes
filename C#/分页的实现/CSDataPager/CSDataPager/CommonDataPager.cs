using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDataPager
{
    /// <summary>
    /// 通用数据分页类
    /// </summary>
    public class CommonDataPager
    {
        #region 一般属性


        /// <summary>
        /// 每页显示的条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 需要显示的字段（以逗号分隔）
        /// </summary>
        public string FieldsName { get; set; }
        /// <summary>
        /// 表的名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// 过滤的条件(主键或唯一键)
        /// </summary>
        public string PrimaryKey { get; set; }
        /// <summary>
        /// 当前显示的页码
        /// </summary>
        public int CurrentPageNo { get; set; }
        /// <summary>
        /// 排序条件
        /// </summary>
        public string Sort { get; set; }
        #endregion
        
        #region 只读属性


        /// <summary>
        /// 记录总数【不能直接赋值】
        /// </summary>
        //public int RecordCount { get; set; }
        private int recordCount;//设置不能从外部直接赋值，只能读取，内部通过访问数据库得到并暂存，需要私有字段
        public int RecordCount
        {
            get { return recordCount; }
        }

        ///总页数 通过计算得到，不需要私有字段
        public int TotalPages
        {
            get
            {
                if (recordCount!=0)
                {
                    if (recordCount % PageSize > 0)
                    {
                        return recordCount / PageSize + 1;
                    }
                    else
                    {
                        return recordCount / PageSize;
                    }
                }
                else
                {
                    CurrentPageNo = 1;
                    return 0;
                }
            }
        }
        #endregion

        //分页查询方法

            /// <summary>
            /// 封装获取数据的SQL语句
            /// </summary>
            /// <returns></returns>
        private string GetPageDataSQL()
        {
            //计算需要过滤的总数
            string filterCount = (PageSize * (CurrentPageNo - 1)).ToString();
            //组合SQL语句
            string sql = "select top {0} {1} from {2} where {3} and {4} not in ";
            sql+="(select top {5} {6} from {7} where {8} order by {9}) order by {10};";
            sql += "select count(*) from {11} where {12}";
            sql = string.Format(sql, PageSize, FieldsName, TableName, Condition, PrimaryKey, filterCount, PrimaryKey, TableName, Condition, Sort, Sort,TableName,Condition);
            return sql;
        }
        /// <summary>
        /// 执行分页查询，返回分页页面数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetPageData()
        {
            //执行查询，返回分页结果集
            DataSet ds = SQLHelper.GetDataSet(GetPageDataSQL());
            //将记录总数赋值给对象属性
            this.recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return ds.Tables[0];
        }
    }
}
