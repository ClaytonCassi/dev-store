using DevStore.Clients.API.Application.Commands;
using DevStore.Clients.API.Application.Events;
using DevStore.Clients.API.Data;
using DevStore.Clients.API.Data.Repository;
using DevStore.Clients.API.Models;
using DevStore.WebAPI.Core.Usuario;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DevStore.Clients.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            //services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.TryAddScoped<IRequestHandler<NewClientCommand, ValidationResult>, ClientCommandHandler>();
            services.TryAddScoped<IRequestHandler<AddAddressCommand, ValidationResult>, ClientCommandHandler>();

            services.TryAddScoped<INotificationHandler<NewClientAddedEvent>, ClientEventHandler>();

            services.AddScoped<IClienteRepository, ClientRepository>();
            services.AddScoped<ClientContext>();
        }
    }
}