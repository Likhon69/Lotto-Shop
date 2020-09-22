using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IOrderProcessManager
    {
        int OrderProcess(string orderNo,string created_By);
    }
}
