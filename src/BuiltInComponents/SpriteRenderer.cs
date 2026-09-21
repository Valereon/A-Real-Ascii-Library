using System.Text.RegularExpressions;
using A_Real_Ascii_Library.Helpers;
using A_Real_Ascii_Library.Helpers.Static;
using Raylib_cs;

namespace A_Real_Ascii_Library.BuiltInComponents;

public class SpriteRenderer : Component, IRenderable
{
    public int fontSize = 20;
    string sprite = "";
    string spritePath;
    public int spacing = 1;
    public Color color = Color.White;

    public override void Update()
    {
        
    }

    public void Render()
    {
        ARAL.Drawing.DrawText(sprite, gameObject.transform, color, fontSize, spacing);
    }

    public void LoadSprite(string filePath)
    {
        spritePath = filePath;
        sprite = FileSystem.ReadFile(filePath);
        sprite = Regex.Replace(sprite, @"\r\n", "\n");
    }

    public void ReloadSprite()
    {
        sprite = FileSystem.ReadFile(spritePath);
        sprite = Regex.Replace(sprite, @"\r\n", "\n");
    }
}