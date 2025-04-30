using Elsa.Models;
using Elsa.Services;
using FastEndpoints;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.Orchestration;
using InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Mappings;
using Microsoft.Extensions.Options;

namespace InsuranceService.ElsaOrchestrator.InsuranceService.ElsaOrchestrator.Api.Features.CancelOrder;

public class GenerateDocumentEndpoint:Endpoint<CalculateServiceRequest, CalculateServiceResponce>
{
    private readonly IStartsWorkflow _workflow;
    private readonly IWorkflowRegistry _registry;
    private readonly IOptions<WorkflowMappings> _mappings;
    public GenerateDocumentEndpoint(IStartsWorkflow workflow, IWorkflowRegistry registry, IOptions<WorkflowMappings> mappings)
    {
        _mappings = mappings;
        _workflow = workflow;
        _registry = registry;
    }
    public override void Configure()
    {
        Post("/CalculateService");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CalculateServiceRequest request, CancellationToken cancellationToken)
    {
        var workflowId = _mappings.Value.CalculateService;
        var blueprint = await _registry.FindAsync(definitionId: workflowId, versionOptions: VersionOptions.Published,
            cancellationToken: cancellationToken);
        var result = await _workflow.StartWorkflowAsync(
        );
    }

}