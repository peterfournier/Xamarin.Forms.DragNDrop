using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Xamarin.Forms.DragNDrop
{
    public class OrderableCollection<TModel> : ObservableCollection<TModel>, IOrderable
    {
        public virtual event EventHandler OrderChanged;

        public virtual void ChangeOrdinal(int oldIndex, int newIndex)
        {
            var priorIndex = oldIndex;
            var latterIndex = newIndex;

            var changedItem = Items[oldIndex];
            if (newIndex < oldIndex)
            {
                // add one to where we delete, because we're increasing the index by inserting
                priorIndex += 1;
            }
            else
            {
                // add one to where we insert, because we haven't deleted the original yet
                latterIndex += 1;
            }

            Items.Insert(latterIndex, changedItem);
            Items.RemoveAt(priorIndex);

            OrderChanged?.Invoke(this, EventArgs.Empty);

            OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Move,
                    changedItem,
                    newIndex,
                    oldIndex));
        }
    }
}
