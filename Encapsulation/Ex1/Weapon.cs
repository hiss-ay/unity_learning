using System;

namespace unity_learning.Encapsulation.Ex1
{
    public class Weapon : IWeaponStats
    {
        public int Damage { get; }
        public int Bullets { get; private set; }

        public Weapon(int damage, int bullets)
        {
            if (damage <= 0 || bullets <= 0)
                throw new ArgumentOutOfRangeException();
            
            Damage = damage;
            Bullets = bullets;
        }

        public void ShotFire(IUnitReceiveDamage unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit)); 
            
            if (Bullets <= 0)
                return;
            
            unit.ReceiveDamage(Damage);
            Bullets--;
        }
    }
    
    public interface IWeaponStats
    {
        int Damage { get; }
        int Bullets { get; }
    }
}