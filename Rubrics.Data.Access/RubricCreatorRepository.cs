using Rubrics.Data.Access.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.Data.Access
{
    public class RubricCreatorRepository : IRubricCreatorRepository
    {
        private IRubricsRepository _repository;
        public RubricCreatorRepository(IRubricsRepository repository)
        {
            _repository = repository;
        }

        public void AddCategory(Category category)
        {
            _repository.Add<Category>(category);
            _repository.Commit();
        }


        public void AddDescription(Description description)
        {
            _repository.Add<Description>(description);
            _repository.Commit();
        }

        public Category FindCategory(Category category)
        {
            return _repository.GetSingle<Category>(x => x.CatName == category.CatName);
        }

        public Description FindDescription(Description description)
        {
            return _repository.GetSingle<Description>(x => x.Name == description.Name);
        }

        public void AddCategoryDescription(CategoryDescription categoryDescription)
        {
            _repository.Add<CategoryDescription>(categoryDescription);
            _repository.Commit();
        }

    }
}
