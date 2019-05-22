using AutoMapper;

namespace BlazorDemoClient.Mappers
{
    public static class MapperProvider
    {
        public static IMapper CreateMapper() => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<HockeyProfile>();
        }).CreateMapper();
    }
}