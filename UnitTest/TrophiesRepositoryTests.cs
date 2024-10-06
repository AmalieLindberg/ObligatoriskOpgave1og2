using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObligatoriskOpgaveTredjeSemester;

namespace UnitTest
{
    [TestClass]
    public class TrophiesRepositoryTests
    {
        private readonly Trophy TrophyHighYear = new() { Competition = "Cricket", Year = 2026 };
        private TrophiesRepository _trophiesRepository;

        [TestInitialize]
        public void Setup()
        {
            _trophiesRepository = new TrophiesRepository();
        }

        [TestMethod]
        public void GetTest()
        {
            IEnumerable<Trophy> trophies = _trophiesRepository.Get(orderBy: "competition");
            Assert.AreEqual(trophies.First().Competition, "Boxing");

            trophies = _trophiesRepository.Get(orderBy: "year");
            Assert.AreEqual(trophies.First().Competition, "Tennis");

            trophies = _trophiesRepository.Get(yearAfter: 1979);
            Assert.AreEqual(4, trophies.Count());
            Assert.AreEqual(trophies.First().Year, 1997);
        }

        [TestMethod()]
        public void RemoveTrophyTest()
        {
            Assert.IsNull(_trophiesRepository.Delete(100));
            Assert.AreEqual(1, _trophiesRepository.Delete(1)?.Id);
            Assert.AreEqual(4, _trophiesRepository.Get().Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            Assert.AreEqual(5, _trophiesRepository.Get().Count());
            Trophy t = new() { Competition = "Cricket", Year = 2023 };
            Assert.IsNull(_trophiesRepository.Update(7, t));
            Assert.AreEqual(1, _trophiesRepository.Update(1, t)?.Id);
            Assert.AreEqual(5, _trophiesRepository.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _trophiesRepository.Update(1, TrophyHighYear));
        }
    }
}
