// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT


namespace Microsoft.LanguageServer.Protocol {
    public enum LSPErrorCodes
    {
        /// <summary>
        /// A request failed but it was syntactically correct, e.g the
        /// method name was known and the parameters were valid. The error
        /// message should contain human readable information about why
        /// the request failed.
        /// 
        /// </summary>
        RequestFailed = -32803,

        /// <summary>
        /// The server cancelled the request. This error code should
        /// only be used for requests that explicitly support being
        /// server cancellable.
        /// 
        /// </summary>
        ServerCancelled = -32802,

        /// <summary>
        /// The server detected that the content of a document got
        /// modified outside normal conditions. A server should
        /// NOT send this error code if it detects a content change
        /// in it unprocessed messages. The result even computed
        /// on an older state might still be useful for the client.
        /// 
        /// If a client decides that a result is not of any use anymore
        /// the client should cancel the request.
        /// </summary>
        ContentModified = -32801,

        /// <summary>
        /// The client has canceled a request and a server as detected
        /// the cancel.
        /// </summary>
        RequestCancelled = -32800,

    }
}