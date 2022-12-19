using System.Drawing;

namespace Eve_Mining.Tools
{
    internal static class ColorExt
    {
        internal static uint ToUint(this Color _c)
        {
            return (uint)(((_c.A << 24) | (_c.R << 16) | (_c.G << 8) | _c.B) & 0xffffffffL);
        }

        internal static Color ToColor(this uint _uiValue)
        {
            return Color.FromArgb((byte)((_uiValue >> 24) & 0xFF),
                       (byte)((_uiValue >> 16) & 0xFF),
                       (byte)((_uiValue >> 8) & 0xFF),
                       (byte)(_uiValue & 0xFF));
        }

        internal static Color BasedColorFromHue6(this uint _uiValue)
        {
            return _uiValue.ToColor().BasedColorFromHue6();
        }

        internal static Color BasedColorFromHue6(this Color _c)
        {
            float h = _c.GetHue();

            if ((h >= 0f && h < 60f) || h == 360)
                return ColorTranslator.FromHtml("#FF0000"); // red
            else if (h >= 60f && h < 120f)
                return ColorTranslator.FromHtml("#FFFF00"); // yellow (web color)=lemon yellow
            else if (h >= 120f && h < 180f)
                return ColorTranslator.FromHtml("#00FF00"); // green
            else if (h >= 180f && h < 240f)
                return ColorTranslator.FromHtml("#00FFFF"); // turquoise blue, cyan (web color)
            else if (h >= 240f && h < 300f)
                return ColorTranslator.FromHtml("#0000FF"); // blue (web color)=ultramarine
            else if (h >= 300f && h < 360f)
                return ColorTranslator.FromHtml("#FF00FF"); // magenta(web color)
            else
                return Color.White;
        }

        internal static Color BasedColorFromHue12(this uint _uiValue)
        {
            return _uiValue.ToColor().BasedColorFromHue6();
        }

        internal static Color BasedColorFromHue12(this Color _c)
        {
            float h = _c.GetHue();

            if ((h >= 0f && h < 30f) || h == 360)
                return ColorTranslator.FromHtml("#FF0000"); // red
            else if (h >= 30f && h < 60f)
                return ColorTranslator.FromHtml("#FF8000"); // orange
            else if (h >= 60f && h < 90f)
                return ColorTranslator.FromHtml("#FFFF00"); // yellow (web color)=lemon yellow
            else if (h >= 90f && h < 120f)
                return ColorTranslator.FromHtml("#80FF00"); // yellowish green, chartreuse
            else if (h >= 120f && h < 150f)
                return ColorTranslator.FromHtml("#00FF00"); // green
            else if (h >= 150f && h < 180f)
                return ColorTranslator.FromHtml("#00FF80"); // emerald green
            else if (h >= 180f && h < 210f)
                return ColorTranslator.FromHtml("#00FFFF"); // turquoise blue, cyan (web color)
            else if (h >= 210f && h < 240f)
                return ColorTranslator.FromHtml("#0080FF"); // azure
            else if (h >= 240f && h < 270f)
                return ColorTranslator.FromHtml("#0000FF"); // blue (web color)=ultramarine
            else if (h >= 270f && h < 300f)
                return ColorTranslator.FromHtml("#8000FF"); // violet
            else if (h >= 300f && h < 330f)
                return ColorTranslator.FromHtml("#FF00FF"); // magenta(web color)
            else if (h >= 330f && h < 360f)
                return ColorTranslator.FromHtml("#FF0080"); // ruby red, crimson
            else
                return Color.White;
        }

        internal static Color BasedColorFromHue24(this uint _uiValue)
        {
            return _uiValue.ToColor().BasedColorFromHue6();
        }

        internal static Color BasedColorFromHue24(this Color _c)
        {
            float h = _c.GetHue();

            if ((h >= 0f && h < 15f) || h == 360)
                return ColorTranslator.FromHtml("#FF0000"); // red
            else if (h >= 15f && h < 30f)
                return ColorTranslator.FromHtml("#FF4000"); // vermilion
            else if (h >= 30f && h < 45f)
                return ColorTranslator.FromHtml("#FF8000"); // orange
            else if (h >= 45f && h < 60f)
                return ColorTranslator.FromHtml("#FFBF00"); // golden yellow
            else if (h >= 60f && h < 75f)
                return ColorTranslator.FromHtml("#FFFF00"); // yellow (web color)=lemon yellow
            else if (h >= 75f && h < 90f)
                return ColorTranslator.FromHtml("#BFFF00"); // yellowish green
            else if (h >= 90f && h < 105f)
                return ColorTranslator.FromHtml("#80FF00"); // yellowish green, chartreuse
            else if (h >= 105f && h < 120f)
                return ColorTranslator.FromHtml("#40FF00"); // leaf green
            else if (h >= 120f && h < 135f)
                return ColorTranslator.FromHtml("#00FF00"); // green
            else if (h >= 135f && h < 150f)
                return ColorTranslator.FromHtml("#00FF40"); // cobalt green
            else if (h >= 150f && h < 165f)
                return ColorTranslator.FromHtml("#00FF80"); // emerald green
            else if (h >= 165f && h < 180f)
                return ColorTranslator.FromHtml("#00FFBF"); // turquoise green, bluish green
            else if (h >= 180f && h < 195f)
                return ColorTranslator.FromHtml("#00FFFF"); // turquoise blue, cyan (web color)
            else if (h >= 195f && h < 210f)
                return ColorTranslator.FromHtml("#00BFFF"); // cerulean blue
            else if (h >= 210f && h < 225f)
                return ColorTranslator.FromHtml("#0080FF"); // azure
            else if (h >= 225f && h < 240f)
                return ColorTranslator.FromHtml("#0040FF"); // blue, cobalt blue
            else if (h >= 240f && h < 255f)
                return ColorTranslator.FromHtml("#0000FF"); // blue (web color)=ultramarine
            else if (h >= 255f && h < 270f)
                return ColorTranslator.FromHtml("#4000FF"); // hyacinth
            else if (h >= 270f && h < 285f)
                return ColorTranslator.FromHtml("#8000FF"); // violet
            else if (h >= 285f && h < 300f)
                return ColorTranslator.FromHtml("#BF00FF"); // purple
            else if (h >= 300f && h < 315f)
                return ColorTranslator.FromHtml("#FF00FF"); // magenta(web color)
            else if (h >= 315f && h < 330f)
                return ColorTranslator.FromHtml("#FF00BF"); // reddish purple
            else if (h >= 330f && h < 345f)
                return ColorTranslator.FromHtml("#FF0080"); // ruby red, crimson
            else if (h >= 345f && h < 360f)
                return ColorTranslator.FromHtml("#FF0040"); // carmine
            else
                return Color.White;
        }
    }
}
