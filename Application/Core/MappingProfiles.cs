using System.Linq;
using Application.Activities;
using Application.Comments;
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
                    options.MapFrom(source => source.Attendees.FirstOrDefault(x => x.IsHost).AppUser.UserName));

            CreateMap<ActivityAttendee, AttendeeDto>()
                .ForMember(destination => destination.DisplayName, options => options.MapFrom(source => source.AppUser.DisplayName))
                .ForMember(destination => destination.Username, options => options.MapFrom(source => source.AppUser.UserName))
                .ForMember(destination => destination.Bio, options => options.MapFrom(source => source.AppUser.Bio))
                .ForMember(destination => destination.Image, options =>
                    options.MapFrom(source => source.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<AppUser, Profiles.Profile>()
                .ForMember(destination => destination.Image, options =>
                    options.MapFrom(source => source.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<Comment, CommentDto>()
                .ForMember(destination => destination.DisplayName, options => options.MapFrom(source => source.Author.DisplayName))
                    .ForMember(destination => destination.Username, options => options.MapFrom(source => source.Author.UserName))
                    .ForMember(destination => destination.Image, options =>
                        options.MapFrom(source => source.Author.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}