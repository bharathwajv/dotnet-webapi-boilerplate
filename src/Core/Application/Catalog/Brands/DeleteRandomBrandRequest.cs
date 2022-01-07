﻿using DN.WebApi.Application.Common.Interfaces;
using MediatR;

namespace DN.WebApi.Application.Catalog.Brands;

public class DeleteRandomBrandRequest : IRequest<string>
{
}

public class DeleteRandomBrandRequestHandler : IRequestHandler<DeleteRandomBrandRequest, string>
{
    private readonly IJobService _jobService;

    public DeleteRandomBrandRequestHandler(IJobService jobService) => _jobService = jobService;

    public Task<string> Handle(DeleteRandomBrandRequest request, CancellationToken cancellationToken)
    {
        string jobId = _jobService.Schedule<IBrandGeneratorJob>(x => x.CleanAsync(), TimeSpan.FromSeconds(5));
        return Task.FromResult(jobId);
    }
}