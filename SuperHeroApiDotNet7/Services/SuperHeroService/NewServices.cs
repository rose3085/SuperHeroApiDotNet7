
using Azure.Core;
using SuperHeroApiDotNet7.UnitOfWork;

namespace SuperHeroApiDotNet7.Services.SuperHeroService
{
    public class NewServices : INewServices
    {
        private const bool V = true;
        private readonly IUnitOfWork _unitOfWork;

        public NewServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddHero(SuperHeroModel hero)
        {
            if (hero != null)
            {
                await _unitOfWork.Name.Add(hero);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }



        public async void Update( SuperHeroModel request, int id)
        {

            var result = await _unitOfWork.Name.GetById(id);
            result.Name = request.Name;
            _unitOfWork.Name.UpdateField(result);
            _unitOfWork.Save();
        }

    }
}
