using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookStore.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        // Đây là một đối tượng của lớp DbSet<T>, đại diện cho một bảng trong cơ sở dữ liệu.
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            // _db.Categories == dbSet
            _db.Products.Include(u => u.Category).Include(u => u.CategoryId);
        }
        //  Phương thức này thêm một đối tượng mới vào cơ sở dữ liệu.
        void IRepository<T>.Add(T entity)
        {
            dbSet.Add(entity);
        }

        // Phương thức này trả về một đối tượng từ cơ sở dữ liệu dựa trên biểu thức lọc được cung cấp.
        T IRepository<T>.Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;

            }
            else
            {
                query = dbSet.AsNoTracking();
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();

        }

        // Phương thức này trả về tất cả các đối tượng từ cơ sở dữ liệu.
        // Category, CategoryId
        IEnumerable<T> IRepository<T>.GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        // Phương thức này xóa một đối tượng khỏi cơ sở dữ liệu.
        void IRepository<T>.Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        // Phương thức này xóa một loạt các đối tượng khỏi cơ sở dữ liệu.
        void IRepository<T>.RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}   
