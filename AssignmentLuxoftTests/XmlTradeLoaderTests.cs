using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLuxoftTests
{
    using System.IO;

    using AssignmentLuxoft.Loaders;
    using AssignmentLuxoft.Models;

    using Xunit;

    public class XmlTradeLoaderTests
    {
        private XmlTradeLoader sut;

        public XmlTradeLoaderTests()
        {
            sut = new XmlTradeLoader();
            
        }

        [Fact]
        public void SupportedSourceType_ShouldBe_xml()
        {
            var expected = ".xml";

            Assert.Equal(expected, sut.SupportedSourceType);
        }

        [Fact]
        public async void ExtractTrades_Should_ReturnCorrectTrades()
        {
            using (var fs = new FileStream(TestConfig.PathToXmlFile, FileMode.Open))
            {
                var trades = await this.sut.ExtractTrades(fs);
                var expectedTrade = new Trade
                                        {
                                            Date = new DateTime(2013, 5, 20),
                                            Open = 30.16m,
                                            High = 30.39m,
                                            Low = 30.02m,
                                            Close = 30.17m,
                                            Volume = 1478200
                                        };

                Assert.Equal(expectedTrade.Date, trades[0].Date);
                Assert.Equal(expectedTrade.Open, trades[0].Open);
                Assert.Equal(expectedTrade.High, trades[0].High);
                Assert.Equal(expectedTrade.Low, trades[0].Low);
                Assert.Equal(expectedTrade.Close, trades[0].Close);
                Assert.Equal(expectedTrade.Volume, trades[0].Volume);
            }
        }

        [Fact]
        public async void ExtractTrades_Should_ThrowOnIncorrectFormat()
        {
            using (var fs = new FileStream(TestConfig.PathToCsvFile, FileMode.Open))
            {
                try
                {
                    this.sut.ExtractTrades(fs);
                }
                catch (Exception ex)
                {
                    Assert.IsType<InvalidDataException>(ex);
                }
            }
        }
    }
}
