using System;
using System.Collections.Generic;

namespace ApiCisalfa.Models
{
    public partial class DtProspetti
    {
        public string CodDeposito { get; set; }
        public int NrProg { get; set; }
        public string NrOrdine { get; set; }
        public string Fornitore { get; set; }
        public string Desfor { get; set; }
        public string Marchio { get; set; }
        public string Desmar { get; set; }
        public string Dep { get; set; }
        public string Desdep { get; set; }
        public string Subdep { get; set; }
        public string NoteDep { get; set; }
        public string Buyer { get; set; }
        public DateTime? DtPrenotazione { get; set; }
        public DateTime? DtArrivoPre { get; set; }
        public DateTime? DtArrivo { get; set; }
        public DateTime? DtConsegna { get; set; }
        public int? DeltaConsegna { get; set; }
        public DateTime? DtAutorizzazione { get; set; }
        public string Autorizzazione { get; set; }
        public string NrDdt { get; set; }
        public DateTime? DtDdt { get; set; }
        public int? NrColli { get; set; }
        public string NrColliDesc { get; set; }
        public int? NrAppesi { get; set; }
        public int? NoteQualita { get; set; }
        public string NoteQualita2 { get; set; }
        public DateTime? DtCarico { get; set; }
        public DateTime? DtCaricoPar { get; set; }
        public int? FlgChiusa { get; set; }
        public int? NoteCarico { get; set; }
        public string NoteCarico2 { get; set; }
        public int? NrPezziDdt { get; set; }
        public int? NrPezziCalc { get; set; }
        public int? NrDiscordanze { get; set; }
        public int? NrEtichettatiForn { get; set; }
        public int? NrEtichettatiSnatt { get; set; }
        public int? NrRietiSnatt { get; set; }
        public string NrMms { get; set; }
        public int? NrSnatt { get; set; }
        public int? NrPrecarico { get; set; }
        public int? NrBancali { get; set; }
        public int? Priorita { get; set; }
        public string NotePriorita { get; set; }
        public string Stato { get; set; }
        public string OperSnatt { get; set; }
        public string SnattMail { get; set; }
        public DateTime? DtMailBuyer { get; set; }
        public DateTime? DtMailSnatt { get; set; }
        public DateTime? DtCreazione { get; set; }
        public DateTime? DtModifica { get; set; }
        public bool? Contata { get; set; }
        public short? DepCat { get; set; }
        public short? SubdepCat { get; set; }
        public string Container20 { get; set; }
        public string Container40 { get; set; }
        public string OrdTriangolato { get; set; }
    }
}
