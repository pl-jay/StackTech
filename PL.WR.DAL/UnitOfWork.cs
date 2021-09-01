using Microsoft.EntityFrameworkCore;
using PL.WR.DAL.IRepositories;
using PL.WR.DAL.Models;
using PL.WR.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.WR.DAL
{
    public class UnitOfWork<TContext> : IDisposable where TContext : DbContext, new()
    {
        private bool disposed = false;
        private DbContext ctx;

        public UnitOfWork()
        {
            ctx = new TContext();
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private IGenericRepository<WeatherRecord, DbContext> weather_record;
        public IGenericRepository<WeatherRecord, DbContext> WeatherRecord
        {
            get
            {
                if (this.weather_record == null)
                {
                    this.weather_record = new GenericRepository<WeatherRecord, DbContext>(ctx);
                }
                return WeatherRecord;
            }
        }


    }
}
