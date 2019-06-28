namespace Xamarin.Forms.DragNDrop
{
    /// <summary>
    /// Used by bound collections to expose item retrieval 
    /// </summary>
    public interface IGroupedOrderable
    {
        /// <summary>
        /// Get's the nested Item from an index of a flat list
        /// </summary>
        /// <param name="flatIndex"></param>
        /// <returns></returns>
        object GetItemFromFlatIndex(long flatIndex);
    }
}
