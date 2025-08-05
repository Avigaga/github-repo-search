using System;
using System.Collections.Generic;

public abstract class Person
{
    public Guid Id { get; } = Guid.NewGuid();
    public string FullName { get; set; }

    protected Person(string fullName)
    {
        FullName = fullName;
    }
}

public class Driver : Person
{
    public Vehicle Vehicle { get; set; }

    public Driver(string fullName, Vehicle vehicle)
        : base(fullName)
    {
        Vehicle = vehicle;
    }
}

public class Passenger : Person
{
    public Passenger(string fullName)
        : base(fullName)
    {
    }
}

public class Vehicle
{
    public string LicensePlate { get; set; }
    public string Model { get; set; }
    public int Capacity { get; set; }

    public Vehicle(string licensePlate, string model, int capacity)
    {
        LicensePlate = licensePlate;
        Model = model;
        Capacity = capacity;
    }
}

public class Ride
{
    public Guid Id { get; } = Guid.NewGuid();
    public Driver Driver { get; set; }
    public Passenger Passenger { get; set; }
    public DateTime StartTime { get; set; }
    public string StartLocation { get; set; }
    public string Destination { get; set; }

    public Ride(Driver driver, Passenger passenger, DateTime startTime, string startLocation, string destination)
    {
        Driver = driver;
        Passenger = passenger;
        StartTime = startTime;
        StartLocation = startLocation;
        Destination = destination;
    }
}
