using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.Services
{
    public interface IBaseService<TEntity> where TEntity : Base
    {
        IEnumerable<TEntity> GetList(int pageindex, int takerecord);
        IEnumerable<TEntity> GetListActive(int pageindex, int takerecord);
        IEnumerable<TEntity> GetList();
        IEnumerable<TEntity> GetListActive();
        int TotalRecord();
        int TotalRecordActive();
        TEntity GetEntityById(Guid id);

        bool Add(TEntity model);

        bool Update(TEntity model);
        bool Update(List<TEntity> dtoList);

        bool Delete(Guid id);

        bool Disable(Guid id);

        bool Active(Guid id);

        int GetPosition();

        bool IsExitsPosition(int position);
    }
}
