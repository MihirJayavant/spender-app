using Android.Content;
using Android.Graphics.Drawables;
using Spender.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TextBox), typeof(Spender.Droid.Renderers.TextBoxRenderer))]
namespace Spender.Droid.Renderers
{
    public class TextBoxRenderer : EntryRenderer
    {
        public TextBoxRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var element = e.NewElement;

            if (Control != null && element is TextBox entry)
            {
                GradientDrawable shape = new GradientDrawable();
                shape.SetColor(entry.TintColor.ToAndroid());
                shape.SetShape(ShapeType.Rectangle);
                shape.SetCornerRadius(entry.BorderRadius);
                Control.SetBackground(shape);
            }
        }
    }
}
