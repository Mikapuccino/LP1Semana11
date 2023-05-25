using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class View : IView
    {
        private readonly Controller controller;

        public View(Controller controller)
        {
            this.controller = controller;
        }
    }
}