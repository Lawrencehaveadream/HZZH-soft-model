using System;
using System.Collections.Generic;
using Common;

namespace Config
{
    [Serializable]
    public   class ConfigAxis : Config
    {
        public ConfigAxis()
        {
            AxisList = new List<Axis>();
        }
        /// <summary>
        /// 属性：轴机械参数列表实体(用于实体删减)
        /// </summary>
        public List<Axis>  AxisList { set; get; }
    }
}
