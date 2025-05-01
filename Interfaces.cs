using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // The IDamageable interface defines the contract for any class that can take damage
    public interface IDamageable
    {
        int Health { get; set; }
        void TakeDamage(int damage);
    }

    // The ICollectible interface defines the contract for any class that can be collected
    public interface ICollectible
    {
        string Name { get; }
        void PickUp(Player player);
    }

    // The IUsable interface defines the contract for any class that can be used
    public interface IUsable
    {
        void Use(Player player);
    }
}
