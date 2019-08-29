using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10event1
{
    public class Person
    {
        public string Name { get; set; }
        private int age;
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
                if (value%12==0)
                {
                    //if (MSG!=null)
                    //{
                    //    MSG();
                    //}
                    if (this._MSG != null)
                    {
                        this._MSG();
                    }
                }
                
            }
        }
        //11 事件入门
        //public event Action MSG; //编译器帮助完成一个私有委托+两个add和remove方法的生成
        //12 事件的本质：事件是由一个私有的委托和一个add一个remove方法组成，类似{get;set}
        private Action _MSG;
        public event Action MSG
        {
            add
            {
                this._MSG += value;
            }
            remove
            {
                this._MSG -= value;
            }
        }
    }
    
}
