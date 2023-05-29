﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace STOlizza.Leto.Server.Migrations
{
    /// <inheritdoc />
    public partial class StolizzaLetoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionnairyDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Smena = table.Column<int>(type: "integer", nullable: false),
                    QImage = table.Column<List<byte>>(type: "smallint[]", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FatherName = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    WorkingPlace = table.Column<string>(type: "text", nullable: false),
                    Post = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    VkLink = table.Column<string>(type: "text", nullable: true),
                    TelegramUsername = table.Column<string>(type: "text", nullable: false),
                    ClothesSize = table.Column<string>(type: "text", nullable: true),
                    Allergies = table.Column<string>(type: "text", nullable: true),
                    Illneses = table.Column<string>(type: "text", nullable: true),
                    KnowledgeSource = table.Column<string>(type: "text", nullable: false),
                    DesiredSkills = table.Column<string>(type: "text", nullable: false),
                    ExpirienceIntentions = table.Column<string>(type: "text", nullable: false),
                    QVideo = table.Column<List<byte>>(type: "smallint[]", nullable: false),
                    VideoPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnairyDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Smenas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    dates = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    isAvailable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smenas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionnairyDTO");

            migrationBuilder.DropTable(
                name: "Smenas");
        }
    }
}
