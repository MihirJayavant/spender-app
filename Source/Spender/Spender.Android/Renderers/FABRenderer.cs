using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Spender.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FAB), typeof(Spender.Droid.Renderers.FABRenderer))]
namespace Spender.Droid.Renderers
{
    public class FABRenderer : ButtonRenderer
    {
        public FABRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            var element = e.NewElement;

            if (Control != null && element is FAB button)
            {
                GradientDrawable shape = new GradientDrawable();
                shape.SetColor(button.TintColor.ToAndroid());
                shape.SetShape(ShapeType.Oval);

                int[][] colorlist = new int[1][];

                colorlist[0] = new int[] { Android.Resource.Attribute.StatePressed };

                var statelist = new ColorStateList(colorlist, new int[] { button.RippleColor.ToAndroid() });

                RippleDrawable ripple = new RippleDrawable(statelist, shape, null);

                Control.SetElevation(button.Elevation);
                Control.StateListAnimator = null;
                Control.SetBackground(ripple);
            }
        }
    }
}