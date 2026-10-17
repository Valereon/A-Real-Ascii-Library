// this will be done by reading scene files later but for now its this 
using A_Real_Ascii_Library.BuiltInComponents;
using Raylib_cs;

public class SceneManager
{

    private static List<GameObject> _gameObjects = new();
    private static List<GameObject> _renderableObjects = new();
    // game objects waiting for their component changes to be applied via applydefferedChanges
    private static Queue<GameObject> _pendingGameObjects = new();

    public static void RegisterGameObject(GameObject gameObject)
    {
        _gameObjects.Add(gameObject);
    }
    public static void DeRegisterGameObject(GameObject gameObject)
    {
        //TODO bounds check
        _gameObjects.Remove(gameObject);
    }
    public static void RegisterRenderableGameObject(GameObject renderable)
    {
        _renderableObjects.Add(renderable);
    }
    public static void DeRegisterRenderableGameObject(GameObject renderable)
    {
        //TODO bounds check
        _renderableObjects.Remove(renderable);
    }
    public static void EnqueueGameObjectToChange(GameObject gameObject)
    {
        _pendingGameObjects.Enqueue(gameObject);
    }
    public static GameObject[] ListGameObjectsUnordered()
    {
        return _gameObjects.ToArray();
    }

    public static void Start()
    {
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            GameObject currGameObject = _gameObjects[i];


            if (!currGameObject.isEnabled)
                continue;

            List<Component> components = currGameObject.GetComponents();
            for (int j = 0; j < components.Count; j++)
            {
                Component currentComponent = components[j];
                if (!currentComponent.IsEnabled)
                    continue;
                currentComponent.Start();
            }
        }
    }


    public static void Loop()
    {
        //TODO make a better version of this via a window class and something to wrap the drawing calls
        while (!Raylib.WindowShouldClose())
        {
            // physics update here
            UpdateGameObjects();
            // late update here for camera stuff
            GatherDrawCalls();
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Renderer.Render();
            Raylib.EndDrawing();
            ApplyGameObjectComponentChanges();
        }
    }


    static void UpdateGameObjects()
    {
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            GameObject currGameObject = _gameObjects[i];

            if (!currGameObject.isEnabled)
                continue;

            List<Component> components = currGameObject.GetComponents();
            for (int j = 0; j < components.Count; j++)
            {
                Component currentComponent = components[j];
                if (!currentComponent.IsEnabled)
                    continue;
                currentComponent.Update();
            }
        }
    }

    static void GatherDrawCalls()
    {
        for (int i = 0; i < _renderableObjects.Count; i++)
        {
            GameObject currGameObject = _renderableObjects[i];

            if (!currGameObject.isEnabled)
                continue;

            List<IRenderable> components = currGameObject.GetRenderableComponents();
            for (int j = 0; j < components.Count; j++)
            {
                IRenderable currentComponent = components[j];
                currentComponent.Render();
            }
        }
    }

    static void ApplyGameObjectComponentChanges()
    {
        while(_pendingGameObjects.Count > 0)
        {
            GameObject gameObject = _pendingGameObjects.Dequeue();
            gameObject.ProcessDeferredComponentChanges();
        }
    }
}