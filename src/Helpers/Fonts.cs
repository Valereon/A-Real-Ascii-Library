using System.Data;
using Raylib_cs;

static class Fonts
{

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
        StateManager.DEFAULT_FONT = font;
    }

    public static Font GetDefaultFont()
    {
        return StateManager.DEFAULT_FONT;
    }



}