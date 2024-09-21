/**
* Author: Mindaugas Kaucikas
* Date: 2024
* Program description: Engine.cs 
*                      Car model used by CarService and CarController
*                      Car.cs, Engine.cs, GearBox.cs and SeatMaterial.cs have the 
*                      following relationships:
*                      
*                      A car can have one engine type.
*                      An engine type can be used in many cars.
*                      A car can have one GearBox type.
*                      One gearbox type can be used by many cars.
*                      A car can have seats maede of one seat material.
*                      The same seat material can be used in many cars.
*
* using Microsoft.AspNetCore.Mvc,using System.Text.Encodings.Web;
*         
* Description: It means that we use classes from the namespaces. Each of them is a
*              namespace which contains other namespaces seperated by a dot.Namespace is a
*              container for classes and other namespaces.
*
* Attributes:   classes that inherit from the Attribute base class. Any class that inherits from Attribute can be used as a sort of "tag" on other pieces of code.
*               While the class is called ObsoleteAttribute, it's only necessary to use [Obsolete] in the code. Most C# code follows this convention. 
*               You can use the full name [ObsoleteAttribute] if you choose.

* namespace:   using System.ComponentModel.DataAnnotations;
* Description: Provides attribute classes that are used to define metadata for ASP.NET MVC and ASP.NET data controls.
*              https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-8.0
*
* Attribute:   RequiredAttribute, call [Required] or [RequiredAttribute]
*
* Description: The attribute marks that the property is required
*
* Attribute:   [MaxLength(100)]
*
* Description:  It is used for the Name property to specify a maximum string length of 100
*
*/

using System.ComponentModel.DataAnnotations;

namespace CarApi.Models;

public class Engine
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
}