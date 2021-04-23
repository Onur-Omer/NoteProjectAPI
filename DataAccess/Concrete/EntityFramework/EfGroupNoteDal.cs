using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGroupNoteDal : EfEntityRepositoryBase<GroupNote, DbContextBase>, IGroupNoteDal
    {
    }
}
