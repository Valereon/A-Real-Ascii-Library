namespace A_Real_Ascii_Library.Helpers.Static;
public class Vector2
{
    public float x, y;


    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    
    
    public System.Numerics.Vector2 AsNum()
    {
        return new System.Numerics.Vector2(x, y);
    }
}