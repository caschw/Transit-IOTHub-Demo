using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Transportation.IoTCore.Tests
{
    [TestClass]
    public class Helpers
    {
        [TestMethod]
        public void GetBytes_ValidInput_ProducesValidOutput()
        {
            // Arrange
            var test = "test string";

            // Act
            var answer = test.GetBytes();

            // Assert
            var reference = new byte[22] { 116, 0, 101, 0, 115, 0, 116, 0, 32, 0, 115, 0, 116, 0, 114, 0, 105, 0, 110, 0, 103, 0 };
            
            Assert.IsTrue(reference.SequenceEqual(answer));
        }

        [TestMethod]
        public void GetBytes_ThisTestWillFail()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void ForEach_AddStrings_GetAppropriateListOfMessages() {
            // Arrange
            var list = new List<string> { "one", "two", "three" };

            // Act
            var answer = list.ForEach((x) => { return new Message(x.GetBytes()); }).ToList();

            // Assert
            Assert.AreEqual(answer.Count(), 3);
            Assert.IsInstanceOfType(answer[0], typeof(Message));
            Assert.IsInstanceOfType(answer[1], typeof(Message));
            Assert.IsInstanceOfType(answer[2], typeof(Message));
        }
    }
}
