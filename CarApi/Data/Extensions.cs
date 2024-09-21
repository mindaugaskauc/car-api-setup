/**
* Author: Mindaugas Kaucikas
* Date: 2024
* Program description: Extensions.cs 
*
* Extensions class:           public static class Extensions
* Description:                The Extensions class gets created
*
* CreateDbIfNotExists method: public static void CreateDbIfNotExists(this IHost host)
* Description:                he CreateDbIfNotExists method is defined as an extension of IHost
*
* CarContext Service:         var services = scope.ServiceProvider;
*                             var context = services.GetRequiredService<CarContext>();
* Description:                A reference to the CarContext service is created.
*
* EnsuredCreated() method:    context.Database.EnsureCreated();
* Description:                The EnsureCreated method ensures that the database exists.
*                             If a database doesn't exist, EnsureCreated creates a new database. 
*                             The new database isn't configured for migrations, so use this method with caution.
*
* DbIntializer.Initialize     DbInitializer.Initialize(context);
* method:
* Description:                The DbIntializer.Initialize method is called. The CarContext object is passed as a parameter.
*
*
*/

//namespace ContosoPizza.Data;
namespace CarApi.Data;

public static class Extensions
{
   public static void CreateDbIfNotExists(this IHost host)
   {
       {
           using (var scope = host.Services.CreateScope())
           {
               var service = scope.ServiceProvider;
               var context = service.GetRequiredService<CarContext>();
               context.Database.EnsureCreated();
               DbInitializer.Initialize(context);
           } 
       } 
   }
}