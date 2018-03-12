using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class AcceptanceTestsForItem
    {
        private readonly Type _itemType = typeof(Item);

        [Test]
        public void Item_ShouldBeAClass()
        {
            _itemType.IsClass.Should().BeTrue();
        }

        [Test]
        public void Item_ShouldHaveExactThreeProperties()
        {
            _itemType.GetProperties().Length.Should().Be(3);
        }

        [Test]
        [TestCase("Name")]
        [TestCase("SellIn")]
        [TestCase("Quality")]
        public void Item_ShouldContainProperty(string name)
        {
            _itemType.GetProperties().Any(property => property.Name == name).Should().BeTrue();
        }

        [Test]
        [TestCase("Name", typeof(string))]
        [TestCase("SellIn", typeof(int))]
        [TestCase("Quality", typeof(int))]
        public void Item_PropertyShouldHaveCorrectType(string name, Type expectedType)
        {
            _itemType.GetProperties().First(property => property.Name == name).PropertyType.Should().Be(expectedType); 
        }

        [Test]
        public void Item_ShouldHaveNoAdditionalMethods()
        {
            // Getter and Setter, Equals, GetType, ... are defined
            _itemType.GetMethods().Length.Should().Be(10);
        }
    }
}
