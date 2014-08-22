using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LegalAmountConverter;

namespace TestLegalAmountConverter
{
    [TestFixture]
    public class EnglishAndMelayuTest
    {
        private English eng, eng2, eng3;
        private Melayu malay, malay2;
        
        [SetUp]
        public void makeNewBasicApplicationInstance()
        {
          eng = new English(8888.88);
          malay = new Melayu(8888.88);
          eng2 = new English(-100);
          eng3 = new English(8888);
          malay2 = new Melayu(8888);
        }

        [Test]       
        public void English_Converter_TestDoubleAndInteger()
        {
            string words = eng.Converter();
            string words2 = eng3.Converter();
            Assert.AreEqual("Eight Thousand Eight Hundred Eighty Eight And Cents Eighty Eight only", words);
            Assert.AreEqual("Eight Thousand Eight Hundred Eighty Eight ", words2);
        }

        [Test]
        public void Melayu_Converter_TestDoubleAndInteger()
        {
            string words = malay.Converter();
            string words2 = malay2.Converter();
            Assert.AreEqual("Lapan Ribu Lapan Ratus Lapan Puluh Lapan Dan Sen Lapan Puluh Lapan sahaja", words);
            Assert.AreEqual("Lapan Ribu Lapan Ratus Lapan Puluh Lapan ", words2);
        }

        [Test]
        [TestCase(0, "")]
        [TestCase(19.99, "Ninteen And Cents Ninty Nine only")]
        [TestCase(99.99, "Ninty Nine And Cents Ninty Nine only")]
        [TestCase(999.99, "Nine Hundred Ninty Nine And Cents Ninty Nine only")]
        [TestCase(9999.99, "Nine Thousand Nine Hundred Ninty Nine And Cents Ninty Nine only")]
        [TestCase(19999.99, "Ninteen Thousand Nine Hundred Ninty Nine And Cents Ninty Nine only")]
        [TestCase(99999.99, "Ninty Nine Thousand Nine Hundred Ninty Nine And Cents Ninty Nine only")]
        [TestCase(999999.99, "Nine Hundred Ninty Nine Thousand Nine Hundred Ninty Nine And Cents Ninty Nine only")]
        public void Converter_boundaryValueAnalysis(double amount, string expectedWords)
        {
            English eng4 = new English(amount);
            string words3 = eng4.Converter();
            Assert.AreEqual(expectedWords, words3);
        }

        [Test]
        [ExpectedException(typeof(NegativeNumberException))]
        public void NegativeNumber_Exception_Throw()
        {
            string words = eng2.Converter();
            throw new NegativeNumberException();
        }



       

    }
}
