using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gsms
{
    class GsmTest
    {
        public static void GsmTests()
        {
            try
            {

                Gsm[] gsm = new Gsm[3];
                gsm[0] = new Gsm("345", "Samsung", 200, "P", new Battery("Unknown", 15, 3, BatteryType.NiMH), new Display("big", 2009));
                gsm[1] = new Gsm("5SD", "Sony Ericson", 200, "Kaloyan Ivanov", new Battery("Sony", 15, 3, new BatteryType()), new Display("small", 9));
                gsm[2] = new Gsm("718", "Nokia");
                //Console.WriteLine(gsm.ToString());
                Console.WriteLine();

                for (int i = 0; i < gsm.Length; i++)
                {
                    Console.WriteLine(gsm[i].ToString());
                    Console.WriteLine();

                }

                Console.WriteLine(Gsm.IPhone4S.ToString());
                Console.WriteLine();
            }
             
            catch (Exception ex)
            {
                Console.WriteLine("Cannot create object: " + ex);
            }
           
        }


    }
}

