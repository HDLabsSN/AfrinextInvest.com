using System;

namespace Web.AfrinextInvest.com.Models
{
    public class Projets
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Pays { get; set; }
        public string SecteurActivite { get; set; }
        public decimal BudgetRequis { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
