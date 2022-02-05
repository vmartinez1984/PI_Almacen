using System.Collections.Generic;
using IntegrationProject.Mvc2.Models;
using IntegrationProject.Mvc2.Entities;
using AutoMapper;
using IntegrationProject.Mvc2.Repositories.Dbs;
using System;

namespace IntegrationProject.Mvc2.Services
{
    public class CategoryService
    {
        private IMapper _mapper;
        private RepositoryFactoryDb _repositoryFactoryDb;

        //private CategoryDao _categoryDao;

        public CategoryService(IMapper mapper, RepositoryFactoryDb repositoryFactoryDb)
        {
            _mapper = mapper;
            //_categoryDao = categoryDao;
            _repositoryFactoryDb = repositoryFactoryDb;
        }

        public List<CategoryViewModel> Get()
        {
            try
            {
                List<CategoryViewModel> list;
                List<CategoryEntity> entities;

                entities = _repositoryFactoryDb.CategoryDao.Get();
                list = _mapper.Map<List<CategoryViewModel>>(entities);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
