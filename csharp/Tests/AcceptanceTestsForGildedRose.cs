using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class AcceptanceTestsForGildedRose
    {
        private readonly Type _gildedRoseType = typeof(GildedRose);

        [Test]
        public void GildedRose_ShouldHaveOneConstructorWithItemListParameter()
        {
            ConstructorInfo[] constructors = _gildedRoseType.GetConstructors();
            constructors.Length.Should().Be(1);

            ParameterInfo[] parameters = constructors.First().GetParameters();
            parameters.Length.Should().Be(1);

            ParameterInfo parameter = parameters.First();
            parameter.ParameterType.Should().Be(typeof(IList<Item>));
        }

        [Test]
        public void GildedRose_MethodUpdateQuality_ShouldExist()
        {
            UpdateQualityMethodInfo().Should().NotBeNull();
        }

        [Test]
        public void GildedRose_MethodUpdateQuality_ShouldHaveVoidReturnType()
        {
            UpdateQualityMethodInfo().ReturnType.Should().Be(typeof(void));
        }

        [Test]
        public void GildedRose_MethodUpdateQuality_ShouldHaveNoParameters()
        {
            UpdateQualityMethodInfo().GetParameters().Length.Should().Be(0);
        }

        private MethodInfo UpdateQualityMethodInfo()
        {
            return _gildedRoseType.GetMethod("UpdateQuality");
        }
    }
}
