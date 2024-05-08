using Dwellers.DwellerCore.Domain.Entities.Dwellings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Application.Interfaces.DwellerCore.Dwellings
{
    public interface IDwellingQueryRepository
    {
        Task<List<string>> GetAllDwellingNames();
        Task<Dwelling> GetDwellingByIdAsync(Guid id);
        Task<Dwelling> GetDwellingByDwellingInhabitantAsync(string dwellerId);

        Task<List<Dwelling>> GetAllDwellingsByListOfIdsAsync(List<Guid> listOfDwellings);
        Task<List<Dwelling>> GetConnectedDwellingsById(List<Guid> dwellingIds);

    }
}
