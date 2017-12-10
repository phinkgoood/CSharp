using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationName.Classes
{
    public interface IDataBase
    {
        bool InsertCategory(Category category);
        bool UpdateCategory(Category category);
        bool RemoveCategoryById(string id);
        Category GetCategoryById(string id);
        Category GetCategoryByName(string name);
        IEnumerable<Category> GetAllCategories();
    }
}
