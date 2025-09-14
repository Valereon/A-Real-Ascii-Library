using Raylib_cs;

public class PlayerMovement : Component
{
    public override void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            gameObject.transform.position.X += 10;
        }
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            gameObject.transform.position.X -= 10;
        }
        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            gameObject.transform.position.Y -= 10;
        }
        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            gameObject.transform.position.Y += 10;
        }
    }
}