using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            public void Constructor_Should_SetNameCorrectly()
            {
                var planet = new Planet("Venus", 120);
                var expectedName = "Venus";

                Assert.That(planet.Name, Is.EqualTo(expectedName));
            }
            [Test]
            public void Constructor_ThrowsException_InvalidPlanetName()
            {
                Assert.Throws<ArgumentException>(
                () => new Planet(null, 120),
                $"Invalid planet name.");
            }

            [Test]
            public void Constructor_ThrowsException_InvalidBudget()
            {
                Assert.Throws<ArgumentException>(
                () => new Planet("Venus", -1),
                $"Budget cannot drop below Zero!");
            }
            [Test]
            public void Constructor_Correctly_CreatesCollectionOfWeapons()
            {
                var planet = new Planet("Venus", 120);

                Assert.That(planet.Weapons.Count, Is.EqualTo(0));
            }
            [Test]
            public void Constructor_Weapon_Correctly_CreatesNewWeapon()
            {
                var weapon = new Weapon("Nuclear", 120, 9);

                Assert.That(weapon.DestructionLevel, Is.EqualTo(9));
                Assert.That(weapon.Price, Is.EqualTo(120));
                Assert.That(weapon.Name, Is.EqualTo("Nuclear"));
            }
        }
    }
}
