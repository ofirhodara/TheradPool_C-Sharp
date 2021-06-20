using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Thread_basic
{
    class SharedInteger
    {
        private static SharedInteger onlyInt = null;
        private int box;
        private SharedInteger()
        {
            box = 0;
        }
        public static SharedInteger GetShow()
        {
            if (onlyInt == null)
                onlyInt = new SharedInteger();
            return onlyInt;
        
        }

        public int GetInt()
        {
            return box;
       
        }
       
        public void incInt()
        {
            this.box++;
        }
    
        public bool is7Boom()
        {
            if (box % 7 == 0)
                return true;

            int num = box;
            while (num != 0)
            {
                if (num % 10 == 7)
                    return true;
                num /= 10;
            }

            return false;
        
        }


    }
}
