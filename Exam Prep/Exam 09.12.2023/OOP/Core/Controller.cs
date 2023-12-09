using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Models.DiverModels;
using NauticalCatchChallenge.Models.FishModels;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> divers;
        private IRepository<IFish> fishs;

        public Controller()
        {
            divers = new DiverRepository();
            fishs = new FishRepository();
        }
        public string DiveIntoCompetition(string diverType, string diverName)
        {
            IDiver diver;

            if (divers.Models.Any(n => n.Name == diverName))
            {
                return $"{diverName} is already a participant -> {nameof(DiverRepository)}.";
            }
            else if (diverType == nameof(ScubaDiver))
            {
                diver = new ScubaDiver(diverName);
            }
            else if (diverType == nameof(FreeDiver))
            {
                diver = new FreeDiver(diverName);
            }
            else
            {
                return $"{diverType} is not allowed in our competition.";
            }
            divers.AddModel(diver);

            return $"{diverName} is successfully registered for the competition -> {nameof(DiverRepository)}.";
        }
        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            IFish fish;

            if (fishs.Models.Any(n => n.Name == fishName))
            {
                return $"{fishName} is already a participant -> {nameof(FishRepository)}.";
            }
            else if (fishType == nameof(ReefFish))
            {
                fish = new ReefFish(fishName, points);
            }
            else if (fishType == nameof(DeepSeaFish))
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == nameof(PredatoryFish))
            {
                fish = new PredatoryFish(fishName, points);
            }
            else
            {
                return $"{fishType} is forbidden for chasing in our competition.";
            }
            fishs.AddModel(fish);

            return $"{fishName} is allowed for chasing.";            
        }
        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (!divers.Models.Any(n => n.Name == diverName))
            {
                return $"{nameof(DiverRepository)} has no {diverName} registered for the competition.";
            }
            else if (!fishs.Models.Any(n =>n.Name == fishName))
            {
                return $"{fishName} is not allowed to be caught in this competition.";
            }

            var diverCheck = divers.Models.FirstOrDefault(n => n.Name == diverName);

            if (diverCheck.HasHealthIssues == true)
            {
                return $"{diverName} will not be allowed to dive, due to health issues.";
            }

            var cuurFishCatch = fishs.Models.FirstOrDefault(n => n.Name == fishName);

            if (diverCheck.OxygenLevel < cuurFishCatch.TimeToCatch)
            {
                diverCheck.Miss(cuurFishCatch.TimeToCatch);

                return $"{diverName} missed a good {fishName}.";
            }
            else if (diverCheck.OxygenLevel == cuurFishCatch.TimeToCatch)
            {
                if (isLucky)
                {
                    diverCheck.Hit(cuurFishCatch);
                    diverCheck.UpdateHealthStatus();

                    return $"{diverName} hits a {cuurFishCatch.Points}pt. {fishName}.";
                }
                else
                {
                    diverCheck.Miss(cuurFishCatch.TimeToCatch);
                    return $"{diverName} missed a good {fishName}.";
                }
            }
            else if (diverCheck.OxygenLevel > cuurFishCatch.TimeToCatch)
            {
                diverCheck.Hit(cuurFishCatch);                
            }

            if (diverCheck.OxygenLevel <= 0)
            {
                diverCheck.UpdateHealthStatus();
            }

            return $"{diverName} hits a {cuurFishCatch.Points}pt. {fishName}.";
        }

        public string HealthRecovery()
        {
            var diversRecovery = divers.Models.Where(h => h.HasHealthIssues == true);

            int countRecovery = 0;

            foreach (var diver in diversRecovery)
            {
                countRecovery++;
                diver.RenewOxy();
                diver.UpdateHealthStatus();
            }

            return $"Divers recovered: {countRecovery}";
        }


        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();

            var currDiver = divers.GetModel(diverName);

            sb.AppendLine(currDiver.ToString());
            sb.AppendLine($"Catch Report:");

            foreach (var fish in currDiver.Catch)
            {
                var currFish = fishs.GetModel(fish);
                sb.AppendLine(currFish.ToString());
            }

            return sb.ToString().TrimEnd();  
        }
        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();

            var orderRepo = divers.Models
                .OrderByDescending(p => p.CompetitionPoints)
                .ThenByDescending(c => c.Catch).ThenBy(n => n.Name).Where(h => h.HasHealthIssues == false);

            foreach (var diver in orderRepo)
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
