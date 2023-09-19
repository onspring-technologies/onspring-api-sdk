using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Tests.Tests.Unit
{
    [TestClass, ExcludeFromCodeCoverage]
    public class FilterTests
    {
        [TestMethod]
        public void Filter_ParameterlessConstructorWhenCalled_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var filter = new Filter();
            Assert.AreEqual(0, filter.FieldId);
            Assert.AreEqual(null, filter.Operator);
            Assert.AreEqual(null, filter.Value);
        }

        [TestMethod]
        public void Filter_WhenActionInvokedOn_ItShouldAnInstanceWithPropertiesSet()
        {
            var fieldId = 1;
            var op = FilterOperator.Equal;
            var value = 1;
            var filter = new Filter();
            var action = (Filter filter) =>
            {
                filter.FieldId = 1;
                filter.Operator = op;
                filter.Value = value;
            };

            action.Invoke(filter);

            Assert.AreEqual(fieldId, filter.FieldId);
            Assert.AreEqual(op, filter.Operator);
            Assert.AreEqual(value, filter.Value);
        }

        [TestMethod]
        public void Filter_ConstructorWhenCalled_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var fieldId = 1;
            var op = FilterOperator.Equal;
            var value = 1;

            var filter = new Filter(fieldId, op, value);

            Assert.AreEqual(fieldId, filter.FieldId);
            Assert.AreEqual(op, filter.Operator);
            Assert.AreEqual(value, filter.Value);
        }

        [TestMethod]
        public void Filter_ConstructorWhenCalledAndOperatorIsNotANullOperatorAndValueIsNull_ItShouldThrowException()
        {
            var action = () => new Filter(1, FilterOperator.And, null);
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Filter_ConstructorWhenCalledAndOperatorIsNotNullOperatorAndValueIsNull_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var fieldId = 1;
            var op = FilterOperator.NotNull;
            object value = null;

            var filter = new Filter(fieldId, op, value);

            Assert.AreEqual(fieldId, filter.FieldId);
            Assert.AreEqual(op, filter.Operator);
            Assert.AreEqual(value, filter.Value);
        }

        [TestMethod]
        public void Filter_ConstructorWhenCalledAndOperatorIsIsNullOperatorAndValueIsNull_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var fieldId = 1;
            var op = FilterOperator.IsNull;
            object value = null;

            var filter = new Filter(fieldId, op, value);

            Assert.AreEqual(fieldId, filter.FieldId);
            Assert.AreEqual(op, filter.Operator);
            Assert.AreEqual(value, filter.Value);
        }

        [TestMethod]
        public void Filter_WhenValueIsSetToNullAndOperatorIsNotANullOperator_ItShouldThrowAnException()
        {
            var filter = new Filter(1, FilterOperator.Equal, 1);
            var action = () => filter.Value = null;
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Filter_WhenValueIsSetToNullAndOperatorIsNotNullOperator_ItShouldSetValueProperty()
        {
            var filter = new Filter(1, FilterOperator.NotNull, 1);
            filter.Value = null;
            Assert.AreEqual(null, filter.Value);
        }

        [TestMethod]
        public void Filter_WhenValueIsSetToNullAndOperatorIsIsNullOperator_ItShouldSetValueProperty()
        {
            var filter = new Filter(1, FilterOperator.IsNull, 1);
            filter.Value = null;
            Assert.AreEqual(null, filter.Value);
        }

        [TestMethod]
        public void Filter_ToStringWhenCalledAndValueIsNull_ItShouldReturnProperFilterString()
        {
            var filter = new Filter(1, FilterOperator.NotNull, null);
            Assert.AreEqual("1 notnull", filter.ToString());
        }

        [TestMethod]
        public void Filter_ToStringWhenCalledAndValueIsDateTime_ItShouldReturnProperFilterString()
        {
            var date = DateTime.UtcNow;
            var filter = new Filter(1, FilterOperator.Equal, date);
            Assert.AreEqual($"1 eq datetime'{date:O}'", $"{filter}");
        }

        [TestMethod]
        public void Filter_ToStringWhenCalledAndValueIsString_ItShouldReturnProperFilterString()
        {
            var stringValue = "hello";
            var filter = new Filter(1, FilterOperator.Equal, stringValue);
            Assert.AreEqual($"1 eq '{stringValue}'", filter.ToString());
        }

        [TestMethod]
        public void Filter_ToStringWhenCalledAndValueIsNumber_ItShouldReturnProperFilterString()
        {
            var num = 1;
            var filter = new Filter(1, FilterOperator.Equal, num);
            Assert.AreEqual($"1 eq {num}", filter.ToString());
        }
    }
}