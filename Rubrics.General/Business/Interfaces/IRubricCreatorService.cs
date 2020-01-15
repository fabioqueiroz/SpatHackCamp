using Rubrics.Data;
using Rubrics.General.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rubrics.General.Business.Interfaces
{
    public interface IRubricCreatorService
    {
        void CreateRubric(List<CategoryModel> categories, List<DescriptionModel> descriptions);
        Category GetCategory(Category category);
    }
}
