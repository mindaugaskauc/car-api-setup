/**
* Author: Mindaugas Kaucikas
* Date: 2024
* Program description: CarContext.cs 
* 
* Constructor: public CarContext (DbContextOptions<CarContext> options)
*
* Description: The constructor accepts a parameter of type DbContextOptions<CarContext>. 
*              The constructor allows external code to pass in the configuration so that the same 
*              DbContext can be shared between test and production code, and even be used with different providers.
* 
* Property:    DbSet<T> 
*
* Description: The DbSet<T> properties correspond to the tables in the database.
*              Cars, Engines, Gearboxes, SeatMaterials DBSet<T> properties correspond
*              to the tables in the database.
*              You can override this behavior if needed.
* 
*              When instantiated, CarContext will expose the Cars, Engines, Gearboxes and SeatMaterials properties. 
*              Changes you make to the collections that those properties expose will be propagated to the database.
*
*/

using Microsoft.EntityFrameworkCore;

using CarApi.Models;


namespace CarApi.Data;

public class CarContext : DbContext
{
    public CarContext (DbContextOptions<CarContext> options)
        : base(options)
    {           
    }

    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Engine> Engines => Set<Engine>();
    public DbSet<Gearbox> Gearboxes => Set<Gearbox>();
    public DbSet<SeatMaterial> SeatMaterials => Set<SeatMaterial>();   
}