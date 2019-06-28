using System;
using System.Collections;

namespace Xamarin.Forms.DragNDrop.Models
{
    public class GroupedOrderableCollection<TModel> : OrderableCollection<TModel>, IGroupedOrderable, IOrderable
        where TModel : IList, IOrderable
    {

        #region Fields & Props
        public new event EventHandler<GroupedOrderableCollectionChangedEventArgs> OrderChanged;
        #endregion


        #region Contructor(s)

        #endregion


        #region Public Methods
        #region IOrderable
        public override void ChangeOrdinal(int oldFlatIndex, int newFlatIndex)
        {
            if (newFlatIndex == 0)
                return;

            var moveDirection = oldFlatIndex < newFlatIndex ? MoveDirection.Down : MoveDirection.Up;
            var priorFlatIndex = oldFlatIndex;
            var latterFlatIndex = newFlatIndex;

            var oldList = GetNestedCollectionFromFlatIndex(priorFlatIndex, moveDirection);
            var newList = GetNestedCollectionFromFlatIndex(latterFlatIndex, moveDirection);

            var changedItem = GetItemFromFlatIndex(priorFlatIndex);

            if (moveDirection == MoveDirection.Up)
            {
                // add one to where we delete, because we're increasing the index by inserting
                if (oldList.Equals(newList))
                    priorFlatIndex += 1;
            }
            else
            {
                // add one to where we insert, because we haven't deleted the original yet
                latterFlatIndex += 1;
            }

            var priorNestedIndex = GetNestedItemIndexFromFlatIndex(priorFlatIndex);
            var latterNestedIndex = GetNestedItemIndexFromFlatIndex(latterFlatIndex);


            newList.Insert(latterNestedIndex, changedItem);
            oldList.RemoveAt(priorNestedIndex);

            OrderChanged?.Invoke(
                this,
                new GroupedOrderableCollectionChangedEventArgs(changedItem,
                                                                oldList,
                                                                newList,
                                                                priorNestedIndex,
                                                                latterNestedIndex)
                );
        }
        #endregion


        #region IGroupedOrderable
        public object GetItemFromFlatIndex(long flatIndex)
        {
            object item = null;

            do
            {
                int currentTotalIndex = -1;
                foreach (var group in this)
                {
                    currentTotalIndex++;
                    foreach (var i in group)
                    {
                        currentTotalIndex++;

                        if (currentTotalIndex == flatIndex)
                            item = i;
                    }
                }

            } while (item == null);

            return item;
        }
        #endregion

        public int GetNestedItemIndexFromFlatIndex(int flatIndex)
        {
            if (flatIndex < 1)
                return 0;

            int currentFlatIndex = 0;
            foreach (var group in this)
            {
                int nestedIndex = 0;
                currentFlatIndex++;

                foreach (var item in group)
                {
                    if (currentFlatIndex == flatIndex)
                        return nestedIndex++;

                    currentFlatIndex++;
                    nestedIndex++;
                }

                if (currentFlatIndex == flatIndex)
                    return nestedIndex;

            }
            return -1;
        }

        public IList GetNestedCollectionFromFlatIndex(int flatIndex, MoveDirection direction)
        {
            if (flatIndex < 1)
                return this[0];

            int currentFlatIndex = 0;
            foreach (var group in this)
            {
                if (currentFlatIndex == flatIndex
                    && direction == MoveDirection.Down)
                    return group;

                currentFlatIndex++;


                foreach (var item in group)
                {
                    if (currentFlatIndex == flatIndex)
                        return group;

                    currentFlatIndex++;
                }

                if (currentFlatIndex == flatIndex
                    && direction == MoveDirection.Up)
                    return group;

            }

            return null;
        }
        #endregion


        #region Private Methods

        #endregion
    }
}
