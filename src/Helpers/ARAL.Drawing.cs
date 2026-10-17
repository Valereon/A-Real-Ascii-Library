using Raylib_cs;
using A_Real_Ascii_Library.Helpers.Static;
using A_Real_Ascii_Library.BuiltInComponents;

namespace A_Real_Ascii_Library.Helpers;

public static partial class ARAL
{
    public static partial class Drawing
    {
        public static void DrawText(string text, Vector2 position, Color? color = null, float? fontSize = null, float spacing = 1f, Font? font = null)
        {
            RDrawText command = new RDrawText(text, position, color, fontSize, spacing, font, 0);
            Renderer.EnqueueCommand(command);
        }
        public static void DrawText(string text, Vector3 position, Color? color = null, float? fontSize = null, float spacing = 1f, Font? font = null)
        {
            DrawText(text, position.DropZ(), color, fontSize, spacing, font); 
        }
        public static void DrawText(string text, BuiltInComponents.Transform position, Color? color = null, float? fontSize = null, float spacing = 1f, Font? font = null)
        {
            DrawText(text, position.GetPosition().DropZ(), color, fontSize, spacing, font);
        }
    }
}