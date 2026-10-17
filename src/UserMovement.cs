using A_Real_Ascii_Library.BuiltInComponents;
using Raylib_cs;

namespace A_Real_Ascii_Library;

public class UserMovement : Component
{

    int i = 0;

    public override void Update()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.C))
        {
            gameObject.AddComponent<PlayerMovement>();
        }

        if (Raylib.IsKeyPressed(KeyboardKey.F))
        {
            gameObject.RemoveComponent<PlayerMovement>();
        }
        if (Raylib.IsKeyPressed(KeyboardKey.G))
        {
            gameObject.AddComponent<SpriteRenderer>();
        }

        if (Raylib.IsKeyPressed(KeyboardKey.V))
            gameObject.RemoveComponent<SpriteRenderer>();


    }
}