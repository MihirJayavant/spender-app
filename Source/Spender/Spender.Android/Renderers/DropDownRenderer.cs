using Android.Content;
using Android.Graphics.Drawables;
using Spender.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DropDown), typeof(Spender.Droid.Renderers.DropDownRenderer))]
namespace Spender.Droid.Renderers
{
    public class DropDownRenderer : PickerRenderer
    {
        public DropDownRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            var element = e.NewElement;

            if (Control != null && element is DropDown picker)
            {
                GradientDrawable shape = new GradientDrawable();
                shape.SetColor(picker.TintColor.ToAndroid());
                shape.SetShape(ShapeType.Rectangle);
                shape.SetCornerRadius(picker.BorderRadius);
                Control.SetBackground(shape);
            }
        }
    }
}