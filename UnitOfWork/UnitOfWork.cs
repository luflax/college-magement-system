using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using College_Management_System.Models;
using College_Management_System.Repositories;

namespace College_Management_System.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LDBEntities context;
        public UnitOfWork(LDBEntities context)
        {
            this.context = context;
        }

        void IDisposable.Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(context);
        }

        int IUnitOfWork.SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}