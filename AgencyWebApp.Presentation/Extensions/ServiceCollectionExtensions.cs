using AgencyWebApp.Application.Auth;
using AgencyWebApp.Application.Auth.Interfaces;
using AgencyWebApp.Application.Services.Implementations;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AgencyWebApp.Infrastructure.Repositories.Implementations;

namespace AgencyWebApp.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IReviewService, ReviewService>();
        }
        public static void AddAuth(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }
    }

}
