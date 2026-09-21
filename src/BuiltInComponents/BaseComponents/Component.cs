namespace A_Real_Ascii_Library.BuiltInComponents;

public abstract class Component
{

    public GameObject gameObject;
    bool isEnabled = true;
    public bool IsEnabled
    {
        get => isEnabled;
        set
        {
            isEnabled = value;
            if (value)
                OnEnable();
        }
    }

    public virtual void Start() { }
    public virtual void OnEnable() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void LateUpdate() { }

    public virtual void OnDestroy() { }

    public override string ToString()
    {
        return GetType().Name; // Returns the name of the component's type
    }
}