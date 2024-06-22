using Microsoft.EntityFrameworkCore;

public class DataContext:DbContext{
    public DataContext(DbContextOptions dbContextOptions):base(dbContextOptions){}

    public DbSet<Proizvod> Proizvodi {get;set;}
    public DbSet<Korpa> Korpe {get; set;}
    public DbSet<ProizvodKorpa> ProizvodKorpe {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<ProizvodKorpa>()
        .HasKey(pk=>new {pk.ProizvodId,pk.KorpaId});
        modelBuilder.Entity<ProizvodKorpa>()
        .HasOne(pk=>pk.Proizvod)
        .WithMany(p=>p.ProizvodKorpe)
        .HasForeignKey(p=>p.ProizvodId);
        modelBuilder.Entity<ProizvodKorpa>()
        .HasOne(pk=>pk.Korpa)
        .WithMany(k=>k.ProizvodKorpe)
        .HasForeignKey(pk=>pk.KorpaId);
    }
}