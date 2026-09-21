using A_Real_Ascii_Library;
using A_Real_Ascii_Library.BuiltInComponents;
using Raylib_cs;
using A_Real_Ascii_Library.Helpers.Static;

public class App
{
    public static void Main(string[] args)
    {
        Raylib.SetConfigFlags(ConfigFlags.VSyncHint | ConfigFlags.HighDpiWindow);
        Raylib.InitWindow(1920, 1080, "Yo wtf");

        SceneManager sceneManager = new SceneManager();

        GameObject myGameObject = new GameObject("ardvark");
        SpriteRenderer sprite2 = myGameObject.AddComponent<SpriteRenderer>();
        sprite2.LoadSprite("H:\\Github\\GitHub\\A-Real-Ascii-Library\\example.txt");

        myGameObject.AddComponent<PlayerMovement>();
        myGameObject.AddComponent<UserMovement>();



        GameObject childGameObject = new GameObject("deer");
        childGameObject.transform.parent = myGameObject.transform;
        myGameObject.transform.child = childGameObject.transform;
        SpriteRenderer sprite = childGameObject.AddComponent<SpriteRenderer>();
        sprite.LoadSprite("H:\\Github\\GitHub\\A-Real-Ascii-Library\\example copy.txt");
        // childGameObject.AddComponent(new PlayerMovement()); 
        childGameObject.transform.SetLocalPosition(new Vector3(500, 50, 0));



        GameObject debug = new GameObject("Debug");
        debug.AddComponent<CustomDebug>();
        TextDisplay textDisplay = debug.AddComponent<TextDisplay>();
        textDisplay.text = "Fuck";



        // myGameObject.transform.scale = new Vector3(10, 10, 0);

        // Font myFont = Fonts.LoadFont("D:\\Github\\GitHub\\A-Real-Ascii-Library\\src\\Urban Shadow Sans Serif.otf");
        // Font myFont = Fonts.LoadFont("D:\\Github\\GitHub\\A-Real-Ascii-Library\\src\\TheConfessionRegular-YBpv.ttf");
        Font myFont = Fonts.LoadFont("H:\\Github\\GitHub\\A-Real-Ascii-Library\\src\\monofonto rg.otf");
        Fonts.SetFontFilterToPoint(myFont);
        Fonts.SetDefaultFont(myFont);

        sceneManager.Start();
        sceneManager.Loop();

        StateManager.End();
    }






}