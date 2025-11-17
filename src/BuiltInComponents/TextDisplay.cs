using A_Real_Ascii_Library.Helpers;
using A_Real_Ascii_Library.Helpers.Static;
using Raylib_cs;

namespace A_Real_Ascii_Library.BuiltInComponents;

public class TextDisplay : Component
{
    public int fontSize = 20;
    public string text = "";
    public int spacing = 1;
    public Color color = Color.White;

    public TextDisplay(string textToDisplay)
    {
        text = textToDisplay;
    }


    public override void Update()
    {
        Vector2 newVec2 = gameObject.transform.GetPosition().DropZ();
        ARAL.Drawing.DrawText(text, newVec2, Color.White);
        // Raylib.DrawTextEx(Fonts.GetDefaultFont(), text, newVec2, fontSize, spacing, color);
    }
}