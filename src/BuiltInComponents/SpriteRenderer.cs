using System.Text.RegularExpressions;
using A_Real_Ascii_Library.Helpers;
using A_Real_Ascii_Library.Helpers.Static;
using Raylib_cs;

namespace A_Real_Ascii_Library.BuiltInComponents;

public class SpriteRenderer : Component, IRenderable
{
    public int fontSize = 20;
    string sprite = "";
    string spriteFilePath;
    public int spacing = 1;
    public Color color = Color.White;

    public int layer {get;} = 0;

    public override void Update()
    {
        
    }

    public void Render()
    {
        ARAL.Drawing.DrawText(sprite, gameObject.Transform, color, fontSize, spacing);
    }

    public void LoadSprite(string filePath)
    {
        spriteFilePath = filePath;
        sprite = FileSystem.ReadFile(filePath);
        sprite = Regex.Replace(sprite, @"\r\n", "\n");
    }

    public void ReloadSprite()
    {
        sprite = FileSystem.ReadFile(spriteFilePath);
        sprite = Regex.Replace(sprite, @"\r\n", "\n");
    }
}