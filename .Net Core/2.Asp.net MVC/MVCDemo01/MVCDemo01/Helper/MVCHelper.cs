using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo01.Helper
{
    public static class MVCHelper
    {
        public static string GetValidMsg(ModelStateDictionary md)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in md.Keys)
            {
                if (md[item].Errors.Count<=0)
                {
                    continue;
                }
                sb.Append($"属性[{item}]验证错误:");
                foreach (var error in md[item].Errors)
                {
                    sb.Append(error.ErrorMessage);
                }
                sb.AppendLine("");
            }
            return sb.ToString();
        }
    }
}