// this will be done by reading scene files later but for now its this 
using System.Collections.Concurrent;
using A_Real_Ascii_Library.BuiltInComponents;
using Raylib_cs;

public class SceneManager
{
    public static List<GameObject> gameObjects = new();

    public void Start()
    {
            for(int i = 0; i < gameObjects.Count; i++)
            {
                GameObject currGameObject = gameObjects[i];

                if (!currGameObject.isEnabled)
                    continue;

                List<Component> components = currGameObject.GetListOfComponents();
                for (int j = 0; j < components.Count; j++)
                {
                    Component currentComponent = components[j];
                    if (!currentComponent.isEnabled)
                        continue;
                    currentComponent.Start();
                }
            } 
    }


    public void Loop()
    {
        while (!Raylib.WindowShouldClose())
        {
            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            for(int i = 0; i < gameObjects.Count; i++)
            {
                GameObject currGameObject = gameObjects[i];

                if (!currGameObject.isEnabled)
                    continue;

                List<Component> components = currGameObject.GetListOfComponents();
                for (int j = 0; j < components.Count; j++)
                {
                    Component currentComponent = components[j];
                    if (!currentComponent.isEnabled)
                        continue;
                    currentComponent.Update();
                }
            }
            Raylib.EndDrawing();
        }
    }



}