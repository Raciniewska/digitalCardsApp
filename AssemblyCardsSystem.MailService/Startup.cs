﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenPipes;
using AssemblyCardsSystem.MailService.Configuration;
using AssemblyCardsSystem.WebApi;
using AssemblyCardsSystem.WebApi.Models;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MailKit.Net.Smtp;
using MimeKit;
using System.Security.Authentication;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace AssemblyCardsSystem.MailService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                var rabbitConfiguration = Configuration.GetSection("RabbitMQ").Get<RabbitMqConfiguration>();

                x.AddConsumer<CardToSendConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri(rabbitConfiguration.ServerAddress), hostConfigurator =>
                    {
                        hostConfigurator.Username(rabbitConfiguration.Username);
                        hostConfigurator.Password(rabbitConfiguration.Password);
                    });

                    cfg.ReceiveEndpoint(host, "notification-service", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));

                        ep.ConfigureConsumer<CardToSendConsumer>(provider);
                    });
                }));
            });

            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

            services.AddSingleton<IHostedService, BusService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) => { await context.Response.WriteAsync("Mail Service started!"); });
        }
    }

    public class CardToSendConsumer : IConsumer<CardToSend>
    {
        public Task Consume(ConsumeContext<CardToSend> context)
        {
            var massage = new MimeMessage();

            Console.WriteLine(context.Message.destinationEmail);
            var receiver = context.Message.destinationEmail;
            if (receiver != null || receiver != "")
            {
                massage.To.Add(new MailboxAddress("to mail", receiver));


                massage.Subject = "Assembly Card Data";
                massage.Body = new TextPart("plain")
                {
                    Text = "Emloyee lastname: " + context.Message.EmployeeLN + "\n" +
                    "Employee firstname: " + context.Message.EmployeeFN + "\n" +
                    "Employee ID: " + context.Message.EmployeeID + "\n" +
                    "KNNR:" + context.Message.KNNR + "\n" +
                    "Sort " + context.Message.Sort + "\n" +
                    "PrNr" + context.Message.PrNr
                };
                using (var client = new SmtpClient())
                {

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("student172071@gmail.com", "Student1@");
                    client.Send(massage);
                    client.Disconnect(true);
                }
            }
            return Task.CompletedTask;
        }
    }
}