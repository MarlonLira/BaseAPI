using AutoMapper;

namespace Application.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper mapper { get; set; }

        public static void RegisterMapping()
        {
            var mapperConfig = new MapperConfiguration(
                config =>
                {
                    config.AddProfile<EntityToModel>();
                }
            );

            mapper = mapperConfig.CreateMapper();
        }
    }
}
