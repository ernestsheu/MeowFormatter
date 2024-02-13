// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT


namespace Microsoft.LanguageServer.Protocol {
    public static class LSPMethods
    {
        /// <summary>
        /// A request to resolve the implementation locations of a symbol at a given text
        /// document position. The request's parameter is of type <see cref="TextDocumentPositionParams" />
        /// the response is of type <see cref="Definition" /> or a Thenable that resolves to such.
        /// </summary>
        public static string TextDocumentImplementation { get; } = "textDocument/implementation";
        /// <summary>
        /// A request to resolve the type definition locations of a symbol at a given text
        /// document position. The request's parameter is of type <see cref="TextDocumentPositionParams" />
        /// the response is of type <see cref="Definition" /> or a Thenable that resolves to such.
        /// </summary>
        public static string TextDocumentTypeDefinition { get; } = "textDocument/typeDefinition";
        /// <summary>
        /// The `workspace/workspaceFolders` is sent from the server to the client to fetch the open workspace folders.
        /// </summary>
        public static string WorkspaceWorkspaceFolders { get; } = "workspace/workspaceFolders";
        /// <summary>
        /// The 'workspace/configuration' request is sent from the server to the client to fetch a certain
        /// configuration setting.
        /// 
        /// This pull model replaces the old push model were the client signaled configuration change via an
        /// event. If the server still needs to react to configuration changes (since the server caches the
        /// result of `workspace/configuration` requests) the server should register for an empty configuration
        /// change event and empty the cache if such an event is received.
        /// </summary>
        public static string WorkspaceConfiguration { get; } = "workspace/configuration";
        /// <summary>
        /// A request to list all color symbols found in a given text document. The request's
        /// parameter is of type <see cref="DocumentColorParams" /> the
        /// response is of type {@link ColorInformation ColorInformation[]} or a Thenable
        /// that resolves to such.
        /// </summary>
        public static string TextDocumentDocumentColor { get; } = "textDocument/documentColor";
        /// <summary>
        /// A request to list all presentation for a color. The request's
        /// parameter is of type <see cref="ColorPresentationParams" /> the
        /// response is of type {@link ColorInformation ColorInformation[]} or a Thenable
        /// that resolves to such.
        /// </summary>
        public static string TextDocumentColorPresentation { get; } = "textDocument/colorPresentation";
        /// <summary>
        /// A request to provide folding ranges in a document. The request's
        /// parameter is of type <see cref="FoldingRangeParams" />, the
        /// response is of type <see cref="FoldingRangeList" /> or a Thenable
        /// that resolves to such.
        /// </summary>
        public static string TextDocumentFoldingRange { get; } = "textDocument/foldingRange";
        /// <summary>
        /// </summary>
        [Proposed]
        [Since("3.18.0")]
        [Direction(MessageDirection.ServerToClient)]
        public static string WorkspaceFoldingRangeRefresh { get; } = "workspace/foldingRange/refresh";
        /// <summary>
        /// A request to resolve the type definition locations of a symbol at a given text
        /// document position. The request's parameter is of type <see cref="TextDocumentPositionParams" />
        /// the response is of type <see cref="Declaration" /> or a typed array of <see cref="DeclarationLink" />
        /// or a Thenable that resolves to such.
        /// </summary>
        public static string TextDocumentDeclaration { get; } = "textDocument/declaration";
        /// <summary>
        /// A request to provide selection ranges in a document. The request's
        /// parameter is of type <see cref="SelectionRangeParams" />, the
        /// response is of type {@link SelectionRange SelectionRange[]} or a Thenable
        /// that resolves to such.
        /// </summary>
        public static string TextDocumentSelectionRange { get; } = "textDocument/selectionRange";
        /// <summary>
        /// The `window/workDoneProgress/create` request is sent from the server to the client to initiate progress
        /// reporting from the server.
        /// </summary>
        public static string WindowWorkDoneProgressCreate { get; } = "window/workDoneProgress/create";
        /// <summary>
        /// A request to result a `CallHierarchyItem` in a document at a given position.
        /// Can be used as an input to an incoming or outgoing call hierarchy.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentPrepareCallHierarchy { get; } = "textDocument/prepareCallHierarchy";
        /// <summary>
        /// A request to resolve the incoming calls for a given `CallHierarchyItem`.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string CallHierarchyIncomingCalls { get; } = "callHierarchy/incomingCalls";
        /// <summary>
        /// A request to resolve the outgoing calls for a given `CallHierarchyItem`.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string CallHierarchyOutgoingCalls { get; } = "callHierarchy/outgoingCalls";
        /// <summary>
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentSemanticTokensFull { get; } = "textDocument/semanticTokens/full";
        /// <summary>
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentSemanticTokensFullDelta { get; } = "textDocument/semanticTokens/full/delta";
        /// <summary>
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentSemanticTokensRange { get; } = "textDocument/semanticTokens/range";
        /// <summary>
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ServerToClient)]
        public static string WorkspaceSemanticTokensRefresh { get; } = "workspace/semanticTokens/refresh";
        /// <summary>
        /// A request to show a document. This request might open an
        /// external program depending on the value of the URI to open.
        /// For example a request to open `https://code.visualstudio.com/`
        /// will very likely open the URI in a WEB browser.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ServerToClient)]
        public static string WindowShowDocument { get; } = "window/showDocument";
        /// <summary>
        /// A request to provide ranges that can be edited together.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentLinkedEditingRange { get; } = "textDocument/linkedEditingRange";
        /// <summary>
        /// The will create files request is sent from the client to the server before files are actually
        /// created as long as the creation is triggered from within the client.
        /// 
        /// The request can return a `WorkspaceEdit` which will be applied to workspace before the
        /// files are created. Hence the `WorkspaceEdit` can not manipulate the content of the file
        /// to be created.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string WorkspaceWillCreateFiles { get; } = "workspace/willCreateFiles";
        /// <summary>
        /// The will rename files request is sent from the client to the server before files are actually
        /// renamed as long as the rename is triggered from within the client.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string WorkspaceWillRenameFiles { get; } = "workspace/willRenameFiles";
        /// <summary>
        /// The did delete files notification is sent from the client to the server when
        /// files were deleted from within the client.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string WorkspaceWillDeleteFiles { get; } = "workspace/willDeleteFiles";
        /// <summary>
        /// A request to get the moniker of a symbol at a given text document position.
        /// The request parameter is of type <see cref="TextDocumentPositionParams" />.
        /// The response is of type {@link Moniker Moniker[]} or `null`.
        /// </summary>
        public static string TextDocumentMoniker { get; } = "textDocument/moniker";
        /// <summary>
        /// A request to result a `TypeHierarchyItem` in a document at a given position.
        /// Can be used as an input to a subtypes or supertypes type hierarchy.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentPrepareTypeHierarchy { get; } = "textDocument/prepareTypeHierarchy";
        /// <summary>
        /// A request to resolve the supertypes for a given `TypeHierarchyItem`.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TypeHierarchySupertypes { get; } = "typeHierarchy/supertypes";
        /// <summary>
        /// A request to resolve the subtypes for a given `TypeHierarchyItem`.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TypeHierarchySubtypes { get; } = "typeHierarchy/subtypes";
        /// <summary>
        /// A request to provide inline values in a document. The request's parameter is of
        /// type <see cref="InlineValueParams" />, the response is of type
        /// {@link InlineValue InlineValue[]} or a Thenable that resolves to such.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentInlineValue { get; } = "textDocument/inlineValue";
        /// <summary>
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ServerToClient)]
        public static string WorkspaceInlineValueRefresh { get; } = "workspace/inlineValue/refresh";
        /// <summary>
        /// A request to provide inlay hints in a document. The request's parameter is of
        /// type <see cref="InlayHintsParams" />, the response is of type
        /// {@link InlayHint InlayHint[]} or a Thenable that resolves to such.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentInlayHint { get; } = "textDocument/inlayHint";
        /// <summary>
        /// A request to resolve additional properties for an inlay hint.
        /// The request's parameter is of type <see cref="InlayHint" />, the response is
        /// of type <see cref="InlayHint" /> or a Thenable that resolves to such.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string InlayHintResolve { get; } = "inlayHint/resolve";
        /// <summary>
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ServerToClient)]
        public static string WorkspaceInlayHintRefresh { get; } = "workspace/inlayHint/refresh";
        /// <summary>
        /// The document diagnostic request definition.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentDiagnostic { get; } = "textDocument/diagnostic";
        /// <summary>
        /// The workspace diagnostic request definition.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string WorkspaceDiagnostic { get; } = "workspace/diagnostic";
        /// <summary>
        /// The diagnostic refresh request definition.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ServerToClient)]
        public static string WorkspaceDiagnosticRefresh { get; } = "workspace/diagnostic/refresh";
        /// <summary>
        /// A request to provide inline completions in a document. The request's parameter is of
        /// type <see cref="InlineCompletionParams" />, the response is of type
        /// {@link InlineCompletion InlineCompletion[]} or a Thenable that resolves to such.
        /// 
        /// </summary>
        [Proposed]
        [Since("3.18.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentInlineCompletion { get; } = "textDocument/inlineCompletion";
        /// <summary>
        /// The `client/registerCapability` request is sent from the server to the client to register a new capability
        /// handler on the client side.
        /// </summary>
        public static string ClientRegisterCapability { get; } = "client/registerCapability";
        /// <summary>
        /// The `client/unregisterCapability` request is sent from the server to the client to unregister a previously registered capability
        /// handler on the client side.
        /// </summary>
        public static string ClientUnregisterCapability { get; } = "client/unregisterCapability";
        /// <summary>
        /// The initialize request is sent from the client to the server.
        /// It is sent once as the request after starting up the server.
        /// The requests parameter is of type <see cref="InitializeParams" />
        /// the response if of type <see cref="InitializeResult" /> of a Thenable that
        /// resolves to such.
        /// </summary>
        public static string Initialize { get; } = "initialize";
        /// <summary>
        /// A shutdown request is sent from the client to the server.
        /// It is sent once when the client decides to shutdown the
        /// server. The only notification that is sent after a shutdown request
        /// is the exit event.
        /// </summary>
        public static string Shutdown { get; } = "shutdown";
        /// <summary>
        /// The show message request is sent from the server to the client to show a message
        /// and a set of options actions to the user.
        /// </summary>
        public static string WindowShowMessageRequest { get; } = "window/showMessageRequest";
        /// <summary>
        /// A document will save request is sent from the client to the server before
        /// the document is actually saved. The request can return an array of TextEdits
        /// which will be applied to the text document before it is saved. Please note that
        /// clients might drop results if computing the text edits took too long or if a
        /// server constantly fails on this request. This is done to keep the save fast and
        /// reliable.
        /// </summary>
        public static string TextDocumentWillSaveWaitUntil { get; } = "textDocument/willSaveWaitUntil";
        /// <summary>
        /// Request to request completion at a given text document position. The request's
        /// parameter is of type <see cref="TextDocumentPosition" /> the response
        /// is of type {@link CompletionItem CompletionItem[]} or <see cref="CompletionList" />
        /// or a Thenable that resolves to such.
        /// 
        /// The request can delay the computation of the <see cref="CompletionItem.detail">`detail`</see>
        /// and <see cref="CompletionItem.documentation">`documentation`</see> properties to the `completionItem/resolve`
        /// request. However, properties that are needed for the initial sorting and filtering, like `sortText`,
        /// `filterText`, `insertText`, and `textEdit`, must not be changed during resolve.
        /// </summary>
        public static string TextDocumentCompletion { get; } = "textDocument/completion";
        /// <summary>
        /// Request to resolve additional information for a given completion item.The request's
        /// parameter is of type <see cref="CompletionItem" /> the response
        /// is of type <see cref="CompletionItem" /> or a Thenable that resolves to such.
        /// </summary>
        public static string CompletionItemResolve { get; } = "completionItem/resolve";
        /// <summary>
        /// Request to request hover information at a given text document position. The request's
        /// parameter is of type <see cref="TextDocumentPosition" /> the response is of
        /// type <see cref="Hover" /> or a Thenable that resolves to such.
        /// </summary>
        public static string TextDocumentHover { get; } = "textDocument/hover";
        public static string TextDocumentSignatureHelp { get; } = "textDocument/signatureHelp";
        /// <summary>
        /// A request to resolve the definition location of a symbol at a given text
        /// document position. The request's parameter is of type <see cref="TextDocumentPosition" />
        /// the response is of either type <see cref="Definition" /> or a typed array of
        /// <see cref="DefinitionLink" /> or a Thenable that resolves to such.
        /// </summary>
        public static string TextDocumentDefinition { get; } = "textDocument/definition";
        /// <summary>
        /// A request to resolve project-wide references for the symbol denoted
        /// by the given text document position. The request's parameter is of
        /// type <see cref="ReferenceParams" /> the response is of type
        /// {@link Location Location[]} or a Thenable that resolves to such.
        /// </summary>
        public static string TextDocumentReferences { get; } = "textDocument/references";
        /// <summary>
        /// Request to resolve a <see cref="DocumentHighlight" /> for a given
        /// text document position. The request's parameter is of type <see cref="TextDocumentPosition" />
        /// the request response is an array of type <see cref="DocumentHighlight" />
        /// or a Thenable that resolves to such.
        /// </summary>
        public static string TextDocumentDocumentHighlight { get; } = "textDocument/documentHighlight";
        /// <summary>
        /// A request to list all symbols found in a given text document. The request's
        /// parameter is of type <see cref="TextDocumentIdentifier" /> the
        /// response is of type {@link SymbolInformation SymbolInformation[]} or a Thenable
        /// that resolves to such.
        /// </summary>
        public static string TextDocumentDocumentSymbol { get; } = "textDocument/documentSymbol";
        /// <summary>
        /// A request to provide commands for the given text document and range.
        /// </summary>
        public static string TextDocumentCodeAction { get; } = "textDocument/codeAction";
        /// <summary>
        /// Request to resolve additional information for a given code action.The request's
        /// parameter is of type <see cref="CodeAction" /> the response
        /// is of type <see cref="CodeAction" /> or a Thenable that resolves to such.
        /// </summary>
        public static string CodeActionResolve { get; } = "codeAction/resolve";
        /// <summary>
        /// A request to list project-wide symbols matching the query string given
        /// by the <see cref="WorkspaceSymbolParams" />. The response is
        /// of type {@link SymbolInformation SymbolInformation[]} or a Thenable that
        /// resolves to such.
        /// 
        ///  need to advertise support for WorkspaceSymbols via the client capability
        ///  `workspace.symbol.resolveSupport`.
        /// </summary>
        [Since("3.17.0 - support for WorkspaceSymbol in the returned data. Clientsneed to advertise support for WorkspaceSymbols via the client capability`workspace.symbol.resolveSupport`.")]
        [Direction(MessageDirection.ClientToServer)]
        public static string WorkspaceSymbol { get; } = "workspace/symbol";
        /// <summary>
        /// A request to resolve the range inside the workspace
        /// symbol's location.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string WorkspaceSymbolResolve { get; } = "workspaceSymbol/resolve";
        /// <summary>
        /// A request to provide code lens for the given text document.
        /// </summary>
        public static string TextDocumentCodeLens { get; } = "textDocument/codeLens";
        /// <summary>
        /// A request to resolve a command for a given code lens.
        /// </summary>
        public static string CodeLensResolve { get; } = "codeLens/resolve";
        /// <summary>
        /// A request to refresh all code actions
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ServerToClient)]
        public static string WorkspaceCodeLensRefresh { get; } = "workspace/codeLens/refresh";
        /// <summary>
        /// A request to provide document links
        /// </summary>
        public static string TextDocumentDocumentLink { get; } = "textDocument/documentLink";
        /// <summary>
        /// Request to resolve additional information for a given document link. The request's
        /// parameter is of type <see cref="DocumentLink" /> the response
        /// is of type <see cref="DocumentLink" /> or a Thenable that resolves to such.
        /// </summary>
        public static string DocumentLinkResolve { get; } = "documentLink/resolve";
        /// <summary>
        /// A request to format a whole document.
        /// </summary>
        public static string TextDocumentFormatting { get; } = "textDocument/formatting";
        /// <summary>
        /// A request to format a range in a document.
        /// </summary>
        public static string TextDocumentRangeFormatting { get; } = "textDocument/rangeFormatting";
        /// <summary>
        /// A request to format ranges in a document.
        /// 
        /// </summary>
        [Proposed]
        [Since("3.18.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentRangesFormatting { get; } = "textDocument/rangesFormatting";
        /// <summary>
        /// A request to format a document on type.
        /// </summary>
        public static string TextDocumentOnTypeFormatting { get; } = "textDocument/onTypeFormatting";
        /// <summary>
        /// A request to rename a symbol.
        /// </summary>
        public static string TextDocumentRename { get; } = "textDocument/rename";
        /// <summary>
        /// A request to test and perform the setup necessary for a rename.
        /// 
        /// </summary>
        [Since("3.16 - support for default behavior")]
        [Direction(MessageDirection.ClientToServer)]
        public static string TextDocumentPrepareRename { get; } = "textDocument/prepareRename";
        /// <summary>
        /// A request send from the client to the server to execute a command. The request might return
        /// a workspace edit which the client will apply to the workspace.
        /// </summary>
        public static string WorkspaceExecuteCommand { get; } = "workspace/executeCommand";
        /// <summary>
        /// A request sent from the server to the client to modified certain resources.
        /// </summary>
        public static string WorkspaceApplyEdit { get; } = "workspace/applyEdit";
        /// <summary>
        /// The `workspace/didChangeWorkspaceFolders` notification is sent from the client to the server when the workspace
        /// folder configuration changes.
        /// </summary>
        public static string WorkspaceDidChangeWorkspaceFolders { get; } = "workspace/didChangeWorkspaceFolders";
        /// <summary>
        /// The `window/workDoneProgress/cancel` notification is sent from  the client to the server to cancel a progress
        /// initiated on the server side.
        /// </summary>
        public static string WindowWorkDoneProgressCancel { get; } = "window/workDoneProgress/cancel";
        /// <summary>
        /// The did create files notification is sent from the client to the server when
        /// files were created from within the client.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string WorkspaceDidCreateFiles { get; } = "workspace/didCreateFiles";
        /// <summary>
        /// The did rename files notification is sent from the client to the server when
        /// files were renamed from within the client.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string WorkspaceDidRenameFiles { get; } = "workspace/didRenameFiles";
        /// <summary>
        /// The will delete files request is sent from the client to the server before files are actually
        /// deleted as long as the deletion is triggered from within the client.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string WorkspaceDidDeleteFiles { get; } = "workspace/didDeleteFiles";
        /// <summary>
        /// A notification sent when a notebook opens.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string NotebookDocumentDidOpen { get; } = "notebookDocument/didOpen";
        public static string NotebookDocumentDidChange { get; } = "notebookDocument/didChange";
        /// <summary>
        /// A notification sent when a notebook document is saved.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string NotebookDocumentDidSave { get; } = "notebookDocument/didSave";
        /// <summary>
        /// A notification sent when a notebook closes.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [Direction(MessageDirection.ClientToServer)]
        public static string NotebookDocumentDidClose { get; } = "notebookDocument/didClose";
        /// <summary>
        /// The initialized notification is sent from the client to the
        /// server after the client is fully initialized and the server
        /// is allowed to send requests from the server to the client.
        /// </summary>
        public static string Initialized { get; } = "initialized";
        /// <summary>
        /// The exit event is sent from the client to the server to
        /// ask the server to exit its process.
        /// </summary>
        public static string Exit { get; } = "exit";
        /// <summary>
        /// The configuration change notification is sent from the client to the server
        /// when the client's configuration has changed. The notification contains
        /// the changed configuration as defined by the language client.
        /// </summary>
        public static string WorkspaceDidChangeConfiguration { get; } = "workspace/didChangeConfiguration";
        /// <summary>
        /// The show message notification is sent from a server to a client to ask
        /// the client to display a particular message in the user interface.
        /// </summary>
        public static string WindowShowMessage { get; } = "window/showMessage";
        /// <summary>
        /// The log message notification is sent from the server to the client to ask
        /// the client to log a particular message.
        /// </summary>
        public static string WindowLogMessage { get; } = "window/logMessage";
        /// <summary>
        /// The telemetry event notification is sent from the server to the client to ask
        /// the client to log telemetry data.
        /// </summary>
        public static string TelemetryEvent { get; } = "telemetry/event";
        /// <summary>
        /// The document open notification is sent from the client to the server to signal
        /// newly opened text documents. The document's truth is now managed by the client
        /// and the server must not try to read the document's truth using the document's
        /// uri. Open in this sense means it is managed by the client. It doesn't necessarily
        /// mean that its content is presented in an editor. An open notification must not
        /// be sent more than once without a corresponding close notification send before.
        /// This means open and close notification must be balanced and the max open count
        /// is one.
        /// </summary>
        public static string TextDocumentDidOpen { get; } = "textDocument/didOpen";
        /// <summary>
        /// The document change notification is sent from the client to the server to signal
        /// changes to a text document.
        /// </summary>
        public static string TextDocumentDidChange { get; } = "textDocument/didChange";
        /// <summary>
        /// The document close notification is sent from the client to the server when
        /// the document got closed in the client. The document's truth now exists where
        /// the document's uri points to (e.g. if the document's uri is a file uri the
        /// truth now exists on disk). As with the open notification the close notification
        /// is about managing the document's content. Receiving a close notification
        /// doesn't mean that the document was open in an editor before. A close
        /// notification requires a previous open notification to be sent.
        /// </summary>
        public static string TextDocumentDidClose { get; } = "textDocument/didClose";
        /// <summary>
        /// The document save notification is sent from the client to the server when
        /// the document got saved in the client.
        /// </summary>
        public static string TextDocumentDidSave { get; } = "textDocument/didSave";
        /// <summary>
        /// A document will save notification is sent from the client to the server before
        /// the document is actually saved.
        /// </summary>
        public static string TextDocumentWillSave { get; } = "textDocument/willSave";
        /// <summary>
        /// The watched files notification is sent from the client to the server when
        /// the client detects changes to file watched by the language client.
        /// </summary>
        public static string WorkspaceDidChangeWatchedFiles { get; } = "workspace/didChangeWatchedFiles";
        /// <summary>
        /// Diagnostics notification are sent from the server to the client to signal
        /// results of validation runs.
        /// </summary>
        public static string TextDocumentPublishDiagnostics { get; } = "textDocument/publishDiagnostics";
        public static string SetTrace { get; } = "$/setTrace";
        public static string LogTrace { get; } = "$/logTrace";
        public static string CancelRequest { get; } = "$/cancelRequest";
        public static string Progress { get; } = "$/progress";
    }
}