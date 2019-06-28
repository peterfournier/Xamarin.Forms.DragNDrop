using AViews = Android.Views;

namespace Xamarin.Forms.DragNDrop.Droid
{
    public class DragItem : Java.Lang.Object
    {
        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// 
        /// The initial index for the data item.
        /// 
        /// 
        /// The view element that is being dragged.
        /// 
        /// 
        /// The data item that is bound to the view.
        /// 
        public DragItem(int index, AViews.View view, object dataItem)
        {
            OriginalIndex = Index = index;
            View = view;
            Item = dataItem;
        }

        /// <summary>
        /// Gets or sets the current index for the data item.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets the original index for the data item
        /// </summary>
        public int OriginalIndex { get; }

        /// <summary>
        /// Gets the data item that is being dragged
        /// </summary>
        public object Item { get; }

        /// <summary>
        /// Gets the view that is being dragged
        /// </summary>
        public AViews.View View { get; }
    }
}
