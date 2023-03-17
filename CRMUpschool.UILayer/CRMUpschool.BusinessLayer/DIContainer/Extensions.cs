// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using AutoMapper;

using CRMUpschool.BusinessLayer.Abstract;
using CRMUpschool.BusinessLayer.Concrete;
using CRMUpschool.BusinessLayer.ValidationRules.ContactValidation;
using CRMUpschool.DataAccessLayer.Abstract;
using CRMUpschool.DataAccessLayer.EntityFramework;
using CRMUpschool.DTOLayer.DTOs.ContactDTOs;
using CRMUpschool.EntityLayer.Concrete;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace CRMUpschool.BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryServices, CategoryManager>();//Kategori servisi gördüün yerde manager çagır
            services.AddScoped<ICategoryDal, EFCategoryDal>();

            services.AddScoped<IEmployeeService, EmployeeManager>();//Kategori servisi gördüün yerde manager çagır
            services.AddScoped<IEmployeeDal, EFEmployeeDal>();

            services.AddScoped<IEmployeeTaskService, EmployeeTaskManager>();
            services.AddScoped<IEmployeeTaskDal, EFEmployeeTaskDal>();

            services.AddScoped<IEmployeeTaskDetailService, EmployeeTaskDetailManager>();
            services.AddScoped<IEmployeeTaskDetailDal, EFEmployeeTaskDetailDal>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EFMessageDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();

            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICustomerDal, EFCustomerDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContactDal>();
        }
        public static void CustomizeValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<ContactAddDTO>, ContactAddValidator>();
            services.AddTransient<IValidator<ContactUpdateDTO>, ContactUpdateValidator>();
        }
    }
}
