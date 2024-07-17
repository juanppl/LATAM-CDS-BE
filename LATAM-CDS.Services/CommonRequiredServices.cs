using AutoMapper;
using LATAM_CDS.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LATAM_CDS.Services
{
    public class CommonRequiredServices
    {
        public CommonRequiredServices(
            DbAppContext context,
            IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public DbAppContext Context { get; }
        public IMapper Mapper { get; }
    }
}
