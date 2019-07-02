using MySquad.Models;
using MySquad.Services;
using NUnit.Framework;
using Xamarin.Forms.DragNDrop;
using Xamarin.Forms.DragNDrop.Models;

namespace Tests
{
    public class GroupedOrderableCollectionTests
    {
        private class TestSquad : OrderableCollection<string>
        {
            public string Title { get; set; }
            public TestSquad(string title)
            {
                Title = title;
            }
        }
        private GroupedOrderableCollection<TestSquad> squads;
        private MockDataStore mockSquadStore;
        [SetUp]
        public void Setup()
        {
            // arrange
            squads = new GroupedOrderableCollection<TestSquad>()
            {
                new TestSquad("Alpha")
                {
                    "AAAA",
                    "BBBB",
                },
                new TestSquad("Bravo")
                {
                    "CCCC",
                    "DDDD",
                }
                ,
                new TestSquad("Charlie")
                {
                    "EEEE",
                    "FFFF",
                    "GGGG",
                    "HHHH",
                    "IIII",
                    "JJJJ",
                }
            };

            mockSquadStore = new MockDataStore();
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 0)]
        [TestCase(5, 1)]
        [TestCase(6, 2)]
        [TestCase(12, 5)]
        public void GetNestedItemIndexFromFlatIndex_WithArgument_ReturnsNestedItemIndex(
            int flatIndex,
            int expectedNestIndex)
        {
            // act
            var result = squads.GetNestedItemIndexFromFlatIndex(flatIndex);

            // assert
            Assert.AreEqual(expectedNestIndex, result);
        }

        [Test]
        [TestCase(0, MoveDirection.Up, 0)]
        [TestCase(-1, MoveDirection.Up, 0)]
        [TestCase(1, MoveDirection.Up, 0)]
        [TestCase(2, MoveDirection.Up, 0)]
        [TestCase(3, MoveDirection.Up, 0)]
        [TestCase(3, MoveDirection.Down, 1)]
        [TestCase(4, MoveDirection.Up, 1)]
        [TestCase(5, MoveDirection.Up, 1)]
        [TestCase(6, MoveDirection.Up, 1)]
        [TestCase(7, MoveDirection.Up, 2)]
        [TestCase(8, MoveDirection.Up, 2)]
        [TestCase(12, MoveDirection.Up, 2)]
        public void GetNestedCollectionFromFlatIndex_WithRootNestedCollection_ReturnCollection(
            int flatIndex,
            MoveDirection moveDirection,
            int expectedGroupIndex
            )
        {
            // act
            var result = squads.GetNestedCollectionFromFlatIndex(flatIndex, moveDirection);

            // assert
            CollectionAssert.AreEqual(squads[expectedGroupIndex], result);
        }

        [Test]
        [TestCase(3, 0)]
        [TestCase(1, 1)]
        public void ChangeOrdinal_ItemInGroupBMovesToEndOfGroupA_GroupHasCorrectCount(int expected, int groupIndex)
        {
            // act
            const int OldFlatIndex = 4;
            const int NewFlatIndex = 3;
            squads.ChangeOrdinal(OldFlatIndex, NewFlatIndex);

            Assert.AreEqual(expected, squads[groupIndex].Count);
        }

        [Test]
        [TestCase(9, 10, 2, 2, "HHHH", Description = "Moving a middle item down with another middle item in same group, checking top item")]
        [TestCase(9, 10, 3, 2, "GGGG", Description = "Moving a middle item down with another middle item in same group, checking bottom item")]
        [TestCase(10, 9, 2, 2, "HHHH", Description = "Moving a middle item up with another middle item in same group, checking top item")]
        [TestCase(10, 9, 3, 2, "GGGG", Description = "Moving a middle item up with another middle item in same group, checking bottom item")]
        [TestCase(4, 2, 1, 0, "CCCC", Description = "Moving first item up in group B to the middle of group A, checking group A middle")]
        [TestCase(4, 2, 0, 1, "DDDD", Description = "Moving first item up in group B to the middle of group A, checking group B first item")]
        [TestCase(1, 2, 0, 0, "BBBB", Description = "Switching First and Last item moving down in a size 2 list, checking firstitem")]
        [TestCase(2, 1, 0, 0, "BBBB", Description = "Switching First and Last item moving up in a size 2 list, checking firstitem")]
        [TestCase(2, 4, 0, 0, "AAAA", Description = "Moving last item down from group A to middle of group B, checking group A")]
        [TestCase(2, 4, 1, 1, "BBBB", Description = "Moving last item down from group A to middle of group B, checking group B middle")]
        [TestCase(5, 6, 0, 2, "DDDD", Description = "Moving last item down from group B to top of group C, checking group C top")]
        public void ChangeOrdinal_MoveItem_ItemHasCorrectPosition(
            int oldFlatIndex,
            int newFlatIndex,
            int itemIndex,
            int groupIndex,
            string expected
            )
        {
            // act
            squads.ChangeOrdinal(oldFlatIndex, newFlatIndex);

            Assert.AreEqual(expected, squads[groupIndex][itemIndex]);
        }

        [Test]
        public void ChangeOrdinal_MoveMarine_ItemHasCorrectPosition()
        {

        }
    }
}