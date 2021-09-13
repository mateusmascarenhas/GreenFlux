﻿using API.Domain.Exceptions;
using API.Domain.Models;
using API.Domain.Repository;
using API.Infrastructure.Models;
using AutoMapper;
using GreenFlux.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.Repository
{
    public class ChargeStationRepository : IChargeStationRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext Context;

        public ChargeStationRepository(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public async Task<ChargeStationModel> GetByIdAsync(Guid id)
        {
            var data = await Context.ChargeStations
                .AsNoTracking()
                .Include(a => a.Connectors)
                .SingleOrDefaultAsync(a => a.Id == id);

            return _mapper.Map<ChargeStationModel>(data);
        }

        public async Task<List<ChargeStationModel>> GetAllChargeStationsByGroupIdAsync(Guid groupId)
        {
            var data = await Context.ChargeStations
                .AsNoTracking()
                .Where(a => a.GroupId == groupId)
                .Include(a => a.Connectors)
                .ToListAsync();

            return _mapper.Map<List<ChargeStationModel>>(data);
        }

        public async Task<ChargeStationModel> Create(ChargeStationModel model)
        {
            var modelDb = _mapper.Map<ChargeStationModel, ChargeStation>(model);
            Context.ChargeStations.Add(modelDb);
            await Context.SaveChangesAsync();
            return model;
        }

        public async Task<ChargeStationModel> Update(ChargeStationModel model)
        {
            var modelDb = _mapper.Map<ChargeStationModel, ChargeStation>(model);
            Context.Update(modelDb);
            await Context.SaveChangesAsync();
            return model;
        }

        public void Remove(Guid chargeStationId)
        {
            var chargeStation = Context.ChargeStations.SingleOrDefault(x => x.Id == chargeStationId);
            if (chargeStation == null) throw new BusinessException("Not Found");
            Context.Remove(chargeStation);
            Context.SaveChanges();
        }
    }
}