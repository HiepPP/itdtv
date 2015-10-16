using System;
using System.Collections.Generic;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.Repositories
{
    public interface IBaseRepository<T> where T : Base
    {
        /// <summary>
        /// Find item by Id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        T FindById(Guid id);

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item">int</param>
        /// <returns></returns>
        bool Update(T item);
        bool Update(List<T> dtoList);

        /// <summary>
        /// Disable by Guid
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        bool DisableById(Guid id);

        /// <summary>
        /// Active by Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ActiveById(Guid id);

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="item">object</param>
        /// <returns></returns>
        bool Add(T item);
        /// <summary>
        /// Delete item by Guid
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns></returns>
        bool DeleteById(Guid id);

        /// <summary>
        /// Total Record
        /// </summary>
        /// <returns></returns>
        int TotalItem();
        int TotalItemActive();

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllActive();

        /// <summary>
        /// Max Position
        /// </summary>
        /// <returns></returns>
        int MaxPosition();

        /// <summary>
        /// Is Exist Position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        bool IsExistPosition(int position);

        /// <summary>
        /// Get All with Pagging
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="totalrecord"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(int pageindex, int totalrecord);
        IEnumerable<T> GetAllActive(int pageindex, int takerecord);
    }
}