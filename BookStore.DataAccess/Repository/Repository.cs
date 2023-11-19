using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

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
        }
        //  Phương thức này thêm một đối tượng mới vào cơ sở dữ liệu.
        void IRepository<T>.Add(T entity)
        {
            dbSet.Add(entity);
        }

        // Phương thức này trả về một đối tượng từ cơ sở dữ liệu dựa trên biểu thức lọc được cung cấp.
        T IRepository<T>.Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        // Phương thức này trả về tất cả các đối tượng từ cơ sở dữ liệu.
        IEnumerable<T> IRepository<T>.GetAll()
        {
            IQueryable<T> query = dbSet;
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
