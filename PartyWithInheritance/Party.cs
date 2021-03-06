﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyWithInheritance
{
    class Party
    {
        public const int CostOfFoodPerPerson = 25;

        public int NumberOfPeople { get; set; }

        public bool FancyDecorations { get; set; }

        public virtual decimal Cost
        {
            get
            {
                decimal totalCost = CalculateCostOfDecorations();

                totalCost += CostOfFoodPerPerson * NumberOfPeople;
 
                if (NumberOfPeople > 12)
                {
                    totalCost += 100M;
                }
                return totalCost;
            }
        }

        private decimal CalculateCostOfDecorations()
        {
            decimal costOfDecorations;
            if (FancyDecorations)
            {
                costOfDecorations = (NumberOfPeople * 15.00M) + 50M;
            }
            else
            {
                return costOfDecorations = (NumberOfPeople * 7.50M) + 30M;
            }
            return costOfDecorations;

        }
    }
}
