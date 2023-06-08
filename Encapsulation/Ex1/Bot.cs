using System;

namespace unity_learning.Encapsulation.Ex1
{
    public class Bot : Unit
    {
        public Bot(int health, Weapon weapon) : base(health, weapon) { }
        
        public void OnSeePlayer(IUnitReceiveDamage unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));
            
            ShotFire(unit);
        }
    }
}