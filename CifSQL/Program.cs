using System;
using CifSQL.Data;
using CifSQL.Models;
using ATCOcif;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;


namespace CifSQL
{
    class Program
    {
        static void Main(string[] args)
        {

            //Parsing cif file into Objects
            ATCOcifParser parser = new ATCOcifParser(ConfigurationManager.AppSettings.Get("filePath"));

            //Create database with the given connection string
            var options = new DbContextOptionsBuilder<CifSQLContext>();
            options.UseSqlServer(ConfigurationManager.ConnectionStrings["sql-server"].ConnectionString);
            using CifSQLContext context = new CifSQLContext(options.Options);
            context.Database.EnsureCreated();

            //Using the parsed objects for creating Entities
            int i = 0;
            foreach (LocationRecord locationRecord in parser.Locations.Values)
            {
                Console.WriteLine("Adding Locations to DB: " + i + "/" + parser.Locations.Count);
                context.Locations.Add(new Location
                {
                    ShortForm = locationRecord.Location,
                    FullForm = locationRecord.FullLocation,
                    GridEasting = locationRecord.GridEasting,
                    GridNorthing = locationRecord.GridNorthing
                });
                i++;
            }
            context.SaveChanges();

            i = 0;
            foreach (RouteDescription route in parser.Routes.Values)
            {
                Console.WriteLine("Adding Routes to DB: " + i + "/" + parser.Routes.Count);
                context.Routes.Add(new Route
                {
                    RouteNumber = route.Route,
                    Direction = route.Direction,
                    Description = route.Description
                });
                i++;
            }
            context.SaveChanges();

            i = 0;
            foreach (JourneyRecord journey in parser.Journeys)
            {
                Console.WriteLine("Adding Journeys to DB: " + i + "/" + parser.Journeys.Count);
                int routeid = context.Routes
                    .Where(r => r.RouteNumber == journey.Header.Route && r.Direction == journey.Header.Direction)
                    .FirstOrDefault().Id;

                Journey j = new Journey
                {
                    RouteId = routeid,
                    BankHolidays = journey.Header.BankHolidays,
                    Monday = journey.Header.OperationDays[0],
                    Tuesday = journey.Header.OperationDays[1],
                    Wednesday = journey.Header.OperationDays[2],
                    Thursday = journey.Header.OperationDays[3],
                    Friday = journey.Header.OperationDays[4],
                    Saturday = journey.Header.OperationDays[5],
                    Sunday = journey.Header.OperationDays[6],
                    Stops = new List<Stop>()
                };

                j.Stops.Add(StopFromRecord(journey.Origin, context, 'O'));
                foreach (StopRecord stop in journey.IntermediateRecords)
                    j.Stops.Add(StopFromRecord(stop, context, 'I'));
                j.Stops.Add(StopFromRecord(journey.Destination, context, 'D'));
                context.Journeys.Add(j);
                i++;
            }
            context.SaveChanges();
            Console.WriteLine("Complete");
        }

        private static Stop StopFromRecord(StopRecord stop, CifSQLContext context, char stoptype = 'I')
        {
            int locationid = context.Locations
                .Where(l => l.ShortForm == stop.Location).FirstOrDefault().Id;

            Stop s = new Stop
            {
                LocationId = locationid,
                Time = new TimeSpan(0, stop.Time.Hours, stop.Time.Minutes, stop.Time.Seconds),
                StopType = stoptype
            };
            return s;
        }

    }
}
