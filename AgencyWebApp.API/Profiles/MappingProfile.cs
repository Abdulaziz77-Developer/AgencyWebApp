using AgencyWebApp.API.DTOs.BookingDTOs;
using AgencyWebApp.API.DTOs.FlightDto;
using AgencyWebApp.API.DTOs.HotelDTOs;
using AgencyWebApp.API.DTOs.ReviewDTOs;
using AgencyWebApp.API.DTOs.TourDTOs;
using AgencyWebApp.API.DTOs.UserDTOs;
using AgencyWebApp.API.Models;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgencyWebApp.API.Profiles
{

    public class MappingProfile : Profile   
    {
        public MappingProfile()
        {
            // User
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // Hotel
            CreateMap<Hotel, HotelDto>();
            CreateMap<CreateHotelDto, Hotel>();
            CreateMap<UpdateHotelDto, Hotel>();
            CreateMap<Hotel,UpdateHotelDto>();

            // Tour
            CreateMap<Tour, TourDto>();
            CreateMap<CreateTourDto, Tour>();
            CreateMap<UpdateTourDto, Tour>();
            CreateMap<TourPoint, TourPointDto>();

            // Flight
            CreateMap<Flight, FlightDto>();
            CreateMap<CreateFlightDto, Flight>();
            CreateMap<UpdateFlightDto, Flight>();

            // Review
            CreateMap<Review, ReviewDto>();
            CreateMap<CreateReviewDto, Review>();
            CreateMap<UpdateReviewDto, Review>();

            // Booking
            CreateMap<Booking, BookingDto>();
            CreateMap<CreateBookingDto, Booking>();
            CreateMap<UpdateBookingDto, Booking>();
        }
    }
}
