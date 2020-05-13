// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Builder.AI.Luis;
//using Microsoft.Bot.Builder.AI.QnA;

namespace GlobalAITourAR.Luis
{
    public interface IBotServices
    {
        LuisRecognizer Dispatch { get; }
        
    }
}
