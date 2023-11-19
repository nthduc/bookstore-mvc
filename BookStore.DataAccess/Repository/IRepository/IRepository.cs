using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository.IRepository
{
    // Interface giúp giảm bớt sự lặp lại của mã nguồn và tăng tính tái sử dụng.
    internal interface IRepository<T> where T : class
    {
        // T -> Category
        // Trả về một danh sách chứa tất cả các đối tượng của lớp T từ cơ sở dữ liệu.
        IEnumerable<T> GetAll();

        // Trả về một đối tượng của lớp T dựa trên biểu thức lọc được cung cấp.
        // Biểu thức này sẽ được sử dụng để lọc các đối tượng trong cơ sở dữ liệu.
        T Get(Expression<Func<T, bool>> filter);

        // Thêm một đối tượng mới của lớp T vào cơ sở dữ liệu.
        void Add(T entity);

        // Xóa một đối tượng của lớp T khỏi cơ sở dữ liệu.
        void Remove(T entity);

        //  Xóa một loạt các đối tượng của lớp T khỏi cơ sở dữ liệu.
        void RemoveRange(IEnumerable<T> entities);
    }
}
