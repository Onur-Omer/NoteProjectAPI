using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserNoteDal : IEntityRepository<UserNote>
    {
    }
}
