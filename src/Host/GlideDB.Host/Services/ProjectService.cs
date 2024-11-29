using GlideDB.Host.Abstractions;
using GlideDB.Host.Abstractions.Services;
using GlideDB.Host.Abstractions.Services.Inputs;
using GlideDB.Host.Extensions;

namespace GlideDB.Host.Services;

public class ProjectService : IProjectService
{
    public void Create(CreateProjectInput input)
    {
        var directoryInfo = new DirectoryInfo(input.DirectoryPath);

        if (directoryInfo.Exists && !directoryInfo.IsEmpty())
        {
            throw new Exception($"Directory {input.DirectoryPath} already exists");
        }

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }
        
        // create git repo
        // create gitignore file
        // create configuration file with application and gitignore version
        // 
        
        
        //git init -b main
        throw new NotImplementedException();
    }
}