global using Microsoft.AspNetCore.Mvc;
global using Autofac;
global using Microsoft.AspNetCore.HttpLogging;
global using Serilog;
global using Autofac.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore;
global using Charisma.CodeChallenge.Api.Infrastructure;
global using Charisma.CodeChallenge.Persistence;
global using Charisma.CodeChallenge.Persistence.Repositories;
global using Shared.Core.Contracts;
global using Shared.Core.Contracts.ApplicationServices;
global using Shared.Core.Contracts.Persistence;
global using Shared.Core.Infrastructure.ApplicationServices;
global using Shared.Core.Infrastructure.Autofac;
global using Shared.Core.Infrastructure.Persistence;
global using Charisma.CodeChallenge.Application.Orders;
global using Charisma.CodeChallenge.Application.Products;
global using Charisma.CodeChallenge.Application.Customers;