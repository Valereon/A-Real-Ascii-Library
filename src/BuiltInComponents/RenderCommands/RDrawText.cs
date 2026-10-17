using A_Real_Ascii_Library.Helpers.Static;
using Raylib_cs;

public struct RDrawText : IRenderCommand2D
{
    public RDrawText(string text, Vector2 position, Color? color = null, float? fontSize = null, float? spacing = null, Font? font = null, int? layer=null)
    {
        this.Layer = layer ?? 0;
        this.text = text;
        this.position = position;
        this.color = color ?? Fonts.GetDefaultFontColor();
        this.fontSize = fontSize ?? Fonts.GetDefaultFontSize();
        this.spacing = spacing ?? Fonts.GetDefaultFontSpacing();
        this.font = font ?? Fonts.GetDefaultFont();
    }
    public int Layer {get; set;}
    string text;
    Vector2 position;
    Color color;
    float fontSize;
    float spacing;
    Font font;


    public void Execute()
    {
        Raylib.DrawTextEx(font, text, position.AsNum(), fontSize, spacing, color);
    }
}