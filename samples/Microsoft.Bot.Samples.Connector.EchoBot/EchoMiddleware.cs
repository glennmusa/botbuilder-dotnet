﻿using Microsoft.Bot.Builder;
using Microsoft.Bot.Connector;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Bot.Samples.Middleware
{
    public class EchoMiddleware : IReceiveActivity
    {
        public async Task<ReceiveResponse> ReceiveActivity(BotContext context, CancellationToken token)
        {
            if (context.IfIntent("echoIntent"))
            {
                long turnNumber = context.State.Conversation["turnNumber"] ?? 0;                   
                context.State.Conversation["turnNumber"] = ++turnNumber;

                context.Responses.Add(
                        context.Request.CreateReply(
                            $"[{turnNumber}] echo: {context.Request.Text.Substring("echo ".Length)}"));                
                
                return new ReceiveResponse(true);
            }
            return new ReceiveResponse(false);
        }
    }
}