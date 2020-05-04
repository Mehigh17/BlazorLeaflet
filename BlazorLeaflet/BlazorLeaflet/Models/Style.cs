using System.Drawing;

namespace BlazorLeaflet.Models
{
    public class Style
    {
        public Color Color { get; set; } = Color.FromArgb(0x33, 0x88, 0xFF);

        public int Weight { get; set; } = 3;

        public float Opacity { get; set; } = 1;
    }
}
