namespace ManagePolicy.WebApp.Extensions.AutoMapper
{
    using GlarisEngine.UserLinkTracker.Domain.Authentication;
    using GlarisEngine.UserLinkTracker.WebAppMVC.Models.Authentication;
    using global::AutoMapper;
    public class AutoMapperProfile : Profile

    {
        // Policy to ViewModel and Vice versa - Data Transfer (Object to Object Mapping)
        public AutoMapperProfile()
        {
            AllowNullDestinationValues = true;

            #region Authentication

            CreateMap<RegisterUserViewModel, User>().ReverseMap();

            CreateMap<LoginUserViewModel, User>().ReverseMap();

            #endregion Authentication    


        }
    }
}
