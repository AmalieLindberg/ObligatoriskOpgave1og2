using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgaveTredjeSemester
{
    public class Trophy
    {
        public int Id { get; set; }
        public string? Competition { get; set; }
        public int Year { get; set; }

        public Trophy(int id, string? competition, int year)
        {
            Id = id;
            Competition = competition;
            Year = year;
        }

        public Trophy() { }

        //ToString() metode
        public override string ToString()
        {
            return $"{Id} {Competition} {Year}";
        }

        //Competition, tekst-streng, min 3 tegn langt, må ikke være null
        public void ValidateCompetition()
        {

            if (Competition == null)
            {
                throw new ArgumentNullException(nameof(Competition), "Competition cannot be null");
            }
            if (Competition.Length < 3)
            {
                throw new ArgumentException("Competition must be at least three characters", nameof(Competition));
            }
        }

        //Year, tal, 1970 <= year  <= 2024
        public void ValidateYear()
        {
            if (Year < 1970)
            {
                throw new ArgumentOutOfRangeException(nameof(Year), "Year must be over 1970");
            }
            if (Year >= 2024)
            {
                throw new ArgumentOutOfRangeException(nameof(Year), "Year can't be over 2024");
            }
        }

        public void Validate()
        {
            ValidateCompetition();
            ValidateYear();
        }
    }
}
