using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

public abstract class BaseDAL<TEntity> where TEntity : BaseEntity
{
    private ModelContext _db;
    protected virtual ModelContext db
    {
        get
        {
            return _db ?? (_db = new ModelContext());
        }
    }

    public virtual IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>>[] predicates)
    {
        IEnumerable<TEntity> entities = null;

        var queryable = db.Set<TEntity>().AsQueryable();

        foreach (var predicate in predicates)
            queryable = queryable.Where(predicate);

        return queryable.ToList();
    }
	
    public virtual IEnumerable<TEntity> SelectOrderedPaged<TEntity, TKey>(List<Expression<Func<TEntity, bool>>> predicates, Expression<Func<TEntity, TKey>>[] keySelectors, bool asc) where TEntity : class
    {
        IQueryable<TEntity> queryable = db.Set<TEntity>().AsQueryable();
        IEnumerable<TEntity> entities = null;

        if (predicates != null)
            foreach (var predicate in predicates)
                queryable = queryable.Where(predicate);

        if (keySelectors != null)
        {
            if (asc)
                foreach (var keySelector in keySelectors)
                    queryable = queryable.OrderBy(keySelector);
            else
                foreach (var keySelector in keySelectors)
                    queryable = queryable.OrderByDescending(keySelector);
        }

        entities = queryable.ToList();

        return entities;
    }

    public virtual TEntity SelectWithId(object key)
    {
        TEntity entity = null;
        entity = db.Set<TEntity>().Find(key);
        return entity;
    }

    public virtual TEntity Insert(TEntity entity)
    {
        try
        {
            db.Set<TEntity>().Add(entity);
            var errors = db.GetValidationErrors();
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            return null;
        }
        return entity;
    }

    public virtual TEntity Update(object key, TEntity entity)
    {
        var tmp = db.Set<TEntity>().Find(key);

        if (tmp == null)
            return null;

        db.Entry(tmp).State = EntityState.Modified;
        db.Entry(tmp).CurrentValues.SetValues(entity);

        db.SaveChanges();

        return entity;
    }

    public virtual bool Delete(object key)
    {
        var b = false;
        try
        {
            var item = db.Set<TEntity>().Find(key);
            db.Entry(item).State = EntityState.Deleted;
            db.SaveChanges();
            b = true;
        }
        catch
        {
            b = false;
        }
        finally
        {
            db.Dispose();
        }

        return b;

    }
}
