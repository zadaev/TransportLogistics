using TransportLogistika.BL;


namespace TransportLogistika.CMD
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    WorkWithTLDB.GMethod();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadKey();
                Console.Clear();
            }



        }
    }
}
