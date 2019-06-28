using System;
using System.Collections;

namespace Xamarin.Forms.DragNDrop
{
    public sealed class GroupedOrderableCollectionChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Object that moved
        /// </summary>
        public object ChangedObject { get; set; }
        /// <summary>
        /// Old group
        /// </summary>
        public IList OldGroup { get; set; }
        /// <summary>
        /// New group
        /// </summary>
        public IList NewGroup { get; set; }

        /// <summary>
        /// Pior index from old group
        /// </summary>
        public int OldIndex { get; set; }
        /// <summary>
        /// New index in new group
        /// </summary>
        public int NewIndex { get; set; }

        public GroupedOrderableCollectionChangedEventArgs(
            object changedObject,
            IList oldGroup,
            IList newGroup,
            int oldIndex,
            int newIndex
            )
        {
            ChangedObject = changedObject;
            OldGroup = oldGroup;
            NewGroup = newGroup;
            OldIndex = oldIndex;
            NewIndex = newIndex;
        }
    }
}
