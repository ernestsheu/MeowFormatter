// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record ClientCompletionItemOptions
    {
        [JsonConstructor]
        public ClientCompletionItemOptions(
            bool? snippetSupport = null,
            bool? commitCharactersSupport = null,
            ImmutableArray<MarkupKind> documentationFormat = default!,
            bool? deprecatedSupport = null,
            bool? preselectSupport = null,
            CompletionItemTagOptions? tagSupport = null,
            bool? insertReplaceSupport = null,
            ClientCompletionItemResolveOptions? resolveSupport = null,
            ClientCompletionItemInsertTextModeOptions? insertTextModeSupport = null,
            bool? labelDetailsSupport = null
        )
        {
            SnippetSupport = snippetSupport;
            CommitCharactersSupport = commitCharactersSupport;
            DocumentationFormat = documentationFormat;
            DeprecatedSupport = deprecatedSupport;
            PreselectSupport = preselectSupport;
            TagSupport = tagSupport;
            InsertReplaceSupport = insertReplaceSupport;
            ResolveSupport = resolveSupport;
            InsertTextModeSupport = insertTextModeSupport;
            LabelDetailsSupport = labelDetailsSupport;
        }
        /// <summary>
        /// Client supports snippets as insert text.
        /// 
        /// A snippet can define tab stops and placeholders with `$1`, `$2`
        /// and `${3:foo}`. `$0` defines the final tab stop, it defaults to
        /// the end of the snippet. Placeholders with equal identifiers are linked,
        /// that is typing in one will update others too.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "snippetSupport")]
        public bool? SnippetSupport { get; init; }
        /// <summary>
        /// Client supports commit characters on a completion item.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "commitCharactersSupport")]
        public bool? CommitCharactersSupport { get; init; }
        /// <summary>
        /// Client supports the following content formats for the documentation
        /// property. The order describes the preferred format of the client.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<MarkupKind>))]
        [DataMember(Name = "documentationFormat")]
        public ImmutableArray<MarkupKind> DocumentationFormat { get; init; }
        /// <summary>
        /// Client supports the deprecated property on a completion item.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "deprecatedSupport")]
        public bool? DeprecatedSupport { get; init; }
        /// <summary>
        /// Client supports the preselect property on a completion item.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "preselectSupport")]
        public bool? PreselectSupport { get; init; }
        /// <summary>
        /// Client supports the tag property on a completion item. Clients supporting
        /// tags have to handle unknown tags gracefully. Clients especially need to
        /// preserve unknown tags when sending a completion item back to the server in
        /// a resolve call.
        /// 
        /// </summary>
        [Since("3.15.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "tagSupport")]
        public CompletionItemTagOptions? TagSupport { get; init; }
        /// <summary>
        /// Client support insert replace edit to control different behavior if a
        /// completion item is inserted in the text or should replace text.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "insertReplaceSupport")]
        public bool? InsertReplaceSupport { get; init; }
        /// <summary>
        /// Indicates which properties a client can resolve lazily on a completion
        /// item. Before version 3.16.0 only the predefined properties `documentation`
        /// and `details` could be resolved lazily.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "resolveSupport")]
        public ClientCompletionItemResolveOptions? ResolveSupport { get; init; }
        /// <summary>
        /// The client supports the `insertTextMode` property on
        /// a completion item to override the whitespace handling mode
        /// as defined by the client (see `insertTextMode`).
        /// 
        /// </summary>
        [Since("3.16.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "insertTextModeSupport")]
        public ClientCompletionItemInsertTextModeOptions? InsertTextModeSupport { get; init; }
        /// <summary>
        /// The client has support for completion item label
        /// details (see also `CompletionItemLabelDetails`).
        /// 
        /// </summary>
        [Since("3.17.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "labelDetailsSupport")]
        public bool? LabelDetailsSupport { get; init; }
    }

}