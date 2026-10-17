using System.Data;
using Raylib_cs;
namespace A_Real_Ascii_Library.Helpers.Static;
static class Fonts
{
    static int _defaultFontSize = 20;
    static float _defaultFontSpacing = 1f;
    static Font _defaultFont;
    static Color _defaultFontColor = Color.Black;
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
        _defaultFontSize = size;
    }

    public static int GetDefaultFontSize()
    {
        return _defaultFontSize;
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
        _defaultFont = font;
    }

    public static Font GetDefaultFont()
    {
        return _defaultFont;
    }

    public static Color GetDefaultFontColor()
    {
        return _defaultFontColor;
    }

    public static void SetDefaultFontColor(Color color)
    {
        _defaultFontColor = color;
    }

    public static float GetDefaultFontSpacing()
    {
        return _defaultFontSpacing;
    }
    public static void SetDefaultFontSpacing(float fontSpacing)
    {
        _defaultFontSpacing = fontSpacing;
    }

}