using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
   public interface IDeletePracticeRepository
    {
        int DeletePracticeMaster(int id);
    }
}
