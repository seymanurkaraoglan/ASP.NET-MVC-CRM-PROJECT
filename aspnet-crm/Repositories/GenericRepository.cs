﻿using aspnet_crm.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_crm.Repositories
{
    public class GenericRepository<T> where T: class,new()
    {
        Context c = new Context();
        public List<T> TList()
        {
            return c.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }
        public void TDelete(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }
        public void TUpdate(T p)
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }
        public T TGet(int id)
        {
            return c.Set<T>().Find(id);
        }
        public List<T> TList(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }
    }
}
