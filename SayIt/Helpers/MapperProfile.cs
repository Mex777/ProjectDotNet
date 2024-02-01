using AutoMapper;
using SayIt.Models.Posts;
using SayIt.Models.Tables;

namespace SayIt.Helpers;

public class MapperProfile : Profile
{
   public MapperProfile()
   {
      CreateMap<Post, PostDTO>()
         .ForMember(
            p => p.Author,
            opts => opts.MapFrom(po => po.Author.Username)
            );
      
      // CreateMap<User, List<PostDTO>>()
         // .ForMember(dest => dest, opt => opt.MapFrom(src => src.Posts));
      // CreateMap<Book, BookDto>()
      //    .ForMember(
      //       bd => bd.PublisherName, 
      //       opts => opts.MapFrom(b => b.Publisher.Name)
      //       );

      // CreateMap<Publisher, PublisherDto>().ForMember(pd => pd.Books,
      // opts => opts.MapFrom(p => p.Books));
   } 
}