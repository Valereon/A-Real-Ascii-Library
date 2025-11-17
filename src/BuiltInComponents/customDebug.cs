namespace A_Real_Ascii_Library.BuiltInComponents;

public class CustomDebug : Component
{
    public override void Start()
    {
    }

    public override void Update()
    {
        string finalString = string.Empty;

        finalString += string.Concat(
            SceneManager.gameObjects.Select(obj => obj.ToString())
        );
        gameObject.GetComponent<TextDisplay>().text = finalString;
    }
}