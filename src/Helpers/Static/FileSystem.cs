namespace A_Real_Ascii_Library.Helpers.Static;

static class FileSystem
{
    public static string ReadFile(string filePath)
    {

        filePath = Path.GetFullPath(filePath);
        if (!File.Exists(filePath))
            throw new ARALFSException($"Could not read File, '{filePath}' Does not exist");
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (UnauthorizedAccessException)
        {
            throw new ARALFSException($"Could not read '{filePath}' Permission denied");
        }
        catch (IOException e)
        {
            throw new ARALFSException($"Error reading file '{filePath}' : {e}");
        }
    }
    /// <summary>
    /// overwrites entire file with specified text
    /// </summary>
    public static void WriteFile(string filePath, string text)
    {
        filePath = Path.GetFullPath(filePath);

        try
        {
            File.WriteAllText(filePath, text);
        }
        catch (UnauthorizedAccessException)
        {
            throw new ARALFSException($"Could not write '{filePath}' Permission denied");
        }
        catch (IOException e)
        {
            throw new ARALFSException($"Error Writing file '{filePath}' : {e}");
        }
    }

    public static void DeleteFile(string filePath)
    {
        filePath = Path.GetFullPath(filePath);

        if (!File.Exists(filePath))
            throw new ARALFSException($"Could not delete File, '{filePath}' Does not exist");
        try
        {
            File.Delete(filePath);
        }
        catch (UnauthorizedAccessException)
        {
            throw new ARALFSException($"Could not delete '{filePath}' Permission denied");
        }
        catch (IOException e)
        {
            throw new ARALFSException($"Error Deleting file '{filePath}' : {e}");
        }
    }

    public static void CreateDirectory(string filePath)
    {
        filePath = Path.GetFullPath(filePath);
        try
        {
            Directory.CreateDirectory(filePath);
        }
        catch (UnauthorizedAccessException)
        {
            throw new ARALFSException($"Could not create directory at path '{filePath}' , Permission Denied");
        }
        catch (IOException e)
        {
            throw new ARALFSException($"Could not create directory '{filePath}' : {e} ");
        }
    }
    public static void DeleteDirectory(string filePath)
    {
        filePath = Path.GetFullPath(filePath);
        if (!File.Exists(filePath))
            throw new ARALFSException($"Could not delete directory, '{filePath}' Does not exist");

        try
        {
            Directory.Delete(filePath);
        }
        catch (UnauthorizedAccessException)
        {
            throw new ARALFSException($"Could not delete directory at path '{filePath}' , Permission Denied");
        }
        catch (IOException e)
        {
            throw new ARALFSException($"Could not delete directory '{filePath}' : {e} ");
        }
    }


}