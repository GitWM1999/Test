using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Education.Service
{
    public class BaseService:IBaseService
    {
        public IMapper _mapper;


        /// <summary>
        /// 映射
        /// </summary>
        public IMapper Mapper => LazyGetRequiredService(ref _mapper);

        public IServiceProvider ServiceProvider { get; set; }

        protected readonly object ServiceProviderLock = new object();

        protected TService LazyGetRequiredService<TService>(ref TService reference)
        {
            if (reference == null)
            {
                lock (ServiceProviderLock)
                {
                    if (reference == null)
                    {
                        reference = ServiceProvider.GetRequiredService<TService>();
                    }
                }
            }

            return reference;
        }
    }
}
