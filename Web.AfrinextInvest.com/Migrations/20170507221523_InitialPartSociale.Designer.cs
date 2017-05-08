using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Web.AfrinextInvest.com.Models;

namespace Web.AfrinextInvest.com.Migrations
{
    [DbContext(typeof(AfrinextInvestContext))]
    [Migration("20170507221523_InitialPartSociale")]
    partial class InitialPartSociale
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Web.AfrinextInvest.com.Models.PartSociale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ActiviteVerifiee");

                    b.Property<int>("AgeActivite");

                    b.Property<decimal>("ChiffreAffaire");

                    b.Property<string>("DescriptionActivite");

                    b.Property<int>("NbPartsACeder");

                    b.Property<string>("NomActivite");

                    b.Property<string>("Pays");

                    b.Property<decimal>("PrixUnitaire");

                    b.Property<string>("SecteurActivite");

                    b.HasKey("Id");

                    b.ToTable("PartSociale");
                });

            modelBuilder.Entity("Web.AfrinextInvest.com.Models.Projets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BudgetRequis");

                    b.Property<DateTime>("DateCreation");

                    b.Property<string>("Description");

                    b.Property<string>("Nom");

                    b.Property<string>("Pays");

                    b.Property<string>("SecteurActivite");

                    b.HasKey("Id");

                    b.ToTable("Projets");
                });
        }
    }
}
