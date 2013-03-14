using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock_Tests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void HandleInputNothingEntered() {
            const string EXPECTED = "Please enter a time in the hh::mm:ss format ";
            string actual = BerlinClockKata.BerlinClockKata.HandleInput("");
            Assert.AreEqual(EXPECTED, actual);
        }

        [TestMethod]
        public void HandleInputCorrectInput() {
            string expected = "Y" + Environment.NewLine + "OOOO" + Environment.NewLine +
                "OOOO" + Environment.NewLine + "OOOOOOOOOOO" + Environment.NewLine + "OOOO";
            string actual = BerlinClockKata.BerlinClockKata.HandleInput("00:00:00");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseTimeValidInput() {
            int[] expected = { 11, 11, 11 };
            int[] actual = BerlinClockKata.BerlinClockKata.ParseTime("11:11:11");
            for (int i = 0; i < 3; i++) {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Please enter between 0 and 24 Hours")]
        public void ParseTimeRightLengthWrongFormatInput() {
            BerlinClockKata.BerlinClockKata.TranslateToBerlinClock("11111:11");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Please enter a time in the hh::mm:ss format ")]
        public void ParseTimeAlphaInput() {
            const string EXPECTED = "Please enter a time in the hh::mm:ss format ";
            int[] actual = BerlinClockKata.BerlinClockKata.ParseTime("aa:aa:aa");
            Assert.AreEqual(EXPECTED, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Please enter a time in the hh::mm:ss format ")]
        public void ParseTimeTooManyColonsException() {
            const string EXPECTED = "Please enter a time in the hh::mm:ss format ";
            int[] actual = BerlinClockKata.BerlinClockKata.ParseTime("1:1:1:1:11");
            Assert.AreEqual(EXPECTED, actual);
        }

        [TestMethod]
        public void GetSecondValueOdd() {
            const string EXPECTED = "O";
            string actual = BerlinClockKata.BerlinClockKata.GetSecondLight(11);
            Assert.AreEqual(EXPECTED, actual);
        }

        [TestMethod]
        public void GetSecondValueEven() {
            const string EXPECTED = "Y";
            string actual = BerlinClockKata.BerlinClockKata.GetSecondLight(12);
            Assert.AreEqual(EXPECTED, actual);
        }

        [TestMethod]
        public void GetSecondValueZero() {
            const string EXPECTED = "Y";
            string actual = BerlinClockKata.BerlinClockKata.GetSecondLight(00);
            Assert.AreEqual(EXPECTED, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Please enter between 0 and 59 for seconds")]
        public void GetSecondTooBig() {
            const string EXPECTED = "Please enter between 0 and 59 for seconds";
            string actual = BerlinClockKata.BerlinClockKata.GetSecondLight(60);
            Assert.AreEqual(EXPECTED, actual);
        }

        [TestMethod]
        public void GetHoursValue13() {
            string expected = "RROO" + Environment.NewLine + "RRRO";
            string actual = BerlinClockKata.BerlinClockKata.GetHourLights(13);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetHoursValue03() {
            string expected = "OOOO" + Environment.NewLine + "RRRO";
            string actual = BerlinClockKata.BerlinClockKata.GetHourLights(03);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetHoursValue24() {
            string expected = "RRRR" + Environment.NewLine + "RRRR";
            string actual = BerlinClockKata.BerlinClockKata.GetHourLights(24);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetHoursValue23() {
            string expected = "RRRR" + Environment.NewLine + "RRRO";
            string actual = BerlinClockKata.BerlinClockKata.GetHourLights(23);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Please enter between 0 and 24 Hours")]
        public void GetHoursValueTooHigh() {
            const string EXPECTED = "Please enter between 0 and 24 Hours";
            string actual = BerlinClockKata.BerlinClockKata.GetHourLights(28);
            Assert.AreEqual(EXPECTED, actual);
        }

        [TestMethod]
        public void GetMinutesValue17() {
            string expected = "YYROOOOOOOO" + Environment.NewLine + "YYOO";
            string actual = BerlinClockKata.BerlinClockKata.GetMinuteLights(17);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMinutesValue00() {
            string expected = "OOOOOOOOOOO" + Environment.NewLine + "OOOO";
            string actual = BerlinClockKata.BerlinClockKata.GetMinuteLights(00);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMinutesValue59() {
            string expected = "YYRYYRYYRYY" + Environment.NewLine + "YYYY";
            string actual = BerlinClockKata.BerlinClockKata.GetMinuteLights(59);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Please enter between 0 and 59 Minutes")]
        public void GetMinuteValueTooHigh() {
            const string EXPECTED = "Please enter between 0 and 59 Minutes";
            string actual = BerlinClockKata.BerlinClockKata.GetMinuteLights(66);
            Assert.AreEqual(EXPECTED, actual);
        }

        [TestMethod]
        public void TestWholeClock00() {
            string expected = "Y" + Environment.NewLine + "OOOO" + Environment.NewLine +
                "OOOO" + Environment.NewLine + "OOOOOOOOOOO" + Environment.NewLine + "OOOO";
            string actual = BerlinClockKata.BerlinClockKata.TranslateToBerlinClock("00:00:00");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWholeClock131701() {
            string expected = "O" + Environment.NewLine + "RROO" + Environment.NewLine +
                "RRRO" + Environment.NewLine + "YYROOOOOOOO" + Environment.NewLine + "YYOO";
            string actual = BerlinClockKata.BerlinClockKata.TranslateToBerlinClock("13:17:01");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWholeClock235959() {
            string expected = "O" + Environment.NewLine + "RRRR" + Environment.NewLine +
                "RRRO" + Environment.NewLine + "YYRYYRYYRYY" + Environment.NewLine + "YYYY";
            string actual = BerlinClockKata.BerlinClockKata.TranslateToBerlinClock("23:59:59");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWholeClock240000() {
            string expected = "Y" + Environment.NewLine + "RRRR" + Environment.NewLine +
                "RRRR" + Environment.NewLine + "OOOOOOOOOOO" + Environment.NewLine + "OOOO";
            string actual = BerlinClockKata.BerlinClockKata.TranslateToBerlinClock("24:00:00");
            Assert.AreEqual(expected, actual);
        }
    }
}
