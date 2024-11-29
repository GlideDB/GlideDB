using GlideDB.Host.Abstractions.Services.Inputs;

namespace GlideDB.Host.Abstractions.Services;

public interface IProjectService
{
    void Create(CreateProjectInput input);
}