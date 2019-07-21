using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Common
{
    public class ResponseResult
    {
        /// <summary>
        /// result
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// error message
        /// </summary>
        public string ErrorMsg { get; set; }

        /// <summary>
        /// return data
        /// </summary>
        public object Data { get; set; }
    }
}
