using AngularWebApp.BusinessLogic.Companies.Models;
using AngularWebApp.BusinessLogic.Users.Models;
using AngularWebApp.Data.Entities.Companies.Models;
using AngularWebApp.Data.Entities.Users.Models;
using AutoMapper;

namespace AngularWebApp.BusinessLogic.Users
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Company, CompanyDto>()
        .ForMember(c => c.FullAddress,
            opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
