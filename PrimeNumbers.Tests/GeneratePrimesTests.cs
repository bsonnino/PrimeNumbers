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
            var actual = GeneratePrimes.GetPrimes(0);
            actual.Should().BeEmpty();
        }

        [Test]
        public void GeneratePrimes1ReturnsEmptyArray()
        {
            var actual = GeneratePrimes.GetPrimes(1);
            actual.Should().BeEmpty();
        }

        [Test]
        public void GeneratePrimes2ReturnsArrayWith2()
        {
            var actual = GeneratePrimes.GetPrimes(2);
            actual.Should().BeEquivalentTo(new[] { 2 });
        }

        [Test]
        public void GeneratePrimes10ReturnsArray()
        {
            var actual = GeneratePrimes.GetPrimes(10);
            actual.Should().BeEquivalentTo(new[] { 2, 3, 5, 7 });
        }

        [Test]
        public void GeneratePrimes10000ReturnsArray()
        {
            var actual = GeneratePrimes.GetPrimes(10000);
            actual.Should().HaveCount(1229).And.EndWith(9973);
        }
    }
}