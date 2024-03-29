// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT


namespace Microsoft.LanguageServer.Protocol {
    public interface IResponse<TResponse> : IMessage
    {

        OrType<string, int> Id { get; }

        TResponse? Result { get; }

        ResponseError? Error { get; }
    }
}
