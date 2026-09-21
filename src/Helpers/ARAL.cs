using Raylib_cs;
using A_Real_Ascii_Library.Helpers.Static;
using A_Real_Ascii_Library.BuiltInComponents;

namespace A_Real_Ascii_Library.Helpers;

public static class ARAL
{
    public static class Drawing
    {
        public static void DrawText(string text, BuiltInComponents.Transform transform)
        {
            Raylib.DrawTextEx(Fonts.GetDefaultFont(), text, transform.GetPosition().DropZ().AsNum(), Fonts.GetDefaultFontSize(), 1f,
                Fonts.GetDefaultFontColor());
        }

        public static void DrawText(string text, BuiltInComponents.Transform transform, Color color)
        {
            Raylib.DrawTextEx(Fonts.GetDefaultFont(), text, transform.GetPosition().DropZ().AsNum(), Fonts.GetDefaultFontSize(), 1f,
                color);
        }

        public static void DrawText(string text, BuiltInComponents.Transform transform, Color color, float fontSize)
        {
            Raylib.DrawTextEx(Fonts.GetDefaultFont(), text, transform.GetPosition().DropZ().AsNum(), fontSize, 1f,
                color);
        }
        public static void DrawText(string text, BuiltInComponents.Transform transform, Color color, float fontSize,
            float spacing)
        {
            Raylib.DrawTextEx(Fonts.GetDefaultFont(), text, transform.GetPosition().DropZ().AsNum(), fontSize, spacing,
                color);
        }
        public static void DrawText(string text, BuiltInComponents.Transform transform, Color color, float fontSize, float spacing,
            Font font)
        {
            Raylib.DrawTextEx(font, text, transform.GetPosition().DropZ().AsNum(), fontSize, spacing,
                color);
        }
    }
}