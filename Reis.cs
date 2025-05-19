namespace HerkansingToets
{
    public class Reis
    {
        public int aantal_personen;

        public List<Boeking> boekingen = new();
        private Catalogus catalogus = new Catalogus();

        public Reis(int Aantal_personen)
        {
            aantal_personen = Aantal_personen;
            catalogus.Initialize(); // initialize zodat alles in 1 lijst gepleurd wordt: ipv steeds een nieuwe(lege) lijst aanmaken
        }

        public float BerekenTotaalPrijs(int aantal_nachten) // aantal nachten toegevoegd zodat het * aantal nachten kan
        {
            float prijs = 0;
            foreach (var boeking in boekingen)
            {
                prijs += boeking.BerekenPrijs(); // Polymorfisme: BerekenPrijs verschilt per type Accomodatie
            }

            Console.WriteLine(prijs); // Debug output, kan verwijderd worden in productie
            return prijs * aantal_nachten;
        }

        public void BoekAccomodatie(string ID, int aantal_nachten)
        {
            // Gebruik de reeds geïnitialiseerde catalogus i.p.v. een nieuwe aan te maken
            // Catalogus wordt hier niet opnieuw geïnitialiseerd; bevat nu de accommodaties uit Initialize()

            var nieuweAcco = catalogus.Lookup(ID);

            if (nieuweAcco != null)
            {
                Console.WriteLine($"Gevonden: {nieuweAcco.ID}"); // debug info
                var nieuweBoeking = new Boeking(aantal_nachten, nieuweAcco, this);
                boekingen.Add(nieuweBoeking);
            }
            else
            {
                Console.WriteLine($"Accomodatie met ID {ID} niet gevonden.");
            }
        }
    }
}
