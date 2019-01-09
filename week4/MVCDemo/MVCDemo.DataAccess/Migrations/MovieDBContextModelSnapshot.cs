﻿// <auto-generated />
using System;
using MVCDemo.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCDemo.DataAccess.Migrations
{
    [DbContext(typeof(MovieDBContext))]
    partial class MovieDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCDemo.DataAccess.CastMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CastMember");
                });

            modelBuilder.Entity("MVCDemo.DataAccess.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MVCDemo.DataAccess.MovieCastMemberJunction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CastMemberId");

                    b.Property<int?>("MovieId");

                    b.HasKey("Id");

                    b.HasIndex("CastMemberId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCastMemberJunction");
                });

            modelBuilder.Entity("MVCDemo.DataAccess.MovieCastMemberJunction", b =>
                {
                    b.HasOne("MVCDemo.DataAccess.CastMember", "CastMember")
                        .WithMany("MovieJunctions")
                        .HasForeignKey("CastMemberId");

                    b.HasOne("MVCDemo.DataAccess.Movie", "Movie")
                        .WithMany("CastMemberJunctions")
                        .HasForeignKey("MovieId");
                });
#pragma warning restore 612, 618
        }
    }
}
