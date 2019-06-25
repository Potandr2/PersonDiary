using AutoMapper;
using PersonDiary.Entities;
using PersonContract = PersonDiary.Contracts.PersonContract.Person;
using LifeEventContract = PersonDiary.Contracts.LifeEventContract.LifeEvent;

namespace PersonDiary.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<PersonContract , Person>();
            CreateMap<Person, PersonContract>();
            CreateMap<LifeEventContract, LifeEvent>();
            CreateMap<LifeEvent, LifeEventContract>().ForMember(dist=>dist.PersonFullName,opt=>opt.MapFrom(src=>$"{src.Person.Name} {src.Person.Surname}"));
        }
    }
}
