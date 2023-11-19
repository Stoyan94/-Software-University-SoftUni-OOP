﻿using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Objects
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWork)
        {
            PartName = partName;
            HoursWorked = hoursWork;
        }

        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString() => 
            $"Part Name: {PartName} Hours Worked: {HoursWorked}";
    }
}
