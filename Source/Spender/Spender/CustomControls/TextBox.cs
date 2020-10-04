using System.ComponentModel;
using Xamarin.Forms;

namespace Spender.CustomControls
{
    [DesignTimeVisible(true)]
    public class TextBox : Entry
    {
        public int BorderRadius { get; set; } = 10;
        public Color BorderColor { get; set; }
        public int Border { get; set; }
        public Color TintColor { get; set; } = Color.FromHex("#95FFFFFF");
    }
}
