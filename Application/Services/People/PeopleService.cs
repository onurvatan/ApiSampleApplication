using Application.Repository;
using Domain;

namespace Application.Services.People
{
    public class PeopleService : IPeopleService
    {
        private readonly IRepository<Person> repository;

        public PeopleService(IRepository<Person> repository)
        {
            this.repository = repository;
        }
        public async Task<int> CreateAsync(PersonDto entity)
        {
            var person = new Person();
            person.BirthDate = entity.BirthDate;
            person.Name = entity.Name;
            return await repository.CreateAsync(person);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<List<PersonDto>> GetAllAsync()
        {
            var list = await repository.GetAllAsync();

            return list.Select(person => new PersonDto { BirthDate = person.BirthDate, Name = person.Name, Id = person.Id }).ToList();
        }

        public async Task<PersonDto> GetByIdAsync(int id)
        {
            var person = await repository.GetByIdAsync(id);
            return new PersonDto { BirthDate = person.BirthDate, Name = person.Name, Id = person.Id };
        }

        public async Task<int> UpdateAsync(PersonDto entity)
        {
            return await repository.UpdateAsync(new Person { BirthDate = entity.BirthDate, Name = entity.Name, Id = entity.Id });
        }
    }
}
