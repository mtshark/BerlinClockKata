using System;
using System.Linq;
using System.Text;

namespace BerlinClockKata {
    public class BerlinClockKata {
        static void Main() {
            string message = "Please enter a time (hh:mm:ss) ";
            string enterTime = "Starting";
            while (enterTime != null && !enterTime.ToUpper().Equals("Q")) {
                Console.Write(message);
                enterTime = Console.ReadLine();
                Console.WriteLine(HandleInput(enterTime));
                message = "Please enter a time (hh:mm:ss) or Q to quit ";
            }
        }

        public static string HandleInput(string pEnterTime) {
            try {
                if (pEnterTime.Length != 8)
                    throw new Exception("Please enter a time in the hh::mm:ss format ");
                return TranslateToBerlinClock(pEnterTime);
            }
            catch (Exception e) {
                return e.Message;
            }
        }

        public static string TranslateToBerlinClock(string pEnterTime) {
            int[] timeSegments = ParseTime(pEnterTime);
            StringBuilder returnTime = new StringBuilder();
            returnTime.AppendLine(GetSecondLight(timeSegments[2]));
            returnTime.AppendLine(GetHourLights(timeSegments[0]));
            returnTime.Append(GetMinuteLights(timeSegments[1]));

            return returnTime.ToString();
        }

        public static StringBuilder FormatTopRow(int topRow) {
            char[] topRowChar = SetLights(topRow, 11, 'Y').ToArray();
            StringBuilder retTopRow = new StringBuilder();
            for (int i = 0; i < topRowChar.Length; i++) {
                if (Math.IEEERemainder(i + 1, 3).Equals(0) && topRowChar[i].Equals('Y'))
                    topRowChar[i] = 'R';
                retTopRow.Append(topRowChar[i]);
            }
            return retTopRow;
        }

        public static string GetHourLights(int pHours) {
            if (pHours > 24) throw new Exception("Please enter between 0 and 24 Hours");
            int bottomRow;
            int topRow = Math.DivRem(pHours, 5, out bottomRow);
            return SetLights(topRow, 4, 'R') + Environment.NewLine + SetLights(bottomRow, 4, 'R');
        }

        public static string GetMinuteLights(int pMinutes) {
            if (pMinutes > 59) throw new Exception("Please enter between 0 and 59 Minutes");
            int bottomRow;
            int topRow = Math.DivRem(pMinutes, 5, out bottomRow);
            return FormatTopRow(topRow) + Environment.NewLine + SetLights(bottomRow, 4, 'Y');
        }

        public static string SetLights(int pLightsToColor, int pLength, char pColor) {
            string h = "";
            h = h.PadLeft(pLightsToColor, pColor);
            return h.PadRight(pLength, 'O');
        }

        public static string GetSecondLight(int pSeconds) {
            if (pSeconds > 59) throw new Exception("Please enter between 0 and 59 for seconds");
            return Math.IEEERemainder(pSeconds, 2).Equals(0) ? "Y" : "O";
        }

        public static int[] ParseTime(string pEnterTime) {
            string[] timeSegments = pEnterTime.Split(':');
            int[] retVal = new int[3];
            try {
                for (int i = 0; i < timeSegments.Length; i++) {
                    retVal[i] = int.Parse(timeSegments[i]);
                }
            }
            catch (Exception) {
                throw new Exception("Please enter a time in the hh::mm:ss format ");
            }
            return retVal;
        }
    }
}
