using Model.MasterModel;
using Model.People;
using Persistence.Repositories.Interfaces;
using Services.DTO_s;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Business.StatService
{
    public class StatService : IStatService
    {
        private IPeopleRepository peopleRepository { get; set; }

        public StatService( IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }
        public async Task<StatsDTO> getStats()
        {
            IList<Person> people = await peopleRepository.GetAllAsync();

            return mapToStatDto(people);
        }


        private StatsDTO mapToStatDto(IList<Person> people)
        {
            StatsDTO statsDTO = new StatsDTO();

            if (people == null)
                return statsDTO;

            statsDTO.Healthy = people.Where(x => x.IdResult == Result.HELTHY).Count();
            statsDTO.Infected = people.Where(x => x.IdResult == Result.INFECTED).Count();
            statsDTO.Inmune = people.Where(x => x.IdResult == Result.INMUNE).Count();

            return statsDTO;
        }
    }
}
