namespace HerkansingToets
{
    public class Catalogus
    {
        // Lijst van beschikbare accommodaties. Wordt gevuld in de Initialize-methode.
        private List<Accomodatie> accomodaties = new List<Accomodatie>();

        public void Initialize()
        {
            // hotelkamer voor 2 personen met ontbijt
            // hotelkamer voor 1 persoon zonder ontbijt
            // hotelkamer voor 2 personen met ontbijt met zichtopzee

            var zichtopzee = new ZichtOpZee(); // vaste toeslag van 20 euro

            // Voeg hotelkamers toe aan de lijst
            accomodaties.Add(new Hotelkamer("1", 2, true, null)); // zonder extra faciliteiten
            accomodaties.Add(new Hotelkamer("2", 1, false, null));
            accomodaties.Add(new Hotelkamer("3", 2, true, [zichtopzee]));  //new List<IFaciliteit> { zichtopzee } = [zichtopzee]

            // chalet voor 4 personen, 3 slaapkamers, tuin 80m2 en buiteenkeuken
            // chalet voor 4 personen, 2 slaapkamers, zwembad en een tuin 120m2

            // Stel faciliteiten samen voor chalet 4
            var tuin1 = new Tuin(80);
            var buitenkeuken = new BuitenKeuken(); // standaard prijs is 0, extra 15 komt erbij
            var faciliteiten1 = new List<IFaciliteit>() { tuin1, buitenkeuken };

            accomodaties.Add(new Chalet("4", 3, faciliteiten1));

            // Stel faciliteiten samen voor chalet 5
            var zwembad = new Zwembad(); // 2 euro per persoon
            var tuin2 = new Tuin(120);
            var faciliteiten2 = new List<IFaciliteit>() { tuin2, zwembad };

            accomodaties.Add(new Chalet("5", 2, faciliteiten2));

            // kampeerplaats met oppervlakte 40m2
            accomodaties.Add(new Kampeerplaats("6", 40, null)); // geen faciliteiten
        }

        public Accomodatie? Lookup(string ID)
        {
            // Zoek een accommodatie op ID en geef deze terug (of null als niet gevonden)
            return accomodaties.Find(x => x.ID == ID);
        }
    }
}
