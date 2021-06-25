using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace GlassDoor.Migrations
{
    public partial class employeecompanyjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrerLevel",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "EducationLevel",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "EmploymentType",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "JobsDetails",
                newName: "SalaryRateId");

            migrationBuilder.RenameColumn(
                name: "ExperienceNedded",
                table: "JobsDetails",
                newName: "SalaryMin");

            migrationBuilder.RenameColumn(
                name: "Locations",
                table: "Companies",
                newName: "Phone");

            migrationBuilder.AddColumn<int>(
                name: "CareerLevelId",
                table: "JobsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EducationLevelId",
                table: "JobsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceNeededMax",
                table: "JobsDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceNeededMin",
                table: "JobsDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobCategoryId",
                table: "JobsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalaryCurrencyId",
                table: "JobsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalaryMax",
                table: "JobsDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobStatusId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobTypeId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AlternativeMobileNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CareerLevelId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EducationLevelId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceYears",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsWillingToRelocate",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MilitaryStatus",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumSalary",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUs",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyIndustryId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanySizeId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyTypeId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YearFounded",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CareerLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyIndustries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyIndustries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanySizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkill",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkill", x => new { x.EmployeesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialLinks_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialLinks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<Point>(type: "geography", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeJobCategory",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    PreferredJobCategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeJobCategory", x => new { x.EmployeesId, x.PreferredJobCategoriesId });
                    table.ForeignKey(
                        name: "FK_EmployeeJobCategory_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeJobCategory_JobCategories_PreferredJobCategoriesId",
                        column: x => x.PreferredJobCategoriesId,
                        principalTable: "JobCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeJobType",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    JobTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeJobType", x => new { x.EmployeesId, x.JobTypesId });
                    table.ForeignKey(
                        name: "FK_EmployeeJobType_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeJobType_JobTypes_JobTypesId",
                        column: x => x.JobTypesId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityCompany",
                columns: table => new
                {
                    CompaniesId = table.Column<int>(type: "int", nullable: false),
                    LocationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityCompany", x => new { x.CompaniesId, x.LocationsId });
                    table.ForeignKey(
                        name: "FK_CityCompany_Cities_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityCompany_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobsDetails_CareerLevelId",
                table: "JobsDetails",
                column: "CareerLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsDetails_EducationLevelId",
                table: "JobsDetails",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsDetails_JobCategoryId",
                table: "JobsDetails",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsDetails_SalaryCurrencyId",
                table: "JobsDetails",
                column: "SalaryCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsDetails_SalaryRateId",
                table: "JobsDetails",
                column: "SalaryRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CityId",
                table: "Jobs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CountryId",
                table: "Jobs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobStatusId",
                table: "Jobs",
                column: "JobStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobTypeId",
                table: "Jobs",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CareerLevelId",
                table: "Employees",
                column: "CareerLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CityId",
                table: "Employees",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryId",
                table: "Employees",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EducationLevelId",
                table: "Employees",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalityId",
                table: "Employees",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyIndustryId",
                table: "Companies",
                column: "CompanyIndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanySizeId",
                table: "Companies",
                column: "CompanySizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyTypeId",
                table: "Companies",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CityCompany_LocationsId",
                table: "CityCompany",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobCategory_PreferredJobCategoriesId",
                table: "EmployeeJobCategory",
                column: "PreferredJobCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobType_JobTypesId",
                table: "EmployeeJobType",
                column: "JobTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_SkillsId",
                table: "EmployeeSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_CompanyId",
                table: "SocialLinks",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_EmployeeId",
                table: "SocialLinks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_EmployeeId",
                table: "UserLanguages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_LanguageId",
                table: "UserLanguages",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyIndustries_CompanyIndustryId",
                table: "Companies",
                column: "CompanyIndustryId",
                principalTable: "CompanyIndustries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanySizes_CompanySizeId",
                table: "Companies",
                column: "CompanySizeId",
                principalTable: "CompanySizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyTypes_CompanyTypeId",
                table: "Companies",
                column: "CompanyTypeId",
                principalTable: "CompanyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CareerLevels_CareerLevelId",
                table: "Employees",
                column: "CareerLevelId",
                principalTable: "CareerLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Cities_CityId",
                table: "Employees",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Countries_CountryId",
                table: "Employees",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Countries_NationalityId",
                table: "Employees",
                column: "NationalityId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EducationLevels_EducationLevelId",
                table: "Employees",
                column: "EducationLevelId",
                principalTable: "EducationLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Cities_CityId",
                table: "Jobs",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Countries_CountryId",
                table: "Jobs",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobStatuses_JobStatusId",
                table: "Jobs",
                column: "JobStatusId",
                principalTable: "JobStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                table: "Jobs",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobsDetails_CareerLevels_CareerLevelId",
                table: "JobsDetails",
                column: "CareerLevelId",
                principalTable: "CareerLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobsDetails_Currencies_SalaryCurrencyId",
                table: "JobsDetails",
                column: "SalaryCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobsDetails_EducationLevels_EducationLevelId",
                table: "JobsDetails",
                column: "EducationLevelId",
                principalTable: "EducationLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobsDetails_JobCategories_JobCategoryId",
                table: "JobsDetails",
                column: "JobCategoryId",
                principalTable: "JobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobsDetails_SalaryRates_SalaryRateId",
                table: "JobsDetails",
                column: "SalaryRateId",
                principalTable: "SalaryRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyIndustries_CompanyIndustryId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanySizes_CompanySizeId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyTypes_CompanyTypeId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CareerLevels_CareerLevelId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Cities_CityId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Countries_CountryId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Countries_NationalityId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EducationLevels_EducationLevelId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Cities_CityId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Countries_CountryId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobStatuses_JobStatusId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_JobsDetails_CareerLevels_CareerLevelId",
                table: "JobsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_JobsDetails_Currencies_SalaryCurrencyId",
                table: "JobsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_JobsDetails_EducationLevels_EducationLevelId",
                table: "JobsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_JobsDetails_JobCategories_JobCategoryId",
                table: "JobsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_JobsDetails_SalaryRates_SalaryRateId",
                table: "JobsDetails");

            migrationBuilder.DropTable(
                name: "CareerLevels");

            migrationBuilder.DropTable(
                name: "CityCompany");

            migrationBuilder.DropTable(
                name: "CompanyIndustries");

            migrationBuilder.DropTable(
                name: "CompanySizes");

            migrationBuilder.DropTable(
                name: "CompanyTypes");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "EmployeeJobCategory");

            migrationBuilder.DropTable(
                name: "EmployeeJobType");

            migrationBuilder.DropTable(
                name: "EmployeeSkill");

            migrationBuilder.DropTable(
                name: "JobStatuses");

            migrationBuilder.DropTable(
                name: "SalaryRates");

            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_JobsDetails_CareerLevelId",
                table: "JobsDetails");

            migrationBuilder.DropIndex(
                name: "IX_JobsDetails_EducationLevelId",
                table: "JobsDetails");

            migrationBuilder.DropIndex(
                name: "IX_JobsDetails_JobCategoryId",
                table: "JobsDetails");

            migrationBuilder.DropIndex(
                name: "IX_JobsDetails_SalaryCurrencyId",
                table: "JobsDetails");

            migrationBuilder.DropIndex(
                name: "IX_JobsDetails_SalaryRateId",
                table: "JobsDetails");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CityId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CountryId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobStatusId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobTypeId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CareerLevelId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CountryId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EducationLevelId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_NationalityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyIndustryId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanySizeId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyTypeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CareerLevelId",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "EducationLevelId",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "ExperienceNeededMax",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "ExperienceNeededMin",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "JobCategoryId",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "SalaryCurrencyId",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "SalaryMax",
                table: "JobsDetails");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobStatusId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobTypeId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AlternativeMobileNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CV",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CareerLevelId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EducationLevelId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ExperienceYears",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsWillingToRelocate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MilitaryStatus",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MinimumSalary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AboutUs",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyIndustryId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanySizeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyTypeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "YearFounded",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "SalaryRateId",
                table: "JobsDetails",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "SalaryMin",
                table: "JobsDetails",
                newName: "ExperienceNedded");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Companies",
                newName: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "CarrerLevel",
                table: "JobsDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "JobsDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationLevel",
                table: "JobsDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "JobsDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "JobsDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentType",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
