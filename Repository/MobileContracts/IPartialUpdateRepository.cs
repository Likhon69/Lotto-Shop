using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.MobileContracts
{
    public interface IPartialUpdateRepository
    {
        string Partialupdate(Guid partialId, Guid uupdateId);
    }
}
