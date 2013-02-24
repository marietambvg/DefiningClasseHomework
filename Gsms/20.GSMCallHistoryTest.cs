using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gsms
{
    class GSMCallHistoryTest
    {
        public static void GsmCallHistoryTest()
        {
        Gsm somePhone = new Gsm("iPhone213", "Apple", 1000, "Ivan Ivanov", new Battery("samsung", 5, 10, BatteryType.LiIon), new Display("small", 123));
         
        Call first = new Call(new DateTime(2012, 09, 30, 9, 30, 40), 0886088088, 38000);
        Call second = new Call(new DateTime(2013, 01, 15, 19, 14, 15), 0886888000, 5000);
        Call third = new Call(new DateTime(2013, 01, 30, 23, 30, 55), 0898898898, 300);
        Call forth = new Call(new DateTime(2013, 02, 22, 22, 22, 22), 0899999999, 40100);
        List<Call>phoneHistory=new List<Call>();
        somePhone.CallHistory = phoneHistory;
        Gsm.AddCalls(somePhone.CallHistory, first);
        Gsm.AddCalls(somePhone.CallHistory, second);
        Gsm.AddCalls(somePhone.CallHistory, third);
        Gsm.AddCalls(somePhone.CallHistory, forth);

        Console.WriteLine("Call History:");
        Console.WriteLine();
        CallHistoryReview(somePhone);
        Console.WriteLine();
        CalculateCallHistoryPrice(somePhone);
        RemoveLongestCall(somePhone);
        Console.WriteLine();
        Console.WriteLine("Call History After removing longest call:");
        Console.WriteLine();
        CalculateCallHistoryPrice(somePhone);
        Console.WriteLine();
        CallHistoryReview(somePhone);
        Gsm.ClearCalls(somePhone.CallHistory);
        Console.WriteLine("Call History After clearing all calls:");
        CallHistoryReview(somePhone);

        }

        private static void CalculateCallHistoryPrice(Gsm somePhone)
        {
            decimal pricePerMinutes = 0.37m;
            decimal totalPrice = Gsm.TotalPrice(somePhone.CallHistory, pricePerMinutes);
            Console.WriteLine("Total price for all calls is {0} EUR", totalPrice);
        }

        private static List<Call> RemoveLongestCall(Gsm somePhone)
        {
            long longestCall = 0;
            int longestCallPosition = 0;
            for (int i = 0; i < somePhone.CallHistory.Count; i++)
            {
                if (somePhone.CallHistory[i].DuratationInSeconds > longestCall)
                {
                    longestCall = somePhone.CallHistory[i].DuratationInSeconds;
                    longestCallPosition = i;
                }

            }
            return Gsm.DeleteCalls(somePhone.CallHistory, somePhone.CallHistory[longestCallPosition]);
        }

        private static void CallHistoryReview(Gsm somePhone)
        {
            for (int i = 0; i < somePhone.CallHistory.Count; i++)
            {
                Console.WriteLine("Phone: {3}, Date and time: {0}, Call to: {1}, duratation {2} seconds", somePhone.CallHistory[i].DateAndTime, somePhone.CallHistory[i].DialedPhoneNumber, somePhone.CallHistory[i].DuratationInSeconds, somePhone.Model);
                Console.WriteLine();
                
            }
        }

        
}
}
