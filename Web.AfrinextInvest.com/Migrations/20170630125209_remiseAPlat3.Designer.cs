using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Web.AfrinextInvest.com.Models;

namespace Web.AfrinextInvest.com.Migrations
{
    [DbContext(typeof(AfrinextInvestContext))]
    [Migration("20170630125209_remiseAPlat3")]
    partial class remiseAPlat3
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

            modelBuilder.Entity("Web.AfrinextInvest.com.Models.Projet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BudgetRequis");

                    b.Property<DateTime>("DateCreation");

                    b.Property<DateTime>("DerniereModification");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Pays")
                        .IsRequired();

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasMaxLength(480);

                    b.Property<int>("SecteurId");

                    b.Property<bool>("isDraft");

                    b.Property<bool>("isVerified");

                    b.HasKey("Id");

                    b.HasIndex("SecteurId");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("Web.AfrinextInvest.com.Models.SecteurActivite", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("nomSecteur")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.ToTable("SecteurActivite");
                });

            modelBuilder.Entity("Web.AfrinextInvest.com.Models.Projet", b =>
                {
                    b.HasOne("Web.AfrinextInvest.com.Models.SecteurActivite", "SecteurActvite")
                        .WithMany("Projets")
                        .HasForeignKey("SecteurId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
