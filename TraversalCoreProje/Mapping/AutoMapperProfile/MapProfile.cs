using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement, AnnouncementAddDto>();

            CreateMap<AppUserLoginDTOs, AppUser>();
            CreateMap<AppUser, AppUserLoginDTOs>();

            CreateMap<AppUserRegisterDTOs, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTOs>();

            CreateMap<AnnouncementListDTO, Announcement>();
            CreateMap<Announcement, AnnouncementListDTO>();

            CreateMap<AnnouncementUpdateDto, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDto>();

            CreateMap<SendMessageDto, ContactUs>();
            CreateMap<ContactUs, SendMessageDto>();


        }
    }
}
