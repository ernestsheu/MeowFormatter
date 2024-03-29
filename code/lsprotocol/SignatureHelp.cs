// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Signature help represents the signature of something
    /// callable. There can be multiple signature but only one
    /// active and only one active parameter.
    /// </summary>
    [DataContract]
    public record SignatureHelp
    {
        [JsonConstructor]
        public SignatureHelp(
            ImmutableArray<SignatureInformation> signatures,
            long? activeSignature = null,
            long? activeParameter = null
        )
        {
            Signatures = signatures;
            ActiveSignature = activeSignature;
            ActiveParameter = activeParameter;
        }
        /// <summary>
        /// One or more signatures.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<SignatureInformation>))]
        [DataMember(Name = "signatures")]
        public ImmutableArray<SignatureInformation> Signatures { get; init; }
        /// <summary>
        /// The active signature. If omitted or the value lies outside the
        /// range of `signatures` the value defaults to zero or is ignored if
        /// the `SignatureHelp` has no signatures.
        /// 
        /// Whenever possible implementors should make an active decision about
        /// the active signature and shouldn't rely on a default value.
        /// 
        /// In future version of the protocol this property might become
        /// mandatory to better express this.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "activeSignature")]
        public long? ActiveSignature { get => activeSignature; set => activeSignature = Validators.validUInteger(value); }
        private long? activeSignature;
        /// <summary>
        /// The active parameter of the active signature.
        /// 
        /// If `null`, no parameter of the signature is active (for example a named
        /// argument that does not match any declared parameters). This is only valid
        /// if the client specifies the client capability
        /// `textDocument.signatureHelp.noActiveParameterSupport === true`
        /// 
        /// If omitted or the value lies outside the range of
        /// `signatures[activeSignature].parameters` defaults to 0 if the active
        /// signature has parameters.
        /// 
        /// If the active signature has no parameters it is ignored.
        /// 
        /// In future version of the protocol this property might become
        /// mandatory (but still nullable) to better express the active parameter if
        /// the active signature does have any.
        /// </summary>
        [DataMember(Name = "activeParameter")]
        public long? ActiveParameter { get; init; }
    }

}
