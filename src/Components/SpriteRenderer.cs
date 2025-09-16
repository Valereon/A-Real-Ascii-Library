using System.Net.Http.Headers;
using System.Numerics;
using System.Text.RegularExpressions;
using Raylib_cs;

public class SpriteRenderer : Component
{
    string sprite = "";
    string spritePath;


    public SpriteRenderer(string filePath)
    {
        filePath = FileSystem.MakePathAbsolute(filePath);
        spritePath = filePath;
        sprite = FileSystem.ReadFile(filePath);
        sprite = Regex.Replace(sprite, @"\r\n", "\n");
        Console.WriteLine(sprite);
    }


    public override void Update()
    {
        Raylib.DrawTextEx(Fonts.GetDefaultFont(), sprite, new Vector2(gameObject.transform.position.X, gameObject.transform.position.Y), 20, 1, Color.White);
    }



    void LoadSprite()
    {

    }
}