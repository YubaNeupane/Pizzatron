using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Future
{
    internal class AsynchronousFuture
    {
        private Object? result;
        private bool resultIsSet;
        private Exception? problem;

        public bool checkResult()
        {
            return resultIsSet;
        } // checkResult()

        public Object? getResult()
        {
            lock (this)
            {
                while (!resultIsSet)
                {
                    Monitor.Wait(this);
                }
                if (problem != null)
                {
                    throw problem;
                }
                return result;
            }

        }
        public void setResult(Object result)
        {
            lock (this)
            {
                if (resultIsSet)
                {
                   // String msg = "Result is already set";
                    return;
                } // if
                this.result = result;
                resultIsSet = true;
                Monitor.PulseAll(this);
            }
           
        } // setResult(Object)

        public  void setException(Exception e)
        {
            lock (this)
            {
                problem = e;
                resultIsSet = true;
                Monitor.PulseAll(this);
            }
       
        } // setException(Exception)
    }
}
