using NUnit.Framework;
using FluentAssertions;

namespace PrimeNumbers.Tests
{
    [TestFixture]
    public class GeneratePrimesTests
    {
        [Test]
        public void GeneratePrimes0ReturnsEmptyArray()
        {
            0.PrimesSmallerOrEqual().Should().BeEmpty();
        }

        [Test]
        public void GeneratePrimes1ReturnsEmptyArray()
        {
            1.PrimesSmallerOrEqual().Should().BeEmpty();
        }

        [Test]
        public void GeneratePrimes2ReturnsArrayWith2()
        {
            2.PrimesSmallerOrEqual()
                .Should().BeEquivalentTo(new[] { 2 });
        }

        [Test]
        public void GeneratePrimes10ReturnsArray()
        {
            10.PrimesSmallerOrEqual()
                .Should().BeEquivalentTo(new[] { 2, 3, 5, 7 });
        }

        [Test]
        public void GeneratePrimes10000ReturnsArray()
        {
            10000.PrimesSmallerOrEqual()
                .Should().HaveCount(1229).And.EndWith(9973);
        }
    }
}