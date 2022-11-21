using ExpressionTrees.Task2.ExpressionMapping.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionTrees.Task2.ExpressionMapping.Tests
{
    [TestClass]
    public class ExpressionMappingTests
    {
        // todo: add as many test methods as you wish, but they should be enough to cover basic scenarios of the mapping generator

        [TestMethod]
        public void TestMethod_AssignedFooProperties()
        {

            var foo = new Foo() { Name = "Test", Age = 20 };
            var mapGenerator = new MappingGenerator();
            var mapper = mapGenerator.Generate<Foo, Bar>();

            var boo = mapper.Map(foo);

            Assert.AreEqual(boo.Name, foo.Name);
            Assert.AreEqual(boo.Age, foo.Age);
        }

        [TestMethod]
        public void TestMethod_UnassignedFooProperties()
        {

            var foo = new Foo();
            var mapGenerator = new MappingGenerator();
            var mapper = mapGenerator.Generate<Foo, Bar>();

            var boo = mapper.Map(foo);

            Assert.AreEqual(boo.Name, foo.Name);
            Assert.AreEqual(boo.Age, foo.Age);
        }
    }
}
