using System.Numerics;
using Raylib_cs;

public class SpriteRenderer : Component
{
    string sprite = "\\_0_/";
    string spritePath;

    public override void Update()
    {
        Raylib.DrawTextEx(Fonts.GetDefaultFont(), sprite, new Vector2(gameObject.transform.position.X, gameObject.transform.position.Y), gameObject.transform.scale.X + gameObject.transform.scale.Y, 0, Color.Black);
    }



    void LoadSprite()
    {
        
    }
}