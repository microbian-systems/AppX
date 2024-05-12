﻿using MassTransit;

namespace Electra.Actors;

public interface IPongGrain : IGrainWithGuidKey
{
    [Alias("Pong")]
    Task Pong(Message message);
}

public class PongGrain(ILogger<PongGrain> logger) : Grain, IPongGrain
{
    public override async Task OnActivateAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("PongGrain activated.");
        await base.OnActivateAsync(cancellationToken);
    }

    public override async Task OnDeactivateAsync(DeactivationReason reason, CancellationToken cancellationToken)
    {
        logger.LogInformation("PongGrain deactivated.");
        await base.OnDeactivateAsync(reason, cancellationToken);
    }

    public Task Pong(Message message)
    {
        logger.LogInformation($"Ping received: {message.content}");

        var id = NewId.NextSequentialGuid();
        // Create a response message
        var responseMessage = new Message(id, $"pong! ping received: {message.content}");

        // Log the response
        logger.LogInformation(responseMessage.content);

        return Task.CompletedTask;
    }
}