using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Business.Entities;

namespace ToDoList.Business.DataAccessors
{
    public interface ICategoryDataAccessor
    {
        List<Category> GetCategories();
        Category GetCategoryById(int id);
        void CreateCategory (Category category);
        void EditCategory (Category category);    
        void DeleteCategory (int id);
    }
}
