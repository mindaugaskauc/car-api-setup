/**
* Author: Mindaugas Kaucikas
* Date: 2024
* Program description: DbInitializer.cs 
*
* Class:   public static class DbInitializer
* Descriptions: The DbInitializer class defined as static. The DbInitializer class is ready to seed the database, 
*               but it needs to be called from Program.cs. 
*
* Method:       public static void Initialize(CarContext context
* Description:  The method is defined as static
*               Initialize accepts a CarContext object as a parameter.
*
* Conditional:  if (context.Cars.Any()
*               && context.Engines.Any()
*               && context.Gearboxes.Any()
*               && context.SeatMaterials.Any())
*
* Description:  If the cars, engines, gearboxes and SeatMaterials tables are empty, then 
*               the cars, engines and gearboxes and SeatMaterials class objects get created
*               with the data.
*
* Engine       ar inlineEngine = new Engine { Name = "Inline" };
* object:
*
* Description:  The engine object gets created
*
* Gearbox object: var mechanicalGearbox = new Gearbox { Name = "Mechanical"};
*
* Description:  The gearbox object gets created.
*
* Array of Car  Array of car objects get created.
* objects: 
*
* AddRange      context.Cars.AddRange(cars);  
* method: 
*
* Description:  The Car objects which contain, Name, Price, Engine, Gearbox and SetMaterial properties 
*               which are assigned string, decimal and object values are added to the object graph by using AddRange.
*
* SaveChanges   context.SaveChanges();
* method:
*
* Description:  The object graph changes are committed to the database by using SaveChanges.
*
*/

using CarApi.Models;

namespace CarApi.Data
{  
    public static class DbInitializer
    {
       public static void Initialize(CarContext context)
       {
           if (context.Cars.Any()
               && context.Engines.Any()
               && context.Gearboxes.Any()
               && context.SeatMaterials.Any())
           {
               return; // DB has been seeded
           }

           var inlineEngine = new Engine { Name = "Inline" };
           var vEngine = new Engine { Name = "V" };
           var flatEngine = new Engine { Name = "Flat" };
           var turboEngine = new Engine { Name = "Turbo" };

           var mechanicalGearbox = new Gearbox { Name = "Mechanical"};
           var automaticGearbox = new Gearbox { Name = "Automatic"};

           var leatherSeatMaterial = new SeatMaterial { Name = "Leather"};
           var vinylSeatMaterial = new SeatMaterial { Name = "Vinyl"};
           var nylonSeatMaterial = new SeatMaterial { Name = "Nylon"};
           var sheepskinSeatMaterial = new SeatMaterial { Name = "Sheepskin"};

           var cars = new Car[]
           {
               new Car
                   {
                       Name = "Opel Mokka",
                       Price = 18490,
                       Engine = turboEngine,
                       Gearbox = automaticGearbox,
                       SeatMaterial = leatherSeatMaterial
                   },
              new Car
                  {
                       Name = "Audi SQ8 e-tron",
                       Price = 13896,
                       Engine = vEngine,
                       Gearbox = mechanicalGearbox,
                       SeatMaterial = sheepskinSeatMaterial
                  },
              new Car
                  {
                       Name = "Volkswagen Atlas",
                       Price = 47500,
                       Engine = flatEngine,
                       Gearbox = automaticGearbox,
                       SeatMaterial = nylonSeatMaterial
                  },
              new Car
                  {
                       Name = "Peogeot 5008",
                       Price = 7500,
                       Engine = inlineEngine,
                       Gearbox = mechanicalGearbox,
                       SeatMaterial = leatherSeatMaterial
                  },
              new Car
                  {
                       Name = "Mazda CX-90",
                       Price = 7500,
                       Engine = vEngine,
                       Gearbox = automaticGearbox,
                       SeatMaterial = vinylSeatMaterial
                  }    
           };

           context.Cars.AddRange(cars);
           context.SaveChanges();           
       }
    }
}


