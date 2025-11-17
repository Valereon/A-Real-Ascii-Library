namespace A_Real_Ascii_Library.BuiltInComponents;

public abstract class Component
{

    public GameObject gameObject;
    public bool isEnabled = true;

    public virtual void Start() { }
    public virtual void Update() { }

    public virtual void OnDestroy() { }

    public override string ToString()
    {
        return GetType().Name; // Returns the name of the component's type
    }
}