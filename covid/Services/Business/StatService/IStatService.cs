using Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business.StatService
{
    public interface IStatService
    {
        Task<StatsDTO> getStats();
    }
}
