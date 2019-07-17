using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomList;

namespace Custom_List_Test
{
    [TestClass]
    public class CustomListTest
    {

        //if I add something to a populated customlist, it should go to indexZero
        [TestMethod]
        public void Add_AddToEmptyList_ItemShouldGoToIndexZero()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 8;
            int actual;
            // act
            test.Add(8);
            actual = test[0];
            // assert
            Assert.AreEqual(expected, actual);
        }

        //if i add something to customlist, count should go up by 1
        [TestMethod]
        public void Add_AddToEmptyList_CountShouldIncreaseToOne()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 1;
            int actual;
            // act
            test.Add(8);
            actual = test.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }
        
        //if i add something to a customlist who has items in the array, it should add the item to the end
        [TestMethod]
        public void Add_AddToPopulatedArray_AddToEnd()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 6;
            int actual;
            // act
            test.Add(8);
            test.Add(6);
            actual = test[1];
            // assert
            Assert.AreEqual(expected, actual);
        }

        //if i add something to customlist whos inner array is full, it should still add the item
        [TestMethod]
        public void Add_AddToFullArray_StillAdd()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 5;
            int actual;
            // act
            test.Add(8);
            test.Add(8);
            test.Add(8);
            test.Add(8);
            test.Add(8);
            actual = test.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
