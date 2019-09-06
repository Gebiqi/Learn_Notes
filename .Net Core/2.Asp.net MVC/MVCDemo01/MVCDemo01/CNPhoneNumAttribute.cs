using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo01
{
    public class CNPhoneNumAttribute:ValidationAttribute
    {
        public CNPhoneNumAttribute()
        {
            this.ErrorMessage = "中国电话号码错误";
        }
        public override bool IsValid(object value)
        {
            if (value is string)
            { 
                string s = (string)value;
                if (s.Contains('-'))
                {
                    string[] ss = s.Split('-');
                    if (ss[0].Length==3||ss[0].Length==4)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (s.Length==11)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}