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
            AList<string> listOfValues = new AList<string>();// {"fill"};
            string value = "test";
            listOfValues.Add("fill");
            //act
            listOfValues.Add(value);
            //assert
            Assert.AreEqual(listOfValues.Count(), 2);
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
            AList<string> listOfValues = new AList<string>();
            string value = "test";
            listOfValues.Add("fill");
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
            //AList<string> listOfValues = new AList<string>() { "test", "fill" };
            AList<string> listOfValues = new AList<string>();
            listOfValues.Add("test");
            listOfValues.Add("fill");
            //act
            int lengthOfAList = listOfValues.Count();
            //assert
            Assert.AreEqual(lengthOfAList, 2);
        }
        [TestMethod]
        public void Count_PropertyUsageForCount_CountEqualsAListLength()
        {
            //arrange
            AList<string> listOfValues = new AList<string>();// { "test", "fill" };
            listOfValues.Add("test");
            listOfValues.Add("fill");
            //act
            int lengthOfAList = listOfValues.Count;
            //assert
            Assert.AreEqual(lengthOfAList, 2);
        }

        //Alist Remove
        [TestMethod]
        public void Remove_RemoveFromAList_IndexIsRemoved()
        {
            //arrange
            string removeThis = "remove";
            AList<string> listOfValues = new AList<string>();// { "test", removeThis, "fill" };
            listOfValues.Add("test");
            listOfValues.Add(removeThis);
            listOfValues.Add("fill");
            //act
            listOfValues.Remove(removeThis);
            //assert
            Assert.AreNotEqual(listOfValues[1], removeThis);
        }
        [TestMethod]
        public void Remove_RemoveFromAList_KeepValueAtIndex1()
        {
            //arrange
            string remove = "remove";
            string doNotRemove = "keep";
            AList<string> listOfValues = new AList<string>();// { remove, doNotRemove };
            listOfValues.Add(remove);
            listOfValues.Add(doNotRemove);
            //act
            listOfValues.Remove(remove);
            //assert
            Assert.AreEqual(listOfValues[0], doNotRemove);
        }
        public void Remove_DoNotRemove_KeepValueAtIndex0()
        {
            //arrange
            string doNotRemove = "keep";
            AList<string> listOfValues = new AList<string>();// { remove, doNotRemove };
            listOfValues.Add(doNotRemove);
            //act
            listOfValues.Remove("remove");
            //assert
            Assert.AreEqual(listOfValues[0], doNotRemove);
        }

        //AList RemoveAt 
        [TestMethod]
        public void RemoveAt_RemoveFromSpecificIndex_Index1Changes()
        {
            //arrange
            string item = "Expected to be removed";
            AList<string> listOfValues = new AList<string>();// { "test", item, "fill" };
            listOfValues.Add("test");
            listOfValues.Add(item);
            listOfValues.Add("fill");
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
            AList<string> listOfValues = new AList<string>();// { "test", "fill", item };
            listOfValues.Add("test");
            listOfValues.Add("fill");
            listOfValues.Add(item);
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
            AList<string> listOfValues = new AList<string>();// { "test", "fill" };
            listOfValues.Add("test");
            listOfValues.Add("fill");
            //act
            listOfValues.RemoveAt(5);
            //assert
        }

        //AList Clear
        [TestMethod]
        public void Clear_ClearsList_AListHasNoValue()
        {
            //arrange
            string item = "Remove this";
            AList<string> listOfValues = new AList<string>();// { item };
            listOfValues.Add(item);
            //act
            listOfValues.Clear();
            //assert
            Assert.AreEqual(listOfValues.Count(), 0);
        }

        //AList Insert
        [TestMethod]
        public void Insert_PutValueAtIndex0_AListIndex0Changes()
        {
            //arrange
            string item = "Expected value";
            AList<string> listOfValues = new AList<string>();
            listOfValues.Add("fill");
            //act
            listOfValues.Insert(0, item);
            //assert
            Assert.AreEqual(listOfValues[0], item);
        }
        [TestMethod]
        public void Insert_PutValueAtIndex0_AListIndex1IsThere()
        {
            //arrange
            string item = "Expected value";
            AList<string> listOfValues = new AList<string>();
            listOfValues.Add(item);
            //act
            listOfValues.Insert(0, "fill");
            //assert
            Assert.AreEqual(listOfValues[1], item);
        }
        [TestMethod]
        public void Insert_PutValueAtIndex1_AListIndex0IsThere()
        {
            //arrange
            string item = "Expected value";
            AList<string> listOfValues = new AList<string>();
            listOfValues.Add(item);
            listOfValues.Add("fill");
            //act
            listOfValues.Insert(1, "fill");
            //assert
            Assert.AreEqual(listOfValues[0], item);
        }
        [TestMethod]
        public void Insert_PutValueAtIndex1_AListIndex2IsThere()
        {
            //arrange
            string item = "Expected value";
            AList<string> listOfValues = new AList<string>();
            listOfValues.Add("fill");
            listOfValues.Add(item);
            //act
            listOfValues.Insert(1, "fill");
            //assert
            Assert.AreEqual(listOfValues[2], item);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexOf_CheckIndex5_ThrowException()
        {
            //arrange
            AList<string> listOfValues = new AList<string>();
            listOfValues.Add("fill");
            listOfValues.Add("fill");
            //act
            string test = listOfValues.IndexOf(5);
            //assert
        }

        //AList IndexOf
        [TestMethod]
        public void IndexOf_CheckIndex0_AListIndex0EqualsValue()
        {
            //arrange
            string value = "Expected value";
            AList<string> listOfValues = new AList<string>();
            listOfValues.Add(value);
            listOfValues.Add("fill");
            listOfValues.Add("fill");
            //act
            string test = listOfValues.IndexOf(0);
            //assert
            Assert.AreEqual(listOfValues[0], value);
        }
        [TestMethod]
        public void IndexOf_CheckIndex1_AListIndex1EqualsValue()
        {
            //arrange
            string value = "Expected value";
            AList<string> listOfValues = new AList<string>();
            listOfValues.Add("fill");
            listOfValues.Add(value);
            listOfValues.Add("fill");
            //act
            string test = listOfValues.IndexOf(1);
            //assert
            Assert.AreEqual(listOfValues[1], value);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexOf_CheckIndex5_ThrowException()
        {
            //arrange
            AList<string> listOfValues = new AList<string>();
            listOfValues.Add("fill");
            listOfValues.Add("fill");
            //act
            string test = listOfValues.IndexOf(5);
            //assert
        }
    }
}
