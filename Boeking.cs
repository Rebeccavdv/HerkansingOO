namespace HerkansingToets
{
    // Boeking-klasse is afhankelijk van aggregatie met Accomodatie en compositie met Reis.
    // Daardoor weet de boeking hoeveel personen er zijn (via de Reis) en wat de toeslagen zijn (via Accomodatie.faciliteiten).
    public class Boeking
    {
        public int aantal_nachten;
        public Accomodatie acomodatie;
        public Reis reis;

        public Boeking(int Aantal_nachten, Accomodatie Acomodatie, Reis Reis)
        {
            aantal_nachten = Aantal_nachten;
            acomodatie = Acomodatie;
            reis = Reis;
        }

        public float BerekenPrijs() // prijs accomodatie + toeslagen van faciliteiten bij de accomodatie
                                    // ik heb nodig: accomodatie, welke faciliteiten daarbij horen
        {
            // voor accomodatie de prijs. Voor elke faciliteit de prijs bij de accomodatie

            float toeslag = 0f;

            // Controle of er faciliteiten zijn gekoppeld aan de accommodatie
            if (acomodatie.faciliteiten != null)
            {
                // Voor elke faciliteit wordt de toeslag berekend op basis van het aantal personen in de reis
                foreach (var faciliteit in acomodatie.faciliteiten)
                {
                    toeslag += faciliteit.BerekenToeslag(reis.aantal_personen);
                }
            }
            else
            {
                Console.WriteLine("Geen faciliteiten gevonden of lijst is leeg.");
            }

            var prijs = acomodatie.BerekenPrijs(reis.aantal_personen); // basisprijs voor de accommodatie
            return prijs + toeslag; // totaalprijs is basisprijs + alle faciliteittoeslagen
        }
    }
}
