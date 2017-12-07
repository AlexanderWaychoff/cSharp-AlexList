using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlexList;
using System.Collections.Generic;

namespace AListTests
{
    [TestClass]
    public class TestAList
    {
        //DetermineCapacity
        [TestMethod]
        public void DetermineCapacity_CountAvailableSpaces_Assert6()
        {
            //arrange
            AList<int> test = new AList<int>();
            test.Add(1);
            test.Add(2);
            //act
            test.CheckCapacity();
            //assert
            Assert.AreEqual(test.Capacity, 6);
        }
        [TestMethod]
        public void DetermineCapacity_CapacityIncreasesFromThreshold_Assert12()
        {
            //arrange
            AList<int> test = new AList<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);
            //act
            test.CheckCapacity();
            //assert
            Assert.AreEqual(test.Capacity, 12);
        }
        //Alist AddToList
        [TestMethod]
        public void Add_AddToAList_Index0EqualsValue()
        {
            //arrange
            AList<string> listOfValues = new AList<string>();
            string value = "test";
            //act
            listOfValues.Add(value);
            //assert
            Assert.AreEqual(listOfValues[0], value);
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
            Assert.AreEqual(listOfValues.Count, 2);
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
        [TestMethod]
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
        [TestMethod]
        public void Add_AddObject_GetSpecificInfo()
        {
            //arrange
            AList<ObjectTest> listOfValues = new AList<ObjectTest>();
            ObjectTest test = new ObjectTest(2, "merfsack");
            //act
            listOfValues.Add(test);
            //assert
            Assert.AreEqual(listOfValues[0].name, "merfsack");
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

        //this one is method, next one is property
        //[TestMethod]
        //public void Count_CheckAListLength_CountEqualsAListLength()
        //{
        //    //arrange
        //    //AList<string> listOfValues = new AList<string>() { "test", "fill" };
        //    AList<string> listOfValues = new AList<string>();
        //    listOfValues.Add("test");
        //    listOfValues.Add("fill");
        //    //act
        //    int lengthOfAList = listOfValues.Count;
        //    //assert
        //    Assert.AreEqual(lengthOfAList, 2);
        //}
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
        [TestMethod]
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
        [TestMethod]
        public void Remove_RemoveFromAList_ReturnTrue()
        {
            //arrange
            string removeThis = "remove";
            bool hasRemoved;
            AList<string> listOfValues = new AList<string>();// { "test", removeThis, "fill" };
            listOfValues.Add("test");
            listOfValues.Add(removeThis);
            listOfValues.Add("fill");
            //act
            hasRemoved = listOfValues.Remove(removeThis);
            //assert
            Assert.IsTrue(hasRemoved);
        }
        [TestMethod]
        public void Remove_DoNotRemoveFromAList_ReturnFalse()
        {
            //arrange
            string removeThis = "remove";
            bool hasRemoved;
            AList<string> listOfValues = new AList<string>();// { "test", removeThis, "fill" };
            listOfValues.Add("test");
            listOfValues.Add("extra");
            listOfValues.Add("fill");
            //act
            hasRemoved = listOfValues.Remove(removeThis);
            //assert
            Assert.IsFalse(hasRemoved);
        }
        [TestMethod]
        public void Remove_CheckIndex0_ValueIsThere()
        {
            //arrange
            string test = "test";
            string removeThis = "remove";
            AList<string> listOfValues = new AList<string>();// { "test", removeThis, "fill" };
            listOfValues.Add(test);
            listOfValues.Add(removeThis);
            listOfValues.Add("fill");
            //act
            listOfValues.Remove(removeThis);
            //assert
            Assert.AreEqual(listOfValues[0], test);
        }
        [TestMethod]
        public void Remove_CheckIndex1_ValueFromIndex2IsThere()
        {
            //arrange
            string test = "test";
            string removeThis = "remove";
            AList<string> listOfValues = new AList<string>();// { "test", removeThis, "fill" };
            listOfValues.Add("fill");
            listOfValues.Add(removeThis);
            listOfValues.Add(test);
            //act
            listOfValues.Remove(removeThis);
            //assert
            Assert.AreEqual(listOfValues[1], test);
        }
        [TestMethod]
        public void Remove_CheckCount_CountEquals2()
        {
            //arrange
            string test = "test";
            string removeThis = "remove";
            AList<string> listOfValues = new AList<string>();// { "test", removeThis, "fill" };
            listOfValues.Add("fill");
            listOfValues.Add(removeThis);
            listOfValues.Add(test);
            //act
            listOfValues.Remove(removeThis);
            //assert
            Assert.AreEqual(listOfValues.Count, 2);
        }
        [TestMethod]
        public void Remove_RemoveObject_ObjectIsGone()
        {
            //arrange
            ObjectTest test = new ObjectTest(3, "remove me");
            AList<ObjectTest> listOfValues = new AList<ObjectTest>();// { "test", removeThis, "fill" };
            listOfValues.Add(test);
            //act
            listOfValues.Remove(test);
            //assert
            Assert.AreNotEqual(listOfValues[0], test);
        }

        //Iterator
        [TestMethod]
        public void Iterator_RemoveObject_ObjectIsGone()
        {
            //arrange
            AList<int> listOfValues = new AList<int>() { 1, 2, 3 };
            AList<int> grabValues = new AList<int>();
            int grab = 0;
            //act
            foreach (var item in listOfValues)
            {
                if(item == 2)
                {
                    grab = 2;
                }
                grabValues.Add(item);
            }
            //assert
            Assert.AreEqual(grabValues[1], grab);
        }
        [TestMethod]
        public void Iterator_CheckCount_EqualsCount()
        {
            //arrange
            AList<int> listOfValues = new AList<int>() { 1, 2, 3 };
            int count = 0;
            //act
            foreach (var item in listOfValues)
            {
                count += 1;
            }
            //assert
            Assert.AreEqual(listOfValues.Count, count);
        }


        //Override ToString
        [TestMethod]
        public void ToString_ObserveEffectsWithList_UnderstandWhatHappens()
        {
            //arrange
            //AList<int> listOfValues = new AList<int>() { 1, 2, 3 };
            List<int> tests = new List<int>() { 1, 2, 3, 4 };
            //int test = 2;
            string grab;
            //act
            //grab = listOfValues.ToString();
            grab = tests[0].ToString();
            //assert
            Assert.AreEqual(grab, "1");
        }
        [TestMethod]
        public void ToString_TestOneIndex_EqualsStringValueOfIndex0()
        {
            //arrange
            AList<int> tests = new AList<int>() { 1, 2, 3, 4 };
            string grab;
            //act
            grab = tests[0].ToString();
            //assert
            Assert.AreEqual(grab, "1");
        }
        [TestMethod]
        public void ToString_TestOneIndex_EqualsStringValueOfIndex3()
        {
            //arrange
            AList<int> tests = new AList<int>() { 1, 2, 3, 4 };
            string grab;
            //act
            grab = tests[3].ToString();
            //assert
            Assert.AreEqual(grab, "4");
        }
        [TestMethod]
        public void ToString_OverrideWholeArray_EqualsStringValueOfEntireArray()
        {
            //arrange
            AList<int> tests = new AList<int>() { 1, 2, 3, 4 };
            string grab;
            //act
            grab = tests.ToString();
            //assert
            Assert.AreEqual(grab, "1, 2, 3, 4");
        }
        //test for overload ToString method; assignment requires override for ToString
        //[TestMethod]
        //public void ToString_OverloadWholeArray_EqualsStringValueOfEntireArrayAndSeperatorInParameterIsTheSame()
        //{
        //    //arrange
        //    AList<int> tests = new AList<int>() { 1, 2, 3, 4 };
        //    string grab;
        //    //act
        //    grab = tests.ToString("..");
        //    //assert
        //    Assert.AreEqual(grab, "1..2..3..4");
        //}

        //overload + operator +++++++++
        [TestMethod]
        public void OverloadAddition_Add2Integers_ResultIsCorrect()
        {
            //arrange
            int number = 2;
            int result = 0;
            //act
            result = number + number;
            //assert
            Assert.AreEqual(result, 4);
        }
        [TestMethod]
        public void OverloadAddition_Add2Strings_StringsCombine()
        {
            //arrange
            string number = "2";
            string result;
            //act
            result = number + number;
            //assert
            Assert.AreEqual(result, "22");
        }
        [TestMethod]
        public void OverloadAddition_Add2StringsFrom2Lists_StringsCombine()
        {
            //arrange
            AList<string> numberOne = new AList<string>() { "2" };
            AList<string> numberTwo = new AList<string>() { "3" };
            string result;
            //act
            result = numberOne[0] + numberTwo[0];
            //assert
            Assert.AreEqual(result, "23");
        }
        [TestMethod]
        public void OverloadAddition_Add2StringsFromSameList_SeeWhatResultIs()
        {
            //arrange
            AList<string> numbers = new AList<string>() { "2", "3" };
            string result;
            //act
            result = numbers[0] + numbers[1];
            //assert
            Assert.AreEqual(result, "23");
        }
        [TestMethod]
        public void OverloadAddition_Add2IntFromSameList_ResultIsCorrect()
        {
            //arrange
            AList<int> numbers = new AList<int>() { 2, 3 };
            int result;
            //act
            result = numbers[0] + numbers[1];
            //assert
            Assert.AreEqual(result, 5);
        }
        [TestMethod]
        public void OverloadAddition_Add2IntAListTogether_SeeWhatResultIs()
        {
            //arrange
            AList<int> numbersOdd = new AList<int>() { 1, 3, 5 };
            AList<int> numbersEven = new AList<int>() { 2, 4, 6 };
            AList<int> result = new AList<int>();
            //act
            //result = numbersOdd + numbersEven;
            //assert
            //Assert.AreEqual(result.ToString, "1, 3, 5, 2, 4, 6";
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
           // Assert.AreNotEqual(listOfValues[1], item);
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
            Assert.AreEqual(listOfValues.Count, 0);
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
            //Assert.AreEqual(listOfValues[0], item);
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
            //Assert.AreEqual(listOfValues[1], item);
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
            //Assert.AreEqual(listOfValues[0], item);
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
            //Assert.AreEqual(listOfValues[2], item);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Insert_IntoIndex5_ThrowException()
        {
            //arrange
            string test = "Exception";
            AList <string> listOfValues = new AList<string>();
            listOfValues.Add("fill");
            listOfValues.Add("fill");
            //act
            listOfValues.Insert(5, test);
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
            //Assert.AreEqual(listOfValues[0], value);
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
            //Assert.AreEqual(listOfValues[1], value);
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
