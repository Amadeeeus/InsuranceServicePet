using FastEndpoints;
using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Activities.Http;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.CancelOrder;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.CreateOrder;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.CreateProduct;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.GenerateDocument;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.GetClaim;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.GetOrder;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.GetProduct;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.GetUser;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.Orchestration;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.ProcessPayment;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.RegisterUser;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.SubmitClaim;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Mappings;

var builder = WebApplication.CreateBuilder(args);
var services = new ServiceCollection();
services.AddElsa(elsa => elsa
    .AddWorkflow<CalculateServiceWorkflow>()
    .AddWorkflow<CancelOrderWorkflow>()
    .AddWorkflow<CreateOrderWorkflow>()
    .AddWorkflow<CreateProductWorkflow>()
    .AddWorkflow<GenerateDocumentWorkflow>()
    .AddWorkflow<GetClaimWorkflow>()
    .AddWorkflow<GetOrderWorkflow>()
    .AddWorkflow<GetProductWorkflow>()
    .AddWorkflow<GetUserWorkflow>()
    .AddWorkflow<ProcessPaymentWorkflow>()
    .AddWorkflow<RegisterUserWorkflow>()
    .AddWorkflow<SubmitClaimWorkflow>().AddActivity<SendHttpRequest>());
builder.Services.AddSwaggerGen();
builder.Services.Configure<WorkflowMappings>(
    builder.Configuration.GetSection("WorkflowMappings"));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.Services.AddFastEndpoints();
app.UseHttpsRedirection();
app.UseFastEndpoints();
app.Run();
