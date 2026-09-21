using Raylib_cs;
using A_Real_Ascii_Library.Helpers.Static;
namespace A_Real_Ascii_Library.BuiltInComponents;

public class RigidBody : Component
{

    public bool hasGravity = true;
    public float gravityScale = 1.0f;


    public override void Update()
    {
        Vector3 objectPosition = gameObject.transform.GetPosition();


        // if(isUsingGravity)
            


        
    }
}