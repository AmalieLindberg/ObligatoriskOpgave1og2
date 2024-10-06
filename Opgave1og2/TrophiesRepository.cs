using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgaveTredjeSemester
{
    public class TrophiesRepository
    {
        private readonly List<Trophy> _trophies = new();
        private int _nextId = 1;

        //Klassen skal indeholde en liste af Trophy objekter. Indsæt mindst 5 objekter i listen.
        public TrophiesRepository()
        {
            _trophies.Add(new Trophy() { Id = 1, Competition = "Football", Year = 1972 });
            _trophies.Add(new Trophy() { Id = 2, Competition = "Basketball", Year = 1981 });
            _trophies.Add(new Trophy() { Id = 3, Competition = "Tennis", Year = 1986 });
            _trophies.Add(new Trophy() { Id = 4, Competition = "Golf", Year = 1997 });
            _trophies.Add(new Trophy() { Id = 5, Competition = "Boxing", Year = 2014 });
        }

        public IEnumerable<Trophy> Get(int? yearAfter = null, string? competitionIncludes = null, string? orderBy = null)
        {
            //Returnerer en kopi af listen af alle Trophy objekter: Brug en copy constructor.
            IEnumerable<Trophy> result = new List<Trophy>(_trophies);

            //Get() skal give mulighed for at filtrere på Year.
            if (yearAfter != null)
            {
                result = result.Where(m => m.Year > yearAfter);
            }
            if (competitionIncludes != null)
            {
                result = result.Where(m => m.Competition.Contains(competitionIncludes));
            }

            //Get() skal give mulighed for at sortere på Competition eller Year .
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "competition":
                    case "competition_asc":
                        result = result.OrderBy(m => m.Competition);
                        break;
                    case "competition_desc":
                        result = result.OrderByDescending(m => m.Competition);
                        break;
                    case "year":
                    case "year_asc":
                        result = result.OrderBy(m => m.Year);
                        break;
                    case "year_desc":
                        result = result.OrderByDescending(m => m.Year);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        //Returnerer Trophy objektet med det angivne id - eller null.
        public Trophy? GetById(int id)
        {
            return _trophies.Find(trophy => trophy.Id == id);
        }

        //Tilføj id til trophy objektet. Tilføjer trophy til listen. Returnerer Trophy objektet
        public Trophy Add(Trophy trophy)
        {
            trophy.Id = _nextId;
            _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }

        //Sletter Trophy objektet med det angivne id. Returnerer Trophy objektet - eller null.
        public Trophy Delete(int id)
        {
            if (id != null)
            {
                Trophy trophy = _trophies.FirstOrDefault(t => t.Id == id);
                if (trophy != null)
                {
                    _trophies.Remove(trophy);
                }
                return trophy;
            }
            return null;
        }

        //Trophy objektet med det angivne id opdateres med values.
        //Returnerer det opdaterede Trophy objekt - eller null.
        public Trophy Update(int id, Trophy values)
        {
            values.Validate();
            Trophy trophy = _trophies.FirstOrDefault(t => t.Id == id);

            if (trophy != null && values != null)
            {
                trophy.Competition = values.Competition;
                trophy.Year = values.Year;
                return trophy;
            }
            return null;
        }
    }
}
