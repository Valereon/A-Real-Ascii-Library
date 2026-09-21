using JetBrains.Annotations;

namespace A_Real_Ascii_Library.BuiltInComponents;

public class GameObject
{
    public Transform transform;
    public string name;
    public bool isEnabled = true;
    List<Component> _components = new();
    List<IRenderable> _renderableComponents = new();


    public GameObject()
    {
        Transform self = AddComponent<Transform>();
        transform = self;
        SceneManager.RegisterGameObject(this);
    }

    public GameObject(string name)
    {
        this.name = name;
        Transform self = AddComponent<Transform>();
        transform = self;
        SceneManager.RegisterGameObject(this);
    }


    public T AddComponent<T>() where T : Component, new()
    {
        T comp = new T();
        comp.gameObject = this;
        if(comp is IRenderable renderable)
        {
            _renderableComponents.Add(renderable);
        }
        _components.Add(comp);
        return comp;
    }

    public List<Component> GetListOfComponents()
    {
        return _components;
    }

    public List<IRenderable> GetListOfRenderableComponents()
    {
        return _renderableComponents;
    }

    public T GetComponent<T>() where T : Component
    {
        foreach (Component targetComponent in _components)
        {
            if (targetComponent is T)
            {
                return (T)targetComponent;
            }
        }

        return null;
    }

    public override string ToString()
    {
        string output = $"------- GAME OBJECT -----\n{name}\n";
        foreach (Component component in GetListOfComponents())
            output += component + "\n";
        output += "RENDERABLE COMPONENTS";
        foreach(IRenderable renderableComponent in GetListOfRenderableComponents())
            output += renderableComponent + "\n";
        output += "------ END GAME OBJECT -------\n";
        return output;
    }
}