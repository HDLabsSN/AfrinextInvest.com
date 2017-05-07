using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Web.AfrinextInvest.com.Models;

namespace Web.AfrinextInvest.com.Migrations
{
    [DbContext(typeof(AfrinextInvestContext))]
    partial class AfrinextInvestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

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
