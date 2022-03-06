using Godot;
using Godot.Collections;
using System;

public static class FileGerenciator
{
    public static Player LoadPlayer(String path)
    {
        return ResourceLoader.Load<Player>(path);
    }

    public static Array<String> ListFilesInDirectory(String path)
    {
        Directory dir = new Directory();
        String defaultDirPath = path;
        Godot.Collections.Array<String> files = new Godot.Collections.Array<String>();

        if (!dir.DirExists(defaultDirPath))
            dir.MakeDirRecursive(defaultDirPath);

        dir.Open(defaultDirPath);
        dir.ListDirBegin();

        while (true)
        {
            String file = dir.GetNext();
            if (file == "")
            {
                break;
            }
            else if (!file.BeginsWith("."))
                files.Add(file);
        }

        dir.ListDirEnd();
        return files;
    }
}
