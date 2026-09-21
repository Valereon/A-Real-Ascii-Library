// this will be done by reading scene files later but for now its this 
using A_Real_Ascii_Library.BuiltInComponents;
using Raylib_cs;

public class SceneManager
{

    private static List<GameObject> gameObjects = new();

    public static A_Real_Ascii_Library.BuiltInComponents.Transform root { get; }
    public static void RegisterGameObject(GameObject gameObject)
    {
        gameObjects.Add(gameObject);
    }
    public static List<GameObject> ListGameObjectsUnordered()
    {
        return gameObjects;
    }
    public static void RegisterComponentAdd()
    {
        
    }
    public static void RegisterComponentRemove()
    {
        
    }

    public void Start()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            GameObject currGameObject = gameObjects[i];

            if (!currGameObject.isEnabled)
                continue;

            List<Component> components = currGameObject.GetListOfComponents();
            for (int j = 0; j < components.Count; j++)
            {
                Component currentComponent = components[j];
                if (!currentComponent.IsEnabled)
                    continue;
                currentComponent.Start();
            }
        }
    }


    public void Loop()
    {
        while (!Raylib.WindowShouldClose())
        {
            // physics update here
            UpdateGameobjects();
            // late update here for camera stuff
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            RenderGameobjects();
            Raylib.EndDrawing();
        }
    }


    void UpdateGameobjects()
    {
        GameObject[] gameObjectsArray = gameObjects.ToArray();
        for (int i = 0; i < gameObjectsArray.Length; i++)
        {
            GameObject currGameObject = gameObjectsArray[i];

            if (!currGameObject.isEnabled)
                continue;

            Component[] components = currGameObject.GetListOfComponents().ToArray();
            for (int j = 0; j < components.Length; j++)
            {
                Component currentComponent = components[j];
                if (!currentComponent.IsEnabled)
                    continue;
                currentComponent.Update();
            }
        }
    }

    void RenderGameobjects()
    {
        GameObject[] gameObjectsArray = gameObjects.ToArray();
        for (int i = 0; i < gameObjectsArray.Length; i++)
        {
            GameObject currGameObject = gameObjectsArray[i];

            if (!currGameObject.isEnabled)
                continue;

            IRenderable[] components = currGameObject.GetListOfRenderableComponents().ToArray();
            for (int j = 0; j < components.Length; j++)
            {
                IRenderable currentComponent = components[j];
                if (currentComponent is Component comp && !comp.gameObject.isEnabled)
                    continue;
                currentComponent.Render();
            }
        }
    }
}