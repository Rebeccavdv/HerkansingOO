namespace HerkansingToets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // reis maken voor john doe, partner en 2 kinderen.
            // Gebruik catalogus klasse voor de accomodaties, daarna de lookup functie. 
            // Bereken totaalprijs reis en print hele reis uit
            var reis = new Reis(3); //maak reis aan met 3 personen, ik hoop nu dat alles in de reis gpleurd wordt zo:

            // Elke keer dat BoekAccomodatie wordt aangeroepen, wordt een nieuwe Catalogus gemaakt met standaarddata.
            // Als je ooit dynamisch accommodaties wilt toevoegen, moet je Catalogus elders beheren.

            reis.BoekAccomodatie("1", 1); // method is een void, dus niet in variabel stoppen
            reis.BoekAccomodatie("2", 1);
            reis.BoekAccomodatie("3", 3);
            reis.BoekAccomodatie("4", 3);
            reis.BoekAccomodatie("5", 5);
            reis.BoekAccomodatie("6", 7);

            var totaal_nachten = 1 + 1 + 3 + 3 + 5 + 7;

            var totaalprijs = reis.BerekenTotaalPrijs(totaal_nachten);
            Console.WriteLine(totaalprijs); // Tering bugs, iets verkeerd in accomodatie (accomodatie = 0)
                                            // uml klopt wel denk
                                            // Debugtip: check of alle BerekenPrijs-methodes in je Accomodatie-subklassen de aantal_nachten gebruiken.
                                            // Momenteel wordt alleen de basisprijs per nacht berekend, niet vermenigvuldigd met het aantal nachten.
        }
    }
}
