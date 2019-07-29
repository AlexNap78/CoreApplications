using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiCisalfa.Models
{
    public partial class DBMAGTSTContext : DbContext
    {
        public DBMAGTSTContext()
        {
        }

        public DBMAGTSTContext(DbContextOptions<DBMAGTSTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DtConf> DtConf { get; set; }
        public virtual DbSet<DtDeposito> DtDeposito { get; set; }
        public virtual DbSet<DtDepositoOperatori> DtDepositoOperatori { get; set; }
        public virtual DbSet<DtOperatori> DtOperatori { get; set; }
        public virtual DbSet<DtPersonalpa> DtPersonalpa { get; set; }
        public virtual DbSet<DtProspetti> DtProspetti { get; set; }

        // Unable to generate entity type for table 'dbo.CIS_VIEW_PROSPETTO_ARRIVI'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.NOTE_PROSPETTO'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog = DBMAGTST; Integrated Security = False; User ID = sa; Password = akama; MultipleActiveResultSets = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<DtConf>(entity =>
            {
                entity.HasKey(e => new { e.CnfKey, e.CnfDes });

                entity.ToTable("DT_CONF");

                entity.Property(e => e.CnfKey)
                    .HasColumnName("cnf_key")
                    .HasMaxLength(15);

                entity.Property(e => e.CnfDes)
                    .HasColumnName("cnf_des")
                    .HasMaxLength(50);

                entity.Property(e => e.CnfValue)
                    .HasColumnName("cnf_value")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<DtDeposito>(entity =>
            {
                entity.HasKey(e => e.CodDeposito);

                entity.ToTable("DT_DEPOSITO");

                entity.Property(e => e.CodDeposito)
                    .HasColumnName("COD_DEPOSITO")
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodMms)
                    .HasColumnName("COD_MMS")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.DepoDesc)
                    .HasColumnName("DEPO_DESC")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DtDepositoOperatori>(entity =>
            {
                entity.HasKey(e => new { e.OperCod, e.CodDeposito });

                entity.ToTable("DT_DEPOSITO_OPERATORI");

                entity.Property(e => e.OperCod)
                    .HasColumnName("OPER_COD")
                    .HasMaxLength(15);

                entity.Property(e => e.CodDeposito)
                    .HasColumnName("COD_DEPOSITO")
                    .HasMaxLength(4);

                entity.Property(e => e.IsDefault)
                    .HasColumnName("IS_DEFAULT")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<DtOperatori>(entity =>
            {
                entity.HasKey(e => new { e.OperCod, e.OperPwd })
                    .HasName("PK_DT_OPERATORI1");

                entity.ToTable("DT_OPERATORI");

                entity.Property(e => e.OperCod)
                    .HasColumnName("OPER_COD")
                    .HasMaxLength(15);

                entity.Property(e => e.OperPwd)
                    .HasColumnName("OPER_PWD")
                    .HasMaxLength(15);

                entity.Property(e => e.Buyer)
                    .HasColumnName("BUYER")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.OperDesruolo)
                    .HasColumnName("OPER_DESRUOLO")
                    .HasMaxLength(20);

                entity.Property(e => e.OperMail)
                    .HasColumnName("OPER_MAIL")
                    .HasMaxLength(500);

                entity.Property(e => e.OperName)
                    .HasColumnName("OPER_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.OperRuolo)
                    .HasColumnName("OPER_RUOLO")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<DtPersonalpa>(entity =>
            {
                entity.HasKey(e => e.OperCod)
                    .HasName("PK_DT_PERSONALPA1");

                entity.ToTable("DT_PERSONALPA");

                entity.Property(e => e.OperCod)
                    .HasColumnName("OPER_COD")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PersCol)
                    .HasColumnName("PERS_COL")
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DtProspetti>(entity =>
            {
                entity.HasKey(e => new { e.CodDeposito, e.NrProg })
                    .HasName("PK_DT_PROSPETTI_1");

                entity.ToTable("DT_PROSPETTI");

                entity.HasIndex(e => e.Buyer)
                    .HasName("IX_BUYER");

                entity.HasIndex(e => e.DtCarico)
                    .HasName("IX_DT_CARICO");

                entity.HasIndex(e => e.DtCaricoPar)
                    .HasName("IX_DT_CARICO_PAR");

                entity.HasIndex(e => new { e.NrProg, e.OperSnatt })
                    .HasName("IX_SNATT");

                entity.Property(e => e.CodDeposito)
                    .HasColumnName("COD_DEPOSITO")
                    .HasMaxLength(4);

                entity.Property(e => e.NrProg).HasColumnName("NR_PROG");

                entity.Property(e => e.Autorizzazione)
                    .HasColumnName("AUTORIZZAZIONE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Buyer)
                    .HasColumnName("BUYER")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Container20)
                    .HasColumnName("CONTAINER_20")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Container40)
                    .HasColumnName("CONTAINER_40")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contata)
                    .HasColumnName("CONTATA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DeltaConsegna).HasColumnName("DELTA_CONSEGNA");

                entity.Property(e => e.Dep)
                    .HasColumnName("DEP")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DepCat).HasColumnName("DEP_CAT");

                entity.Property(e => e.Desdep)
                    .HasColumnName("DESDEP")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Desfor)
                    .HasColumnName("DESFOR")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Desmar)
                    .HasColumnName("DESMAR")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DtArrivo)
                    .HasColumnName("DT_ARRIVO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtArrivoPre)
                    .HasColumnName("DT_ARRIVO_PRE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtAutorizzazione)
                    .HasColumnName("DT_AUTORIZZAZIONE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtCarico)
                    .HasColumnName("DT_CARICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtCaricoPar)
                    .HasColumnName("DT_CARICO_PAR")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtConsegna)
                    .HasColumnName("DT_CONSEGNA")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtCreazione)
                    .HasColumnName("DT_CREAZIONE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtDdt)
                    .HasColumnName("DT_DDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtMailBuyer)
                    .HasColumnName("DT_MAIL_BUYER")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtMailSnatt)
                    .HasColumnName("DT_MAIL_SNATT")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtModifica)
                    .HasColumnName("DT_MODIFICA")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtPrenotazione)
                    .HasColumnName("DT_PRENOTAZIONE")
                    .HasColumnType("datetime");

                entity.Property(e => e.FlgChiusa).HasColumnName("FLG_CHIUSA");

                entity.Property(e => e.Fornitore)
                    .HasColumnName("FORNITORE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Marchio)
                    .HasColumnName("MARCHIO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoteCarico).HasColumnName("NOTE_CARICO");

                entity.Property(e => e.NoteCarico2)
                    .HasColumnName("NOTE_CARICO2")
                    .IsUnicode(false);

                entity.Property(e => e.NoteDep)
                    .HasColumnName("NOTE_DEP")
                    .IsUnicode(false);

                entity.Property(e => e.NotePriorita)
                    .HasColumnName("NOTE_PRIORITA")
                    .IsUnicode(false);

                entity.Property(e => e.NoteQualita).HasColumnName("NOTE_QUALITA");

                entity.Property(e => e.NoteQualita2)
                    .HasColumnName("NOTE_QUALITA2")
                    .IsUnicode(false);

                entity.Property(e => e.NrAppesi).HasColumnName("NR_APPESI");

                entity.Property(e => e.NrBancali).HasColumnName("NR_BANCALI");

                entity.Property(e => e.NrColli).HasColumnName("NR_COLLI");

                entity.Property(e => e.NrColliDesc)
                    .HasColumnName("NR_COLLI_DESC")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NrDdt)
                    .HasColumnName("NR_DDT")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NrDiscordanze).HasColumnName("NR_DISCORDANZE");

                entity.Property(e => e.NrEtichettatiForn).HasColumnName("NR_ETICHETTATI_FORN");

                entity.Property(e => e.NrEtichettatiSnatt).HasColumnName("NR_ETICHETTATI_SNATT");

                entity.Property(e => e.NrMms)
                    .HasColumnName("NR_MMS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NrOrdine)
                    .HasColumnName("NR_ORDINE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NrPezziCalc).HasColumnName("NR_PEZZI_CALC");

                entity.Property(e => e.NrPezziDdt).HasColumnName("NR_PEZZI_DDT");

                entity.Property(e => e.NrPrecarico).HasColumnName("NR_PRECARICO");

                entity.Property(e => e.NrRietiSnatt).HasColumnName("NR_RIETI_SNATT");

                entity.Property(e => e.NrSnatt).HasColumnName("NR_SNATT");

                entity.Property(e => e.OperSnatt)
                    .HasColumnName("OPER_SNATT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.OrdTriangolato)
                    .HasColumnName("ORD_TRIANGOLATO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Priorita).HasColumnName("PRIORITA");

                entity.Property(e => e.SnattMail)
                    .HasColumnName("SNATT_MAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stato)
                    .HasColumnName("STATO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subdep)
                    .HasColumnName("SUBDEP")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.SubdepCat).HasColumnName("SUBDEP_CAT");
            });
        }
    }
}
