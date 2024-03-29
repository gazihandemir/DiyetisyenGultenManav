﻿using DiyetisyenGultenManav.Common;
using DiyetisyenGultenManav.Core.DataAccess;
using DiyetisyenGultenManav.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.DataAccessLayer.EntityFramework
{
    public class Repository<T> : RepositoryBase, IDataAccess<T> where T : class
    {
        // private DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
        //  private DataAccessLayer.DatabaseContext db;
        private DbSet<T> _objectSet;
        public Repository()
        {
            //    db = RepositoryBase.CreateContext();
            _objectSet = context.Set<T>();
        }
        public List<T> List()
        {
            return _objectSet.ToList();
        }
        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }
        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }
        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;
                DateTime now = DateTime.Now;
                o.CreatedOn = now;
                o.ModifiedOn = now;
                o.ModifiedUsername = App.Common.GetCurrentUsername(); // TODO : işlem yapan kullanıcı adı yazılmalı.

            }
            return Save();
        }
        public int Update(T obj)
        {
            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;

                o.ModifiedOn = DateTime.Now;

                //  o.ModifiedUsername = "system"; // TODO : işlem yapan kullanıcı adı yazılmalı.
                o.ModifiedUsername = App.Common.GetCurrentUsername();


            }
            return Save();
        }
        public int UpdateGörüntülenme(T obj)
        {
            if (obj is BlogYazısı)
            {
                BlogYazısı blog = obj as BlogYazısı;
                

            }
            return Save();
        }
        public int Delete(T obj)
        {
            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;

                o.ModifiedOn = DateTime.Now;
                o.ModifiedUsername = "system"; // TODO : işlem yapan kullanıcı adı yazılmalı.

            }
            _objectSet.Remove(obj);
            return Save();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
