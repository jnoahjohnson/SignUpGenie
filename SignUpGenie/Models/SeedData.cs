using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpGenie.Models
{
    public class SeedData
    {
        // Method to feed in seed data if needed
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            // Setup Context
            GenieDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<GenieDbContext>(); ;

            // Check for pending migrations
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            // Add Default Tours
            if (!context.Tours.Any())
            {
				Console.WriteLine("Add seed data!");
				// Get current DateTime
				DateTime today = DateTime.Today;

				List<Tour> initialTours = new List<Tour>();

				// Set the first day of the seed data (tomorrow)
				DateTime startDateTime = new DateTime(today.Year, today.Month, today.Day + 1, 8, 0, 0);

				// Do the following for 7 periods (days)
				for (int i = 1; i <= 7; i++)
				{
					// Timespan for a day that will increase by a day each time through
					TimeSpan day = new TimeSpan(i, 0, 0, 0);

					// Do the following for each hour from 8am to 8pm
					for (int j = 0; j < 13; j++)
					{
						// Timespan for an hour that will increase each time through
						TimeSpan hour = new TimeSpan(j, 0, 0);

						// New start time based on the start date and the current increased day and hour
						DateTime tourDateTime = startDateTime + day + hour;

						// Append new Tour object to the tour context
						initialTours.Add(new Tour
						{
							DateTime = tourDateTime
						});

					}

				}

				// Add tour objects to context and then save the context
				context.Tours.AddRange(initialTours);
				context.SaveChanges();
			}
            
        }
    }
}
