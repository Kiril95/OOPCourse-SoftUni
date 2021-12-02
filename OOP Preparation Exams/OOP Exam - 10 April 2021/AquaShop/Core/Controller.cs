using System;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private List<IAquarium> aquariums = new List<IAquarium>();
        private DecorationRepository decorations = new DecorationRepository();

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decor;

            if (decorationType == nameof(Ornament))
            {
                decor = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decor = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decor);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var targetDecor = decorations.FindByType(decorationType);
            var targetAquarium = aquariums.Find(x => x.Name == aquariumName);

            if (targetDecor is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            targetAquarium?.AddDecoration(targetDecor);
            decorations.Remove(targetDecor);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var targetAquarium = aquariums.Find(x => x.Name == aquariumName);
            IFish fish;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (targetAquarium is FreshwaterAquarium && fishType == nameof(FreshwaterFish))
            {
                //POSSIBLE ERROR
                targetAquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            if (targetAquarium is SaltwaterAquarium && fishType == nameof(SaltwaterFish))
            {
                targetAquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else
            {
                return (OutputMessages.UnsuitableWater);
            }
        }

        public string FeedFish(string aquariumName)
        {
            var targetAquarium = aquariums.Find(x => x.Name == aquariumName);
            targetAquarium?.Feed();
            
            return string.Format(OutputMessages.FishFed, targetAquarium?.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            var targetAquarium = aquariums.Find(x => x.Name == aquariumName);
            decimal decorPrice = targetAquarium.Decorations.Sum(x => x.Price);
            decimal fishesPrice = targetAquarium.Fish.Sum(x => x.Price);
            decimal total = decorPrice + fishesPrice;

            return string.Format(OutputMessages.AquariumValue, aquariumName, total);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}