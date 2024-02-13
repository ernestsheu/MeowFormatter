// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT


namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Describes how an <see cref="InlineCompletionItemProvider">inline completion provider</see> was triggered.
    /// 
    /// </summary>
    public enum InlineCompletionTriggerKind
    {
        /// <summary>
        /// Completion was triggered explicitly by a user gesture.
        /// </summary>
        Invoked = 1,

        /// <summary>
        /// Completion was triggered automatically while editing.
        /// </summary>
        Automatic = 2,

    }
}
