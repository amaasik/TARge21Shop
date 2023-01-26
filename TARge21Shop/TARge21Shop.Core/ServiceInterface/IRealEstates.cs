using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface IRealEstates
    {
        Task<RealEstate> GetAsync(Guid id);
    }
}
