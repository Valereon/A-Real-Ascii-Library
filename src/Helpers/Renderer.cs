using A_Real_Ascii_Library.BuiltInComponents;

public static class Renderer
{
    static Queue<IRenderCommand2D> _renderCommands = new();

    public static void EnqueueCommand(IRenderCommand2D command)
    {
        _renderCommands.Enqueue(command);
    }


    public static void Render()
    {
        // _renderCommands.OrderBy(key => key.Layer);
        while(_renderCommands.Count > 0)
        {
            IRenderCommand2D command = _renderCommands.Dequeue();
            command.Execute();
        }
    }
}