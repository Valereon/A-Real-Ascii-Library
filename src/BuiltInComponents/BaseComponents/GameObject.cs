using System.ComponentModel;
using JetBrains.Annotations;

namespace A_Real_Ascii_Library.BuiltInComponents;

public class GameObject
{
    public Transform Transform {get;}
    public string name = "NoName";
    public bool isEnabled = true;
    List<Component> _components = new();
    List<IRenderable> _renderableComponents = new();
    bool isChangesQueued = false;
    bool isRenderable = false;
    Queue<Component> _componentsToAdd = new();
    Queue<Component> _componentsToRemove = new();
    Queue<IRenderable> _renderableComponentsToAdd = new();
    Queue<IRenderable> _renderableComponentsToRemove = new();


    public GameObject()
    {
        Transform self = AddComponent<Transform>();
        Transform = self;
        SceneManager.RegisterGameObject(this);
    }

    public GameObject(string name)
    {
        this.name = name;
        Transform self = AddComponent<Transform>();
        Transform = self;
        SceneManager.RegisterGameObject(this);
    }


    public T AddComponent<T>() where T : Component, new()
    {
        T comp = new T();
        comp.gameObject = this;
        if (comp is IRenderable renderable)
            _renderableComponentsToAdd.Enqueue(renderable);
        _componentsToAdd.Enqueue(comp);

        if (!isChangesQueued)
        {
            isChangesQueued = true;
            SceneManager.EnqueueGameObjectToChange(this);
        }


        return comp;
    }

    // TODO : be able to specify the instance of the actual compoennt in overload
    public void RemoveComponent<T>() where T : Component
    {
        if (_components.Count <= 0)
            throw new ARALException($"Gameobject {name} has no component of type {typeof(T)}");

        //TODO: turn this into get component
        Component? comp = _components.FirstOrDefault(key => key is T);

        if (comp is null)
            throw new ARALException($"Gameobject {name} has no component of type {typeof(T)}");


        if (comp is IRenderable renderable)
        {
            _renderableComponentsToRemove.Enqueue(renderable);
            _componentsToRemove.Enqueue(comp);
        }
        else
            _componentsToRemove.Enqueue(comp);


        if (!isChangesQueued)
        {
            isChangesQueued = true;
            SceneManager.EnqueueGameObjectToChange(this);
        }
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
        Component? comp = _componentsToAdd.FirstOrDefault(key => key is T);
        if(comp != null)  
            return (T)comp;

        //TODO: make this return do literally anything else
        return null;
    }

    // TODO: make this also check the queue to add and return those as well and not return the live list of components maybe a copy or Ireadonly
    public List<Component> GetComponents()
    {
        return _components;
    }

    // todo dont return live list
    public List<IRenderable> GetRenderableComponents()
    {
        return _renderableComponents;
    }

    public void ProcessDeferredComponentChanges()
    {
        DeferredComponentAdd();
        DeferredComponentRemove();
        UpdateRenderableState();
        isChangesQueued = false;
    }


    void DeferredComponentAdd()
    {
        while (_componentsToAdd.Count > 0)
        {
            Component component = _componentsToAdd.Dequeue();
            _components.Add(component);
        }
        while (_renderableComponentsToAdd.Count > 0)
        {
            IRenderable component = _renderableComponentsToAdd.Dequeue();
            _renderableComponents.Add(component);
        }
    }

    void DeferredComponentRemove()
    {
        while (_componentsToRemove.Count > 0)
        {
            Component component = _componentsToRemove.Dequeue();
            _components.Remove(component);
        }
        while (_renderableComponentsToRemove.Count > 0)
        {
            IRenderable component = _renderableComponentsToRemove.Dequeue();
            _renderableComponents.Remove(component);
        }
    }
    void UpdateRenderableState()
    {
        bool shouldBeRenderable = _renderableComponents.Count > 0;
        if(shouldBeRenderable == isRenderable)
            return;
        isRenderable = shouldBeRenderable;
        if(isRenderable)
            SceneManager.RegisterRenderableGameObject(this);
        else
            SceneManager.DeRegisterRenderableGameObject(this);
    }

    public override string ToString()
    {
        string output = $"------- GAME OBJECT -----\n{name}\n";
        foreach (Component component in GetComponents())
            output += component + "\n";
        output += "RENDERABLE COMPONENTS\n";
        foreach (IRenderable renderableComponent in GetRenderableComponents())
            output += renderableComponent + "\n";
        output += "------ END GAME OBJECT -------\n";
        return output;
    }
}