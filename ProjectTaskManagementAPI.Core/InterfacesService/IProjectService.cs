using ProjectTaskManagementAPI.Core.Dtos;

namespace ProjectTaskManagementAPI.Core.InterfacesService
{
    public interface IProjectService
    {
        Task<int> CreateProject(CreateProjectDto dto, int userId);

        Task<List<ProjectDto>> GetAllProjects(int userId);

        Task<ProjectDto?> GetById(int id, int userId);

        Task<bool> UpdateProject(int id, UpdateProjectDto dto, int userId);

        Task<bool> DeleteProject(int id, int userId);
    }
}
