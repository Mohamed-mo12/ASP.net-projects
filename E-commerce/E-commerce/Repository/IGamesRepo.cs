using E_commerce.Models;
using E_commerce.ViewModel;

namespace E_commerce.Repository
{
    public interface IGamesRepo
    {
        Task Create(CreateGameViewModel Game);
        List<Game> GetAll();

        Task<Game?> Update(UpdateViewModel update);

        Game? GetDetails(int id);
        void Delete(int id); 
    }

    
}
