using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlexList;

namespace AListTests
{
    [TestClass]
    public class TestAList
    {
        [TestMethod]
        public void SaveStoredValue_SaveString_isTypeString()
        {
            //arrange
            StoredValue<string> saveValue = new StoredValue<string>();
            string value = "test";
            //act
            saveValue.SaveStoredValue(value);
            //assert
            Assert.AreEqual(saveValue.value, value);
        }
        [TestMethod]
        public void SaveStoredValue_SaveInt_isTypeInt()
        {
            //arrange
            StoredValue<int> saveValue = new StoredValue<int>();
            int value = 27;
            //act
            saveValue.SaveStoredValue(value);
            //assert
            Assert.AreEqual(saveValue.value, value);
        }
        [TestMethod]
        public void SaveStoredValue_SaveDouble_isTypeDouble()
        {
            //arrange
            StoredValue<double> saveValue = new StoredValue<double>();
            double value = 10.77;
            //act
            saveValue.SaveStoredValue(value);
            //assert
            Assert.AreEqual(saveValue.value, value);
        }
        [TestMethod]
        public void SaveStoredValue_SaveObjectName_isTypeObjectsName()
        {
            //arrange
            StoredValue<ObjectTest> saveValue = new StoredValue<ObjectTest>();
            ObjectTest obj = new ObjectTest(1, "meepstick");
            //act
            saveValue.SaveStoredValue(obj);
            //assert
            Assert.AreEqual(saveValue.value.name, obj.name);
        }
        public void SaveStoredValue_SaveObjectSize_isTypeObjectsSize()
        {
            //arrange
            StoredValue<ObjectTest> saveValue = new StoredValue<ObjectTest>();
            ObjectTest obj = new ObjectTest(1, "meepstick");
            //act
            saveValue.SaveStoredValue(obj);
            //assert
            Assert.AreEqual(saveValue.value.size, obj.size);
        }
    }
}
