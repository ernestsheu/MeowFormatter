// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Represents programming constructs like variables, classes, interfaces etc.
    /// that appear in a document. Document symbols can be hierarchical and they
    /// have two ranges: one that encloses its definition and one that points to
    /// its most interesting range, e.g. the range of an identifier.
    /// </summary>
    [DataContract]
    public record DocumentSymbol
    {
        [JsonConstructor]
        public DocumentSymbol(
            string name,
            SymbolKind kind,
            Range range,
            Range selectionRange,
            string? detail = null,
            ImmutableArray<SymbolTag> tags = default!,
            bool? deprecated = null,
            ImmutableArray<DocumentSymbol> children = default!
        )
        {
            Name = name;
            Detail = detail;
            Kind = kind;
            Tags = tags;
            Deprecated = deprecated;
            Range = range;
            SelectionRange = selectionRange;
            Children = children;
        }
        /// <summary>
        /// The name of this symbol. Will be displayed in the user interface and therefore must not be
        /// an empty string or a string only consisting of white spaces.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; init; }
        /// <summary>
        /// More detail for this symbol, e.g the signature of a function.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "detail")]
        public string? Detail { get; init; }
        /// <summary>
        /// The kind of this symbol.
        /// </summary>
        [DataMember(Name = "kind")]
        public SymbolKind Kind { get; init; }
        /// <summary>
        /// Tags for this document symbol.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [JsonConverter(typeof(CustomArrayConverter<SymbolTag>))]
        [DataMember(Name = "tags")]
        public ImmutableArray<SymbolTag> Tags { get; init; }
        /// <summary>
        /// Indicates if this symbol is deprecated.
        /// 
        /// </summary>
        [Obsolete("Use tags instead")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "deprecated")]
        public bool? Deprecated { get; init; }
        /// <summary>
        /// The range enclosing this symbol not including leading/trailing whitespace but everything else
        /// like comments. This information is typically used to determine if the clients cursor is
        /// inside the symbol to reveal in the symbol in the UI.
        /// </summary>
        [DataMember(Name = "range")]
        public Range Range { get; init; }
        /// <summary>
        /// The range that should be selected and revealed when this symbol is being picked, e.g the name of a function.
        /// Must be contained by the `range`.
        /// </summary>
        [DataMember(Name = "selectionRange")]
        public Range SelectionRange { get; init; }
        /// <summary>
        /// Children of this symbol, e.g. properties of a class.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<DocumentSymbol>))]
        [DataMember(Name = "children")]
        public ImmutableArray<DocumentSymbol> Children { get; init; }
    }

}
