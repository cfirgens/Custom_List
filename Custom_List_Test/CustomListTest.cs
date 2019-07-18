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
            int expected = 8;
            int actual;
            // act
            test.Add(4);
            test.Add(4);
            test.Add(4);
            test.Add(4);
            test.Add(8);
            test.Add(8);
            test.Add(8);
            test.Add(8);
            actual = test[4];
            // assert
            Assert.AreEqual(expected, actual);
        }

        //if i add something to customlist whose inner array is full twice, it should still add the item
        [TestMethod]
        public void Add_AddToDoubleFullArray_StillAdd()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 12;
            int actual;
            // act
            test.Add(4);
            test.Add(4);
            test.Add(4);
            test.Add(4);
            test.Add(8);
            test.Add(8);
            test.Add(8);
            test.Add(8);
            test.Add(12);
            test.Add(12);
            test.Add(12);
            test.Add(12);
            actual = test[8];
            // assert
            Assert.AreEqual(expected, actual);

        }


        //if i remove something to a customlist who has items in the array, it should shift items over
        [TestMethod]
        public void Remove_RemoveFromPopulatedArray_ShiftEverythingOver()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 3;
            int actual;

            // act
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Remove(2);

            actual = test[1];
            // assert
            Assert.AreEqual(expected, actual);
        }


        //if i remove something to a customlist who has items in the array the count should lower
        [TestMethod]
        public void Remove_RemoveFromPopulatedArray_CountLowers()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 2;
            int actual;

            // act
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Remove(2);

            actual = test.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        //if i remove something in a customlist that doesnt exist, it should return that item wasn't found
        [TestMethod]
        public void Remove_RemoveFromPopulatedArray_NothingChangesFromListCountRemainsTheSame()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 3;
            int actual;

            // act
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Remove(4);

            actual = test.Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        //if i remove something in a customlist that doesnt have anything in it, it should return that list is empty
        [TestMethod]
        public void Remove_RemoveFromEmptyArray_TheCountDoesntChange()
        {
            // arrange
            CustomList<int> test = new CustomList<int>();
            int expected = 0;
            int actual;

            // act
            test.Remove(4);
            actual = test.Count;

            // assert
            Assert.AreEqual(expected, actual);
        }

        //if i convert an empty list to a string, it should return an empty string
        [TestMethod]
        public void Convert_ConvertToStringFromEmptyArray_ReturnEmptyString()
        {
            //arrange
            CustomList<int> test = new CustomList<int>();
            string expected = "";
            string actual;

            //act
            actual = test.Convert();

            //assert
            Assert.AreEqual(expected, actual);
        }

        //if i convert a list to a string, it should return a string full of the list
        [TestMethod]
        public void Convert_ConvertToString_ReturnString()
        {
            //arrange
            CustomList<int> test = new CustomList<int>();
            int intsToAdd = 7;
            for(int i =0; i< intsToAdd; i++)
            {
                test.Add(i);
            }

            string expected = "0 1 2 3 4 5 6 ";
            string actual;

            //act
            actual = test.Convert();

            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
