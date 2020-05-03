// <copyright file="LogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace LoLesports.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using LoLesports.Data;
    using LoLesports.Logic;
    using LoLesports.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests Logic methods.
    /// </summary>
    [TestFixture]
    public class LogicTests
    {
        private static Mock<IRepository<Liga>> testliga;
        private static Mock<IRepository<Jatekos>> testjatekos;
        private static Mock<IRepository<Csapat>> testcsapat;

        private static JatekosLogic testjatekoslogic;
        private static CsapatLogic testcsapatlogic;
        private static LigaLogic testligalogic;

        private static List<Jatekos> jatekoslist;
        private static List<Csapat> csapatlist;
        private static List<Liga> ligalist;

        /// <summary>
        /// Sets up mocked repos , testlists for all tests.
        /// </summary>
        [SetUp]
        public static void SetupRepos()
        {
            testliga = new Mock<IRepository<Liga>>();
            testcsapat = new Mock<IRepository<Csapat>>();
            testjatekos = new Mock<IRepository<Jatekos>>();

            testjatekoslogic = new JatekosLogic(testjatekos.Object, testcsapat.Object, testliga.Object);
            testcsapatlogic = new CsapatLogic(testcsapat.Object);
            testligalogic = new LigaLogic(testliga.Object);

            jatekoslist = new List<Jatekos>();
            jatekoslist.Add(new Jatekos() { Felhasznalonev = "Jozsi", Vezeteknev = "asd", Keresztnev = "asd", Eletkor = 15, Pozicio = "asd", Nemzetiseg = "Hungary", Csapatnev = "G2 Esports" });
            jatekoslist.Add(new Jatekos() { Felhasznalonev = "Pityu", Vezeteknev = "asd", Keresztnev = "asd", Eletkor = 15, Pozicio = "asd", Nemzetiseg = "Hungary", Csapatnev = "G2 Esports" });
            jatekoslist.Add(new Jatekos() { Felhasznalonev = "Mark", Vezeteknev = "Oh", Keresztnev = "Hi", Eletkor = 50, Pozicio = "asd", Nemzetiseg = "Poland", Csapatnev = "Cloud9" });

            csapatlist = new List<Csapat>();
            csapatlist.Add(new Csapat() { Csapatnev = "G2 Esports", Liga_nev = "LEC", Csapat_rovidites = "G2", Org_szekhely = "Germany", Alapitas_datum = null, Fo_edzo = "Szabó Péter", Bajnoksag_reszvetel = true });
            csapatlist.Add(new Csapat() { Csapatnev = "SK Telecom T1", Liga_nev = "LCK", Csapat_rovidites = "SKT", Org_szekhely = "Korea", Alapitas_datum = null, Fo_edzo = "Szabó Péter", Bajnoksag_reszvetel = true });
            csapatlist.Add(new Csapat() { Csapatnev = "Cloud9", Liga_nev = "LCS", Csapat_rovidites = "C9", Org_szekhely = "USA", Alapitas_datum = null, Fo_edzo = "Reapered", Bajnoksag_reszvetel = true });
            csapatlist.Add(new Csapat() { Csapatnev = "Excel Esports", Liga_nev = "LEC", Csapat_rovidites = "EX", Org_szekhely = "UK", Alapitas_datum = null, Fo_edzo = "Peter Dun", Bajnoksag_reszvetel = false });

            ligalist = new List<Liga>();
            ligalist.Add(new Liga() { Liga_nev = "LEC", Regio = "EU", Studio_hely = "Germany", Szezon_kezdet = new DateTime(1999, 11, 10), Szezon_vege = new DateTime(1999, 11, 12), Csapatok_szama = 10 });
        }

        /// <summary>
        /// Tests CreateLigaElement function.
        /// </summary>
        [Test]
        public void CreateLigaElement_Test()
        {
            // Arrange
            List<object> createlisttest = new List<object>()
            {
            "LCS", "NA", "USA", new DateTime(1999, 11, 4), new DateTime(1999, 11, 10), 12,
            };

            testliga.Setup(r => r.GetTableElement((string)createlisttest[0])).Returns((Liga)null);

            // Act, Assert
            Assert.That(testligalogic.CreateLigaElement(createlisttest), Is.True);
            testliga.Verify(l => l.CreateElement(createlisttest), Times.Once);
            testliga.Verify(l => l.GetTableElement(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        /// Tests UpdateJatekosElement function.
        /// </summary>
        [Test]
        public void UpdateJatekos_Test()
        {
            // Arrange
            List<object> updatelisttest = new List<object>()
            {
             "Jozsi", "yozsi", "asd", 99,  "asd",  "asd", "G2 Esports",
            };

            testjatekos.Setup(x => x.GetTableElement(It.IsAny<string>())).Returns(new Jatekos() { Felhasznalonev = "Jozsi", Vezeteknev = "asd", Keresztnev = "asd", Eletkor = 99, Pozicio = "asd", Nemzetiseg = "asd", Csapatnev = "G2 Esports" }).Verifiable();

            // Act,Assert
            Assert.That(testjatekoslogic.UpdateJatekosElement(updatelisttest), Is.True);
            testjatekos.Verify(x => x.UpdateElement(updatelisttest), Times.Once);
            testjatekos.Verify(mock => mock.GetTableElement(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        /// Tests DeleteCsapatElement function.
        /// </summary>
        [Test]
        public void DeleteCsapat_Test()
        {
            // Arrange
            string deletetest = "SK Telecom T1";
            testcsapat.Setup(x => x.GetTableElement(It.IsAny<string>())).Returns(new Csapat() { Csapatnev = "SK Telecom T1", Liga_nev = "LCK", Csapat_rovidites = "SKT", Org_szekhely = "Korea", Alapitas_datum = null, Fo_edzo = "Szabó Péter", Bajnoksag_reszvetel = true }).Verifiable();

            // Act, Assert
            Assert.That(testcsapatlogic.DeleteCsapatElement(deletetest), Is.True);
            testcsapat.Verify(mock => mock.GetTableElement(It.IsAny<string>()), Times.Once);
            testcsapat.Verify(mock => mock.DeleteElement(deletetest), Times.Once);
        }

        /// <summary>
        /// Tests GetSingleLigaElement function.
        /// </summary>
        [Test]
        public void ReadSingleLiga_Test()
        {
            // Arrange
            string readsingletestinput = "LEC";
            testliga.Setup(m => m.GetTableElement(It.IsAny<string>())).Returns(new Liga() { Liga_nev = "LEC", Regio = "EU", Studio_hely = "Germany", Szezon_kezdet = new DateTime(1999, 11, 10), Szezon_vege = new DateTime(1999, 11, 12), Csapatok_szama = 10 }).Verifiable();

            // Act, Assert
            testligalogic.GetSingleLigaData(readsingletestinput);
            testliga.Verify(x => x.GetTableElement(It.IsAny<string>()), Times.Once);
            testliga.Verify(x => x.GetSingleTableData(It.IsAny<Liga>()), Times.Once);
        }

        /// <summary>
        /// Tests GetLigaData function.
        /// </summary>
        [Test]
        public void ReadAllLiga_Test()
        {
            // Arrange
            List<Liga> readlist = new List<Liga>();
            readlist.Add(new Liga() { Liga_nev = "LEC", Regio = "EU", Studio_hely = "Germany", Szezon_kezdet = new DateTime(1999, 11, 10), Szezon_vege = new DateTime(1999, 11, 12), Csapatok_szama = 10 });

            StringBuilder readoutput = new StringBuilder();
            readoutput.AppendLine("Liganév: LEC, Régió: EU, Stúdió helye: Germany, Szezon kezdete: 1999. 11. 10. 0:00:00, Szezon vége: 1999. 11. 12. 0:00:00, Csapatok száma: 10");
            testliga.Setup(x => x.GetTableElements()).Returns(readlist.AsQueryable());

            // Act, Assert
            testligalogic.GetLigaData();
            testliga.Verify(x => x.GetTableElements(), Times.Once);
            testliga.Verify(x => x.GetTableData(readlist), Times.Once);
        }

        /// <summary>
        /// Tests FullInfo function.
        /// </summary>
        [Test]
        public void FullInfo_Test()
        {
            // Arrange
            string infotestinput = "Jozsi";
            StringBuilder readoutput = new StringBuilder();

            testjatekos.Setup(x => x.GetTableElements()).Returns(jatekoslist.AsQueryable());
            testcsapat.Setup(x => x.GetTableElements()).Returns(csapatlist.AsQueryable());
            testliga.Setup(x => x.GetTableElements()).Returns(ligalist.AsQueryable());
            testjatekos.Setup(x => x.GetTableElement(It.IsAny<string>())).Returns(new Jatekos() { Felhasznalonev = "Jozsi", Vezeteknev = "asd", Keresztnev = "asd", Eletkor = 15, Pozicio = "asd", Nemzetiseg = "asd", Csapatnev = "G2 Esports" }).Verifiable();

            // Act, Assert
            testjatekoslogic.GetFullInfo(infotestinput);
            testjatekos.Verify(x => x.GetTableElement(It.IsAny<string>()), Times.Exactly(4));  // 1x hogy nem null, 3x összes játékos feltétel check
            Assert.That(testjatekoslogic.GetFullInfo(infotestinput).ToString(), Contains.Substring("Csapat játékosainak száma: 2")); // csak 2 mert a 3-nak nem egyezik a csapat
            Assert.That(testjatekoslogic.GetFullInfo(infotestinput).ToString(), Contains.Substring("LEC"));
        }

        /// <summary>
        /// Tests MatchCreator function.
        /// </summary>
        [Test]
        public void MatchCreator_Test()
        {
            // Arrange
            string matchcreatorinput = "SK Telecom T1";
            IEnumerable<string> expectedresult = new string[] { "G2 Esports", "Cloud9" };

            testcsapat.Setup(x => x.GetTableElement(It.IsAny<string>())).Returns(new Csapat() { Csapatnev = "SK Telecom T1", Liga_nev = "LCK", Csapat_rovidites = "SKT", Org_szekhely = "South Korea", Alapitas_datum = new DateTime(2014, 02, 15), Fo_edzo = "Kim 'kkOma' Jeong-gyun", Bajnoksag_reszvetel = true }).Verifiable();
            testcsapat.Setup(x => x.GetTableElements()).Returns(csapatlist.AsQueryable());

            // Act, Assert
            var result = testcsapatlogic.MatchCreator(matchcreatorinput);
            testcsapat.Verify(x => x.GetTableElement(It.IsAny<string>()), Times.Once);
            testcsapat.Verify(x => x.GetTableElements(), Times.Once);
            Assert.That(result.Count(), Is.EqualTo(2)); // mert nem lehet ellenfél: 1.saját maga 2. aki nem vesz a bajnokságon részt
            Assert.That(result, Is.EqualTo(expectedresult));
        }

        /// <summary>
        /// Tests GetPlayersByCountry function.
        /// </summary>
        [Test]
        public void GetPlayersByCountry_Test()
        {
            // Arrange
            testjatekos.Setup(x => x.GetTableElements()).Returns(jatekoslist.AsQueryable());

            // Act, Assert
            var result = testjatekoslogic.GetPlayersByCountry();
            testjatekos.Verify(x => x.GetTableElements(), Times.Once);
            Assert.That(testjatekoslogic.GetPlayersByCountry().ToString(), Contains.Substring("Hungary"));
            Assert.That(testjatekoslogic.GetPlayersByCountry().ToString(), Contains.Substring("Játékosok száma: 2"));
        }
    }
}
