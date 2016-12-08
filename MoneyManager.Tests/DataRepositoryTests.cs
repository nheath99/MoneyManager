using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyManager.Data;
using FluentAssertions;

namespace MoneyManager.Tests
{
    [TestClass]
    public class DataRepositoryTests
    {
        [TestMethod]
        public void NextOccurenceTest()
        {
            RepeatingTransaction r1 = new RepeatingTransaction()
            {
                NextOccurence = new DateTime(2010, 1, 1),
                Repeat = RepeatingTransaction.RepeatType.None
            };

            DataRepository repo = new DataRepository();
            repo.GetNextOccurance(r1).Should().BeNull();
        }
    }
}
