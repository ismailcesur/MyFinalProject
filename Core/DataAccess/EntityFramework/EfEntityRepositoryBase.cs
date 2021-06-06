using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity> 
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()  
    {
        public void Add(TEntity entity)
        {
            #region Youtube dersinden
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
            #endregion

            #region Udemy dersinden
            //using (NortwindContext context = new NortwindContext())
            //{
            //    context.Products.Add(entity);
            //    context.SaveChanges();
            //}
            #endregion


        }

        public void Delete(TEntity entity)
        {
            #region Youtube dersinden
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
            #endregion

            #region Udemy dersi
            //using (NortwindContext context = new NortwindContext())
            //{
            //    context.Products.Remove(context.Products.SingleOrDefault(p => p.ProductId == entity.ProductId));
            //    context.SaveChanges();
            //}
            #endregion



        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }

            #region Udemy dersi
            //using (NortwindContext context = new NortwindContext())
            //{
            //    return context.Products.ToList();
            //}

            #endregion


        }

        //public TEntity GetById(int id)
        //{
        //    using (TContext context = new TContext())
        //    {
        //        return context.Products.SingleOrDefault(p => p.ProductId == id);
        //    }
        //}

        public void Update(TEntity entity)
        {

            #region Youtube dersi
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }

            #endregion

            #region Udemy dersi
            //using (NortwindContext context = new NortwindContext())
            //{
            //    var productToUpdate = context.Products.SingleOrDefault(p => p.ProductId == entity.ProductId);
            //    productToUpdate.ProductName = entity.ProductName;
            //    productToUpdate.UnitPrice = entity.UnitPrice;
            //    productToUpdate.UnitsInStock = entity.UnitsInStock;
            //    productToUpdate.CategoryId = entity.CategoryId;
            //    context.SaveChanges();
            //}
            #endregion



        }

    }
}
