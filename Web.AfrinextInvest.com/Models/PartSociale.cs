using System.ComponentModel.DataAnnotations;

namespace Web.AfrinextInvest.com.Models
{
    public class PartSociale
    {
        [Key]
        public int Id { get; set; }
        public string NomActivite { get; set; }
        public string DescriptionActivite { get; set; }
        public int AgeActivite { get; set; }
        public decimal ChiffreAffaire { get; set; }
        public int NbPartsACeder { get; set; }
        public decimal PrixUnitaire { get; set; }
        public string SecteurActivite { get; set; }
        public string Pays { get; set; }
        public bool ActiviteVerifiee { get; set; }
    }
}
