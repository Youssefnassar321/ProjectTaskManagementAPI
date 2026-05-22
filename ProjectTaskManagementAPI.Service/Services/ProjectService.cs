using ProjectTaskManagementAPI.Core.Dtos;
using ProjectTaskManagementAPI.Core.Entities;
using ProjectTaskManagementAPI.Core.Interfaces;
using ProjectTaskManagementAPI.Core.InterfacesService;

namespace ProjectTaskManagementAPI.Service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> CreateProject(CreateProjectDto dto, int userId)
        {
            var project = new Projects
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedBy = userId,
                CreatedAt = DateTime.Now
            };

            await _projectRepository.AddAsync(project);

            return project.Id;
        }

        public async Task<List<ProjectDto>> GetAllProjects(int userId)
        {
            var projects = await _projectRepository.GetAllAsync();

            var result = projects
                .Select(p => new ProjectDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    CreatedAt = p.CreatedAt
                })
                .ToList();

            return result;
        }

        public async Task<ProjectDto?> GetById(int id, int userId)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                return null;

            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt
            };
        }

        public async Task<bool> UpdateProject(int id, UpdateProjectDto dto, int userId)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                return false;

            project.Name = dto.Name;
            project.Description = dto.Description;
            project.CreatedBy = userId;

            await _projectRepository.UpdateAsync(project);

            return true;
        }

        public async Task<bool> DeleteProject(int id, int userId)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                return false;

            await _projectRepository.DeleteAsync(project);

            return true;
        }
    }
}
