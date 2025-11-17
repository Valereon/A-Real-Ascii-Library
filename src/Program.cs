using System.Globalization;
using A_Real_Ascii_Library.BuiltInComponents;
using Microsoft.VisualBasic;
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
        myGameObject.AddComponent(new SpriteRenderer("D:\\Github\\GitHub\\A-Real-Ascii-Library\\example.txt"));
        myGameObject.AddComponent(new PlayerMovement());
        



        GameObject childGameObject = new GameObject("deer");
        childGameObject.transform.parent = myGameObject.transform;
        myGameObject.transform.child = childGameObject.transform;
        childGameObject.AddComponent(new SpriteRenderer("D:\\Github\\GitHub\\A-Real-Ascii-Library\\example copy.txt"));
        // childGameObject.AddComponent(new PlayerMovement()); 
        childGameObject.transform.SetLocalPosition(new Vector3(500, 50, 0));



        GameObject debug = new GameObject("Debug");
        debug.AddComponent(new CustomDebug());
        debug.AddComponent(new TextDisplay("fuck"));



        // myGameObject.transform.scale = new Vector3(10, 10, 0);

        // Font myFont = Fonts.LoadFont("D:\\Github\\GitHub\\A-Real-Ascii-Library\\src\\Urban Shadow Sans Serif.otf");
        // Font myFont = Fonts.LoadFont("D:\\Github\\GitHub\\A-Real-Ascii-Library\\src\\TheConfessionRegular-YBpv.ttf");
        Font myFont = Fonts.LoadFont("D:\\Github\\GitHub\\A-Real-Ascii-Library\\src\\monofonto rg.otf");
        Fonts.SetFontFilterToPoint(myFont);
        Fonts.SetDefaultFont(myFont);

        sceneManager.Start();
        sceneManager.Loop();

        StateManager.End();
    }






}