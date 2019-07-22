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
            string expected = "0 1 2 3 4 5 6 ";
            string actual;

            //act
            for (int i = 0; i < intsToAdd; i++)
            {
                test.Add(i);
            }

            actual = test.Convert();

            //assert
            Assert.AreEqual(expected, actual);
        }

        //if i add two lists together, it should return a list at the counts added together
        [TestMethod]
        public void OverloadAdd_AddTwoLists_ReturnListWithCountOfBothListsAdded()
        {
            //arrange
            CustomList<int> listOne = new CustomList<int>();
            CustomList<int> listTwo = new CustomList<int>();
            CustomList<int> combinedList = new CustomList<int>();
            int intsToAdd = 5;
            int expected = 10;
            int actual;

            //act
            for (int i = 0; i < intsToAdd; i++)
            {
                listOne.Add(i);
                listTwo.Add(i);
            }

            combinedList = listOne + listTwo;

            actual = combinedList.Count;

            //assert
            Assert.AreEqual(expected, actual);
        }


        //if i add two lists with 0 count together, it should return a 0 count list
        [TestMethod]
        public void OverloadAdd_AddTwoListsOfZeroTogether_ReturnListWithZeroCount()
        {
            //arrange
            CustomList<int> listOne = new CustomList<int>();
            CustomList<int> listTwo = new CustomList<int>();
            CustomList<int> combinedList = new CustomList<int>();
            int expected = 0;
            int actual;

            //act
            combinedList = listOne + listTwo;
            actual = combinedList.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }
        //if i add two lists togther one with 0 count and the other with 4, the third list should be 4
        [TestMethod]
        public void OverloadAdd_AddTwoListsOfZeroAndFourTogether_ReturnListWithFourCount()
        {
            //arrange
            CustomList<int> listOne = new CustomList<int>();
            CustomList<int> listTwo = new CustomList<int>();
            CustomList<int> combinedList = new CustomList<int>();
            int expected = 4;
            int actual;
            int intsToAdd = 4;

            //act
            for (int i = 0; i < intsToAdd; i++)
            {
                listOne.Add(i);
            }
            combinedList = listOne + listTwo;
            actual = combinedList.Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        //if i zip two lists together with 0 count, it should remain 0 count
        [TestMethod]
        public void Zip_ZipTwoListsWithZeroCount_ReturnListWithZeroCount()
        {
            //arrange
            var listOne = new CustomList<int>();
            var listTwo = new CustomList<int>();
            var zippedList = new CustomList<int>();
            int expected = 0;
            int actual;

            //act
            zippedList = CustomList<int>.Zip(listOne, listTwo);
            actual = zippedList.Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        //if i zip two lists together each with two count, it should have 4 count
        [TestMethod]
        public void Zip_ZipTwoListsWithTwoCount_ReturnListWithFourCount()
        {
            //arrange
            var listOne = new CustomList<int>();
            var listTwo = new CustomList<int>();
            var zippedList = new CustomList<int>();
            int expected = 4;
            int actual;
            int intsToAdd = 2;

            //act
            for (int i = 0; i < intsToAdd; i++)
            {
                listOne.Add(i);
                listTwo.Add(i);
            }

            zippedList = CustomList<int>.Zip(listOne, listTwo);
            actual = zippedList.Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        //if i zip two lists together, the values should zip ie list one 123; list two 456; zipped list 142536;
        [TestMethod]
        public void Zip_ZipTwoList_ReturnListThatZipsTwoListsTogether()
        {
            //arrange
            var listOne = new CustomList<int>();
            var listTwo = new CustomList<int>();
            var zippedList = new CustomList<int>();
            int expected = 1;
            int actual;
            int intsToAdd = 2;

            //act
            for (int i = 0; i < intsToAdd; i++)
            {
                listOne.Add(i);
                listTwo.Add(i);
            }

            zippedList = CustomList<int>.Zip(listOne, listTwo);
            actual = zippedList[3];

            //assert
            Assert.AreEqual(expected, actual);
        }

        //if i zip two lists together that are different lengths, the shorter should zip and the longers values will fill in
        [TestMethod]
        public void Zip_ZipTwoDifferentLengthList_ReturnListThatZipsTwoListsTogether()
        {
            //arrange
            var listOne = new CustomList<int>();
            var listTwo = new CustomList<int>();
            var zippedList = new CustomList<int>();
            int expected = 8;
            int actual;


            //act
            for (int i = 0; i < 3; i++)
            {
                listOne.Add(i);
            }
            for (int j = 0; j < 5; j++)
            {
                listTwo.Add(j);
            }

            zippedList = CustomList<int>.Zip(listOne, listTwo);
            actual = zippedList.Count;

            //assert
            Assert.AreEqual(expected, actual);
        }

        //if i subtract two lists from each other and nothing is subtracted the count should remain the same
        [TestMethod]
        public void OverrideSubtract_SubtractTwoListsThatChangeNothing_ReturnSameCountForFirstList()
        {
            //arrange
            var listOne = new CustomList<int>();
            var listTwo = new CustomList<int>();
            var subtractedList = new CustomList<int>();

            int expected = 4;
            int actual;

            //act
            for (int i = 0; i < 4; i++)
            {
                listOne.Add(i);
                listTwo.Add(i + 5);
            }

            subtractedList = listOne - listTwo;
            actual = subtractedList.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

        //if i subtract two lists from each other and one thing is subtracted the count should drop by one
        [TestMethod]
        public void OverrideSubtract_SubtractTwoListsThatSubtractOneValue_ReturnCountMinusOne()
        {
            //arrange
            var listOne = new CustomList<int>();
            var listTwo = new CustomList<int>();
            var subtractedList = new CustomList<int>();

            int expected = listOne.Count - 1;
            int actual;

            //act
            for (int i = 0; i < 4; i++)
            {
                listOne.Add(i);
                listTwo.Add(i + 3);
            }

            subtractedList = listOne - listTwo;
            actual = subtractedList.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

        //if i subtract two lists from each other and more than one thing is subtracted the count should drop by that number
        [TestMethod]
        public void OverrideSubtract_SubtractTwoListsThatSubtractMoreThanOneValue_ReturnCountMinusThatValue()
        {
            //arrange
            var listOne = new CustomList<int>();
            var listTwo = new CustomList<int>();
            var subtractedList = new CustomList<int>();
            int expected = listOne.Count - 2;
            int actual;

            //act 
            for (int i = 0; i < 4; i++)
            {
                listOne.Add(i);
                listTwo.Add(i + 2);
            }
            subtractedList = listOne - listTwo;
            actual = subtractedList.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

        //if i subtract two lists from each other and all of list one is subtracted the count should be zero
        [TestMethod]
        public void OverrideSubtract_SubtractTwoListsAllListOneIsSubtracted_ReturnCountZero()
        {
            //arrange
            var listOne = new CustomList<int>();
            var listTwo = new CustomList<int>();
            var subtractedList = new CustomList<int>();
            int expected = 0;
            int actual;

            //act 
            for (int i = 0; i < 4; i++)
            {
                listOne.Add(i);
                listTwo.Add(i);
            }
            subtractedList = listOne - listTwo;
            actual = subtractedList.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
