using Raylib_cs;
using A_Real_Ascii_Library.Helpers.Static;
namespace A_Real_Ascii_Library.BuiltInComponents;

public class PlayerMovement : Component
{
    float movementStep = 20f;

    public override void Update()
    {
        Vector3 position = gameObject.Transform.GetPosition();
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            position.x += movementStep;
        }
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            position.x -= movementStep;
        }
        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            position.y -= movementStep;
        }
        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            position.y += movementStep;
        }
        gameObject.Transform.SetPosition(position);
        
    }
}