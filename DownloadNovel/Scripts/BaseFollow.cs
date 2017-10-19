using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yungs
{
    public class BaseFollow:IDisposable
    {
        public virtual void OnLoad() { }
        public virtual void Dispose() { }

    }
}
