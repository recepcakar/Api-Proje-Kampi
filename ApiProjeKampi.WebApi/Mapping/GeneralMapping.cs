using ApiProjeKampi.WebApi.Dtos.FutureDtos;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;

namespace ApiProjeKampi.WebApi.Mapping
{
    public class GeneralMapping  : Profile //Profile sınıfından mirasa aldık
    {
        public GeneralMapping()
        {

            CreateMap<Feature,CreateFeatureDto>().ReverseMap();
          CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
          CreateMap<Feature,ResultFeatureDto>().ReverseMap();
          CreateMap<Feature,GetByIdFeatureDto>().ReverseMap();


          CreateMap<Message, ResultMessageDto>().ReverseMap();
          CreateMap<Message,CreateMessageDto>().ReverseMap();
          CreateMap<Message,GetByIdMessageDto>().ReverseMap();
          CreateMap<Message,UpdateMessageDto>().ReverseMap();
      
        }
    }
}
