using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Uow;
using Microsoft.EntityFrameworkCore;
using Base.District;
using Base.EntityFrameworkCore;

namespace Base.SendData
{
    public class BaseDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly BaseDbContext _baseDbContext;
        public BaseDataSeedContributor(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            //await InsertDistrict();
        }
        [UnitOfWork]
        public async Task InsertDistrict()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "../../database/District.sql");
            var listSql = File.ReadAllText(path).Split("GO");
            foreach (var sqls in listSql)
            {     
                await _baseDbContext.Database.ExecuteSqlCommandAsync(sqls);
            }
        }
    }
}
