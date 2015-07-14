// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoaderManagerTests.cs" company="">
//   
// </copyright>
// <summary>
//   The loader manager tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AssignmentLuxoftTests
{
    using System.Collections.Generic;
    using System.Linq;

    using AssignmentLuxoft.Contracts;
    using AssignmentLuxoft.Loaders;

    using Xunit;

    /// <summary>
    ///     The loader manager tests.
    /// </summary>
    public class LoaderManagerTests
    {
        /// <summary>
        ///     The sut.
        /// </summary>
        private LoaderManager sut;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoaderManagerTests"/> class.
        /// </summary>
        public LoaderManagerTests()
        {
            this.sut =
                new LoaderManager(
                    new List<TradeLoaderBase>
                        {
                            new TextTradeLoader { IsActive = false }, 
                            new CsvTradeLoader { IsActive = true }
                        });
        }


        /// <summary>
        /// the get trade loader_ should return_ correct loader.
        /// </summary>
        [Fact]
        public void GetTradeLoader_ShouldReturn_CorrectLoader()
        {
            var expected = typeof(CsvTradeLoader);

            var actual = this.sut.GetTradeLoader(".csv");

            Assert.Equal(expected, actual.GetType());
        }

        /// <summary>
        /// The get trade loader_ should return null_ if correct loader is inactive.
        /// </summary>
        [Fact]
        public void GetTradeLoader_ShouldReturnNull_IfCorrectLoaderIsInactive()
        {
            var actual = this.sut.GetTradeLoader(".txt");

            Assert.Null(actual);
        }

        /// <summary>
        /// Initialize_s the should_ add three default loaders.
        /// </summary>
        [Fact]
        public void Initialize_Should_AddThreeDefaultLoaders()
        {
            sut.Initialize();
            
            Assert.NotNull(sut.Loaders.FirstOrDefault(loader => loader.GetType() == typeof(CsvTradeLoader)));
            Assert.NotNull(sut.Loaders.FirstOrDefault(loader => loader.GetType() == typeof(TextTradeLoader)));
            Assert.NotNull(sut.Loaders.FirstOrDefault(loader => loader.GetType() == typeof(XmlTradeLoader)));
        }
    }
}