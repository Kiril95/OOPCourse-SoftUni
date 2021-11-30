using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            string outputMessage = string.Empty;

            if (!racerOne.IsAvailable())
            {
                outputMessage = string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                outputMessage = string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                outputMessage = OutputMessages.RaceCannotBeCompleted;
            }

            if(racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                racerOne.Race();
                racerTwo.Race();
                double racerOneChance = 0;
                double racerTwoChance = 0;

                if (racerOne.RacingBehavior == "strict")
                {
                    racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2;
                }
                else if (racerOne.RacingBehavior == "aggressive")
                {
                    racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1;
                }

                if (racerTwo.RacingBehavior == "strict")
                {
                    racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2;
                }
                else if (racerTwo.RacingBehavior == "aggressive")
                {
                    racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1;
                }

                if (racerOneChance > racerTwoChance)
                {
                    outputMessage = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
                if (racerTwoChance > racerOneChance)
                {
                    outputMessage = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
                }
            }

            return outputMessage;
        }
    }
}