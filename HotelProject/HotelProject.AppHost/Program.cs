var builder = DistributedApplication.CreateBuilder(args);

builder
    .AddProject<Projects.AuthenticationDuendeService>("duende");

builder
    .AddProject<Projects.Frontend>("frontend");

builder
    .AddProject<Projects.BookingService>("booking");
builder
    .AddProject<Projects.PayService>("payment");
builder
    .AddProject<Projects.ResaurantService>("restaurant");
builder
    .AddProject<Projects.KundenfeedbackService>("feedback");
builder
    .AddProject<Projects.RoomService>("room");
builder
    .AddProject<Projects.AuthenticationApiService>("api");

builder.Build().Run();