using InteleqtCapture.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteleqtCapture.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CustomerContext>();
                context.Database.EnsureCreated();

                if (context.annuities != null && context.annuities.Any())
                    return;   // db has already been seeded

                var annuities = GetAnnuities().ToArray();
                context.annuities.AddRange(annuities);
                context.SaveChanges();

                var maintenances = GetMaintenances().ToArray();
                context.maintenances.AddRange(maintenances);
                context.SaveChanges();


                var products = GetValuesFromCSV().ToArray();
                context.products.RemoveRange(context.products);
                context.SaveChanges();
                context.products.AddRange(products);
                context.SaveChanges();
            }
        }

        public static List<Annuity> GetAnnuities()
        {
            List<Annuity> annuities = new List<Annuity>() {
              new Annuity {EntityId="80000129-1512119372", EntityFullName="Jag", AnnuityAmount=23425, StartDate=new DateTime(2018, 4, 20), RenewalDate= new DateTime(2019,3,26), AnniversaryDate=new DateTime(2019, 4, 20)},
              new Annuity {EntityId="8000014F-1538139847", EntityFullName="UD Trucks", AnnuityAmount=51544, StartDate=new DateTime(2019, 9, 30), RenewalDate= new DateTime(2019,8,30), AnniversaryDate=new DateTime(2019, 9, 30)},
              new Annuity {EntityId="8000013D-1526547562", EntityFullName="Cargo Motors", AnnuityAmount=27200, StartDate=new DateTime(2019, 9, 30), RenewalDate= new DateTime(2020,1,28), AnniversaryDate=new DateTime(2020, 2, 28)}
            };
            return annuities;
        }

        public static List<Maintenance> GetMaintenances()
        {
            List<Maintenance> maintenances = new List<Maintenance>() {
              new Maintenance {EntityId="800000D4-1466598197", EntityFullName="DGB", StartDate=new DateTime(2018, 5, 5), RenewalDate= new DateTime(2019,5,5), Quantity=3, Item="Qlik Sense Professional User 101 - 250", Product="Qlik Sense", ProductCategory="Qlik Sense Enterprise Prof/Analyser Prod Sites (PERPETUAL)", UnitPrice=19536, Value=0, YearlyMaintenance=0},
              new Maintenance {EntityId="800000D1-1464172818", EntityFullName="McDonalds", StartDate=new DateTime(2018, 6, 28), RenewalDate= new DateTime(2019,6,28), Quantity=4, Item="Qlik Sense Professional User 51 - 100", Product="Qlik Sense", ProductCategory="Qlik Sense Enterprise Prof/Analyser Prod Sites (PERPETUAL)", UnitPrice=20592, Value=0, YearlyMaintenance=0},
            };
            return maintenances;
        }
        
        public static List<Product> GetValuesFromCSV()
        {
            var reader = new helper.helper();
            return reader.ReadProducts();
        }
    }
}
