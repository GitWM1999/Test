using AspNetCoreRateLimit;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Education.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace API
{
    public class Startup
    {
        private readonly ConfigHelper _configHelper;
        private readonly IHostEnvironment _env;

        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            Configuration = configuration;
            _configHelper = new ConfigHelper();
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            #region 数据库连接
            var dbConfig = _configHelper.Get<DbConfig>("dbConfig",_env.EnvironmentName,true);
            #endregion

            #region     后台原样输出
            //< !--在Startup类的ConfigureServices()方法中进行配置，DefaultContractResolver() 原样输出，返回的 json 与后台定义一致-- >
            services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = null);
            #endregion 

            #region 限流配置
            //加载配置
            services.AddOptions();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);//设置兼容性版本
            services.AddMemoryCache();
            //加载IpRateLimiting配置
            //services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            var ratelimitconfig = _configHelper.Load("rateLimit", _env.EnvironmentName, true);  //读取自定义IP限流配置
            services.Configure<IpRateLimitOptions>(ratelimitconfig.GetSection("IpRateLimiting"));
            //注入计数器和规则存储
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            //添加框架服务
            services.AddMvc();
            // clientId / clientIp解析器使用它。
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //配置（计数器密钥生成器）
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            #endregion

            #region AutoMapper 自动映射

            var serviceAssembly = Assembly.Load("Education.Service");
            services.AddAutoMapper(serviceAssembly);

            #endregion

            #region Core跨域请求
            services.AddCors(c =>
            {
                c.AddPolicy("CorsPolicy", policy =>
                {
                    var corsPath = _configHelper.Load("corUrls", _env.EnvironmentName, true).GetSection("CorsPaths").GetChildren().Select(p => p.Value).ToArray();
                    policy
                    .WithOrigins(corsPath)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowCredentials()//指定处理cookie
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(60));
                    //如果接口已验证过一次跨域，则在60分钟内再次请求时，将不需要验证跨域
                });
            });
            #endregion

            #region Redis
            services.AddSingleton(new RedisHelper());
            //redis缓存
            var section = Configuration.GetSection("Redis:Default");
            //连接字符串
            ConfigHelperRedis._conn = section.GetSection("Connection").Value;

            //实例化名称
            ConfigHelperRedis._name = section.GetSection("InstanceName").Value;
            //默认数据库
            ConfigHelperRedis._db = int.Parse(section.GetSection("DefaultDB").Value ?? "0");
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseLog();

            app.UseIpRateLimiting();//添加限流中间件

            app.UseRouting();

            app.UseStaticFiles();//文件

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //其他代码
        public void ConfigureContainer(ContainerBuilder builder)
        {

            #region 拦截器注入
            builder.RegisterType<LogInterceptor>();
            builder.RegisterType<RedisCacheInterceptor>();
            builder.RegisterType<TransactionInterceptor>();
            #endregion

            //加载程序集
            var Service = Assembly.Load("Education.Service");
            var Service1 = Assembly.Load("Education.Repository");

            //根据名称约定（服务层的接口和实现均以Service结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(Service, Service1)
                .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()//AsImplementedInterfaces()  是以接口方式进行注入,注入这些类的所有的公共接口作为服务（除了释放资源）
                .PropertiesAutowired()
                .InstancePerLifetimeScope()    //线程独立
                .EnableInterfaceInterceptors()//开启拦截器
                .InterceptedBy(typeof(LogInterceptor), typeof(RedisCacheInterceptor), typeof(TransactionInterceptor));

            
        }
    }
}
