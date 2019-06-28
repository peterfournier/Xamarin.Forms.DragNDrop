using System.Linq;

namespace Xamarin.Forms.DragNDrop
{
    public static class Sorting
    {
        public static readonly BindableProperty IsSortableProperty =
            BindableProperty.CreateAttached(
                "IsSortable",
                typeof(bool),
                typeof(ListViewSortableEffect), false,
                propertyChanged: OnIsSortabbleChanged
                );

        public static bool GetIsSortable(BindableObject view)
        {
            return (bool)view.GetValue(IsSortableProperty);
        }

        public static void SetIsSortable(BindableObject view, bool value)
        {
            view.SetValue(IsSortableProperty, value);
        }

        static void OnIsSortabbleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as ListView;
            if (view == null)
            {
                return;
            }

            if (!view.Effects.Any(item => item is ListViewSortableEffect))
            {
                view.Effects.Add(new ListViewSortableEffect());
            }
        }

        class ListViewSortableEffect : RoutingEffect
        {
            public ListViewSortableEffect() : base($"Xamarin.Forms.DragNDrop.{nameof(ListViewSortableEffect)}")
            {

            }
        }
    }
}
