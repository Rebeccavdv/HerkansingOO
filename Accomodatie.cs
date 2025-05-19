using System.Collections.Generic;

namespace HerkansingToets
{
    public class Accomodatie
    {
        public string ID;
        // meerdere faciliteiten in 1> maak een lijst aan. Als ik de lijst hier instantieer (new list), hoef ik dat later niet te doen
        public List<IFaciliteit> faciliteiten; // aggregatie connectie in de uml
        // een list mag leeg zijn, daarom de "?" in IFaciliteit? overbodig

        // Deze methode wordt overschreven in subklassen met hun eigen logica
        public virtual float BerekenPrijs(int aantal_personen) { return 0; }
    }

    public class Kampeerplaats : Accomodatie
    {
        public int oppervlakte;

        public Kampeerplaats(string ID, int Oppervlakte, List<IFaciliteit> Faciliteiten)
        {
            oppervlakte = Oppervlakte;
            faciliteiten = Faciliteiten ?? new List<IFaciliteit>(); // als er geen faciliteiten meegegeven zijn, maak dan een lege lijst aan
                                                                    // Maak altijd een lege lijst aan, zodat 'faciliteiten' nooit null is.
                                                                    // Dit voorkomt fouten bij het doorlopen van de lijst (foreach) wanneer er geen faciliteiten zijn.
            this.ID = ID;
        }

        // 1 eur per m2 per nacht
        public override float BerekenPrijs(int aantal_personen)
        {
            var prijs = oppervlakte * 1;
            return prijs;
        }
    }

    public class Hotelkamer : Accomodatie
    {
        public int aantal_bedden;
        public bool inclusief_ontbijt;

        public Hotelkamer(string ID, int Aantal_bedden, bool Inclusief_ontbijt, List<IFaciliteit> Faciliteiten)
        {
            aantal_bedden = Aantal_bedden;
            inclusief_ontbijt = Inclusief_ontbijt;
            faciliteiten = Faciliteiten ?? new List<IFaciliteit>();
            this.ID = ID;
        }

        public override float BerekenPrijs(int aantal_personen)
        {
            // 120 eur zonder, 15 eur per persoon
            // zichtopzee is + 20 eur, voeg toe bij program :P

            var prijs_per_nacht = 120;

            if (inclusief_ontbijt)
            {
                var ontbijt_prijs = aantal_personen * 15;
                return prijs_per_nacht + ontbijt_prijs;
            }
            else
            {
                return prijs_per_nacht;
            }
        }
    }

    public class Chalet : Accomodatie
    {
        public int aantal_slaapkamers;

        public Chalet(string ID, int Aantal_slaapkamers, List<IFaciliteit> Faciliteiten)
        {
            aantal_slaapkamers = Aantal_slaapkamers;
            faciliteiten = Faciliteiten ?? new List<IFaciliteit>();
            this.ID = ID;
        }

        // chalet voor 4 personen is 25 eur per nacht
        public override float BerekenPrijs(int aantal_personen)
        {
            // Alleen exact 4 personen toegestaan; anders is de prijs 0
            return (aantal_personen == 4) ? 25 : 0;
        }
    }
}
