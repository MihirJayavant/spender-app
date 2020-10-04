
using System.ComponentModel;
using Xamarin.Forms;

namespace Spender.CustomControls
{
    [DesignTimeVisible(true)]
    public class FAB : Button
    {
        public int Elevation { get; set; } = 0;
        public Color RippleColor { get; set; }
        public Color TintColor { get; set; }
    }
}
