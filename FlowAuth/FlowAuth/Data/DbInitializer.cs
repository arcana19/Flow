using FlowAuth.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowAuth.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            context.Database.EnsureCreated();
            //Staff
            if (context.Staffs.Any())
            {
                return; //Db is already seeded
            }
            //We need the staff memebers to exist before the system users can
            var staff = new Staff[]
            {
                //Note: date format only works for "mm/dd/yyyy" when initilizing our data
            new Staff{Staff_type = "Management" , Staff_fullName = "Joe Msiza", Staff_country = "South Africa",Staff_idNum = 8502065323081 ,Staff_cellphone =0815575319 , Staff_res_addr = "6618 Bandura street,Midrand,Johannersburg ,2000",Staff_email = "joemsiza@gmail.com",Staff_position =  "Quantity Surveyor",Staff_medicalAid = "BONITAS",Staff_medicalAidNo =0002343, Staff_DOB = DateTime.Parse("06-02-1985") , Staff_emp_nature = "permanent", Staff_incomeTax = 0000453134,Staff_nextKin_name = "Patrick Msiza" ,Staff_nextKin_cellphone = 0822614589,Staff_leaveDays=30,Staff_rate = 2000},
            new Staff{Staff_type = "Management" , Staff_fullName = "Thabo Simelane", Staff_country = "South Africa",Staff_idNum = 8403051223081 ,Staff_cellphone = 0833215366 , Staff_res_addr = "13 Sunset drive,Midrand,Johannersburg ,2000",Staff_email = "thabosimelane@gmail.com",Staff_position =  "Human Resources",Staff_medicalAid = "BONITAS",Staff_medicalAidNo=0003243, Staff_DOB = DateTime.Parse("05-03-1984") , Staff_emp_nature = "permanent", Staff_incomeTax = 0000543263,  Staff_nextKin_name = "Sihle Simelane" , Staff_nextKin_cellphone =072125489,Staff_leaveDays=20,Staff_rate = 2130},
            new Staff{Staff_type = "Admin" , Staff_fullName = "Patrick Masemola",Staff_country = "South Africa", Staff_idNum = 9102075489084 ,Staff_cellphone =0721254351 , Staff_res_addr = "18 Leyds,Hatfield,Pretoria ,0002",Staff_email = "patrickmasemola@gmail.com",Staff_position =  "Technologist",Staff_medicalAid = "BONITAS",Staff_medicalAidNo = 00023546, Staff_DOB = DateTime.Parse("07-02-1991") , Staff_emp_nature = "permanent", Staff_incomeTax = 0000441123, Staff_nextKin_name = "Paul Matla" ,Staff_nextKin_cellphone = 0611098543,Staff_leaveDays= 30 , Staff_rate = 1300 },
            new Staff{Staff_type = "Staff" , Staff_fullName = "Jacob Visser", Staff_country = "South Africa",Staff_idNum = 8704085863081 ,Staff_cellphone = 0615457519 , Staff_res_addr = "21 Weaver street,Sandton,Johannersburg ,2014",Staff_email = "jacobvisser@gmail.com",Staff_position =  "Quantity Surveyor",Staff_medicalAid = "BONITAS",Staff_medicalAidNo =0002343, Staff_DOB = DateTime.Parse("08-04-1987") , Staff_emp_nature = "temporary",Staff_incomeTax = 0000443245,  Staff_nextKin_name = "Carren Visser" , Staff_nextKin_cellphone =0811763423,Staff_lastDay = DateTime.Parse("05/05/2018") ,Staff_leaveDays =0,Staff_rate = 3400},
            new Staff{Staff_type = "Staff" , Staff_fullName = "Jasmine Thompson", Staff_country = "South Africa",Staff_idNum = 9306023323086 ,Staff_cellphone = 0822133619, Staff_res_addr = "458 Vilakazi street,Soweto,Johannersburg ,1800",Staff_email = "jasminethompson@gmail.com",Staff_position =  "Architect",Staff_medicalAid = "BONITAS",Staff_medicalAidNo =0001243, Staff_DOB = DateTime.Parse("06-02-1993") , Staff_emp_nature = "permanent",Staff_incomeTax = 000044123,  Staff_nextKin_name = "Aviwe Ndlovo" , Staff_nextKin_cellphone = 0722734422 ,Staff_leaveDays = 15,Staff_rate = 1200},
            new Staff{Staff_type = "Staff" , Staff_fullName = "Catherine Tshabalala",Staff_country = "South Africa", Staff_idNum = 9012065353088 ,Staff_cellphone =0815575437 , Staff_res_addr = "213 Kaufman Rd, Halfway Gardens, Midrand, 1686",Staff_email = "catherinetshabalala@gmail.com",Staff_position =  "Technologist",Staff_medicalAid = "BONITAS",Staff_medicalAidNo =0001563, Staff_DOB = DateTime.Parse("06-12-1990") , Staff_emp_nature = "temporary",Staff_incomeTax = 000077658, Staff_nextKin_name = "Julian Gomes" , Staff_nextKin_cellphone = 0821203656,Staff_leaveDays=2,Staff_rate = 2250},
            new Staff{Staff_type = "Staff" , Staff_fullName = "John Greenwood",Staff_country = "Germany", Staff_passport = 930206655 ,Staff_cellphone =0815144337 , Staff_res_addr = "88 Corobay ave, Contstantia , Pretoria, 0122",Staff_email = "johngreenwood@gmail.com",Staff_position =  "Archticet",Staff_medicalAid = "BONITAS",Staff_medicalAidNo = 0003263, Staff_DOB = DateTime.Parse("06-02-1993") , Staff_emp_nature = "permanent", Staff_nextKin_name = "Natalie Stone",Staff_incomeTax = 0011324456,  Staff_nextKin_cellphone = 0721905639 ,Staff_leaveDays=35, Staff_rate = 3000 }

           };
            foreach (Staff s in staff)
            {
                await context.Staffs.AddAsync(s);
            }
            await context.SaveChangesAsync();


            int adminId1 = 0;
            int adminId2 = 0;

            //Seeding database with roles
            string role1 = "Admin";
            string desc1 = "This  is the administrator role";

            string role2 = "Management";
            string desc2 = "This is the manager role";

            string role3 = "Staff";
            string desc3 = "This is the general users";

            string password = "pA$$word123";

            //we start checking if something is in db and then add it if it's a null return
            if(await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new AppRole(role1,desc1));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new AppRole(role2, desc2));
            }
            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new AppRole(role3, desc3));
            }

            if (await userManager.FindByNameAsync("thabosimelane@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "thabosimelane@gmail.com",
                    FullName = "Thabo Simelane",
                    Email = "thabosimelane@gmail.com",
                    StaffID = 2,
                    //Staff_idNum = 8403051223081,
                    
                };

                var result = await userManager.CreateAsync(user);
                if(result.Succeeded)
                {
                    //the user is created and is now given a password hash and to the roles
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                //adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("joemsiza@gmail.com") == null)
            {
                var user = new AppUser
                {
                    
                    UserName = "joemsiza@gmail.com",
                    FullName = "Joe Msiza",
                    Email = "joemsiza@gmail.com",
                    StaffID = 1,
                    //Staff_idNum = 8502065323081,
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    //the user is created and is now given a password hash and to the roles
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
                //adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("jacobvisser@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "jacobvisser@gmail.com",
                    FullName = "Jacob Visser",
                    Email = "jacobvisser@gmail.com",
                    StaffID = 4,
                   // Cellphone = 0812793322,
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    //the user is created and is now given a password hash and to the roles
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }
               // adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("patrickmasemola@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "patrickmasemola@gmail.com",
                    FullName = "Patric Masemola",
                    Email = "patrickmasemola@gmail.com",
                    StaffID = 3,
                    // Cellphone = 0812793322,
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    //the user is created and is now given a password hash and to the roles
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }
                //adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("jasminethompson@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "jasminethompson@gmail.com",
                    FullName = "Jasmine Thompson",
                    Email = "jasminethompson@gmail.com",
                    StaffID = 5,
                    // Cellphone = 0812793322,
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    //the user is created and is now given a password hash and to the roles
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }
                //adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("catherinetshabalala@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "catherinetshabalala@gmail.com",
                    FullName = "Catherine Tshabalala",
                    Email = "catherinetshabalala@gmail.com",
                    StaffID = 6,
                    // Cellphone = 0812793322,
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    //the user is created and is now given a password hash and to the roles
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }
                //adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("johngreenwood@gmail.com") == null)
            {
                var user = new AppUser
                {
                    UserName = "johngreenwood@gmail.com",
                    FullName = "John Greenwood",
                    Email = "johngreenwood@gmail.com",
                    StaffID = 7,
                    // Cellphone = 0812793322,
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    //the user is created and is now given a password hash and to the roles
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }
                //adminId2 = user.Id;
            }

            //************* Seeding FLOW ******************// 


            //Phase Names
            if(context.PhaseNames.Any())
            {
                return; //DB is already seeded
            }
            var phaseName = new PhaseName[]
            {
                new PhaseName{Phase_name = "Inception"},
                new PhaseName{Phase_name = "Documentation And Procurement"},
                new PhaseName{Phase_name = "Design development"},
                new PhaseName{Phase_name = "Design Concepts"},
                new PhaseName{Phase_name = "Construction"},
                new PhaseName{Phase_name = "Close Out"},
            };
            foreach (PhaseName pn in phaseName)
            {
                await context.PhaseNames.AddAsync(pn);
            }
            await context.SaveChangesAsync();

            //Task descriptions
            if (context.TaskDescrptions.Any())
            {
                return; //DB is already seeded
            }
            var tasks = new TaskDescription[]
            {
                new TaskDescription{Task_name = "Login"},
                new TaskDescription{Task_name = "Regular Hrs"},
                new TaskDescription{Task_name = "Gen. Admin"},
                new TaskDescription{Task_name = "Working Dwgs & Documentation"},
                new TaskDescription{Task_name = "Travel"},
                new TaskDescription{Task_name = "Site Inspection"},
                new TaskDescription{Task_name = "Overtime Hrs"},
                new TaskDescription{Task_name = "Interruptions"},
                new TaskDescription{Task_name = "Costing"},
                new TaskDescription{Task_name = "Sick Hours"},
                new TaskDescription{Task_name = "Meeting - Office"},
                new TaskDescription{Task_name = "Procurement"},
                new TaskDescription{Task_name = "Paid Leave"},
                new TaskDescription{Task_name = "Proj. Admin"},
                new TaskDescription{Task_name = "Building Programme"},
                new TaskDescription{Task_name = "Meeting - Project"},
                new TaskDescription{Task_name = "Site Management"},
                new TaskDescription{Task_name = " Site Visit-Measurements"},
                new TaskDescription{Task_name = "Council Running"},
                new TaskDescription{Task_name = "Design Concept"},
                new TaskDescription{Task_name = "Design Development"},
                new TaskDescription{Task_name = "Council Dwgs"},
                new TaskDescription{Task_name = "Lunch"},
                new TaskDescription{Task_name = "Log Out"},
            };
            foreach (TaskDescription t in tasks)
            {
                await context.AddAsync(t);
            }
            await context.SaveChangesAsync();

            //Clients
            if (context.Clients.Any())
            {
                return; //DB is already seeded
            }
            var clients = new Client[]
            {
                new Client{Client_name="Vincent",Client_service="Accountant",Client_DOB=DateTime.Parse("01-12-1956"),Client_id_no=5612016103089,Client_work_address="Raimond 6,Felix,Johannesburg,2003",Client_contactEmail="jabu@freshproduce.com",Client_contactNo=0664435575,Client_workNo=0114526564,Account_status="Good",Client_contactName = "Jabu Pule"},
                new Client{Client_name="Nicole",Client_service="Project Manager",Client_DOB=DateTime.Parse("02-11-1989"),Client_id_no=891102103089,Client_work_address="Dooly bay ,Sandton,Johannesburg,2004",Client_contactEmail="suzanne@pwd.com",Client_contactNo=0763795575,Client_workNo=0116324564,Account_status="Good",Client_contactName = "Suzanne Porch"},
                new Client{Client_name="Jamy",Client_service="School Principle",Client_DOB=DateTime.Parse("04-12-1966"),Client_id_no=6612046403089,Client_work_address="Maboneng,Soweto East,Johannesburg,2005",Client_contactEmail="jack@builders.com",Client_contactNo=0797645575,Client_workNo=0124376564,Account_status="Good",Client_contactName = "Jack Grey"},
                new Client{Client_name="Floyd",Client_service="Software Programmer",Client_DOB=DateTime.Parse("07-09-1990"),Client_id_no=9009076103089,Client_work_address="Clear Waters 23,Midrand,Johannesburg,2008",Client_contactEmail="steve@techworld.com",Client_contactNo=0852475755,Client_workNo=0114863564,Account_status="Good",Client_contactName = "Steve Blue"},
                new Client{Client_name="Gail",Client_service="Engineer",Client_DOB=DateTime.Parse("10-03-1987"),Client_id_no=8703316103089,Client_work_address="Lee Waters,Benoni,Johannesburg,2009",Client_contactEmail="joshua@amazingwork.com",Client_contactNo=0678435575,Client_workNo=0138536566,Account_status="Good",Client_contactName = "Joshua Harris"},
                new Client{Client_name="Firdows",Client_service="Accountant",Client_DOB=DateTime.Parse("01-12-1956"),Client_id_no=5612016103089,Client_work_address="Raimond 6,Felix,Johannesburg,2003",Client_contactEmail="firdows@arcana.com",Client_contactNo=0664435575,Client_workNo=0114526564,Account_status="Good",Client_contactName = "Firdows"},
                new Client{Client_name="Harvey",Client_service="Project Manager",Client_DOB=DateTime.Parse("02-11-1989"),Client_id_no=891102103089,Client_work_address="Dooly bay ,Sandton,Johannesburg,2004",Client_contactEmail="harvey@liftit.com",Client_contactNo=0763795575,Client_workNo=0116324564,Account_status="Good",Client_contactName = "Harvey"},
                new Client{Client_name="Sibusiso",Client_service="School Principle",Client_DOB=DateTime.Parse("04-12-1966"),Client_id_no=6612046403089,Client_work_address="Maboneng,Soweto East,Johannesburg,2005",Client_contactEmail="sibusiso@devops.com",Client_contactNo=0797645575,Client_workNo=0124376564,Account_status="Blacklisted",Client_contactName = "Sibusiso"},
                new Client{Client_name="Chris",Client_service="Software Programmer",Client_DOB=DateTime.Parse("07-09-1990"),Client_id_no=9009076103089,Client_work_address="Clear Waters 23,Midrand,Johannesburg,2008",Client_contactEmail="chris@excutives.com",Client_contactNo=0852475755,Client_workNo=0114863564,Account_status="Blacklisted",Client_contactName = "Chris FLow"},
                new Client{Client_name="Ernest",Client_service="Engineer",Client_DOB=DateTime.Parse("10-03-1987"),Client_id_no=8703316103089,Client_work_address="Lee Waters,Benoni,Johannesburg,2009",Client_contactEmail="eva@lightworks.com",Client_contactNo=0678435575,Client_workNo=0138536564,Account_status="Blacklisted", Client_contactName = "Eva Green"},
                new Client{Client_name="Tom",Client_service="Accountant",Client_DOB=DateTime.Parse("01-12-1956"),Client_id_no=5612016103089,Client_work_address="Raimond 6,Felix,Johannesburg,2003",Client_contactEmail="tom@homeprojects,com",Client_contactNo=0664435575,Client_workNo=0114526564,Account_status="Good",Client_contactName= "Tom Hanks"},
                new Client{Client_name="Mitch",Client_service="Project Manager",Client_DOB=DateTime.Parse("02-11-1989"),Client_id_no=891102103089,Client_work_address="Dooly bay ,Sandton,Johannesburg,2004",Client_contactEmail="steve@construct.com",Client_contactNo=0763795575,Client_workNo=0116324564,Account_status="Good",Client_contactName = "Steve Evens"},
                new Client{Client_name="Sipho",Client_service="School Principle",Client_DOB=DateTime.Parse("04-12-1966"),Client_id_no=6612046403089,Client_work_address="Maboneng,Soweto East,Johannesburg,2005",Client_contactEmail="sipho@fusion.com",Client_contactNo=0797645575,Client_workNo=0124376564,Account_status="Good",Client_contactName = "Sipho Ndovo"},
                new Client{Client_name="Jimmy",Client_service="Software Programmer",Client_DOB=DateTime.Parse("07-09-1990"),Client_id_no=9009076103089,Client_work_address="Clear Waters 23,Midrand,Johannesburg,2008",Client_contactEmail="jimmy@buildit.com",Client_contactNo=0852475755,Client_workNo=01148635,Account_status="Good",Client_contactName = "Jimmy Nuetron"},
                new Client{Client_name="David",Client_service="Engineer",Client_DOB=DateTime.Parse("10-03-1987"),Client_id_no=8703316103089,Client_work_address="Lee Waters,Benoni,Johannesburg,2009",Client_contactEmail="david@mineit.com",Client_contactNo=0678435575,Client_workNo=0138536567,Account_status="Good",Client_contactName = "David Stone"},
                new Client{Client_name="AB ltd",Company_regNo="1234567",Client_work_address= "2965 Tshepiso street, simunye, Westonaria,1779",Client_service="Hotel developer",Client_workNo=0116356352,Account_status="Good",Client_contactName= "Beki Matlala",Client_contactNo = 0722559446,Client_contactEmail = "beki@abltd.com"},
                new Client{Client_name="Coldes ltd",Company_regNo="1234567",Client_work_address= "0001 Tshepiso street, simunye, Westonaria,1779",Client_service="Architecture",Client_workNo=0116356352,Account_status="Good",Client_contactName= "Thabo Tsene",Client_contactNo = 0855793261,Client_contactEmail = "thabo@coldes.com"},
                new Client{Client_name="Droid ltd",Company_regNo="1234567",Client_work_address= "8882 Tshepiso street, simunye, Westonaria,1779",Client_service="Gravel seller",Client_workNo=0116356352,Account_status="Blacklisted" ,Client_contactName= "Tshepo Malisela",Client_contactNo = 07621254986,Client_contactEmail = "tshepo@droid.com"},
                new Client{Client_name="Triller ltd",Company_regNo="1234567",Client_work_address= "7264 Tshepiso street, simunye, Westonaria,1779",Client_service="Software Warehous",Client_workNo=0116356352,Account_status="Good",Client_contactName= "Frank Ocean",Client_contactNo = 0721742532,Client_contactEmail = "frank@triller.com"},
                new Client{Client_name="HIM ltd",Company_regNo="1234567",Client_work_address= "7263 Tshepiso street, simunye, Westonaria,1779",Client_service="Hotel developer",Client_workNo=0116356352,Account_status="Good",Client_contactName= "Ray Donovan",Client_contactNo =  0816675319,Client_contactEmail = "rat@him.com"}

            };
            foreach (Client c in clients)
            {
                await context.AddAsync(c);
            }
            await context.SaveChangesAsync();

            //Suppliers
            if (context.Suppliers.Any())
            {
                return; //DB is already seeded
            }
            var suppliers = new Supplier[]
            {
                 new Supplier{Supplier_name="CashBuild",Supplier_reg_no="12568975",Supplier_bank_name="Capitec",Supplier_bank_accNumber="1520296004",Supplier_bank_accType="Business",Supplier_bank_branch="Westonaria",Supplier_address="Raimond 6,Felix,Johannesburg,4556",Supplier_vatNo=3263787489, Supplier_contactName="Jason",Supplier_contactNo=0725617834,Supplier_services = "plumbing"},
                 new Supplier{Supplier_name="Build it",Supplier_reg_no="33468975",Supplier_bank_name="ABSA",Supplier_bank_accNumber="5438563973",Supplier_bank_accType="Business",Supplier_bank_branch="Sandton",Supplier_address="Silver avenue,Sandton,Johannesburg,3543",Supplier_vatNo=64394633, Supplier_contactName="John",Supplier_contactNo=0824317834,Supplier_services = "bricks"},
                 new Supplier{Supplier_name="Lods Solutions",Supplier_reg_no="2168975",Supplier_bank_name="Standard Bank",Supplier_bank_accNumber="6484546004",Supplier_bank_accType="Business",Supplier_bank_branch="Braamfontein",Supplier_address="Dolar Bay,Braamfontein,Johannesburg,1111",Supplier_vatNo=65289252,Supplier_contactName="Linda",Supplier_contactNo=0824317834,Supplier_services = "cement"},
                 new Supplier{Supplier_name="ArchiTech",Supplier_reg_no="1434975",Supplier_bank_name="African Bank",Supplier_bank_accNumber="153736004",Supplier_bank_accType="Business",Supplier_bank_branch="Randfontein",Supplier_address="RD Lovender,randfontein,Johannesburg,1779",Supplier_vatNo=457243652,Supplier_contactName="Luci",Supplier_contactNo=0824317834,Supplier_services = "tiles"},
                 new Supplier{Supplier_name="Lorries Grale",Supplier_reg_no="23114975",Supplier_bank_name="Tymes",Supplier_bank_accNumber="92635204",Supplier_bank_accType="Business",Supplier_bank_branch="South gate",Supplier_address="Gold Reef 11,South gate,Johannesburg,2003",Supplier_vatNo=6587365332,Supplier_contactName="Harvey",Supplier_contactNo=0824317834,Supplier_services = "roofing"},
                 new Supplier{Supplier_name="Brick4Hire",Supplier_reg_no="52548615",Supplier_bank_name="Capitec",Supplier_bank_accNumber="123456789",Supplier_bank_accType="Business",Supplier_bank_branch="Rosebank",Supplier_address="33 Baker street,Rosebank,Johannesburg,4556",Supplier_vatNo=5424618754, Supplier_contactName="Firdows",Supplier_contactNo=0725617834,Supplier_services = "landscaping"},
                 new Supplier{Supplier_name="Bails",Supplier_reg_no="23168759",Supplier_bank_name="ABSA",Supplier_bank_accNumber="544554788",Supplier_bank_accType="Business",Supplier_bank_branch="Bloemleg",Supplier_address="Silver avenue,Bloemfontien,Free State,3543",Supplier_vatNo=5445875654, Supplier_contactName="Sibusiso",Supplier_contactNo=0824317834,Supplier_services = "plumbing"},
                 new Supplier{Supplier_name="Lundi Logistics",Supplier_reg_no="88975642",Supplier_bank_name="Standard Bank",Supplier_bank_accNumber="246574579",Supplier_bank_accType="Business",Supplier_bank_branch="Jeppes Town",Supplier_address="Kindle Bay,Jeppe,Johannesburg,1111",Supplier_vatNo=5721642457,Supplier_contactName="Chris",Supplier_contactNo=0824317834,Supplier_services = "cement"},
                 new Supplier{Supplier_name="Plumbed Ltc",Supplier_reg_no="21634251",Supplier_bank_name="African Bank",Supplier_bank_accNumber="754127677",Supplier_bank_accType="Business",Supplier_bank_branch="Wandreos",Supplier_address="11 Jan Smuts,Livelong,Johannesburg,1779",Supplier_vatNo=457261547,Supplier_contactName="Jabu",Supplier_contactNo=0824317834,Supplier_services = "tiles"},
                 new Supplier{Supplier_name="Waze cement",Supplier_reg_no="78549613",Supplier_bank_name="Tymes",Supplier_bank_accNumber="7454478576",Supplier_bank_accType="Business",Supplier_bank_branch="Naas",Supplier_address="Naas Block C,Mbombela,Nelspruit,2003",Supplier_vatNo=752164477,Supplier_contactName="Sipho",Supplier_contactNo=0824317834,Supplier_services = "roofing"},
                 new Supplier{Supplier_name="Patel",Supplier_reg_no="21643519",Supplier_bank_name="Capitec",Supplier_bank_accNumber="1520296004",Supplier_bank_accType="Business",Supplier_bank_branch="Westonaria",Supplier_address="Shefield 16,Westonaria,Johannesburg,4556",Supplier_vatNo=421546277, Supplier_contactName="Khunta",Supplier_contactNo=0725617834,Supplier_services = "plumbing"},
                 new Supplier{Supplier_name="Hotel Solution",Supplier_reg_no="33542671",Supplier_bank_name="ABSA",Supplier_bank_accNumber="142576777",Supplier_bank_accType="Business",Supplier_bank_branch="Sandton",Supplier_address="Silver avenue,Sandton,Johannesburg,3543",Supplier_vatNo=572612457, Supplier_contactName="Kendrick",Supplier_contactNo=0824317834,Supplier_services = "bricks"},
                 new Supplier{Supplier_name="Shavel",Supplier_reg_no="21682216",Supplier_bank_name="Standard Bank",Supplier_bank_accNumber="175246579",Supplier_bank_accType="Business",Supplier_bank_branch="Braamfontein",Supplier_address="Dolar Bay,Braamfontein,Johannesburg,1111",Supplier_vatNo=54216227,Supplier_contactName="Jeffery",Supplier_contactNo=0824317834,Supplier_services = "cement"},
                 new Supplier{Supplier_name="Grafelt",Supplier_reg_no="21654997",Supplier_bank_name="African Bank",Supplier_bank_accNumber="27564754121",Supplier_bank_accType="Business",Supplier_bank_branch="Randfopntein",Supplier_address="RD Lovender,randfontein,Johannesburg,1779",Supplier_vatNo=457243652,Supplier_contactName="Draimond",Supplier_contactNo=0824317834,Supplier_services = "tiles"},
                 new Supplier{Supplier_name="ZinkDat",Supplier_reg_no="78945612",Supplier_bank_name="Tymes",Supplier_bank_accNumber="454712541",Supplier_bank_accType="Business",Supplier_bank_branch="South gate",Supplier_address="Gold Reef 11,South gate,Johannesburg,2003",Supplier_vatNo=6587365332,Supplier_contactName="Billie",Supplier_contactNo=0824317834,Supplier_services = "roofing"}
            };
            foreach (Supplier s in suppliers)
            {
                await context.Suppliers.AddAsync(s);
            }
            await context.SaveChangesAsync();

            //Projects
            if (context.Projects.Any())
            {
                return; //DB is already seeded
            }
            var projects = new Project[]
            {
                 //Note: date format only works for "mm/dd/yyyy" when initilizing our data

            new Project{Project_Code="89AU2017",Project_location="Biccard 11,Braamfontein,Johannesburg 2000",Project_nature="Office Space",Project_description="12 floor building with 120 rooms",Project_startDate = DateTime.Parse("06-02-2017"),Project_dueDate = DateTime.Parse("06-11-2018"),Project_endDate = DateTime.Parse("12-03-2018"),Project_budget=9800000,Project_status="Over Budget",ClientID=1},
            new Project{Project_Code="70HOU2017",Project_location="Valbank 29,Tshane South,Pretoria 1779",Project_nature="Apartments",Project_description="Apartment project for 24 buildings",Project_startDate = DateTime.Parse("02-05-2017"),Project_dueDate = DateTime.Parse("05-10-2018"),Project_budget=900000,Project_status="On Budget",ClientID=2},
            new Project{Project_Code="87OPI2018",Project_location="Lethabo 6,westonaria, Johannnesburg 1782",Project_nature="Restuarant",Project_description="Restuarant with 6 rooms",Project_startDate = DateTime.Parse("02-02-2018"),Project_dueDate = DateTime.Parse("05-05-2019"),Project_budget=19500000,Project_status="Over Budget",ClientID=2},
            new Project{Project_Code="65APL2018",Project_location="2067 Tshepiso street,Rand South,Middleburg 2319",Project_nature="Compound",Project_description="5 room compound with 3 floors ",Project_startDate = DateTime.Parse("06-03-2018"),Project_dueDate = DateTime.Parse("03-10-2019"),Project_budget=800000,Project_status="On Budget",ClientID=3},
            new Project{Project_Code="21WES2018",Project_location="Larry Bay 77,Comton East,Cape Town 1000",Project_nature="Skyscraper",Project_description="60 floor skyscraper",Project_startDate = DateTime.Parse("01-05-2018"),Project_dueDate = DateTime.Parse("10-03-2019"),Project_endDate = DateTime.Parse("12-05-2018"),Project_budget=400000,Project_status="Over Budget",ClientID=4},
            new Project{Project_Code="89SUN2018",Project_location="Block C,Nass,Mbombela,Nelspruit 1600",Project_nature="Mall",Project_description="3 floor mall with food court and cinema",Project_startDate = DateTime.Parse("08-09-2018"),Project_dueDate = DateTime.Parse("02-01-2019"),Project_budget=7100000,Project_status="Under Budget",ClientID=5},
            new Project{Project_Code="25HOU2018",Project_location="11 Jan Smuts Avenue, Braamfontein, Johannesburg 2000",Project_nature="Apartments",Project_description="9 story building with with 1500 to 2000 m park",Project_startDate = DateTime.Parse("02-10-2018"),Project_dueDate = DateTime.Parse("02-01-2019"),Project_budget=80000,Project_status="Under Budget",ClientID=6},
            new Project{Project_Code="87OPE2018",Project_location="12 Zidom Bay, Limbridge kom,Johannnesburg 2019 ",Project_nature="Mansion",Project_description="12 room mansion with 3 gym spaces and a swimming pool",Project_startDate = DateTime.Parse("05-11-2018"),Project_dueDate = DateTime.Parse("03-02-2019"),Project_budget=560000,Project_status="On Budget",ClientID=7},
            new Project{Project_Code="65OBS2018",Project_location="Bloodline 45, Greenhills, Johannneburg 1673",Project_nature="School",Project_description="2000 to 3000 m school with 20 rooms",Project_startDate = DateTime.Parse("06-11-2018"),Project_dueDate = DateTime.Parse("08-03-2019"),Project_budget=124000,Project_status="On Budget",ClientID=8},
            new Project{Project_Code="24LES2018",Project_location="T Juncture Estate, Rosebank, johannesburg 1559",Project_nature="Hotel",Project_description="8 floor hotel with indoor pool and a casino",Project_startDate = DateTime.Parse("07-11-2018"),Project_dueDate = DateTime.Parse("02-04-2019"),Project_budget=1250000,Project_status="Over Budget",ClientID=9},
            new Project{Project_Code="90AUC2018",Project_location="16 West Norway, Bloemfontein,Free State 4325",Project_nature="Office Space",Project_description="4 floor building",Project_startDate = DateTime.Parse("08-11-2018"),Project_dueDate = DateTime.Parse("06-04-2019"),Project_budget=13000000,Project_status="On Budget",ClientID=10},
            new Project{Project_Code="72HOU2018",Project_location="12 Julieville,Randfonteing,Johannneburg 1779",Project_nature="Church",Project_description="15 room bulding for church",Project_startDate = DateTime.Parse("09-11-2018"),Project_dueDate = DateTime.Parse("09-05-2019"),Project_budget=250000,Project_status="On Budget",ClientID=11},
            new Project{Project_Code="87POL2018",Project_location="Cookie fields bay, Westonaria, Johannneburg 1779",Project_nature="Airport",Project_description="1500 to 2000 metre^2 wide space for airport",Project_startDate = DateTime.Parse("10-11-2018"),Project_dueDate = DateTime.Parse("10-05-2019"),Project_budget=160000,Project_status="Under Budget",ClientID=12},
            new Project{Project_Code="65APL2019",Project_location="Green Beach Fields, Ramdfontein, Johannesburg 1778",Project_nature="Tennis Court",Project_description="3000 to 4000 metre wide area tennis court",Project_startDate = DateTime.Parse("08-01-2019"),Project_dueDate = DateTime.Parse("02-01-2020"),Project_budget=360000,Project_status="Under Budget",ClientID=13},
            new Project{Project_Code="88NWC2019",Project_location="King Bardi Bay, Simunye EXTR 2, Johannesburg 573",Project_nature="Office Space",Project_description="60m tall building with 50 rooms",Project_startDate = DateTime.Parse("01-03-2019"),Project_dueDate = DateTime.Parse("02-04-2020"),Project_budget=420000,Project_status="Under Budget",ClientID=14},
            };
            foreach (Project p in projects)
            {
                await context.Projects.AddAsync(p);
            }
            await context.SaveChangesAsync();

            //SuppliedBy
            if (context.SuppliedBys.Any())
            {
                return; //DB is already seeded
            }

            var suppliedBy = new SuppliedBy[]
            {
                    new SuppliedBy{SupplierID=1,Project_Code="89AU2017"},
                    new SuppliedBy{SupplierID=1,Project_Code="65APL2019"},
                    new SuppliedBy{SupplierID=2,Project_Code="70HOU2017"},
                    new SuppliedBy{SupplierID=3,Project_Code="87OPI2018"},
                    new SuppliedBy{SupplierID=3,Project_Code="65APL2019"},
                    new SuppliedBy{SupplierID=4,Project_Code="65APL2018"},
                    new SuppliedBy{SupplierID=5,Project_Code="21WES2018"},
                    new SuppliedBy{SupplierID=2,Project_Code="89SUN2018"},
                    new SuppliedBy{SupplierID=5,Project_Code="70HOU2017"},
                    new SuppliedBy{SupplierID=1,Project_Code="88NWC2019"},
                    new SuppliedBy{SupplierID=5,Project_Code="90AUC2018"},
                    new SuppliedBy{SupplierID=7,Project_Code="21WES2018"},
                    new SuppliedBy{SupplierID=7,Project_Code="25HOU2018"},
                    new SuppliedBy{SupplierID=8,Project_Code="72HOU2018"},
                    new SuppliedBy{SupplierID=9,Project_Code="24LES2018"},
                    new SuppliedBy{SupplierID=10,Project_Code="21WES2018"},
                    new SuppliedBy{SupplierID=11,Project_Code="89SUN2018"},
                    new SuppliedBy{SupplierID=11,Project_Code="65APL2019"},
                    new SuppliedBy{SupplierID=12,Project_Code="21WES2018"},
                    new SuppliedBy{SupplierID=12,Project_Code="88NWC2019"},
                    new SuppliedBy{SupplierID=13,Project_Code="90AUC2018"},
                    new SuppliedBy{SupplierID=13,Project_Code="65OBS2018"},
                    new SuppliedBy{SupplierID=14,Project_Code="21WES2018"},
                    new SuppliedBy{SupplierID=14,Project_Code="87OPE2018"},
                    new SuppliedBy{SupplierID=6,Project_Code="87POL2018"},
                    new SuppliedBy{SupplierID=5,Project_Code="87POL2018"},
                    new SuppliedBy{SupplierID=4,Project_Code="72HOU2018"},
                    new SuppliedBy{SupplierID=4,Project_Code="87OPE2018"},
                    new SuppliedBy{SupplierID=12,Project_Code="21WES2018"},
                    new SuppliedBy{SupplierID=8,Project_Code="65OBS2018"},
                    new SuppliedBy{SupplierID=9,Project_Code="88NWC2019"},

           };
            foreach (SuppliedBy s in suppliedBy)
            {
                await context.SuppliedBys.AddAsync(s);
            }
            await context.SaveChangesAsync();

            //Assigneds
            if (context.Assigneds.Any())
            {
                return; //DB is already seeded
            }
            var assigned = new Assigned[]
                {
                    new Assigned{StaffID=1, Project_Code="89AU2017"},
                    new Assigned{StaffID=1, Project_Code="65OBS2018"},
                    new Assigned{StaffID=1, Project_Code="87OPE2018"},
                    new Assigned{StaffID=1, Project_Code="90AUC2018"},
                    new Assigned{StaffID=3, Project_Code="87OPI2018"},
                    new Assigned{StaffID=3, Project_Code="70HOU2017"},
                    new Assigned{StaffID=3, Project_Code="87OPE2018"},
                    new Assigned{StaffID=3, Project_Code="24LES2018"},
                    new Assigned{StaffID=2, Project_Code="70HOU2017"},
                    new Assigned{StaffID=2, Project_Code="89SUN2018"},
                    new Assigned{StaffID=2, Project_Code="65APL2019"},
                    new Assigned{StaffID=2, Project_Code="24LES2018"},
                    new Assigned{StaffID=4, Project_Code="65OBS2018"},
                    new Assigned{StaffID=4, Project_Code="70HOU2017"},
                    new Assigned{StaffID=4, Project_Code="90AUC2018"},
                    new Assigned{StaffID=4, Project_Code="88NWC2019"},
                    new Assigned{StaffID=4, Project_Code="87OPE2018"},
                    new Assigned{StaffID=4, Project_Code="72HOU2018"},
                    new Assigned{StaffID=5, Project_Code="21WES2018"},
                    new Assigned{StaffID=5, Project_Code="88NWC2019"},
                    new Assigned{StaffID=5, Project_Code="89SUN2018"},
                    new Assigned{StaffID=5, Project_Code="90AUC2018"},
                    new Assigned{StaffID=6, Project_Code="21WES2018"},
                    new Assigned{StaffID=6, Project_Code="65APL2019"},
                    new Assigned{StaffID=6, Project_Code="25HOU2018"},
                    new Assigned{StaffID=6, Project_Code="65OBS2018"},
                    new Assigned{StaffID=7, Project_Code="65OBS2018"},
                    new Assigned{StaffID=7, Project_Code="72HOU2018"},
                    new Assigned{StaffID=7, Project_Code="90AUC2018"},
                    new Assigned{StaffID=7, Project_Code="65OBS2018"},
                    new Assigned{StaffID=7, Project_Code="65OBS2018"},
                };
            foreach (Assigned a in assigned)
            {
                await context.AddAsync(a);
            }
            await context.SaveChangesAsync();

            //Claims
            if (context.Claims.Any())
            {
                return; //DB is already seeded
            }
            var claims = new Claim[]
            {
                //Note: date format only works for "mm/dd/yyyy" when initilizing our data
                new Claim{UserId = 2,StaffID = 3, Claim_amount = 200,Claim_date = DateTime.Parse("03-24-2018"),Claim_description = "In a meeting with Floyd and we got refreshments",Claim_status = "Approved",},
                new Claim{UserId = 3,StaffID = 4, Claim_amount = 300,Claim_date = DateTime.Parse("04-10-2018"),Claim_description = "Had to pick up supply from CashbUild",Claim_status = "Approved",},
                new Claim{UserId = 2,StaffID = 1, Claim_amount = 400,Claim_date = DateTime.Parse("05-17-2018"),Claim_description = "Travelled with client to see site",Claim_status = "Approved",},
                new Claim{UserId = 2,StaffID = 1, Claim_amount = 700,Claim_date = DateTime.Parse("06-27-2018"),Claim_description = "Picked up client from they home and had a meeeting",Claim_status = "Approved",},
                new Claim{UserId = 3,StaffID = 4, Claim_amount = 150,Claim_date = DateTime.Parse("08-03-2018"),Claim_description = "Refreshments for meeting",Claim_status = "Approved",},
                new Claim{StaffID = 4, Claim_amount = 150,Claim_date = DateTime.Parse("08-03-2018"),Claim_description = "Refreshments for meeting",Claim_status = "Pending"},
                new Claim{UserId = 1,StaffID = 2, Claim_amount = 400,Claim_date = DateTime.Parse("08-29-2018"),Claim_description = "Admin asked me to go get office supply",Claim_status = "Approved",},
            };
            foreach (Claim c in claims)
            {
                await context.AddAsync(c);
            }
            await context.SaveChangesAsync();

            //Logs
            if (context.Logs.Any())
            {
                return; //DB is already seeded
            }
            var log = new Log[]
           {
                    //Note: date format only works for "mm/dd/yyyy" when initilizing our data
                //Logs for 89AU2017
                new Log{StaffID = 1,TaskDescriptionID = 1,Log_hours = 0.25, Project_Code = "89AU2017",Log_date = DateTime.Parse("10-08-2017")},
                new Log{StaffID = 1,TaskDescriptionID = 22,Log_hours = 8, Project_Code = "89AU2017" ,Log_date = DateTime.Parse("10-08-2017")},
                new Log{StaffID = 1,TaskDescriptionID = 17,Log_hours = 2, Project_Code = "89AU2017" ,Log_date = DateTime.Parse("10-08-2017")},
                new Log{StaffID = 1,TaskDescriptionID = 22,Log_hours = 8, Project_Code = "89AU2017" ,Log_date = DateTime.Parse("10-15-2017")},
                new Log{StaffID = 1,TaskDescriptionID = 16,Log_hours = 1, Project_Code = "89AU2017" ,Log_date = DateTime.Parse("10-08-2017")},
                new Log{StaffID = 1,TaskDescriptionID = 23,Log_hours = 1, Project_Code = "89AU2017",Log_date = DateTime.Parse("10-08-2017") },
                new Log{StaffID = 1,TaskDescriptionID = 5,Log_hours = 1 , Project_Code = "89AU2017" ,Log_date = DateTime.Parse("10-15-2017")},
                new Log{StaffID = 1,TaskDescriptionID = 22,Log_hours = 8, Project_Code = "89AU2017" ,Log_date = DateTime.Parse("12-10-2017")},
                new Log{StaffID = 1,TaskDescriptionID = 24,Log_hours = 0.25, Project_Code = "89AU2017",Log_date = DateTime.Parse("10-08-2017")},
                new Log{StaffID = 1,TaskDescriptionID = 7,Log_hours = 1 , Project_Code ="89AU2017", Log_date = DateTime.Parse("11-11-2017")},
                new Log{StaffID = 6,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="89AU2017", Log_date = DateTime.Parse("01-14-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 6,Log_hours = 3 , Project_Code ="89AU2017", Log_date = DateTime.Parse("01-14-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 18,Log_hours = 2 , Project_Code ="89AU2017", Log_date = DateTime.Parse("01-14-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="89AU2017", Log_date = DateTime.Parse("03-27-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 23,Log_hours = 1 , Project_Code ="89AU2017", Log_date = DateTime.Parse("03-27-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 13,Log_hours = 1 , Project_Code ="89AU2017", Log_date = DateTime.Parse("01-14-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="89AU2017", Log_date = DateTime.Parse("01-14-2018")},


                //Logs for 70HOU2017
                new Log{StaffID = 2,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("03-10-2017")},
                new Log{StaffID = 2,TaskDescriptionID = 4,Log_hours = 4 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("03-10-2017")},
                new Log{StaffID = 2,TaskDescriptionID = 22,Log_hours = 8 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("03-15-2017")},
                new Log{StaffID = 2,TaskDescriptionID = 4,Log_hours = 4 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("03-10-2017")},
                new Log{StaffID = 2,TaskDescriptionID = 13,Log_hours = 1 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("03-10-2017")},
                new Log{StaffID = 4,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("06-11-2017")},
                new Log{StaffID = 4,TaskDescriptionID = 7,Log_hours = 1 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("06-11-2017")},
                new Log{StaffID = 4,TaskDescriptionID = 22,Log_hours = 8 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("07-11-2017")},
                new Log{StaffID = 4,TaskDescriptionID = 15,Log_hours = 4 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("06-11-2017")},
                new Log{StaffID = 4,TaskDescriptionID = 5,Log_hours = 4 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("06-11-2017")},
                new Log{StaffID = 4,TaskDescriptionID = 24,Log_hours = 0.25, Project_Code = "70HOU2017",Log_date = DateTime.Parse("11-01-2017")},
                new Log{StaffID = 2,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("11-01-2017")},
                new Log{StaffID = 2,TaskDescriptionID = 4,Log_hours = 2 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("11-01-2017")},
                new Log{StaffID = 2,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("11-03-2017")},
                new Log{StaffID = 2,TaskDescriptionID = 6,Log_hours = 4 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("11-01-2017")},
                new Log{StaffID = 2,TaskDescriptionID = 24,Log_hours = 0.25, Project_Code = "70HOU2017",Log_date = DateTime.Parse("11-01-2017")},
                new Log{StaffID = 3,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("03-04-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 5,Log_hours = 1 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("03-04-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 17,Log_hours = 4 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("03-04-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 22,Log_hours = 8 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("03-13-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 6,Log_hours = 4 , Project_Code ="70HOU2017", Log_date = DateTime.Parse("03-04-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 24,Log_hours = 0.25, Project_Code = "70HOU2017",Log_date = DateTime.Parse("03-04-2018")},

                //Logs for 87OPI2018
                new Log{StaffID = 3,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("08-10-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 4,Log_hours = 4 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("08-10-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 22,Log_hours = 8 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("08-14-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 4,Log_hours = 4 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("08-10-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 7,Log_hours = 4 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("08-10-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("08-10-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("10-18-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 4,Log_hours = 4 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("10-18-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 22,Log_hours = 8 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("10-22-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 3,Log_hours = 2 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("10-18-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 7,Log_hours = 1 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("10-18-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="87OPI2018", Log_date = DateTime.Parse("10-18-2018")},

                //Logs for 89SUN2018
                new Log{StaffID = 2,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-10-2018")},
                new Log{StaffID = 2,TaskDescriptionID = 17,Log_hours = 3 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-10-2018")},
                new Log{StaffID = 2,TaskDescriptionID = 4,Log_hours = 4 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-10-2018")},
                new Log{StaffID = 2,TaskDescriptionID = 22,Log_hours = 8 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-15-2018")},
                new Log{StaffID = 2,TaskDescriptionID = 4,Log_hours = 4 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-10-2018")},
                new Log{StaffID = 2,TaskDescriptionID = 13,Log_hours = 4 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-10-2018")},
                new Log{StaffID = 2,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-10-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-21-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-21-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 4,Log_hours = 4 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-21-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 22,Log_hours = 8 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("11-15-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 4,Log_hours = 4 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-21-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 13,Log_hours = 2 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-21-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("10-21-2018")},
                new Log{StaffID = 2,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("01-10-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 17,Log_hours = 3 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("01-10-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 18,Log_hours = 4 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("01-11-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("01-18-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 20,Log_hours = 4 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("01-10-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 13,Log_hours = 1 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("01-10-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="89SUN2018", Log_date = DateTime.Parse("01-10-2019")},

                //Logs for 65APL2018(no one is assigned)


                //Logs for 24LES2018
                new Log{StaffID = 4,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="24LES2018", Log_date = DateTime.Parse("07-19-2018")},
                new Log{StaffID = 4,TaskDescriptionID = 17,Log_hours = 1 , Project_Code ="24LES2018", Log_date = DateTime.Parse("07-19-2018")},
                new Log{StaffID = 4,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="24LES2018", Log_date = DateTime.Parse("07-19-2018")},
                new Log{StaffID = 4,TaskDescriptionID = 22,Log_hours = 7 , Project_Code ="24LES2018", Log_date = DateTime.Parse("08-23-2018")},
                new Log{StaffID = 4,TaskDescriptionID = 5,Log_hours = 2 , Project_Code ="24LES2018", Log_date = DateTime.Parse("07-19-2018")},
                new Log{StaffID = 4,TaskDescriptionID = 13,Log_hours = 1 , Project_Code ="24LES2018", Log_date = DateTime.Parse("07-19-2018")},
                new Log{StaffID = 4,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="24LES2018", Log_date = DateTime.Parse("07-19-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="24LES2018", Log_date = DateTime.Parse("09-12-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 17,Log_hours = 1 , Project_Code ="24LES2018", Log_date = DateTime.Parse("09-12-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="24LES2018", Log_date = DateTime.Parse("09-12-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 22,Log_hours = 5 , Project_Code ="24LES2018", Log_date = DateTime.Parse("09-28-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 5,Log_hours = 2 , Project_Code ="24LES2018", Log_date = DateTime.Parse("09-12-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="24LES2018", Log_date = DateTime.Parse("09-28-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="24LES2018", Log_date = DateTime.Parse("09-12-2018")},
                new Log{StaffID = 3,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="24LES2018", Log_date = DateTime.Parse("10-09-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="24LES2018", Log_date = DateTime.Parse("11-12-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 17,Log_hours = 1 , Project_Code ="24LES2018", Log_date = DateTime.Parse("11-12-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="24LES2018", Log_date = DateTime.Parse("11-12-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 22,Log_hours = 5 , Project_Code ="24LES2018", Log_date = DateTime.Parse("12-08-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 5,Log_hours = 2 , Project_Code ="24LES2018", Log_date = DateTime.Parse("11-12-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="24LES2018", Log_date = DateTime.Parse("11-12-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="24LES2018", Log_date = DateTime.Parse("11-12-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="24LES2018", Log_date = DateTime.Parse("01-09-2019")},

                //Logs for 21WES2018
                new Log{StaffID = 6,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="21WES2018", Log_date = DateTime.Parse("03-14-2017")},
                new Log{StaffID = 6,TaskDescriptionID = 17,Log_hours = 1 , Project_Code ="21WES2018", Log_date = DateTime.Parse("03-14-2017")},
                new Log{StaffID = 6,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="21WES2018", Log_date = DateTime.Parse("03-14-2017")},
                new Log{StaffID = 6,TaskDescriptionID = 22,Log_hours = 5 , Project_Code ="21WES2018", Log_date = DateTime.Parse("04-28-2017")},
                new Log{StaffID = 6,TaskDescriptionID = 5,Log_hours = 2 , Project_Code ="21WES2018", Log_date = DateTime.Parse("03-14-2017")},
                new Log{StaffID = 6,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="21WES2018", Log_date = DateTime.Parse("04-28-2017")},
                new Log{StaffID = 6,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="21WES2018", Log_date = DateTime.Parse("03-14-2017")},
                new Log{StaffID = 6,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="21WES2018", Log_date = DateTime.Parse("10-09-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="21WES2018", Log_date = DateTime.Parse("06-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 17,Log_hours = 1 , Project_Code ="21WES2018", Log_date = DateTime.Parse("06-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="21WES2018", Log_date = DateTime.Parse("06-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 23,Log_hours = 1 , Project_Code ="21WES2018", Log_date = DateTime.Parse("11-29-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 22,Log_hours = 5 , Project_Code ="21WES2018", Log_date = DateTime.Parse("11-29-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 5,Log_hours = 2 , Project_Code ="21WES2018", Log_date = DateTime.Parse("06-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="21WES2018", Log_date = DateTime.Parse("06-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="21WES2018", Log_date = DateTime.Parse("06-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="21WES2018", Log_date = DateTime.Parse("01-09-2019")},

                //Logs for 65OBS2018

                new Log{StaffID = 6,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("03-14-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 17,Log_hours = 1 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("03-14-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("03-14-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 22,Log_hours = 5 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("04-28-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 5,Log_hours = 2 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("03-14-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("04-28-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("03-14-2018")},
                new Log{StaffID = 6,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("10-09-2018")},
                new Log{StaffID = 7,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("06-23-2019")},
                new Log{StaffID = 7,TaskDescriptionID = 17,Log_hours = 1 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("06-23-2019")},
                new Log{StaffID = 7,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("06-23-2019")},
                new Log{StaffID = 7,TaskDescriptionID = 23,Log_hours = 1 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("03-29-2019")},
                new Log{StaffID = 7,TaskDescriptionID = 22,Log_hours = 5 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("03-29-2019")},
                new Log{StaffID = 7,TaskDescriptionID = 5,Log_hours = 2 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("06-23-2019")},
                new Log{StaffID = 7,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("06-23-2019")},
                new Log{StaffID = 7,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("06-23-2019")},
                new Log{StaffID = 7,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="65OBS2018", Log_date = DateTime.Parse("01-09-2019")},

                //Logs for 88NWC2019
                new Log{StaffID = 4,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("06-19-2018")},
                new Log{StaffID = 4,TaskDescriptionID = 17,Log_hours = 1 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("03-19-2018")},
                new Log{StaffID = 4,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("06-19-2018")},
                new Log{StaffID = 4,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("03-23-2018")},
                new Log{StaffID = 4,TaskDescriptionID = 5,Log_hours = 2 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("06-19-2018")},
                new Log{StaffID = 4,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("06-19-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("07-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 17,Log_hours = 1 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("07-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("07-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 23,Log_hours = 1 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("09-29-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 22,Log_hours = 5 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("09-29-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 5,Log_hours = 2 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("07-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("07-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("07-23-2018")},
                new Log{StaffID = 5,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="88NWC2019", Log_date = DateTime.Parse("01-09-2019")},


                //Logs for 65APL2019
                new Log{StaffID = 6,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="65APL2019", Log_date = DateTime.Parse("10-11-2019")},
                new Log{StaffID = 6,TaskDescriptionID = 8,Log_hours = 1 , Project_Code ="65APL2019", Log_date = DateTime.Parse("10-21-2019")},
                new Log{StaffID = 6,TaskDescriptionID = 4,Log_hours = 4 , Project_Code ="65APL2019", Log_date = DateTime.Parse("10-21-2019")},
                new Log{StaffID = 6,TaskDescriptionID = 22,Log_hours = 8 , Project_Code ="65APL2019", Log_date = DateTime.Parse("08-15-2019")},
                new Log{StaffID = 6,TaskDescriptionID = 4,Log_hours = 4 , Project_Code ="65APL2019", Log_date = DateTime.Parse("10-11-2019")},
                new Log{StaffID = 6,TaskDescriptionID = 13,Log_hours = 2 , Project_Code ="65APL2019", Log_date = DateTime.Parse("10-11-2019")},
                new Log{StaffID = 6,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="65APL2019", Log_date = DateTime.Parse("10-21-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 1,Log_hours = 0.25 , Project_Code ="65APL2019", Log_date = DateTime.Parse("01-10-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 17,Log_hours = 3 , Project_Code ="65APL2019", Log_date = DateTime.Parse("01-10-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 18,Log_hours = 4 , Project_Code ="65APL2019", Log_date = DateTime.Parse("01-11-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 22,Log_hours = 6 , Project_Code ="65APL2019", Log_date = DateTime.Parse("01-18-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 20,Log_hours = 4 , Project_Code ="65APL2019", Log_date = DateTime.Parse("01-10-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 13,Log_hours = 1 , Project_Code ="65APL2019", Log_date = DateTime.Parse("01-10-2019")},
                new Log{StaffID = 2,TaskDescriptionID = 24,Log_hours = 0.25 , Project_Code ="65APL2019", Log_date = DateTime.Parse("01-10-2019")},


           };
            foreach (Log l in log)
            {
                await context.AddAsync(l);
            }
            await context.SaveChangesAsync();

            //Leaves
            if (context.Leaves.Any())
            {
                return; //DB is already seeded
            }
            var leaves = new Leave[]
                {
                    //Note: date format only works for "mm/dd/yyyy" when initilizing our data
                    new Leave{StaffID=1, Leave_type = LeaveType.Annual, Leave_startDate =  DateTime.Parse("10-03-2018") , Leave_endDate =  DateTime.Parse("10-26-2018") , Leave_status = "Approved" ,Leave_motivation = "" ,UserId = 1 },
                    new Leave{StaffID=2, Leave_type = LeaveType.Medical, Leave_startDate =  DateTime.Parse("06-16-2019") , Leave_endDate =  DateTime.Parse("06-30-2019"), Leave_status = "Pending",Leave_motivation= "I got sick during the week and the doctor recommends that I stay at home."  },
                    new Leave{StaffID=2, Leave_type = LeaveType.Maternity ,Leave_startDate =  DateTime.Parse("08-02-2018")  , Leave_endDate =  DateTime.Parse("08-23-2018"),Leave_status = "Approved"  ,Leave_motivation="", UserId =1 },
                    new Leave{StaffID=1, Leave_type = LeaveType.Study , Leave_startDate = DateTime.Parse("06-04-2017"), Leave_endDate = DateTime.Parse("07-04-2017"),Leave_status = "Approved" , Leave_motivation = "" ,UserId = 2}
                };
            foreach (Leave l in leaves)
            {
                await context.AddAsync(l);
            }
            await context.SaveChangesAsync();


            if (context.Phases.Any())
            {
                return; //Db is already seeded
            }
            var phase = new Phase[]
            {
            new Phase {PhaseNameID=1, Project_Code="89AU2017", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="70HOU2017", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="87OPI2018", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="65APL2018", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="21WES2018", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="89SUN2018", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="25HOU2018", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="87OPE2018", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="65OBS2018", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="24LES2018", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="90AUC2018", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="72HOU2018", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="87POL2018", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="65APL2019", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},
            new Phase {PhaseNameID=1, Project_Code="88NWC2019", Phase_startDate = DateTime.Parse("06-02-2017"), Phase_endDate = DateTime.Parse("06-11-2018"), Phase_budget = 980000},

            new Phase {PhaseNameID=2,Project_Code="89AU2017", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="70HOU2017", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="87OPI2018", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="65APL2018", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="21WES2018", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="89SUN2018", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="25HOU2018", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="87OPE2018", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="65OBS2018", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="24LES2018", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="90AUC2018", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="72HOU2018", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="87POL2018", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="65APL2019", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},
            new Phase {PhaseNameID=2,Project_Code="88NWC2019", Phase_startDate = DateTime.Parse("02-05-2017"), Phase_endDate = DateTime.Parse("05-10-2018"), Phase_budget = 90000},

            new Phase {PhaseNameID=3,Project_Code="89AU2017", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="70HOU2017", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="87OPI2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="65APL2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="21WES2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="89SUN2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="25HOU2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="87OPE2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="65OBS2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="24LES2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="90AUC2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="72HOU2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="87POL2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="65APL2019", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
            new Phase {PhaseNameID=3,Project_Code="88NWC2019", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},

            new Phase {PhaseNameID=4, Project_Code="89AU2017", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="70HOU2017", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="87OPI2018", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="65APL2018", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="21WES2018", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="89SUN2018", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="25HOU2018", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4,Project_Code="87OPE2018", Phase_startDate = DateTime.Parse("02-02-2018"), Phase_endDate = DateTime.Parse("05-05-2019"), Phase_budget = 1950000},
             new Phase {PhaseNameID=4, Project_Code="65OBS2018", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="24LES2018", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="90AUC2018", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="72HOU2018", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="87POL2018", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="65APL2019", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},
             new Phase {PhaseNameID=4, Project_Code="88NWC2019", Phase_startDate = DateTime.Parse("06-03-2018"), Phase_endDate = DateTime.Parse("03-10-2019"), Phase_budget = 80000},

            new Phase {PhaseNameID=5, Project_Code="89AU2017", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="70HOU2017", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="87OPI2018", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="65APL2018", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="21WES2018", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="89SUN2018", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="25HOU2018", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="87OPE2018", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="65OBS2018", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="24LES2018", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="90AUC2018", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="72HOU2018", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="87POL2018", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="65APL2019", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},
            new Phase {PhaseNameID=5, Project_Code="88NWC2019", Phase_startDate = DateTime.Parse("01-05-2018"), Phase_endDate = DateTime.Parse("10-03-2019"), Phase_budget = 40000},

            new Phase {PhaseNameID=6, Project_Code="89AU2017", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
             new Phase {PhaseNameID=6, Project_Code="70HOU2017", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
             new Phase {PhaseNameID=6, Project_Code="87OPI2018", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
            new Phase {PhaseNameID=6, Project_Code="65APL2018", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
            new Phase {PhaseNameID=6, Project_Code="21WES2018", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
            new Phase {PhaseNameID=6, Project_Code="89SUN2018", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
            new Phase {PhaseNameID=6, Project_Code="25HOU2018", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
            new Phase {PhaseNameID=6, Project_Code="87OPE2018", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
            new Phase {PhaseNameID=6, Project_Code="65OBS2018", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
            new Phase {PhaseNameID=6, Project_Code="24LES2018", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
             new Phase {PhaseNameID=6, Project_Code="90AUC2018", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
             new Phase {PhaseNameID=6, Project_Code="72HOU2018", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
             new Phase {PhaseNameID=6, Project_Code="87POL2018", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
          new Phase {PhaseNameID=6, Project_Code="65APL2019", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000},
           new Phase {PhaseNameID=6, Project_Code="88NWC2019", Phase_startDate = DateTime.Parse("08-09-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 710000}
                                                                                                                  
            /*
            new Phase {PhaseNameID=4, Project_Code="87OPE2018", Phase_startDate = DateTime.Parse("02-10-2018"), Phase_endDate = DateTime.Parse("02-01-2019"), Phase_budget = 8000 },
            new Phase {PhaseNameID=3, Project_Code="24LES2018", Phase_startDate = DateTime.Parse("05-11-2018"), Phase_endDate = DateTime.Parse("03-02-2019"), Phase_budget = 56000 },
            new Phase {PhaseNameID=5, Project_Code="70HOU2017", Phase_startDate = DateTime.Parse("06-11-2018"), Phase_endDate = DateTime.Parse("08-03-2019"), Phase_budget = 12400 },
            new Phase {PhaseNameID=2,Project_Code="89SUN2018", Phase_startDate = DateTime.Parse("07-11-2018"), Phase_endDate = DateTime.Parse("02-04-2019"), Phase_budget = 120000},
            new Phase {PhaseNameID=4,Project_Code="65APL2019", Phase_startDate = DateTime.Parse("08-11-2018"), Phase_endDate = DateTime.Parse("06-04-2019"), Phase_budget = 1300000 },
            new Phase {PhaseNameID=1,Project_Code="87OPE2018", Phase_startDate = DateTime.Parse("09-11-2018"), Phase_endDate = DateTime.Parse("09-05-2019"), Phase_budget = 25000 },
            new Phase {PhaseNameID=3,Project_Code="24LES2018", Phase_startDate = DateTime.Parse("10-11-2018"), Phase_endDate = DateTime.Parse("10-05-2019"), Phase_budget = 16000 },
            new Phase {PhaseNameID=2, Project_Code="65OBS2018", Phase_startDate = DateTime.Parse("08-01-2019"), Phase_endDate = DateTime.Parse("02-01-2020"), Phase_budget = 36000 },
            new Phase {PhaseNameID=5,Project_Code="70HOU2017", Phase_startDate = DateTime.Parse("01-03-2019"), Phase_endDate = DateTime.Parse("02-04-2020"), Phase_budget = 42000 }
            */
             };
            foreach (Phase ph in phase)
            {
                await context.Phases.AddAsync(ph);
            }
            await context.SaveChangesAsync();

        }
    }
}
