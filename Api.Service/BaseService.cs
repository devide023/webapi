﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Batch;
using Api.Model;
using Api.Model.Parm;
using Api.Dao;
using Webdiyer.WebControls.Mvc;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace Api.Service
{
    public class BaseService<T> : IBase<T> where T:class
    {
        public T Add(T entry)
        {
            try
            {
                using (Db db = new Db())
                {
                    db.Entry<T>(entry).State = EntityState.Added;
                    db.SaveChanges();
                    return entry;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Find(int id)
        {
            try
            {
                using (Db db = new Db())
                {
                    return db.Set<T>().Find(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> Get_List()
        {
            try
            {
                using (Db db = new Db())
                {
                    var list = db.Set<T>() as IQueryable<T>;
                    return list.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual IEnumerable<T> Get_List<P, TKey>(P parm, Expression<Func<T, TKey>> orderByLambda) where P : BaseParm
        {
            try
            {
                using (Db db = new Db())
                {
                    var list = db.Set<T>() as IQueryable<T>;
                    return list.OrderByDescending(orderByLambda).ToPagedList(parm.pageindex, parm.pagesize);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public virtual IEnumerable<T> Get_List<P, TKey>(P parm, Expression<Func<T, TKey>> orderByLambda,out int record_count) where P : BaseParm
        {
            try
            {
                using (Db db = new Db())
                {
                    var list = db.Set<T>() as IQueryable<T>;
                    record_count = list.Count();
                    return list.OrderByDescending(orderByLambda).ToPagedList(parm.pageindex, parm.pagesize);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Remove(List<int> ids)
        {
            try
            {
                using (Db db = new Db())
                {
                    foreach (var item in ids)
                    {
                        T entry = db.Set<T>().Find(item);
                        db.Entry<T>(entry).State = EntityState.Deleted;
                    }
                    return db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Remove(int id)
        {
            try
            {
                using (Db db = new Db())
                {
                    var entry = db.Set<T>().Find(id);
                    db.Entry<T>(entry).State = EntityState.Deleted;
                    db.SaveChanges();
                    return entry;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Update(T entry)
        {
            try
            {
                using (Db db = new Db())
                {
                    db.Entry<T>(entry).State = EntityState.Modified;
                    db.SaveChanges();
                    return entry;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
