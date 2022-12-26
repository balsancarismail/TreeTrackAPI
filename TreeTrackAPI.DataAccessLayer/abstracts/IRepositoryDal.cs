﻿using System.Linq.Expressions;
using TreeTrackAPI.Domain.abstracts;
using TreeTrackAPI.Domain.enums;

namespace TicketSystem.Core.Abstract.Dal
{
    public interface IRepositoryDal<TEntity> where TEntity : class, BaseEntity, new()
    {
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> selector, OrderType orderByType = OrderType.DESC);
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> selector, OrderType orderByType = OrderType.DESC);
        Task<TEntity?> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, bool asNoTracking = false);
    }
}