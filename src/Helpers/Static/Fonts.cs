using System.Data;
using Raylib_cs;
namespace A_Real_Ascii_Library.Helpers.Static;
static class Fonts
{
    static int DefaultFontSize = 20;
    static Font DEFAULT_FONT;
    static Color DEFAULT_FONT_COLOR = Color.Black;
    public static Font LoadFont(string fileLocation)
    {
        Font font = Raylib.LoadFontEx(fileLocation, 256, null, 0);
        StateManager.loadedFonts.Add(font);
        return font;
    }

    public static void UnloadFont(Font font)
    {
        Raylib.UnloadFont(font);
        StateManager.loadedFonts.Remove(font);
    }

    public static void SetFontSize(Font font, int newSize)
    {
        font.BaseSize = newSize;
    }

    public static void SetDefaultFontSize(int size)
    {
        DefaultFontSize = size;
    }

    public static int GetDefaultFontSize()
    {
        return DefaultFontSize;
    }

    public static void SetFontFilterToPoint(Font font)
    {
        Raylib.SetTextureFilter(font.Texture, TextureFilter.Point);
    }

    public static void SetFontFilterToBilinear(Font font)
    {
        Raylib.SetTextureFilter(font.Texture, TextureFilter.Bilinear);
    }

    public static void SetFontFilterToTrilinear(Font font)
    {
        Raylib.GenTextureMipmaps(ref font.Texture);
        Raylib.SetTextureFilter(font.Texture, TextureFilter.Trilinear);
    }

    public static void SetDefaultFont(Font font)
    {
        DEFAULT_FONT = font;
    }

    public static Font GetDefaultFont()
    {
        return DEFAULT_FONT;
    }

    public static Color GetDefaultFontColor()
    {
        return DEFAULT_FONT_COLOR;
    }

    public static void SetDefaultFontColor(Color color)
    {
        DEFAULT_FONT_COLOR = color;
    }



}