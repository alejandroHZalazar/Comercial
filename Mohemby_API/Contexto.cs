using Microsoft.EntityFrameworkCore;
using Mohemby_API.Modelos;
using System;

namespace Mohemby_API;
public class Contexto: DbContext
{
    public DbSet<Especialidad> Especialidades {get;set;}
    public DbSet<Horario> Horarios {get; set;}

    public DbSet<Inactivismo_medico> Inactivismo_Medicos { get; set; }
    public DbSet<Medico_especialidad> Medico_Especialidades {get; set; }
    public DbSet<Medico> Medicos { get; set; }

    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<pol_Costo> pol_Costos  { get; set; }
    public DbSet<Pol_Costos_OS> pol_Costos_Oss {get; set; }
    public DbSet<Rayos_Costo_OS> rayos_Costo_Oss {get; set; }
    public DbSet<Afiliado> Afiliados {get; set;}
    public DbSet<UserApi> UserApis {get; set;}

    public Contexto(DbContextOptions<Contexto> options) :base(options) { }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          modelBuilder.Entity<Especialidad>(especialidad=> 
          {
            especialidad.ToTable("especialidad");
            especialidad.HasKey(p=>p.id);
            especialidad.Property(p=>p.nombre).HasMaxLength(100);
            especialidad.Property(p=>p.tipo).HasMaxLength(2);
            especialidad.Property(p=>p.baja);
            especialidad.Property(p=>p.esEspecialidad);
            especialidad.Property(p=>p.esGuardia);
          });

          modelBuilder.Entity<Horario>(horario=>
          {
            horario.ToTable("horarios");
            horario.HasKey(p=>p.id);
            horario.Property(p=>p.dia).HasMaxLength(15);
            horario.Property(p=>p.horario);
            horario.Property(p=>p.fk_medico);
            horario.Property(p=>p.cancelado);
            horario.Property(p=>p.consultorio).HasMaxLength(5);
            horario.Property(p=>p.baja);
            horario.Property(p=>p.sobreTurno);
          });

          modelBuilder.Entity<Inactivismo_medico>(inactivismo_medico=>
          {
             inactivismo_medico.ToTable("inactivismo_medico");
             inactivismo_medico.HasKey(p=>p.id);
             inactivismo_medico.Property(p=>p.fk_medico);
             inactivismo_medico.Property(p=>p.fecha_inicio);
             inactivismo_medico.Property(p=>p.fecha_fin);
             inactivismo_medico.Property(p=>p.terminado);   
          });

          modelBuilder.Entity<Medico>(medico=>
          {
            medico.ToTable("medico");
            medico.HasKey(p=>p.id);
            medico.Property(p=>p.nombre).HasMaxLength(200);
            medico.Property(p=>p.domicilio).HasMaxLength(200);
            medico.Property(p=>p.telFijo).HasMaxLength(50);
            medico.Property(p=>p.telCel).HasMaxLength(50);
            medico.Property(p=>p.baja);
            medico.Property(p=>p.firma);
            medico.Property(p=>p.esEspecialista);
            medico.Property(p=>p.consultorio).HasMaxLength(1);
            medico.Property(p=>p.matricula).HasMaxLength(20);
            medico.Property(p=>p.esGuardia);
          });

          modelBuilder.Entity<Medico_especialidad>(medico_especialidad=>
          {
            medico_especialidad.ToTable("medico_especialidad");
            medico_especialidad.HasKey(p=>p.id);
            medico_especialidad.Property(p=>p.fk_medico);
            medico_especialidad.Property(p=>p.fk_especialidad );
          });

