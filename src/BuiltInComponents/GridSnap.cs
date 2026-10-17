namespace A_Real_Ascii_Library.BuiltInComponents;
using A_Real_Ascii_Library.Helpers.Static;
public class GridSnap : Component
{
    public float gridSize;

    private bool hasCustomGrid;
    private float gridSizeX;
    private float gridSizeY;

    public override void Update()
    {
        Vector3 currentPos = gameObject.Transform.GetPosition();
        if (hasCustomGrid)
        {
            currentPos.x = MathF.Round(currentPos.x / gridSizeX) * gridSizeX;
            currentPos.y = MathF.Round(currentPos.y / gridSizeY) * gridSizeY;
        }
        else
        {
            currentPos.x = MathF.Round(currentPos.x / gridSize) * gridSize;
            currentPos.y = MathF.Round(currentPos.y / gridSize) * gridSize;
        }
        gameObject.Transform.SetPosition(currentPos);
    }

    public void ToggleCustomGrid(bool state)
    {
        hasCustomGrid = state;
    }

    public void SetCustomXGrid(float size)
    {
        gridSizeX = size;
    }

    public void SetCustomYGrid(float size)
    {
        gridSizeY = size;
    }
}