using AutoMapper;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.VM.Client;
using SSH_FrontEnd.VM.EventVM;


namespace SSH_FrontEnd
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Event, EventDTO>().ReverseMap();
          

            CreateMap<Florist, FloristDTO>().ReverseMap();
            

            CreateMap<VenueProvider, VenueProviderDTO>().ReverseMap();
           

            CreateMap<OrderStatus, OrderStatusDTO>().ReverseMap();
           
            CreateMap<VenueType, VenueTypeDTO>().ReverseMap();
            

            CreateMap<Venue, VenueDTO>().ReverseMap();
          

            CreateMap<VenueOrder, VenueOrderDTO>().ReverseMap();
           

            CreateMap<FlowerArrangementType, FlowerArrangementTypeDTO>().ReverseMap();
            

            CreateMap<FlowerArrangementOrder, FlowerArrangementOrderDTO>().ReverseMap();
          

            CreateMap<FlowerArrangement, FlowerArrangementDTO>().ReverseMap();
        
           

            CreateMap<PerformerType, PerformerTypeDTO>().ReverseMap();
           

            CreateMap<MusicProvider, MusicProviderDTO>().ReverseMap();
          

            CreateMap<MusicProviderOrder, MusicProviderOrderDTO>().ReverseMap();
           

            CreateMap<MenuTypeDTO, MenuType>().ReverseMap();
          

            CreateMap<MenuOrderDTO, MenuOrder>().ReverseMap();
          

            CreateMap<Menu, MenuDTO>().ReverseMap();
          

            CreateMap<PlaylistItem, PlaylistItemDTO>().ReverseMap();
         

            CreateMap<PartnerStatus, PartnerStatusDTO>().ReverseMap();
          

            CreateMap<PastryShop, PastryShopDTO>().ReverseMap();
         

            CreateMap<Pastry, PastryDTO>().ReverseMap();
        

            CreateMap<PastryOrder, PastryOrderDTO>().ReverseMap();
        

            CreateMap<Pastry, PastryTypeDTO>().ReverseMap();
          

       


            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();

            CreateMap<EventDTO, MyEventsViewModel>().ReverseMap();
            CreateMap<ApplicationUserDTO, ProfileViewModel>().ReverseMap();


        }
    }
}
