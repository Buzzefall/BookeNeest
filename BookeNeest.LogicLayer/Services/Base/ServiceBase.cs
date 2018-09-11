using System;
using System.Collections.Generic;
using System.ComponentModel;
using AutoMapper;
using BookeNeest.Domain.Contracts;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;
using Unity.Attributes;

namespace BookeNeest.LogicLayer.Services
{
    public abstract class ServiceBase<TEntityDto> //: IServiceBase<TEntityDto>
    {
        protected readonly IUnitOfWork unitOfWork;

        //[InjectionConstructor]
        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //public TEntityDto FindById(Guid entityId);
        //public IList<TEntityDto> FindByName(string entityName);

        //public void AddNew(TEntityDto entityDto);


    }
}
