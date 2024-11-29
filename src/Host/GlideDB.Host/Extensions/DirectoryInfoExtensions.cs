namespace GlideDB.Host.Extensions;

public static class DirectoryInfoExtensions
{
    public static bool IsEmpty(this DirectoryInfo directoryInfo)
    {
        return directoryInfo.GetFiles().Length == 0 && directoryInfo.GetDirectories().Length == 0;
    }
}