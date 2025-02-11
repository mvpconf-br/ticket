// Copyright (c) 2025 MVP Conf Brazil
// MIT License - see LICENSE.md for details

using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithImage("postgres", "16.6")
    .WithPgAdmin(pgWeb => pgWeb.WithHostPort(5050));

var ticketdb = postgres.AddDatabase("ticketdb");

var redis = builder.AddRedis("redis")
    .WithImage("redis", "7.4.2")
    .WithRedisInsight();

builder.AddProject<MVPConf_Ticket_Api>("api")
    .WithReference(ticketdb);
builder.Build().Run();
