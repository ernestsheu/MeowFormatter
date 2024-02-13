// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT


namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The reason why code actions were requested.
    /// 
    /// </summary>
    public enum CodeActionTriggerKind
    {
        /// <summary>
        /// Code actions were explicitly requested by the user or by an extension.
        /// </summary>
        Invoked = 1,

        /// <summary>
        /// Code actions were requested automatically.
        /// 
        /// This typically happens when current selection in a file changes, but can
        /// also be triggered when file content changes.
        /// </summary>
        Automatic = 2,

    }
}
