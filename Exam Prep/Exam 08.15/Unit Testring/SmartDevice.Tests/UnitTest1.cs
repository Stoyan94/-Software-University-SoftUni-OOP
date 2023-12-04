namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
      
        [Test]
        public void CtorShouldInitilazieCorrectly()
        {
            int excpetedMemory = 10;
            int avaibleMemory = 5;

            Device device = new Device(excpetedMemory);
            device.TakePhoto(5);
            int photo = device.Photos;

            Assert.AreEqual(excpetedMemory, device.MemoryCapacity);
            Assert.AreEqual(avaibleMemory, device.AvailableMemory);
        }

        [Test] 

        public void InstallAppMethodShouldWorkCorrectly()
        {
            Device device = new Device(50);

            string appName = "TestApp";
            int appSize = 20;

            device.InstallApp(appName,appSize);

            Assert.AreNotEqual(device.MemoryCapacity, appSize);
            Assert.IsTrue(device.Applications.Contains(appName));
            
        }
    }
}