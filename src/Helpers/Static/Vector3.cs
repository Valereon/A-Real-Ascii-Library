namespace A_Real_Ascii_Library.Helpers.Static;

public class Vector3
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

    public System.Numerics.Vector3 ToNumerics()
    {
        return new System.Numerics.Vector3(x, y, z);
    }

    public Num AsNum()
    {
        return new Num(new Vector3(x, y, z));
    }

    public Vector2 DropZ()
    {
        return new Vector2(x, y);
    }

    public Vector2 DropY(Vector3 vector)
    {
        return new Vector2(vector.x, vector.z);
    }

    public Vector2 DropX(Vector3 vector)
    {
        return new Vector2(vector.y, vector.z);
    }


    public override string ToString()
    {
        return $"{x} {y} {z}";
    }
}

public class Num
{
    private Vector3 _vector;

    public Num(Vector3 vector)
    {
        this._vector = vector;
    }

    public System.Numerics.Vector2 DropZ()
    {
        return new System.Numerics.Vector2(_vector.x, _vector.y);
    }

    public System.Numerics.Vector2 DropY()
    {
        return new System.Numerics.Vector2(_vector.x, _vector.z);
    }

    public System.Numerics.Vector2 DropX()
    {
        return new System.Numerics.Vector2(_vector.y, _vector.z);
    }

    public Vector3 ToVec3()
    {
        return _vector;
    }
}