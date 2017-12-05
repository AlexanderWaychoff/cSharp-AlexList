using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlexList;

namespace AListTests
{
    [TestClass]
    public class TestAList
    {
        //StoredValue AddValue
        [TestMethod]
        public void AddValue_SaveString_isTypeString()
        {
            //arrange
            StoredValue<string> saveValue = new StoredValue<string>();
            string value = "test";
            //act
            saveValue.AddValue(value);
            //assert
            Assert.AreEqual(saveValue.value, value);
        }
        [TestMethod]
        public void AddValue_SaveInt_isTypeInt()
        {
            //arrange
            StoredValue<int> saveValue = new StoredValue<int>();
            int value = 27;
            //act
            saveValue.AddValue(value);
            //assert
            Assert.AreEqual(saveValue.value, value);
        }
        [TestMethod]
        public void AddValue_SaveDouble_isTypeDouble()
        {
            //arrange
            StoredValue<double> saveValue = new StoredValue<double>();
            double value = 10.77;
            //act
            saveValue.AddValue(value);
            //assert
            Assert.AreEqual(saveValue.value, value);
        }
        [TestMethod]
        public void AddValue_SaveObjectName_isTypeObjectsName()
        {
            //arrange
            StoredValue<ObjectTest> saveValue = new StoredValue<ObjectTest>();
            ObjectTest obj = new ObjectTest(1, "meepstick");
            //act
            saveValue.AddValue(obj);
            //assert
            Assert.AreEqual(saveValue.value.name, obj.name);
        }
        [TestMethod]
        public void AddValue_SaveObjectSize_isTypeObjectsSize()
        {
            //arrange
            StoredValue<ObjectTest> saveValue = new StoredValue<ObjectTest>();
            ObjectTest obj = new ObjectTest(1, "meepstick");
            //act
            saveValue.AddValue(obj);
            //assert
            Assert.AreEqual(saveValue.value.size, obj.size);
        }

        //Alist AddToList
        [TestMethod]
        public void Add_AddToAList_CountGoesUp()
        {
            //arrange
            AList<string> listOfValues = new AList<string>();
            string value = "test";
            //act
            listOfValues.Add(value);
            //assert
            Assert.AreEqual(listOfValues.listLength, 1);
        }
        [TestMethod]
        public void Add_AddToAList_CountGoesTo2()
        {
            //arrange
            AList<string> listOfValues = new AList<string>() {"fill"};
            string value = "test";
            //act
            listOfValues.Add(value);
            //assert
            Assert.AreEqual(listOfValues.listLength, 2);
        }
        [TestMethod]
        public void Add_CheckIndex0_Index0EqualsValue()
        {
            //arrange
            AList<string> listOfValues = new AList<string>();
            string value = "test";
            //act
            listOfValues.Add(value);
            //assert
            Assert.AreEqual(listOfValues[0], value);
        }
        public void Add_CheckIndex1_Index1EqualsValue()
        {
            //arrange
            AList<string> listOfValues = new AList<string>() {"fill"};
            string value = "test";
            //act
            listOfValues.Add(value);
            //assert
            Assert.AreEqual(listOfValues[1], value);
        }

        //program already prevents adding different values
        //[TestMethod]
        //[ExpectedException(typeof(InvalidOperationException))]
        //public void Add_DontAddDifferentTypes_ThrowsException()
        //{
        //    //arrange
        //    AList<string> listOfValues = new AList<string>();
        //    StoredValue<string> saveValue = new StoredValue<string>();
        //    string value = "test";
        //    int notString = 1;
        //    //act
        //    listOfValues.AddToList(value);
        //    listOfValues.AddToList(notString);
        //    //assert not used
        //}

        //AList Count
        [TestMethod]
        public void Count_CheckAListLength_CountEqualsAListLength()
        {
            //arrange
            AList<string> listOfValues = new AList<string>() { "test", "fill" };
            //act
            int lengthOfAList = listOfValues.Count();
            //assert
            Assert.AreEqual(lengthOfAList, 2);
        }
        [TestMethod]
        public void Count_PropertyUsageForCount_CountEqualsAListLength()
        {
            //arrange
            AList<string> listOfValues = new AList<string>() { "test", "fill" };
            //act
            int lengthOfAList = listOfValues.Count;
            //assert
            Assert.AreEqual(lengthOfAList, 2);
        }

        //Alist Remove
        [TestMethod]
        public void Remove_RemoveFromAList_CountGoesDown()
        {
            //arrange
            string removeThis = "remove";
            AList<string> listOfValues = new AList<string>() { "test", removeThis, "fill" };
            //act
            listOfValues.Remove(removeThis);
            //assert
            Assert.AreNotEqual(listOfValues[1], removeThis);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Remove_RemoveFromAList_ExceptionCheckingPastLength()
        {
            //arrange
            string remove = "remove";
            string doNotRemove = "keep";
            AList<string> listOfValues = new AList<string>() { remove, doNotRemove };
            //act
            listOfValues.Remove(remove);
            //assert
            Assert.AreEqual(listOfValues[0], doNotRemove);
        }

        //AList RemoveAt 
        [TestMethod]
        public void RemoveAt_RemoveFromSpecificIndex_Index1Changes()
        {
            //arrange
            string item = "Expected to be removed";
            AList<string> listOfValues = new AList<string>() { "test", item, "fill" };
            //act
            listOfValues.RemoveAt(1);
            //assert
            Assert.AreNotEqual(listOfValues[1], item);
        }
        [TestMethod]
        public void RemoveAt_RemoveFromSpecificIndex_Index1IsWhatIndex2ValueWas()
        {
            //arrange
            string item = "Expected value";
            AList<string> listOfValues = new AList<string>() { "test", "fill", item };
            //act
            listOfValues.RemoveAt(1);
            //assert
            Assert.AreEqual(listOfValues[1], item);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_RemoveFromAList_ExceptionCheckingPastLength()
        {
            //arrange
            AList<string> listOfValues = new AList<string>() { "test", "fill" };
            //act
            listOfValues.RemoveAt(5);
            //assert
        }

        //AList Clear
        [TestMethod]
        public void Clear_ClearsList_AListHasNoValue()
        {
            //arrange
            string item = "Expected value";
            AList<string> listOfValues = new AList<string>() { item };
            //act
            listOfValues.Clear();
            //assert
            Assert.AreNotEqual(listOfValues.Count(), 0);
        }
    }
}
