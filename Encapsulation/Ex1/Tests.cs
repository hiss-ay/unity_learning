using System;
using NUnit.Framework;

namespace unity_learning.Encapsulation.Ex1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ReceiveDamage_DecreasesHealth()
        {
            int initialHealth = 30;
            int damage = 10;
            
            Player player = new Player(initialHealth, new Weapon(10, 100));
            Bot bot = new Bot(100, new Weapon(damage, 100));

            bot.OnSeePlayer(player);
            
            Assert.AreEqual(initialHealth - damage, player.Health);
        }

        [Test]
        public void ReceiveDamage_Dies()
        {
            Player player = new Player(30, new Weapon(10, 100));
            Bot bot = new Bot(100, new Weapon(50, 100));

            bot.OnSeePlayer(player);

            Assert.IsFalse(player.IsAlive);
        }

        [Test]
        public void OnSeePlayer_PlayerNotNull()
        {
            Player player = new Player(100, new Weapon(10, 100));
            Bot bot = new Bot(100, new Weapon(10, 100));

            bot.OnSeePlayer(player);

            Assert.AreEqual(99, bot.WeaponStats.Bullets);
        }

        [Test]
        public void OnSeePlayer_PlayerNull()
        {
            Bot bot = new Bot(100, new Weapon(10, 100));
            bot.OnSeePlayer(null);
        }
        
        [Test]
        public void CanICreateInvalidUnit()
        {
            Bot bot = new Bot(-100, new Weapon(10, 100));
        }
        
        [Test]
        public void CanICreateInvalidWeapon()
        {
            Weapon weapon = new Weapon(-10, -10);
        }
    }
}