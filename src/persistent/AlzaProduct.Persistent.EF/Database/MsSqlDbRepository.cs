using AlzaProduct.Core.Interfaces.Persistent;
using Microsoft.Extensions.Configuration;

namespace AlzaProduct.Persistent.EF.Database;
internal class MsSqlDbRepository(AppDbContext appDbContext, IConfiguration config) : IRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    private readonly IConfiguration _config = config;
}
