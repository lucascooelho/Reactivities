using System.Linq;
using Application.Activities;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
            CreateMap<Activity, ActivityDto>()
                .ForMember(destination => destination.HostUsername, options =>
                    options.MapFrom(s => s.Attendees.FirstOrDefault(x => x.IsHost).AppUser.UserName));

            CreateMap<ActivityAttendee, Profiles.Profile>()
                .ForMember(destination => destination.DisplayName, options => options.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(destination => destination.Username, options => options.MapFrom(s => s.AppUser.UserName))
                .ForMember(destination => destination.Bio, options => options.MapFrom(s => s.AppUser.Bio));

        }
    }
}