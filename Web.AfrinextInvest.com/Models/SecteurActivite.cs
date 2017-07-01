using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.AfrinextInvest.com.Models
{
    public class SecteurActivite
    {
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }
        [StringLength(30, ErrorMessage = "le nom du secteur d'activité ne doit pas dépasser 30 caractères")]
        [DisplayName("Secteur d'activité")]
        [Required(ErrorMessage = "Vous devez mettre le nom du secteur d'activité")]
        public string nomSecteur{ get; set; }
        [DisplayName("Description")]
        public string description { get; set; }

        public virtual ICollection<Projet> Projets { get; set; }
    }
}
