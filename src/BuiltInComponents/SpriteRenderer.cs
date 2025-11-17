using System.Text.RegularExpressions;
using A_Real_Ascii_Library.Helpers.Static;
using Raylib_cs;

namespace A_Real_Ascii_Library.BuiltInComponents;

public class SpriteRenderer : Component
{
    public int fontSize = 20;
    string sprite = "";
    string spritePath;
    public int spacing = 1;
    public Color color = Color.White;


    public SpriteRenderer(string filePath)
    {
        LoadSprite(filePath);
    }


    public override void Update()
    {
        System.Numerics.Vector2 newVec2 = gameObject.transform.GetPosition().AsNum().DropZ();
        Raylib.DrawTextEx(Fonts.GetDefaultFont(), sprite, newVec2, fontSize, spacing, color);
    }



    void LoadSprite(string filePath)
    {
        filePath = FileSystem.MakePathAbsolute(filePath);
        spritePath = filePath;
        sprite = FileSystem.ReadFile(filePath);
        sprite = Regex.Replace(sprite, @"\r\n", "\n");
    }
}