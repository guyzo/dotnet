using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using System.Reflection;
using System.IO;
using NHibernate;
using FluentNHibernate.Conventions.Helpers;

namespace Dotnet.Samples.NHibernate
{
    public static class Helpers
    {
        public static ISessionFactory CreateSessionFactory()
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var sdf = Path.Combine(dir, "res", "Catalog.sdf");
            var cfg = MsSqlCeConfiguration
                .Standard.ConnectionString(raw => raw.Is(string.Format("Data Source = {0}", sdf)))
                .ShowSql()
                .FormatSql();

            return Fluently.Configure()
                .Database(cfg)
                .Mappings(map => map.FluentMappings
                    .AddFromAssemblyOf<Book>()
                    .Conventions.Add(Table.Is(pl => string.Format("{0}s", pl.EntityType.Name))))
                .BuildSessionFactory();
        }
    }
}
