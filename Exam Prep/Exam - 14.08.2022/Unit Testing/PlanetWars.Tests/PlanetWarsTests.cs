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
            [Test]
            public void AddWeapon_WeaponIsAddedToPlanetCollectionOfWeapons()
            {
                var planet = new Planet("Venus", 120);
                var weapon = new Weapon("Nuclear", 100, 3);

                planet.AddWeapon(weapon);

                Assert.That(planet.Weapons.Count, Is.EqualTo(1));
            }

            [Test]
            public void AddWeapon_AlreadyAddedWeapon()
            {
                var planet = new Planet("Venus", 120);
                var weapon = new Weapon("Nuclear", 20, 12);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(
                () => planet.AddWeapon(weapon),
                $"There is already a {weapon.Name} weapon");
            }

            [Test]
            public void DestructionLevel_DestructionLevelIsReturned()
            {
                var planet = new Planet("Venus", 80);
                var weapon = new Weapon("Nuclear", 30, 3);
                var weaponTwo = new Weapon("SpaceMissiles", 20, 2);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weaponTwo);

                Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(5));
            }

            [Test]
            public void Profit_BudgetIncreasesWithGivenAmount()
            {
                var planet = new Planet("Venus", 80);
                planet.Profit(33);

                Assert.That(planet.Budget, Is.EqualTo(113));
            }
        }
    }
}
