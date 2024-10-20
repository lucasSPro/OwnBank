using AutoMapper;
using GestorAvaliacao.Application.Services.AutoMapper;


namespace UtilidadesComumsTestes.Mapper
{
    public class MapperBuilder
    {
        public static IMapper Build()
        {
            return new MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();
        }
    }
}
