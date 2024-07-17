using AutoMapper;
using LATAM_CDS.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LATAM_CDS.Services
{
    public abstract class QueryServiceBase
    {
        private readonly CommonRequiredServices _commonRequiredServices;

        protected QueryServiceBase(CommonRequiredServices commonRequiredServices)
        => _commonRequiredServices = commonRequiredServices;

        protected DbAppContext Context { get => _commonRequiredServices.Context; }
        protected IMapper ObjectMapper { get => _commonRequiredServices.Mapper; }
    }
}
