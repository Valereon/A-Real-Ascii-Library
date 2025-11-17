
namespace A_Real_Ascii_Library.BuiltInComponents;
using A_Real_Ascii_Library.Helpers.Static;
public class Transform : Component
{
    public Transform parent;
    public Transform child;
    private Vector3 position;
    private Vector3 localPosition;
    private Vector3 rotation;
    private Vector3 scale;


    public Transform()
    {
        localPosition = Vector3.zero;
        parent = null;
        position = Vector3.zero;
        rotation = Vector3.zero;
        scale = Vector3.one;
    }

    public Vector3 GetPosition()
    {
        if (parent == null)
            return localPosition;

        Vector3 parentPos = parent.GetPosition();
        return new Vector3(
            parentPos.x + localPosition.x,
            parentPos.y + localPosition.y,
            parentPos.z + localPosition.z
        );
    }
    public void SetPosition(Vector3 newPos)
    {
        position = newPos;
    }

    public void SetLocalPosition(Vector3 newPos)
    {
        localPosition = newPos;
    }

    public override string ToString()
    {
        if (parent == null)
        {
            return $"World Positioin: {position}; Local pos {localPosition}; scale {scale}; rotation {rotation}; parent: null";
        }
        else
        {
            return $"World Positioin: {position}; Local pos {localPosition}; scale {scale}; rotation {rotation}; parent: {parent.gameObject.name}";
        }
    }
}