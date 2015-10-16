using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ssc.consulting.switchboard.Models;
using ssc.consulting.switchboard.Repositories;

namespace ssc.consulting.switchboard.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Base
    {
        private readonly IBaseRepository<TEntity> _iRepository = new BaseRepository<TEntity>();

        public IEnumerable<TEntity> GetList(int pageindex, int takerecord)
        {
            return _iRepository.GetAll(pageindex, takerecord);
        }
        public IEnumerable<TEntity> GetListActive(int pageindex, int takerecord)
        {
            return _iRepository.GetAllActive(pageindex, takerecord);
        }

        public IEnumerable<TEntity> GetList()
        {
            return _iRepository.GetAll();
        }

        public IEnumerable<TEntity> GetListActive()
        {
            return _iRepository.GetAllActive();
        }

        public TEntity GetEntityById(Guid id)
        {
            return _iRepository.FindById(id);
        }

        public bool Add(TEntity model)
        {
            return _iRepository.Add(model);
        }

        public bool Update(TEntity model)
        {
            return _iRepository.Update(model);
        }
        public bool Update(List<TEntity> dtoList)
        {
            return _iRepository.Update(dtoList);
        }

        public bool Delete(Guid id)
        {
            return _iRepository.DeleteById(id);
        }

        public bool Disable(Guid id)
        {
            return _iRepository.DisableById(id);
        }

        public bool Active(Guid id)
        {
            return _iRepository.ActiveById(id);
        }

        public int GetPosition()
        {
            return _iRepository.MaxPosition();
        }

        public bool IsExitsPosition(int position)
        {
            return _iRepository.IsExistPosition(position);
        }

        public int TotalRecord()
        {
            return _iRepository.TotalItem();
        }

        public int TotalRecordActive()
        {
            return _iRepository.TotalItemActive();
        }
    }
}