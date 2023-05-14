using Autofac;
using Autofac.Extras.DynamicProxy;
using GlarisEngine.UserLinkTracker.Infrastructure.Logging;
using GlarisEngine.UserLinkTracker.RepositoryInterface;
using Insight.Database;
using System.Data.Common;
using System.Data.SqlClient;

namespace GlarisEngine.UserLinkTracker.WebAppMVC.IOC
{
    public class RepositoryIOCModule : Module
    {
        private readonly DbConnection _sqlConnection;
        private readonly string _lifeTime;

        public RepositoryIOCModule(string sqlConnectionString)
        {
            this._sqlConnection = new SqlConnection(sqlConnectionString);
        }

        protected override void Load(ContainerBuilder builder)
        {
            SqlInsightDbProvider.RegisterProvider();



            builder
            .Register(b => this._sqlConnection.AsParallel<IAuthenticationRepository>())
            .InstancePerLifetimeScope()
            .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LogInterceptor));         


            base.Load(builder);
        }
    }
}
