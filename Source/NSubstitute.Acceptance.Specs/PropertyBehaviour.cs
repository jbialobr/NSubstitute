using System;
using NUnit.Framework;

namespace NSubstitute.Acceptance.Specs
{
    public class PropertyBehaviour
    {
        [Pending]
        [Test]
        public void Properties_just_work()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Name = "This name";
            Assert.That(calculator.Name, Is.EqualTo("This name"));
        }

        [Test]
        public void Make_a_readonly_property_return_a_specific_value()
        {
            var calculator = Substitute.For<ICalculator>();
            var specificDate = new DateTime(2010, 1, 2, 3, 4, 5);
            calculator.Now.Return(specificDate);
            Assert.That(calculator.Now, Is.EqualTo(specificDate));
        }

        [Test]
        public void Check_a_property_setter_was_called()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Name = "This name";
            calculator.Received().Name = "This name";
            Assert.Throws<CallNotReceivedException>(() => calculator.Received().Name = "Other name");
        }

        [Test]
        public void Check_a_property_getter_was_called()
        {
            var calculator = Substitute.For<ICalculator>();
            var theName = calculator.Name;
            var name = calculator.Received().Name;
            Assert.Throws<CallNotReceivedException>(() => { var x = calculator.Received().Now; });

        }

    }
}