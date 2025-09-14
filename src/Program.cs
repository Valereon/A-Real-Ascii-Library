using System.Numerics;
using Raylib_cs;



public class App()
{
    public static void Main(string[] args)
    {
        Raylib.SetConfigFlags(ConfigFlags.VSyncHint | ConfigFlags.HighDpiWindow);
        Raylib.InitWindow(1920, 1080, "Yo wtf");

        SceneManager sceneManager = new SceneManager();

        GameObject myGameObject = new GameObject();
        myGameObject.AddComponent(new SpriteRenderer());
        myGameObject.AddComponent(new PlayerMovement());

        myGameObject.transform.scale = new Vector3(25, 25, 0);

        // Font myFont = Fonts.LoadFont("D:\\Github\\GitHub\\A-Real-Ascii-Library\\src\\Urban Shadow Sans Serif.otf");
        Font myFont = Fonts.LoadFont("D:\\Github\\GitHub\\A-Real-Ascii-Library\\src\\TheConfessionRegular-YBpv.ttf");
        Fonts.SetFontFilterToPoint(myFont);
        Fonts.SetDefaultFont(myFont);
        sceneManager.Start();
        // while (!Raylib.WindowShouldClose())
        // {
            // Raylib.BeginDrawing();
            // Raylib.ClearBackground(Color.RayWhite);

            // Raylib.DrawText("Whats up my broski", 20, 20, 90, Color.Black);


            // Raylib.DrawTextEx(myFont, "this is the new font", new Vector2(100, 100), 96, 10, Color.Black);


            // Raylib.EndDrawing();

        // }
        sceneManager.Loop();

        StateManager.End();
    }





    
}