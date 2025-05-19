namespace HerkansingToets
{
    // Interface voor faciliteiten — dwingt alle faciliteitklassen om een BerekenToeslag-methode te implementeren
    public interface IFaciliteit
    {
        public float BerekenToeslag(int aantal_personen);
    }

    public class Zwembad : IFaciliteit
    {
        public int lengte;
        public int breedte;
        public int diepte;

        // 2 euro per persoon
        public float BerekenToeslag(int aantal_personen)
        {
            float toeslag = aantal_personen * 2;
            return toeslag;
        }
    }

    public class BuitenKeuken : IFaciliteit
    {
        public float prijs;

        // extra prijs buitenkeuken is 15 eur
        public float BerekenToeslag(int aantal_personen)
        {
            return prijs + 15;  // er staat extra prijs, dus ik voeg toe aan de prijs
            // Opmerking: de veldwaarde 'prijs' moet elders worden ingesteld, anders is deze 0
        }
    }

    public class Tuin : IFaciliteit
    {
        public int oppervlakte;

        public Tuin(int Oppervlakte)
        {
            oppervlakte = Oppervlakte;
        }

        // 0.1 eur per 1m
        public float BerekenToeslag(int aantal_personen)
        {
            float toeslag = oppervlakte * (float)0.1;
            return toeslag;
            // Toeslag is gebaseerd op grootte van de tuin, niet op aantal personen
        }
    }

    public class ZichtOpZee : IFaciliteit
    {
        // toeslag is 20 eur
        public float BerekenToeslag(int aantal_personen)
        {
            return 20;
            // Vast bedrag ongeacht aantal personen
        }
    }
}
