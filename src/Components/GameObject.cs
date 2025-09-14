public class GameObject
{
    public string tag;
    public Transform transform;
    List<Component> components = new();




    public GameObject()
    {
        transform = new Transform();
        AddComponent(transform);
        SceneManager.gameObjects.Add(this);
    }


    public void AddComponent(Component component)
    {
        component.gameObject = this;
        components.Add(component);
    }


    public void RemoveComponent(Component component)
    {
        
    }



    public List<Component> GetListOfComponents()
    {
        return components;
    }

    public T GetComponent<T>() where T : Component
    {
        foreach (Component component in components)
        {
            if (component is T)
            {
                return (T)component;
            }
        }
        return null;
    }

}