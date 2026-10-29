using System.Collections.ObjectModel;
using System.ComponentModel;
using JetBrains.Annotations;

namespace A_Real_Ascii_Library.BuiltInComponents;

public class GameObject
{
    public Transform Transform { get; }
    public string name { get; set; }
    public bool isEnabled = true;

    List<Component> _components = new();
    List<IRenderable> _renderableComponents = new();
    bool _isChangesQueued = false;
    bool _isRenderable = false;
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
        T comp = new T
        {
            gameObject = this
        };

        if (comp is IRenderable renderable)
            _renderableComponentsToAdd.Enqueue(renderable);
        _componentsToAdd.Enqueue(comp);

        if (!_isChangesQueued)
        {
            _isChangesQueued = true;
            SceneManager.EnqueueGameObjectToChange(this);
        }


        return comp;
    }

    // TODO : be able to specify the instance of the actual compoennt in overload
    public void RemoveComponent<T>() where T : Component
    {
        if (_components.Count <= 0)
            throw new ARALException($"Gameobject {name} has no component of type {typeof(T)}");

        Component? comp = GetComponent<T>();

        if (comp is null)
            throw new ARALException($"Gameobject {name} has no component of type {typeof(T)}");


        if (comp is IRenderable renderable)
        {
            _renderableComponentsToRemove.Enqueue(renderable);
            _componentsToRemove.Enqueue(comp);
        }
        else
            _componentsToRemove.Enqueue(comp);


        if (!_isChangesQueued)
        {
            _isChangesQueued = true;
            SceneManager.EnqueueGameObjectToChange(this);
        }
    }


    public T? GetComponent<T>() where T : Component
    {
        foreach (Component targetComponent in _components)
        {
            if (targetComponent is T)
            {
                return (T)targetComponent;
            }
        }
        Component? comp = _componentsToAdd.FirstOrDefault(key => key is T);

        if (comp != null)
            return (T)comp;


        return null;
    }


    public ReadOnlyCollection<Component> GetComponents()
    {
        return _components.AsReadOnly();
    }

    public ReadOnlyCollection<Component> GetAllComponents()
    {
        List<Component> temp = [.. _components, .. _componentsToAdd.ToList(), .. _componentsToRemove.ToList()];
        return temp.AsReadOnly();
    }
    public ReadOnlyCollection<Component> GetAllValidComponents()
    {
        List<Component> temp = [.. _components, .. _componentsToAdd.ToList()];
        return temp.AsReadOnly();
    }

    public ReadOnlyCollection<IRenderable> GetRenderableComponents()
    {
        return _renderableComponents.AsReadOnly();
    }

    public ReadOnlyCollection<IRenderable> GetAllRenderableComponents()
    {
        List<IRenderable> temp = [.. _renderableComponents, .. _renderableComponentsToAdd.ToList(), .. _renderableComponentsToRemove.ToList()];
        return temp.AsReadOnly();
    }

    public ReadOnlyCollection<IRenderable> GetAllValidRenderableComponents()
    {
        List<IRenderable> temp = [.. _renderableComponents, .. _renderableComponentsToAdd.ToList()];
        return temp.AsReadOnly();
    }

    public void ProcessDeferredComponentChanges()
    {
        DeferredComponentAdd();
        DeferredComponentRemove();
        UpdateRenderableState();
        _isChangesQueued = false;
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
        if (shouldBeRenderable == _isRenderable)
            return;
        _isRenderable = shouldBeRenderable;
        if (_isRenderable)
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