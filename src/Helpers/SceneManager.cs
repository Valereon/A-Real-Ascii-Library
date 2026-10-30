// this will be done by reading scene files later but for now its this 
using System.Collections.ObjectModel;
using A_Real_Ascii_Library.BuiltInComponents;
using Raylib_cs;

public class SceneManager
{

    private static List<GameObject> _gameObjects = new();
    private static List<GameObjectData> gameObjectDatas = new();
    private static List<GameObject> _renderableObjects = new();
    private static Queue<GameObject> _pendingGameObjects = new();

    public static void RegisterGameObject(GameObject gameObject)
    {
        if (!_gameObjects.Contains(gameObject))
        {
            GameObjectData data = new GameObjectData(gameObject, gameObject.GetAllValidComponents(), gameObject.GetAllValidRenderableComponents());
            gameObjectDatas.Add(data);
            _gameObjects.Add(gameObject);
        }
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

            GameObjectData data = new GameObjectData(currGameObject, currGameObject.GetAllValidComponents(), currGameObject.GetAllValidRenderableComponents());
            gameObjectDatas.Add(data);
            for (int j = 0; j < data.components.Count; j++)
            {
                Component currentComponent = data.components[j];
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
            Raylib.DrawFPS(1000,500);
            Renderer.Render();
            Raylib.EndDrawing();
            ApplyGameObjectComponentChanges();
        }
    }


    static void UpdateGameObjects()
    {
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            GameObjectData dataObject = gameObjectDatas[i];

            if (!dataObject.gameObject.isEnabled)
                continue;

            // ReadOnlyCollection<Component> components = currGameObject.GetAllValidComponents();
            for (int j = 0; j < dataObject.components.Count; j++)
            {
                Component currentComponent = dataObject.components[j];
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
            GameObjectData currData = gameObjectDatas[i];
            GameObject currGameObject = currData.gameObject;

            if (!currGameObject.isEnabled)
                continue;
            
            for (int j = 0; j < currData.renderables.Count; j++)
            {
                IRenderable currentComponent = currData.renderables[j];
                currentComponent.Render();
            }
        }
    }

    static void ApplyGameObjectComponentChanges()
    {
        while (_pendingGameObjects.Count > 0)
        {
            GameObject gameObject = _pendingGameObjects.Dequeue();
            gameObject.ProcessDeferredComponentChanges();
            GameObjectData data = gameObjectDatas.First(key => key.gameObject == gameObject);
            data.UpdateComponentsList(gameObject.GetAllValidComponents());
            data.UpdateRenderableList(gameObject.GetAllValidRenderableComponents());

        }
    }
}