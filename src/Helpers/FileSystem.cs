
/// <summary>
/// Manages things related to the .blink folder and the projects structure and integrity 
/// </summary>
static class FileSystem
{
    public static string fileSystemRoot = string.Empty;
    public static string PathSeparator = @"\";


    public static string ReadFile(string filePath)
    {

        filePath = MakePathAbsolute(filePath);
        if (!File.Exists(filePath))
            throw new ARALFSException($"Could not read File, '{filePath}' Does not exist");

        try
        {
            // Console.WriteLine(File.ReadAllText(filePath));
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


        filePath = MakePathAbsolute(filePath);

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
        filePath = MakePathAbsolute(filePath);

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
        filePath = MakePathAbsolute(filePath);
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
        filePath = MakePathAbsolute(filePath);
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




    
    /// <summary>
    /// This will take any path including relative paths. Clean them and turn them absolute including ".\" "\" or "python.exe"
    /// </summary>
    public static string MakePathAbsolute(string path)
    {
        if (path == null)
            return string.Empty;

        //crude path check
        if (path.Contains(PathSeparator))
        {
            if (path.Contains($@".{PathSeparator}"))
            {
                Path.GetFullPath(Path.Combine(fileSystemRoot, path));
            }
        }

        if (path.Contains(fileSystemRoot))
        {
            return path;
        }
        else
        {
            return Path.GetFullPath(Path.Combine(fileSystemRoot, path.TrimStart('\\', '/')));
        }
    }

    /// <summary>
    /// Takes an absolute path and returns a path relative to the root of the project.
    /// used for the paths in toml
    /// </summary>
    public static string MakePathRelative(string path)
    {
        if (path.Contains(fileSystemRoot))
        {
            return path.Replace(fileSystemRoot, @$".");
        }
        else
        {
            if (path.Contains(@$".{PathSeparator}"))
            {
                return path;
            }
            return $@".{PathSeparator}{path}";
        }
    }

    /// <summary>
    /// Tries to remove the exe ending from the path and if it cannot then it returns the original path
    /// </summary>
    //TODO : CHANGE THIS TO BE FILE ENDING NOT JUST EXE
    public static string TryRemoveExeEnding(string path)
    {
        if (path.EndsWith(".exe"))
        {
            return path.Replace(".exe", string.Empty);
        }

        return path;
    }
    public static void UpdatePathSeparator()
    {
        PathSeparator = Path.DirectorySeparatorChar.ToString();
    }
}