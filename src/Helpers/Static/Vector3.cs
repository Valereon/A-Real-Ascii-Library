namespace A_Real_Ascii_Library.Helpers.Static;

public struct Vector3
{
    public float x, y, z;


    public static Vector3 zero => new Vector3(0, 0, 0);
    public static Vector3 one => new Vector3(1, 1, 1);
    public static Vector3 up => new Vector3(0, 1, 0);
    public static Vector3 down => new Vector3(0, -1, 0);
    public static Vector3 left => new Vector3(-1, 0, 0);
    public static Vector3 right => new Vector3(1, 0, 0);
    public static Vector3 forward => new Vector3(0, 0, 1);
    public static Vector3 back => new Vector3(0, 0, -1);

    public Vector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Num AsNum()
    {
        return new Num(this);
    }

    public Vector2 DropZ()
    {
        return new Vector2(x, y);
    }

    public Vector2 DropY()
    {
        return new Vector2(x, z);
    }

    public Vector2 DropX()
    {
        return new Vector2(y, z);
    }


    public override string ToString()
    {
        return $"{x} {y} {z}";
    }
}

public class Num
{
    private System.Numerics.Vector3 _vector;

    public Num(Vector3 vector)
    {
        _vector = new(vector.x, vector.y, vector.z);
    }
    
    public System.Numerics.Vector3 GetVector()
    {
        return _vector;
    }


    public System.Numerics.Vector2 DropZ()
    {
        return new System.Numerics.Vector2(_vector.X, _vector.Y);
    }

    public System.Numerics.Vector2 DropY()
    {
        return new System.Numerics.Vector2(_vector.X, _vector.Z);
    }

    public System.Numerics.Vector2 DropX()
    {
        return new System.Numerics.Vector2(_vector.Z, _vector.Z);
    }

    public Vector3 ToARALVec3()
    {
        return new Vector3(_vector.X, _vector.Y, _vector.Z);
    }
}