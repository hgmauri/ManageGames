using AutoMapper;
using ManageGames.Domain.Entities;
using ManageGames.Web.Models;

namespace ManageGames.Web.MapperProfile
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Genero, GeneroVM>();
            CreateMap<GeneroVM, Genero>();
            
            CreateMap<JogoVM, Jogo>();
            CreateMap<Jogo, JogoVM>();

            CreateMap<AmigoVM, Amigo>();
            CreateMap<Amigo, AmigoVM>();

            CreateMap<EmprestimoVM, Emprestimo>();
            CreateMap<Emprestimo, EmprestimoVM>();
        }
    }
}