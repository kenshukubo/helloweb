using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace helloweb.Models.Interface {
    public interface IGreeting {
        string Greet();
    }
    public class GoodMorning : IGreeting
    {
        public string Greet()
        {
            return "Good Morning!!";
        }
    }
    public class GoodEvening : IGreeting
    {
        public string Greet()
        {
            return "Good Evening!!";
        }
    }
}