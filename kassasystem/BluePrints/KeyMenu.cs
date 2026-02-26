using System;
using kassasystem.Products;

using System.Threading;

namespace kassasystem
{
    internal class KeyMenu
    {
        public string Option1;
        public string Option2;
        public string Option3;
        public string Option4;

        public KeyMenu(string option1, string option2, string option3, string option4)
        {
            Option1 = option1;
            Option2 = option2;
            Option3 = option3;
            Option4 = option4;
        }
        public KeyMenu(string option1, string option2, string option3)
        {
            Option1 = option1;
            Option2 = option2;
            Option3 = option3;
        }
        public KeyMenu(string option1, string option2)
        {
            Option1 = option1;
            Option2 = option2;
        }
    }
}

