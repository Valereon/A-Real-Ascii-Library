using A_Real_Ascii_Library.Helpers;
using A_Real_Ascii_Library.Helpers.Static;
using Raylib_cs;

namespace A_Real_Ascii_Library.BuiltInComponents;

public class TextDisplay : Component, IRenderable
{
    public int fontSize = 20;
    public string text = "";
    public int spacing = 1;
    public Color color = Color.White;

    public int layer {get;} = 0;

    public void Render()
    {
        ARAL.Drawing.DrawText(text, gameObject.Transform, Color.White);
    }
}