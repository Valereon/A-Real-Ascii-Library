namespace A_Real_Ascii_Library.BuiltInComponents;

public class GameObject
{
    public Transform transform;
    public string name;
    public bool isEnabled = true;
    List<Component> components = new();


    public GameObject()
    {
        transform = new Transform();
        AddComponent(transform);
        SceneManager.gameObjects.Add(this);
    }

    public GameObject(string name)
    {
        transform = new Transform();
        AddComponent(transform);
        SceneManager.gameObjects.Add(this);
        this.name = name;
    }


    public void AddComponent(Component component)
    {
        component.gameObject = this;
        components.Add(component);
    }


    public void RemoveComponent(Component component)
    {
        components.Remove(component);
    }


    public List<Component> GetListOfComponents()
    {
        return components;
    }

    public T GetComponent<T>() where T : Component
    {
        foreach (Component targetComponent in components)
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
        output += "------ END GAME OBJECT -------\n";
        return output;
    }
}