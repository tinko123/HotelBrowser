using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBrowser.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly HotelBrowserDbContext data;
        public Repository(HotelBrowserDbContext _data)
        {
            data = _data;
        }
        private DbSet<T> DbSet<T>() where T : class
        {
            return data.Set<T>();
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }
    }
}
