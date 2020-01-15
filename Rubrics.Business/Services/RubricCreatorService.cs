using Rubrics.Data;
using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrics.Business.Services
{
    public class RubricCreatorService : IRubricCreatorService
    {
        private IRubricCreatorRepository _rubricCreatorRepository;
        public RubricCreatorService(IRubricCreatorRepository rubricCreatorRepository)
        {
            _rubricCreatorRepository = rubricCreatorRepository;
        }

        public void CreateRubric(List<CategoryModel> categories, List<DescriptionModel> descriptions)
        {
            var allDescriptions = new List<Description>();
            var allCategories = new List<Category>();
            var index = 0;
            var catInDb = new Category();
            var newCategoryDescription = new CategoryDescription();

            foreach (var cat in categories)
            {
                var bindedCategory = new Category
                {
                    CatName = cat.Name
                };

                // Create a new category in the db
                _rubricCreatorRepository.AddCategory(bindedCategory);

                allCategories.Add(bindedCategory);

                // Retrieve this category back
                catInDb = GetCategory(bindedCategory);

            }

            foreach (var desc in descriptions)
            {
                var newDescription = new Description();
                newDescription.Name = desc.Description;

                // Create a new description
                _rubricCreatorRepository.AddDescription(newDescription);

                // Find the description in the db
                var descriptionInDb = _rubricCreatorRepository.FindDescription(newDescription);

                allDescriptions.Add(descriptionInDb);

                index++;

                if (index == 4)
                {
                    var cat = allCategories.First();

                    foreach (var item in allDescriptions)
                    {
                        newCategoryDescription.CategoryId = cat.Id;
                        newCategoryDescription.DescriptionId = item.Id;

                        // Create a new CategoryDescription in the db
                        _rubricCreatorRepository.AddCategoryDescription(newCategoryDescription);

                        newCategoryDescription = new CategoryDescription();

                    }
                    index = 0;
                    allCategories.RemoveAt(0);
                    allDescriptions = new List<Description>();
                }
            }
        }

        public Category GetCategory(Category category)
        {
            return _rubricCreatorRepository.FindCategory(category);
        }
    }
}
