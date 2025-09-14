public abstract class Component
{

    public GameObject gameObject;
    public bool isEnabled = true;

    public virtual void Start() { }
    public virtual void Update() { }

    public virtual void OnDestroy() { }
    

}