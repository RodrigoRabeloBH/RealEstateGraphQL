using RealStateManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateManager.Infrastructure
{
    public static class RealStateSeedData
    {
        public static async Task SeedAsync(RealStateContext context)
        {
            if (!context.Properties.Any() || !context.Payments.Any())
            {
                var properties = new List<Property>
                {
                    new Property
                    {
                        City = "Katowice",
                        Family = "Smith",
                        Name = "Big house",
                        Street = "Sokolska",
                        Value = 100000,
                        Payments = new List<Payment>
                        {
                            new Payment
                            {
                                CreatedDate = new DateTime(2019, 07, 01),
                                OverdueDate = new DateTime(2019, 07, 15),
                                Paid = true,
                                Value = 1500
                            },
                            new Payment
                            {
                                CreatedDate = new DateTime(2019, 08, 01),
                                OverdueDate = new DateTime(2019, 08, 15),
                                Paid = true,
                                Value = 1500
                            },
                            new Payment
                            {
                                CreatedDate = new DateTime(2019, 09, 01),
                                OverdueDate = new DateTime(2019, 09, 15),
                                Paid = false,
                                Value = 1500
                            }
                        }
                    },
                    new Property
                    {
                        City = "Warszawa",
                        Family = "Nowak",
                        Name = "White house",
                        Street = "Wiejska",
                        Value = 300500,
                        Payments = new List<Payment>
                        {
                            new Payment
                            {
                                CreatedDate = new DateTime(2019, 07, 01),
                                OverdueDate = new DateTime(2019, 07, 15),
                                Paid = true,
                                Value = 3000
                            },
                            new Payment
                            {
                                CreatedDate = new DateTime(2019, 08, 01),
                                OverdueDate = new DateTime(2019, 08, 15),
                                Paid = true,
                                Value = 3000
                            },
                            new Payment
                            {
                                CreatedDate = new DateTime(2019, 09, 01),
                                OverdueDate = new DateTime(2019, 09, 15),
                                Paid = false,
                                Value = 3000
                            }
                        }
                    },
                    new Property
                    {
                        City = "Gdańska",
                        Family = "Pomorscy",
                        Name = "Sea house",
                        Street = "Gdańska",
                        Value = 51000,
                        Payments = new List<Payment>
                        {
                            new Payment
                            {
                                CreatedDate = new DateTime(2019, 07, 01),
                                OverdueDate = new DateTime(2019, 07, 15),
                                Paid = true,
                                Value = 800
                            },
                            new Payment
                            {
                                CreatedDate = new DateTime(2019, 08, 01),
                                OverdueDate = new DateTime(2019, 08, 15),
                                Paid = true,
                                Value = 800
                            },
                            new Payment
                            {
                                CreatedDate = new DateTime(2019, 09, 01),
                                OverdueDate = new DateTime(2019, 09, 15),
                                Paid = true,
                                Value = 800
                            }
                        }
                    }
                };

                context.AddRange(properties);

                await context.SaveChangesAsync();
            }
        }
    }
}
