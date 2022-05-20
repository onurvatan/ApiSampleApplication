namespace Application.Services.People
{
    public interface IPeopleService
    {
        Task<PersonDto> GetByIdAsync(int id);
        Task<List<PersonDto>> GetAllAsync();
        Task<int> CreateAsync(PersonDto entity);
        Task<int> UpdateAsync(PersonDto entity);
        Task<int> DeleteAsync(int id);
    }
}
