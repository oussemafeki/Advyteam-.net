namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context3")
        {
        }

        public virtual DbSet<affectationproject> affectationproject { get; set; }
        public virtual DbSet<categorie> categorie { get; set; }
        public virtual DbSet<competance> competance { get; set; }
        public virtual DbSet<conge> conge { get; set; }
        public virtual DbSet<critere> critere { get; set; }
        public virtual DbSet<demande> demande { get; set; }
        public virtual DbSet<departement> departement { get; set; }
        public virtual DbSet<detailstache> detailstache { get; set; }
        public virtual DbSet<employe> employe { get; set; }
        public virtual DbSet<expenses> expenses { get; set; }
        public virtual DbSet<forum> forum { get; set; }
        public virtual DbSet<managereval> managereval { get; set; }
        public virtual DbSet<mission> mission { get; set; }
        public virtual DbSet<modules> modules { get; set; }
        public virtual DbSet<poste> poste { get; set; }
        public virtual DbSet<project> project { get; set; }
        public virtual DbSet<selfeval> selfeval { get; set; }
        public virtual DbSet<skills> skills { get; set; }
        public virtual DbSet<taches> taches { get; set; }
        public virtual DbSet<training> training { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categorie>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<categorie>()
                .HasMany(e => e.competance)
                .WithMany(e => e.categorie)
                .Map(m => m.ToTable("categorie_competance"));

            modelBuilder.Entity<competance>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<competance>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<competance>()
                .HasMany(e => e.poste)
                .WithMany(e => e.competance)
                .Map(m => m.ToTable("poste_competance").MapLeftKey("competances_id").MapRightKey("Postes_id"));

            modelBuilder.Entity<conge>()
                .Property(e => e.certefica)
                .IsUnicode(false);

            modelBuilder.Entity<conge>()
                .Property(e => e.demandeConge)
                .IsUnicode(false);

            modelBuilder.Entity<conge>()
                .Property(e => e.reponse)
                .IsUnicode(false);

            modelBuilder.Entity<conge>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<conge>()
                .Property(e => e.typeConge)
                .IsUnicode(false);

            modelBuilder.Entity<critere>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<critere>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<critere>()
                .HasMany(e => e.managereval)
                .WithRequired(e => e.critere)
                .HasForeignKey(e => e.critere_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<critere>()
                .HasMany(e => e.selfeval)
                .WithRequired(e => e.critere)
                .HasForeignKey(e => e.critere_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<departement>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<detailstache>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.affectationproject)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.useraffectation_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.demande)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.employe_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.taches)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.employe_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.managereval)
                .WithRequired(e => e.employe)
                .HasForeignKey(e => e.employe_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.conge)
                .WithMany(e => e.employe)
                .Map(m => m.ToTable("employe_conge").MapLeftKey("iduser_id").MapRightKey("conges_id"));

            modelBuilder.Entity<expenses>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<expenses>()
                .HasMany(e => e.mission)
                .WithOptional(e => e.expenses)
                .HasForeignKey(e => e.expense_id);

            modelBuilder.Entity<forum>()
                .Property(e => e.message)
                .IsUnicode(false);

            modelBuilder.Entity<forum>()
                .Property(e => e.nometudiant)
                .IsUnicode(false);

            modelBuilder.Entity<forum>()
                .Property(e => e.prenometudiant)
                .IsUnicode(false);

            modelBuilder.Entity<managereval>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.adresse)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.nomMission)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.demande)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.mission_id);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.skills)
                .WithMany(e => e.mission)
                .Map(m => m.ToTable("skills_mission").MapLeftKey("missions_id").MapRightKey("listSkill_id"));

            modelBuilder.Entity<modules>()
                .Property(e => e.descriptionModule)
                .IsUnicode(false);

            modelBuilder.Entity<modules>()
                .Property(e => e.nomModule)
                .IsUnicode(false);

            modelBuilder.Entity<modules>()
                .HasMany(e => e.taches)
                .WithOptional(e => e.modules)
                .HasForeignKey(e => e.modules_id);

            modelBuilder.Entity<poste>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<poste>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<poste>()
                .Property(e => e.typeContrat)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.affectationproject)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.projetaffectation_id);

            modelBuilder.Entity<project>()
                .HasMany(e => e.mission)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.idProject);

            modelBuilder.Entity<project>()
                .HasMany(e => e.modules)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.projet_id);

            modelBuilder.Entity<selfeval>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<skills>()
                .Property(e => e.Skillname)
                .IsUnicode(false);

            modelBuilder.Entity<taches>()
                .Property(e => e.descriptionTache)
                .IsUnicode(false);

            modelBuilder.Entity<taches>()
                .Property(e => e.nomTache)
                .IsUnicode(false);

            modelBuilder.Entity<taches>()
                .HasMany(e => e.detailstache)
                .WithOptional(e => e.taches)
                .HasForeignKey(e => e.id_tache);

            modelBuilder.Entity<training>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<training>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<training>()
                .HasMany(e => e.employe)
                .WithMany(e => e.training)
                .Map(m => m.ToTable("training_employe").MapLeftKey("Training_id").MapRightKey("employee_id"));
        }
    }
}
