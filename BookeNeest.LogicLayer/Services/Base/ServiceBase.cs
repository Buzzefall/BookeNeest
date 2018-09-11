using System;
using System.Collections.Generic;
using AutoMapper;
using BookeNeest.Domain.Contracts;
using BookeNeest.Domain.Contracts.Services;
using BookeNeest.Domain.DTOs;
using BookeNeest.Domain.Models;
using Unity.Attributes;

namespace BookeNeest.LogicLayer.Services
{
    public abstract class ServiceBase<TEntityDto> : IServiceBase<TEntityDto> where TEntityDto : class
    {
        protected readonly IUnitOfWork unitOfWork;

        //[InjectionConstructor]
        protected virtual ServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        

        
    }
}
