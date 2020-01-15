using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.Data.Access.RepositoryInterfaces
{
    public interface IRubricCreatorRepository
    {
        void AddCategory(Category category);
        Category FindCategory(Category category);
        void AddDescription(Description description);
        Description FindDescription(Description description);

        void AddCategoryDescription(CategoryDescription categoryDescription);
    }
}
