using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEntity
{
    public class DeskInfo
    {
        /// <summary>
        /// 桌台id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 桌台名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 桌台类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 桌台费用
        /// </summary>
        public int Fee { get; set; }
        /// <summary>
        /// 桌台位置
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 桌台备注
        /// </summary>
        public string Notes { get; set; }
    }
}
