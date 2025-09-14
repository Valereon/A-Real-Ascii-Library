// this will be done by reading scene files later but for now its this 
using Raylib_cs;

public class SceneManager
{
    public static List<GameObject> gameObjects = new();



    public void Start()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            foreach (Component component in gameObject.GetListOfComponents())
            {
                if (component.isEnabled)
                    component.Start();
            }
        }
    }


    public void Loop()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);
            foreach (GameObject gameObject in gameObjects)
            {
                foreach (Component component in gameObject.GetListOfComponents())
                {
                    if (component.isEnabled)
                        component.Update();
                }
            }
            Raylib.EndDrawing();
        }
    }



}