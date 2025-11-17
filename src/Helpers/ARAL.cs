using Raylib_cs;
using A_Real_Ascii_Library.Helpers.Static;

namespace A_Real_Ascii_Library.Helpers;

public static class ARAL
{
    public static class Drawing
    {
        public static void DrawText(string text, Vector2 position)
        {
            Raylib.DrawTextEx(Fonts.GetDefaultFont(), text, position.AsNum(), Fonts.GetDefaultFontSize(), 1f,
                Fonts.GetDefaultFontColor());
        }

        public static void DrawText(string text, Vector2 position, Color color)
        {
            Raylib.DrawTextEx(Fonts.GetDefaultFont(), text, position.AsNum(), Fonts.GetDefaultFontSize(), 1f,
                color);
        }

        public static void DrawText(string text, Vector2 position, Color color, float fontSize)
        {
            Raylib.DrawTextEx(Fonts.GetDefaultFont(), text, position.AsNum(), fontSize, 1f,
                color);
        }

        public static void DrawText(string text, Vector2 position, Color color, Color fontColor, float fontSize,
            Font font)
        {
            Raylib.DrawTextEx(font, text, position.AsNum(), fontSize, 1f,
                color);
        }

        public static void DrawText(string text, Vector2 position, Color color, Color fontColor, float fontSize,
            Font font, float spacing)
        {
            Raylib.DrawTextEx(font, text, position.AsNum(), fontSize, spacing,
                color);
        }
    }
}