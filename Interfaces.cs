using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public interface IDamageable
    {
        int Health { get; set; }
        void TakeDamage(int damage);
    }

    public interface ICollectible
    {
        string Name { get; }
        void PickUp(Player player);
    }

    public interface IUsable
    {
        void Use(Player player);
    }
}
