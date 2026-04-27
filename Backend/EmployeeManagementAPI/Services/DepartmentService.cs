using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDto> GetDepartmentByIdAsync(int id);
        Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto createDto);
        Task<DepartmentDto> UpdateDepartmentAsync(int id, UpdateDepartmentDto updateDto);
        Task<bool> DeleteDepartmentAsync(int id);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _context.Departments
                .Include(d => d.Employees)
                .OrderBy(d => d.Name)
                .Select(d => MapToDto(d))
                .ToListAsync();

            return departments;
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (department == null)
                throw new KeyNotFoundException($"Department with ID {id} not found");

            return MapToDto(department);
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto createDto)
        {
            var department = new Department
            {
                Name = createDto.Name,
                Description = createDto.Description,
                ManagerName = createDto.ManagerName,
                CreatedAt = DateTime.UtcNow
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return await GetDepartmentByIdAsync(department.Id);
        }

        public async Task<DepartmentDto> UpdateDepartmentAsync(int id, UpdateDepartmentDto updateDto)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                throw new KeyNotFoundException($"Department with ID {id} not found");

            department.Name = updateDto.Name;
            department.Description = updateDto.Description;
            department.ManagerName = updateDto.ManagerName;

            _context.Departments.Update(department);
            await _context.SaveChangesAsync();

            return await GetDepartmentByIdAsync(id);
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                throw new KeyNotFoundException($"Department with ID {id} not found");

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return true;
        }

        private DepartmentDto MapToDto(Department department)
        {
            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                ManagerName = department.ManagerName,
                CreatedAt = department.CreatedAt,
                EmployeeCount = department.Employees?.Count ?? 0
            };
        }
    }
}
