using ApiPersonService.Data.Converter.Implementation;
using ApiPersonService.Data.VO;
using ApiPersonService.Hypermedia.utils;
using ApiPersonService.Repository;

namespace ApiPersonService.Business.Implementation;

public class PersonBusinessImplementation : IPersonBusiness
{
    private readonly IPersonRepository _personRepository;
    private readonly PersonConverter _converter;

    public PersonBusinessImplementation(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
        _converter = new PersonConverter();
    }

    public List<PersonVO> FindAll()
    {
        return _converter.Parse(_personRepository.FindAll());
    }

    public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
    {
        var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
        var size = (pageSize < 1) ? 10 : pageSize;
        var offset = page > 0 ? (page - 1) * size : 0;

        string paginationQuery = "select * from person p where 1 = 1";
        string countQuery = "select count(*) from person p where 1 = 1;";

        if (!string.IsNullOrWhiteSpace(name))
            paginationQuery = paginationQuery + $" and p.first_name like '%{name}%'";
            countQuery = countQuery + $" and p.first_name like '%{name}%'";

        paginationQuery += $" order by p.first_name {sort} limit {size} offset {offset};";

        var persons = _personRepository.FindWithPagedSearch(paginationQuery);
        int totalResults = _personRepository.GetCount(countQuery);

        return new PagedSearchVO<PersonVO>
        {
            CurrentPage = page,
            List = _converter.Parse(persons),
            PageSize = size,
            SortDirections = sort,
            TotalResults = totalResults
        };
    }

    public PersonVO FindById(long id)
    {
        return _converter.Parse(_personRepository.FindById(id));
    }

    public List<PersonVO> FindByName(string firstName, string lastName)
    {
        return _converter.Parse(_personRepository.FindByName(firstName, lastName));
    }

    public PersonVO Create(PersonVO person)
    {
        var personEntity = _converter.Parse(person);
        personEntity = _personRepository.Create(personEntity);
        return _converter.Parse(personEntity);
    }

    public PersonVO Update(PersonVO person)
    {
        if (!_personRepository.Exists(person.Id))
            return new PersonVO();

        var personEntity = _converter.Parse(person);
        personEntity = _personRepository.Update(personEntity);
        return _converter.Parse(personEntity);
    }

    public async Task<PersonVO> DisableAsync(long id)
    {
        var personEntity = await _personRepository.DisableAsync(id);
        return _converter.Parse(personEntity);
    }

    public void Delete(long id)
    {
        if (!_personRepository.Exists(id))
            return;

        _personRepository.Delete(id);
    }
}