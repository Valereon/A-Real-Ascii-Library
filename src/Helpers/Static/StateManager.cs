using Raylib_cs;
namespace A_Real_Ascii_Library.Helpers.Static;
public enum STATE
{
    PLAY,
    EDIT,
    END
}



// TODO: add boolean return values to know if anything failed unloading or loading something or starting or stopping
public static class StateManager
{
    public static List<Font> loadedFonts = new();
    public static STATE state;
    public static Action<STATE>? onStateChanged;
    


    public static void Start()
    {
        state = STATE.PLAY;
        onStateChanged?.Invoke(state);
    }


    public static void End()
    {
        state = STATE.END;
        onStateChanged?.Invoke(state);
        Cleanup();
    }


    static void Cleanup()
    {
        FontCleanup();
    }

    static void FontCleanup()
    {
        for (int i = loadedFonts.Count - 1; i >= 0; i--)
        {
            Fonts.UnloadFont(loadedFonts[i]);
        }
    }


}