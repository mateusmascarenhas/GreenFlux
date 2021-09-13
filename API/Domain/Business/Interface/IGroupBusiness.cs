﻿using API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Domain.Business.Interface
{
    public interface IGroupBusiness
    {
        Task<List<GroupModel>> GetAll();

        Task<GroupModel> GetById(Guid id);

        Task<GroupModel> Create(GroupModel groupModel);

        Task Remove(Guid groupId);

        Task<GroupModel> Update(GroupModel model);
    }
}