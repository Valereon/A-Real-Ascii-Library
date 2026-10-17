using A_Real_Ascii_Library;
using A_Real_Ascii_Library.BuiltInComponents;
using Raylib_cs;
using A_Real_Ascii_Library.Helpers.Static;

public class App
{
    public static void Main(string[] args)
    {
        //TODO: make a class to handle the window of raylib
        Raylib.SetConfigFlags(ConfigFlags.VSyncHint | ConfigFlags.HighDpiWindow);
        Raylib.InitWindow(1920, 1080, "Yo wtf");
        StateManager.Start();


        GameObject myGameObject = new GameObject("ardvark");
        SpriteRenderer sprite = myGameObject.AddComponent<SpriteRenderer>();
        sprite.LoadSprite("resources/example.txt");

        myGameObject.AddComponent<PlayerMovement>();
        myGameObject.AddComponent<UserMovement>();



        GameObject childGameObject = new GameObject("deer");
        childGameObject.Transform.parent = myGameObject.Transform;
        myGameObject.Transform.child = childGameObject.Transform;
        SpriteRenderer sprite2 = childGameObject.AddComponent<SpriteRenderer>();
        sprite2.LoadSprite("resources/example copy.txt");
        // childGameObject.AddComponent(new PlayerMovement()); 
        childGameObject.Transform.SetLocalPosition(new Vector3(500, 50, 0));



        GameObject debug = new GameObject("Debug");
        debug.AddComponent<CustomDebug>();
        TextDisplay textDisplay = debug.AddComponent<TextDisplay>();
        textDisplay.text = "Fuck";



        // myGameObject.transform.scale = new Vector3(10, 10, 0);

        Font myFont = Fonts.LoadFont("resources/monofonto rg.otf");
        Fonts.SetFontFilterToPoint(myFont);
        Fonts.SetDefaultFont(myFont);

        SceneManager.Start();
        SceneManager.Loop();

        StateManager.End();
    }






}