using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs.Attributes;

namespace glkt.Model.VO.Excel
{
    public class SubjectData
    {
        /// <summary>
        /// 一级菜单
        /// </summary>
        [ExcelColumnName("一级分类")]
        public string OneSudjectName { get; set; }

        /// <summary>
        /// 二级菜单
        /// </summary>
        [ExcelColumnName("二级分类")]
        public string TwoSudjectName { get; set; }

    }
}
