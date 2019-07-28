using AutoMapper;
using PersonDiary.Entities;
using LifeEventContract = PersonDiary.Contracts.LifeEventContract.LifeEvent;
using PersonContract = PersonDiary.Contracts.PersonContract.Person;

namespace PersonDiary.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<PersonContract, Person>();
            CreateMap<Person, PersonContract>().ForMember(dist => dist.HasFile, opt => opt.MapFrom(src => src.Biography != null));
            CreateMap<LifeEventContract, LifeEvent>();
            CreateMap<LifeEvent, LifeEventContract>().ForMember(dist => dist.Personfullname, opt => opt.MapFrom(src => $"{src.Person.Name} {src.Person.Surname}"));
        }
    }
}
