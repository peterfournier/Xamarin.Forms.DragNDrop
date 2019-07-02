using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySquad.Models;

namespace MySquad.Services
{
    public class MockDataStore : IDataStore<Marine, Guid>
    {
        List<Marine> Marines;
        List<FireTeam> FireTeams;
        public MockDataStore()
        {
            Marines = new List<Marine>();
            var mockMarines = new List<Marine>
            {
                new Marine { Order = 1, FirstName = "Theo", LastName = "Robrecht", Rank = MarineCorpsRankFactory.Sergeant },
                new Marine { Order = 2, FirstName = "Ardito", LastName = "Prabhakar", Rank = MarineCorpsRankFactory.Corporal },
                new Marine { Order = 3, FirstName = "Gilbert", LastName = "Lupus", Rank = MarineCorpsRankFactory.Corporal },
                new Marine { Order = 4, FirstName = "Epaphras", LastName = "Teige", Rank = MarineCorpsRankFactory.Corporal },
                new Marine { Order = 5, FirstName = "Gerolamo", LastName = "Brett", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 6, FirstName = "Neo", LastName = "Devaraja", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 7, FirstName = "Roberto", LastName = "Ankit", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 8, FirstName = "Krishna", LastName = "Aryan", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 9, FirstName = "Kepheus", LastName = "Arnold", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 10, FirstName = "Manlius", LastName = "Maikel", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 11, FirstName = "Mpho", LastName = "Evander", Rank = MarineCorpsRankFactory.PrivateFirstClass },
                new Marine { Order = 12, FirstName = "Carran", LastName = "Otho", Rank = MarineCorpsRankFactory.PrivateFirstClass },
                new Marine { Order = 13, FirstName = "Manas", LastName = "Oddr", Rank = MarineCorpsRankFactory.Private },
                new Marine { Order = 14, FirstName = "Herb", LastName = "Dionysos", Rank = MarineCorpsRankFactory.Private },
            };

            FireTeams = new List<FireTeam>();
            FireTeams.Add(new FireTeam(
                "Alpha",
                new Marine { FirstName = "Ardito", LastName = "Prabhakar", Rank = MarineCorpsRankFactory.Corporal }
                )
            {
                new Marine { Order = 1, FirstName = "Gerolamo", LastName = "Brett", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 2, FirstName = "Neo", LastName = "Devaraja", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 3, FirstName = "Mpho", LastName = "Evander", Rank = MarineCorpsRankFactory.PrivateFirstClass },
                new Marine { Order = 4, FirstName = "Herb", LastName = "Dionysos", Rank = MarineCorpsRankFactory.Private },
                new Marine { Order = 5, FirstName = "Gerolamo", LastName = "Brett", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 6, FirstName = "Neo", LastName = "Devaraja", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 7, FirstName = "Roberto", LastName = "Ankit", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 8, FirstName = "Krishna", LastName = "Aryan", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 9, FirstName = "Kepheus", LastName = "Arnold", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 10, FirstName = "Manlius", LastName = "Maikel", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 11, FirstName = "Mpho", LastName = "Evander", Rank = MarineCorpsRankFactory.PrivateFirstClass },
                new Marine { Order = 12, FirstName = "Carran", LastName = "Otho", Rank = MarineCorpsRankFactory.PrivateFirstClass },
                new Marine { Order = 13, FirstName = "Manas", LastName = "Oddr", Rank = MarineCorpsRankFactory.Private },
                new Marine { Order = 14, FirstName = "Herb", LastName = "Dionysos", Rank = MarineCorpsRankFactory.Private },
            });
            FireTeams.Add(new FireTeam(
                "Bravor",
                new Marine { FirstName = "Gilbert", LastName = "Lupus", Rank = MarineCorpsRankFactory.Corporal }
                )
            {
                new Marine { Order = 1, FirstName = "Roberto", LastName = "Ankit", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 2, FirstName = "Krishna", LastName = "Aryan", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 3, FirstName = "Carran", LastName = "Otho", Rank = MarineCorpsRankFactory.PrivateFirstClass },

            });
            FireTeams.Add(new FireTeam(
                "Charlie",
                new Marine { FirstName = "Ardito", LastName = "Prabhakar", Rank = MarineCorpsRankFactory.Corporal }
                )
            {
                new Marine { Order = 1, FirstName = "Kepheus", LastName = "Arnold", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 2, FirstName = "Manlius", LastName = "Maikel", Rank = MarineCorpsRankFactory.LanceCorporal },
                new Marine { Order = 3, FirstName = "Manas", LastName = "Oddr", Rank = MarineCorpsRankFactory.Private },
            });

            foreach (var Marine in mockMarines)
            {
                Marines.Add(Marine);
            }
        }

        public async Task<bool> AddMarineAsync(Marine Marine)
        {
            Marines.Add(Marine);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMarineAsync(Marine Marine)
        {
            var oldMarine = Marines.Where((Marine arg) => arg.ID == Marine.ID).FirstOrDefault();
            Marines.Remove(oldMarine);
            Marines.Add(Marine);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMarineAsync(Guid id)
        {
            var oldMarine = Marines.Where((Marine arg) => arg.ID == id).FirstOrDefault();
            Marines.Remove(oldMarine);

            return await Task.FromResult(true);
        }

        public async Task<Marine> GetMarineAsync(Guid id)
        {
            return await Task.FromResult(Marines.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Marine>> GetMarinesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Marines);
        }

        public async Task<List<FireTeam>> GetFireTeamsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(FireTeams);
        }
    }
}