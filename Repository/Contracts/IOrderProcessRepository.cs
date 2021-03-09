using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IOrderProcessRepository
    {
        int OrderProcess(string orderNo, string created_By);
    }
}
