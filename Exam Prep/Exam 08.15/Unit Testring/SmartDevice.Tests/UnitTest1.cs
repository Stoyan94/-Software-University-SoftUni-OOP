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

             string retur = device.InstallApp(appName,appSize);

            Assert.AreNotEqual(device.MemoryCapacity, appSize);
            Assert.IsTrue(device.Applications.Contains(appName));
            Assert.AreEqual(retur, "TestApp is installed successfully. Run application?");
        }

        [Test]

        public void InstallAppMethodShoulThrowException()
        {
            Device device = new Device(50);

            string appName = "TestApp";
            int appSize = 100;         

            Assert.Throws<InvalidOperationException>(() =>
            {
                device.InstallApp(appName, appSize);
            }, "Not enough available memory to install the app.");
        }

        [Test] 
        public void TakePhotoShouldAddCorrectlyPhoto()
        {
            Device device = new Device(50);

            Assert.That(device.TakePhoto(20));
            Assert.IsFalse(device.TakePhoto(60));
        }

        [Test]

        public void FormatDeviceShouldWorkCorrectly()
        {
            Device device = new Device(50);
            device.FormatDevice();            

            Assert.That(device.Photos == 0);
            Assert.IsTrue(device.AvailableMemory == device.MemoryCapacity);
          
        }

        [Test]

        public void GetStatusMethodShouldWorkCorrectly()
        {
            Device device = new Device(50);

            device.TakePhoto(20);
            device.InstallApp("test", 10);

            string result = device.GetDeviceStatus();

            Assert.That(device.GetDeviceStatus(), Is.EqualTo(result));

        }
    }
}