using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Configuration;
using System.Data.Entity.ModelConfiguration;
using Personeltakip.VO;

public class ModelContext : DbContext
{
		public DbSet<Bolum> Bolums { get; set; }

		public DbSet<Izin> Izins { get; set; }

		public DbSet<Personel> Personels { get; set; }


	
    #region Constructor

    public ModelContext()
        : base(CS)
    {

    }

    #endregion

    #region Static

    #region  Field
    private static string CS
    {
        get { return ConfigurationManager.ConnectionStrings["cs"].ConnectionString; }
    }
    #endregion

    #endregion

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
		modelBuilder.Configurations.Add(new BolumConfiguration());

		modelBuilder.Configurations.Add(new IzinConfiguration());

		modelBuilder.Configurations.Add(new PersonelConfiguration());


        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        base.OnModelCreating(modelBuilder);
    }

		public class BolumConfiguration : EntityTypeConfiguration<Bolum>
		{
			public BolumConfiguration()
			{
				ToTable("Bolum");
			}
		}

		public class IzinConfiguration : EntityTypeConfiguration<Izin>
		{
			public IzinConfiguration()
			{
				ToTable("Izin");
			}
		}

		public class PersonelConfiguration : EntityTypeConfiguration<Personel>
		{
			public PersonelConfiguration()
			{
				ToTable("Personel");
			}
		}



}