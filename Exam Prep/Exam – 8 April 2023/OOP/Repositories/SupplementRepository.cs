﻿using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplements;

        public SupplementRepository()
        {
            this.supplements = new List<ISupplement>();
        }
        public IReadOnlyCollection<ISupplement> Models()=> supplements.AsReadOnly();

        public void AddNew(ISupplement model) => supplements.Add(model);

        public bool RemoveByName(string typeName)
            => supplements.Remove(supplements.FirstOrDefault(s => s.GetType().Name == typeName));
        public ISupplement FindByStandard(int interfaceStandard)
            => supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);


    }
}
