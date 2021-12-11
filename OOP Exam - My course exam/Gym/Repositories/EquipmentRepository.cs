using System.Collections.Generic;
using System.Linq;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> equipment = new List<IEquipment>();
        public IReadOnlyCollection<IEquipment> Models => this.equipment.AsReadOnly();

        public void Add(IEquipment model)
        {
            this.equipment.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            return this.equipment.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.equipment.FirstOrDefault(x => x.GetType().Name == type);
        }
    }
}