namespace Hypo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int v = 0; v < 1;)
            {
                
                int maandinkomen = 0;
                int rentevastePeriode = 0;
                int maandinkomenPartner = 0;
                bool studieschuld = false;
                string postcode = "";
                float jaarinkomen = 0;
                float maximaleHypotheek = 0;
                float rentePercentage = 0;

                Console.WriteLine("Vul maandinkomen in. ");
                maandinkomen = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Vul rentevaste periode in. (1, 5, 10, 20, 30)");
                rentevastePeriode = Convert.ToInt32(Console.ReadLine());
                rentePercentage = ReturnRentePercentage(rentevastePeriode);

                Console.WriteLine("Vul maandinkomen partner in. Vul '0' in wanneer dit niet van toepassing is.");
                maandinkomenPartner = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Heeft u en/of uw partner een studieschuld? Y/N");
                string studieschuldyn = Console.ReadLine();

                if (studieschuldyn == "Y")
                {
                    studieschuld = true;
                }

                Console.WriteLine("Vul uw postcode in.");
                postcode = Console.ReadLine();

                if ( postcode == "9679" || postcode == "9681" || postcode == "9682")
                {
                    Console.WriteLine("Vanwege dalende woningwaarde en de kans op aarbevingen in dit gebied, worden er geen berekeningen gemaakt.");
                    continue;
                }
                
                jaarinkomen = ReturnJaarinkomen(maandinkomen, maandinkomenPartner);
                Console.WriteLine("Jaarinkomen: " + jaarinkomen);
                
                maximaleHypotheek = ReturnMaximaleHypotheek(jaarinkomen, studieschuld);
                Console.WriteLine("Maximale Hypotheek: " + maximaleHypotheek);
                Console.WriteLine("U mag " + maximaleHypotheek + "lenen maximaal voor 30 jaar. Dit is exclusief rente.");
                
                
            }
        }

        public static float ReturnJaarinkomen(int maandinkomen, int maandinkomenPartner)
        {
           return (maandinkomen + maandinkomenPartner) * 12;
        }
        
        public static float ReturnMaximaleHypotheek(float jaarinkomen, bool studieschuld)
        {
            if (studieschuld)
            {
                return (jaarinkomen * 4.25f)* 0.75f;
            }

            return jaarinkomen * 4.25f;
        }
        
        public static float ReturnRentePercentage(int rentevastePeriode)
        {
            float rente = 0;
            
            switch (rentevastePeriode)
            {
                case 1:
                    rente = 2;
                    break;
                case 5:
                    rente = 3;
                    break;
                case 10:
                    rente = 3.5f;
                    break;
                case 20:
                    rente = 4.5f;
                    break;
                case 30:
                    rente = 5;
                    break;
                default:
                    break;
            }
            return rente;
        }
    }
}