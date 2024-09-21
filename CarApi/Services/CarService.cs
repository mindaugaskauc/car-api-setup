/**
* Author: Mindaugas Kaucikas
* Date: 2024
* Program description: CarService.cs 
*
*                      Services/CarService.cs is a service class that defines create, read, update, 
*                      and delete (CRUD) methods. All the methods currently throw System.NotImplementedException. 
*
*                      In Program.cs, CarService is registered with the ASP.NET Core dependency injection system.           
*
* PizzaContext field:  @param private readonly CarContext _context;
*
* Description:         class-level field for CarContext
*
* PizzaService         public CarService(CarContext context))
* constructor:         {
*                         _context = context;
*                      }
* 
* Description:         constructor method signature accepts a CarContext parameter
*                      The _context field accepts the CarContext field         
*                      When the CarService instance is created, a CarContext is injected into the constructor.
*
* GetAll() method:     public IEnumerable<Car> GetAll()
*                      {
*                         //throw new NotImplementedException();
*                         return _context.Cars
*                             .Include(p => p.Engine)
*                             .Include(p => p.Gearbox)
*                             .Include(p => p.SeatMaterial)
*                             .AsNoTracking()
*                             .ToList();
*                      }
*
* Description:         The Cars collection contains all the rows in the cars table.
*                      The AsNoTracking extension method instructs EF Core to disable change tracking.
*                      Because this operation is read-only, AsNoTracking can optimize performance.
*                      The Include extension method takes a lambda expression to specify that the Engine, 
*                      Gearbox and SeatMaterial navigation properties are to be included in the result by using eager loading. 
*                      Without this expression, EF Core returns null for those properties. 
*                      All of the cars are returned with ToList.
* 
* GetById(int id)      public Car? GetById(int id)
* method               {

*                         return _context.Cars
*                             .Include(p => p.Engine)
*                             .Include(p => p.Gearbox)
*                             .Include(p => p.SeatMaterial)
*                             .AsNoTracking()
*                             .SingleOrDefault(p => p.Id == id);
*                      }  
* 
* Description:         The Include extension method takes a lambda expression to specify that the Engine, 
*                      Gearbox, SeatMaterial navigation properties are to be included in the result by using eager loading. 
*                      Without this expression, EF Core returns null for those properties.
*
*                      The SingleOrDefault method returns a pizza that matches the lambda expression.
*                        If no records match, null is returned.
*                        If multiple records match, an exception is thrown.
*                        The lambda expression describes records where the Id property is equal to the id parameter.    
*
* Create                public Car? Create(Car newCar)
* (Pizza newPizza)      {
* method:                
*                          _context.Cars.Add(newCar);
*                          _context.SaveChanges();
*
*                          return newCar
*                       }   
* 
* Description:         newCar is assumed to be a valid object. EF Core doesn't do data validation, 
*                      so the ASP.NET Core runtime or user code must handle any validation.
*                     
*                      The Add method adds the newPizza entity to the EF Core object graph.
*
*                      The SaveChanges method instructs EF Core to persist the object changes to the database.                   
*        
*
* UpdateEngine method:  public void UpdateEngine(int carId, int engineId)
*
* Description:         References to existing Car and Engine objects are created by using Find. Find is an optimized 
*                      method to query records by their primary key. Find searches the local entity graph first before 
*                      it queries the database.
*
*                      The Car.Engine property is set to the Engine object.
*
*                      An Update method call is unnecessary because EF Core detects that you set the Engine property on Car.
*
*                      The SaveChanges method instructs EF Core to persist the object changes to the database.
*
* UpdateGearbox method: public void UpdateGearbox(int carId, int gearboxId)
*
* Description:         References to existing Car and Gearbox objects are created by using Find. Find is an optimized 
*                      method to query records by their primary key. Find searches the local entity graph first before 
*                      it queries the database.
*
*                      The Car.Gearbox property is set to the Gearbox object.
*
*                      An Update method call is unnecessary because EF Core detects that you set the Gearbox property on Car.
*
*                      The SaveChanges method instructs EF Core to persist the object changes to the database.
*
* UpdateSeatMaterial   public void UpdateSeatMaterial(int carId, int seatMaterialId)
* method:
*
* Desription:          References to existing Car and SeatMaterial objects are created by using Find. Find is an optimized 
*                      method to query records by their primary key. Find searches the local entity graph first before 
*                      it queries the database.
*
*                      The Car.SeatMaterial property is set to the SeatMaterial object.
*
*                      An Update method call is unnecessary because EF Core detects that you set the SeatMaterial property on Car.
*
*                      The SaveChanges method instructs EF Core to persist the object changes to the database.
*  
* 
* DeleteById method:   public void DeleteById(int id)
*
* Description:         The Find method retrieves a car by the primary key (which is Id in this case).
*
*                      The Remove method removes the carToDelete entity in EF Core's object graph.
*
*                      The SaveChanges method instructs EF Core to persist the object changes to the database.     
*
*
*/

using CarApi.Models;
using CarApi.Data;
using Microsoft.EntityFrameworkCore;


namespace CarApi.Services;

public class CarService
{
   
    private readonly CarContext _context;

    public CarService(CarContext context)
    {
        _context = context;
    }

    public IEnumerable<Car> GetAll()
    {
        //throw new NotImplementedException();
        return _context.Cars
            .Include(p => p.Engine)
            .Include(p => p.Gearbox)
            .Include(p => p.SeatMaterial)
            .AsNoTracking()
            .ToList();
    }

    public Car? GetById(int id)
    {
        //throw new NotImplementedException();
        return _context.Cars
            .Include(p => p.Engine)
            .Include(p => p.Gearbox)
            .Include(p => p.SeatMaterial)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public Car? Create(Car newCar)
    {
        //throw new NotImplementedException();
        _context.Cars.Add(newCar);
        _context.SaveChanges();

        return newCar;
    }

    public void UpdateEngine(int carId, int engineId)
    {
        //throw new NotImplementedException();
        var carToUpdate = _context.Cars.Find(carId);
        var engineToUpdate = _context.Engines.Find(engineId);

        if (carToUpdate is null || engineToUpdate is null)
        {
            throw new InvalidOperationException("Car or engine does not exist");
        }

        carToUpdate.Engine = engineToUpdate;

        _context.SaveChanges();

    }
    
    public void UpdateGearbox(int carId, int gearboxId)
    {
        //throw new NotImplementedException();
        var carToUpdate = _context.Cars.Find(carId);
        var gearboxToUpdate = _context.Gearboxes.Find(gearboxId);

        if (carToUpdate is null || gearboxToUpdate is null)
        {
            throw new InvalidOperationException("Car or gearbox does not exist");
        }

        carToUpdate.Gearbox = gearboxToUpdate;

        _context.SaveChanges();

    }

    public void UpdateSeatMaterial(int carId, int seatMaterialId)
    {
        //throw new NotImplementedException();
        var carToUpdate = _context.Cars.Find(carId);
        var seatMaterialToUpdate = _context.SeatMaterials.Find(seatMaterialId);

        if (carToUpdate is null || seatMaterialToUpdate is null)
        {
            throw new InvalidOperationException("Car or seat material does not exist");
        }

        carToUpdate.SeatMaterial = seatMaterialToUpdate;

        _context.SaveChanges();

    }

    public void DeleteById(int id)
    {
       //throw new NotImplementedException();
       var carToDelete = _context.Cars.Find(id);
       if (carToDelete is not null)
       {
           _context.Cars.Remove(carToDelete);
           _context.SaveChanges();
       }     
    }
}