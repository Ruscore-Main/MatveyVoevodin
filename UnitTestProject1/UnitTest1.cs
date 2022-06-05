using MatveiVoevodin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestRegistration
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(ValidateTest.ValidateRegistration("lg", "1234", "Matvey", "Voevodin"), "Длина логина должна быть больше 3х символов");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(ValidateTest.ValidateRegistration("login", "123", "Matvey", "Voevodin"), "Длина пароля должна быть больше 4х символов");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(ValidateTest.ValidateRegistration("login", "12345", "M", "Voevodin"), "Имя должна быть больше 1-го символов");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(ValidateTest.ValidateRegistration("login", "12345", "Matvey", "Voe"), "Фамилия должна быть больше 4х символов");

        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(ValidateTest.ValidateRegistration("login", "12345", "Matvey", "Voevodin"), "Успешно");

        }
    }
}
