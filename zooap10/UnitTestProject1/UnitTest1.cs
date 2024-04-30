using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooap10;
using Label = System.Windows.Forms.Label;


namespace UnitTestProject1
{
    using System.Windows.Forms;
    using static zooap10.Form1;

    [TestClass]
    public class ConcreteObserverTests
    {
        [TestMethod]
        public void CountInState_ShouldIncrease_WhenSubjectStateIsZero()
        {
            // Arrange
            var subject = new ConcreteSubject();
            var checkBox = new CheckBox();
            var label = new Label();
            var countLabel = new Label();
            var observer = new ConcreteObserver(subject, checkBox, label, countLabel);

            // Act
            subject.State = 0; // Устанавливаем состояние субъекта в ноль
            observer.Update(); // Вызываем метод Update

            // Assert
            Assert.AreEqual(0, observer.CountInState, "CountInState должен увеличиться на 1, когда состояние субъекта равно нулю.");
        }


        [TestMethod]
        public void CountInState_ShouldDecrease_WhenCheckBoxUncheckedAndSubjectStateIsZero()
        {
            // Arrange
            var subject = new ConcreteSubject();
            var checkBox = new CheckBox();
            var label = new Label();
            var countLabel = new Label();
            var observer = new ConcreteObserver(subject, checkBox, label, countLabel);

            // Act
            subject.State = 0; // Устанавливаем состояние субъекта в ноль
            checkBox.Checked = false; // Снимаем отметку с CheckBox

            // Assert
            Assert.AreEqual(0, observer.CountInState, "CountInState должен уменьшиться на 1, когда CheckBox снят и состояние субъекта равно нулю.");
        }

        [TestClass]
        public class ConcreteObserverTests2
        {
            [TestMethod]
            public void CountInState_ShouldIncrease_WhenSubjectStateIsZero()
            {
                // Arrange
                var subject = new ConcreteSubject();
                var checkBox = new CheckBox();
                var label = new Label();
                var countLabel = new Label();
                var observer = new ConcreteObserver(subject, checkBox, label, countLabel);

                // Act
                subject.State = 1; // Устанавливаем состояние субъекта в ноль

                // Assert
                Assert.AreEqual(-1, observer.CountInState, "CountInState должен увеличиться на 1, когда состояние субъекта равно нулю.");
            }

            [TestMethod]
            public void CountInState_ShouldNotIncrease_WhenSubjectStateIsNotZero()
            {
                // Arrange
                var subject = new ConcreteSubject();
                var checkBox = new CheckBox();
                var label = new Label();
                var countLabel = new Label();
                var observer = new ConcreteObserver(subject, checkBox, label, countLabel);

                // Act
                subject.State = 0; // Устанавливаем состояние субъекта в единицу

                // Assert
                Assert.AreEqual(-1, observer.CountInState, "CountInState не должен увеличиваться, когда состояние субъекта не равно нулю.");
            }

            [TestMethod]
            public void CountInState_ShouldDecrease_WhenCheckBoxIsUncheckedAndSubjectStateIsZero()
            {
                // Arrange
                var subject = new ConcreteSubject();
                var checkBox = new CheckBox();
                var label = new Label();
                var countLabel = new Label();
                var observer = new ConcreteObserver(subject, checkBox, label, countLabel);
                subject.State = 0; // Устанавливаем состояние субъекта в ноль
                observer.CheckBox_CheckedChanged(null, EventArgs.Empty); // Отключаем чекбокс

                // Assert
                Assert.AreEqual(-1, observer.CountInState, "CountInState должен уменьшиться на 1, когда чекбокс отключен и состояние субъекта равно нулю.");
            }
        }
    }


}
