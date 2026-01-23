using AgencyWebApp.Application.DTOs.BookingDTOs;
using AgencyWebApp.Application.DTOs.FlightDto;
using AgencyWebApp.Application.DTOs.HotelDTOs;
using AgencyWebApp.Application.DTOs.ReviewDTOs;
using AgencyWebApp.Application.DTOs.TourDTOs;
using AgencyWebApp.Application.DTOs.UserDTOs;
using AgencyWebApp.Domain.Models;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgencyWebApp.Application.Profiles
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
