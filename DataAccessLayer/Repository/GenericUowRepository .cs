﻿
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericUowRepository<T> : IGenericUowDal<T> where T : class
    {
        private readonly Context _context;

        public GenericUowRepository(Context context)
        {
            _context = context;
        }
        public void Insert(T t)
        {
            _context.Add(t);
        }

        public void UpDate(T t)
        {
           _context.Update(t);
        }

        public void MultiUpdate(List<T> t)
        {
            _context.UpdateRange(t);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

    }
}