          modelBuilder.Entity<Paciente>(paciente =>
          {
            paciente.ToTable("Pacientes");
            paciente.HasKey(p=>p.id);
            paciente.Property(p=>p.nombre).HasMaxLength(80);
            paciente.Property(p=>p.fechaNac);
            paciente.Property(p=>p.fk_tipoDoc);
            paciente.Property(p=>p.nroDocumento);
            paciente.Property(p=>p.cuil);
            paciente.Property(p=>p.fechaAlta);
            paciente.Property(p=>p.fechaBaja);
            paciente.Property(p=>p.calle).HasMaxLength(250);
            paciente.Property(p=>p.numeroCalle).HasMaxLength(50);
            paciente.Property(p=>p.entreCalle).HasMaxLength(50);
            paciente.Property(p=>p.ycalle).HasMaxLength(50);
            paciente.Property(p=>p.piso).HasMaxLength(50);
            paciente.Property(p=>p.dpto).HasMaxLength(50);
            paciente.Property(p=>p.casa).HasMaxLength(50);
            paciente.Property(p=>p.lote).HasMaxLength(50);
            paciente.Property(p=>p.mz).HasMaxLength(50);
            paciente.Property(p=>p.pc).HasMaxLength(50);
            paciente.Property(p=>p.block).HasMaxLength(50);
            paciente.Property(p=>p.qta).HasMaxLength(50);
            paciente.Property(p=>p.uf).HasMaxLength(50);
            paciente.Property(p=>p.etapa).HasMaxLength(50);
            paciente.Property(p=>p.torre).HasMaxLength(50);
            paciente.Property(p=>p.tira).HasMaxLength(50);
            paciente.Property(p=>p.chacra).HasMaxLength(50);
            paciente.Property(p=>p.fk_barrio);
            paciente.Property(p=>p.radioGeografico);
            paciente.Property(p=>p.telFijo).HasMaxLength(50);
            paciente.Property(p=>p.telCelular).HasMaxLength(50);
            paciente.Property(p=>p.email).HasMaxLength(50);
            paciente.Property(p=>p.esSocio);
            paciente.Property(p=>p.baja );
            paciente.Property(p=>p.fk_obraSocial);
            paciente.Property(p=>p.fk_condicionIVA);
            paciente.Property(p=>p.cuit).HasMaxLength(50);
            paciente.Property(p=>p.nroAfiliado);
            paciente.Property(p=>p.fk_grupo);
            paciente.Property(p=>p.fk_pais);
            paciente.Property(p=>p.fk_provincia);
            paciente.Property(p=>p.fk_localidad);
            paciente.Property(p=>p.nroAfiliadoOS).HasMaxLength(100);
            paciente.Property(p=>p.sexo).HasMaxLength(2);
          });

          modelBuilder.Entity<Pol_Costos_OS>(pol_Costos_OS=>
          {
            pol_Costos_OS.ToTable("pol_Costos_OS");
            pol_Costos_OS.HasKey("id");
            pol_Costos_OS.Property("fk_obraSocial");
            pol_Costos_OS.Property("descripcion").HasMaxLength(100);
            pol_Costos_OS.Property("importe");
            pol_Costos_OS.Property("importeEME");
            pol_Costos_OS.Property("codigoOS").HasMaxLength(50);
            pol_Costos_OS.Property("tipo").HasMaxLength(2);
            pol_Costos_OS.Property("baja");
            pol_Costos_OS.Property("coseguro");
          });

          modelBuilder.Entity<pol_Costo>(pol_costo=>
          {
            pol_costo.ToTable("polCostos");
            pol_costo.HasKey("id");
            pol_costo.Property("obraSocial").HasMaxLength(100);
            pol_costo.Property("coef");
            pol_costo.Property("baja");
            pol_costo.Property("fk_tipo_obraSocial");
            pol_costo.Property("esOS");

          });

          modelBuilder.Entity<Rayos_Costo_OS>(rayos_Costo_OS=>
          {
            rayos_Costo_OS.ToTable("rayos_Costos_OS");
            rayos_Costo_OS.HasKey("id");
            rayos_Costo_OS.Property("fk_obraSocial");
            rayos_Costo_OS.Property("descripcion").HasMaxLength(100);
            rayos_Costo_OS.Property("importe");
            rayos_Costo_OS.Property("importeEME");
            rayos_Costo_OS.Property("codigoOS").HasMaxLength(50);
            rayos_Costo_OS.Property("tipo").HasMaxLength(2);
            rayos_Costo_OS.Property("baja");
            rayos_Costo_OS.Property("coseguro");
          });

          modelBuilder.Entity<Afiliado>(afiliado=>
          {
            afiliado.ToTable("Afiliados");
            afiliado.Property("id");
            afiliado.Property("fk_grupo");
            afiliado.Property("nro");
            afiliado.Property("nombre").HasMaxLength(50);
            afiliado.Property("fechaNac");
            afiliado.Property("nroDocumento");
            afiliado.Property("fechaAlta");
            afiliado.Property("fechaBaja");
            afiliado.Property("baja");
            afiliado.Property("calle");
            afiliado.Property("telCelular");
            afiliado.Property("email");
            afiliado.Property("abusador");
          });

           modelBuilder.Entity<UserApi>(userApi=>
            {
                userApi.ToTable("SecurityAppi");
                userApi.HasKey(p=> p.id);
                userApi.Property(p=> p.user);
                userApi.Property(p=> p.password);
            });
     }

}