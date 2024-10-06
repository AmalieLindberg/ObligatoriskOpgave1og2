using ObligatoriskOpgaveTredjeSemester;

namespace UnitTest
{
    [TestClass]
    public class TrophyTests
    {
        private readonly Trophy _trophy = new() { Id = 1, Competition = "Rugby", Year = 2010 };
        private readonly Trophy _nullCompetition = new() { Id = 2, Year = 2022 };
        private readonly Trophy _emptyCompetition = new Trophy() { Id = 3, Competition = "", Year = 2003 };
        private readonly Trophy _highYear = new Trophy() { Id = 4, Competition = "Swimming", Year = 2026 };

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("1 Rugby 2010", _trophy.ToString());
        }

        [TestMethod()]
        public void ValidateCompetitionTest()
        {
            _trophy.ValidateCompetition();
            Assert.ThrowsException<ArgumentNullException>(() => _nullCompetition.ValidateCompetition());
            Assert.ThrowsException<ArgumentException>(() => _emptyCompetition.ValidateCompetition());
        }

        public void ValidateYearTest()
        {
            _trophy.ValidateYear();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _highYear.ValidateYear());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            _trophy.Validate();
        }
    }
}