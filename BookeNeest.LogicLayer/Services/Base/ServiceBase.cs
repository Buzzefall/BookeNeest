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
    public abstract class ServiceBase
    {
        protected readonly IUnitOfWork unitOfWork;

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

    }
}
