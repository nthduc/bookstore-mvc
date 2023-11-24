using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository
{
    /** 
    Trong lập trình, Unit of Work (UoW) là một mẫu thiết kế (design pattern) giúp quản lý các thao tác với cơ sở dữ liệu1. 
    UoW đảm bảo rằng tất cả các thay đổi được thực hiện trên nhiều đối tượng trong ứng dụng đều được commit vào cơ sở dữ liệu hoặc được rollback2. 
    Nó cung cấp một cách tổ chức và nhất quán để quản lý các thay đổi và giao dịch cơ sở dữ liệu2.
     */
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
      
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
