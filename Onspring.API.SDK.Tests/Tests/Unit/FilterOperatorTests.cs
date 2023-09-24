using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Tests.Unit
{
    [TestClass, ExcludeFromCodeCoverage]
    public class FilterOperatorTests
    {
        [TestMethod]
        public void Equal_WhenCalled_ItShouldReturnCorrectOperator()
        {
            var op = FilterOperator.Equal;
            Assert.IsInstanceOfType<FilterOperator>(op);
            Assert.AreEqual(1, op.Id);
            Assert.AreEqual("eq", op.Name);
        }

        [TestMethod]
        public void Equal_WhenComparedToItself_ItShouldReturnTrue()
        {
            var result = FilterOperator.Equal == FilterOperator.Equal;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equal_WhenComparedToAnotherOperator_ItShouldReturnFalse()
        {
            var result = FilterOperator.Equal == FilterOperator.NotEqual;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equal_WhenToStringIsCalled_ItShouldReturnProperName()
        {
            var op = $"{FilterOperator.Equal}";
            Assert.AreEqual("eq", op);
        }

        [TestMethod]
        public void NotEqual_WhenCalled_ItShouldReturnCorrectOperator()
        {
            var op = FilterOperator.NotEqual;
            Assert.IsInstanceOfType<FilterOperator>(op);
            Assert.AreEqual(2, op.Id);
            Assert.AreEqual("ne", op.Name);
        }

        [TestMethod]
        public void NotEqual_WhenComparedToItself_ItShouldReturnTrue()
        {
            var result = FilterOperator.NotEqual == FilterOperator.NotEqual;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NotEqual_WhenComparedToAnotherOperator_ItShouldReturnFalse()
        {
            var result = FilterOperator.NotEqual == FilterOperator.Equal;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NotEqual_WhenToStringIsCalled_ItShouldReturnProperName()
        {
            var op = $"{FilterOperator.NotEqual}";
            Assert.AreEqual("ne", op);
        }

        [TestMethod]
        public void Contains_WhenCalled_ItShouldReturnCorrectOperator()
        {
            var op = FilterOperator.Contains;
            Assert.IsInstanceOfType<FilterOperator>(op);
            Assert.AreEqual(3, op.Id);
            Assert.AreEqual("contains", op.Name);
        }

        [TestMethod]
        public void Contains_WhenComparedToItself_ItShouldReturnTrue()
        {
            var result = FilterOperator.Contains == FilterOperator.Contains;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_WhenComparedToAnotherOperator_ItShouldReturnFalse()
        {
            var result = FilterOperator.Contains == FilterOperator.Equal;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_WhenToStringIsCalled_ItShouldReturnProperName()
        {
            var op = $"{FilterOperator.Contains}";
            Assert.AreEqual("contains", op);
        }

        [TestMethod]
        public void IsNull_WhenCalled_ItShouldReturnCorrectOperator()
        {
            var op = FilterOperator.IsNull;
            Assert.IsInstanceOfType<FilterOperator>(op);
            Assert.AreEqual(4, op.Id);
            Assert.AreEqual("isnull", op.Name);
        }

        [TestMethod]
        public void IsNull_WhenComparedToItself_ItShouldReturnTrue()
        {
            var result = FilterOperator.IsNull == FilterOperator.IsNull;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNull_WhenComparedToAnotherOperator_ItShouldReturnFalse()
        {
            var result = FilterOperator.IsNull == FilterOperator.Equal;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNull_WhenToStringIsCalled_ItShouldReturnProperName()
        {
            var op = $"{FilterOperator.IsNull}";
            Assert.AreEqual("isnull", op);
        }

        [TestMethod]
        public void NotNull_WhenCalled_ItShouldReturnCorrectOperator()
        {
            var op = FilterOperator.NotNull;
            Assert.IsInstanceOfType<FilterOperator>(op);
            Assert.AreEqual(5, op.Id);
            Assert.AreEqual("notnull", op.Name);
        }

        [TestMethod]
        public void NotNull_WhenComparedToItself_ItShouldReturnTrue()
        {
            var result = FilterOperator.NotNull == FilterOperator.NotNull;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NotNull_WhenComparedToAnotherOperator_ItShouldReturnFalse()
        {
            var result = FilterOperator.NotNull == FilterOperator.Equal;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NotNull_WhenToStringIsCalled_ItShouldReturnProperName()
        {
            var op = $"{FilterOperator.NotNull}";
            Assert.AreEqual("notnull", op);
        }

        [TestMethod]
        public void GreaterThan_WhenCalled_ItShouldReturnCorrectOperator()
        {
            var op = FilterOperator.GreaterThan;
            Assert.IsInstanceOfType<FilterOperator>(op);
            Assert.AreEqual(6, op.Id);
            Assert.AreEqual("gt", op.Name);
        }

        [TestMethod]
        public void GreaterThan_WhenComparedToItself_ItShouldReturnTrue()
        {
            var result = FilterOperator.GreaterThan == FilterOperator.GreaterThan;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThan_WhenComparedToAnotherOperator_ItShouldReturnFalse()
        {
            var result = FilterOperator.GreaterThan == FilterOperator.Equal;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GreaterThan_WhenToStringIsCalled_ItShouldReturnProperName()
        {
            var op = $"{FilterOperator.GreaterThan}";
            Assert.AreEqual("gt", op);
        }

        [TestMethod]
        public void LessThan_WhenCalled_ItShouldReturnCorrectOperator()
        {
            var op = FilterOperator.LessThan;
            Assert.IsInstanceOfType<FilterOperator>(op);
            Assert.AreEqual(7, op.Id);
            Assert.AreEqual("lt", op.Name);
        }

        [TestMethod]
        public void LessThan_WhenComparedToItself_ItShouldReturnTrue()
        {
            var result = FilterOperator.LessThan == FilterOperator.LessThan;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LessThan_WhenComparedToAnotherOperator_ItShouldReturnFalse()
        {
            var result = FilterOperator.LessThan == FilterOperator.Equal;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LessThan_WhenToStringIsCalled_ItShouldReturnProperName()
        {
            var op = $"{FilterOperator.LessThan}";
            Assert.AreEqual("lt", op);
        }

        [TestMethod]
        public void And_WhenCalled_ItShouldReturnCorrectOperator()
        {
            var op = FilterOperator.And;
            Assert.IsInstanceOfType<FilterOperator>(op);
            Assert.AreEqual(8, op.Id);
            Assert.AreEqual("and", op.Name);
        }

        [TestMethod]
        public void And_WhenComparedToItself_ItShouldReturnTrue()
        {
            var result = FilterOperator.And == FilterOperator.And;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void And_WhenComparedToAnotherOperator_ItShouldReturnFalse()
        {
            var result = FilterOperator.And == FilterOperator.Equal;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void And_WhenToStringIsCalled_ItShouldReturnProperName()
        {
            var op = $"{FilterOperator.And}";
            Assert.AreEqual("and", op);
        }

        [TestMethod]
        public void Or_WhenCalled_ItShouldReturnCorrectOperator()
        {
            var op = FilterOperator.Or;
            Assert.IsInstanceOfType<FilterOperator>(op);
            Assert.AreEqual(9, op.Id);
            Assert.AreEqual("or", op.Name);
        }

        [TestMethod]
        public void Or_WhenComparedToItself_ItShouldReturnTrue()
        {
            var result = FilterOperator.Or == FilterOperator.Or;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Or_WhenComparedToAnotherOperator_ItShouldReturnFalse()
        {
            var result = FilterOperator.Or == FilterOperator.Equal;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Or_WhenToStringIsCalled_ItShouldReturnProperName()
        {
            var op = $"{FilterOperator.Or}";
            Assert.AreEqual("or", op);
        }

        [TestMethod]
        public void Not_WhenCalled_ItShouldReturnCorrectOperator()
        {
            var op = FilterOperator.Not;
            Assert.IsInstanceOfType<FilterOperator>(op);
            Assert.AreEqual(10, op.Id);
            Assert.AreEqual("not", op.Name);
        }

        [TestMethod]
        public void Not_WhenComparedToItself_ItShouldReturnTrue()
        {
            var result = FilterOperator.Not == FilterOperator.Not;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Not_WhenComparedToAnotherOperator_ItShouldReturnFalse()
        {
            var result = FilterOperator.Not == FilterOperator.Equal;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Not_WhenToStringIsCalled_ItShouldReturnProperName()
        {
            var op = $"{FilterOperator.Not}";
            Assert.AreEqual("not", op);
        }
    }
}