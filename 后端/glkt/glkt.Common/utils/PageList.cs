using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Common.utils
{
    public class PageList
    {
        /// <summary>
        /// 数据
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 一页显示的数据条数
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 总数据条数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 上一页
        /// </summary>
        public bool Previous { get; set; }

        /// <summary>
        /// 下一页
        /// </summary>
        public bool Next { get; set; }

        public PageList(dynamic data, int index, int size, int count)
        {
            Data = data;
            Index = index;
            Size = size;
            Count = count;
            Total = CalculationTotal(size,count);
            Previous = index > 1;
            Next = index < Total;
        }

        private int CalculationTotal(int size, int count)
        {
            if (Count == 0) return 0;

            int total = count / size;
            if (count % size > 0) total += 1;
            return total;
        }

    }
}
