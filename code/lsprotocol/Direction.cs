// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT


namespace Microsoft.LanguageServer.Protocol {
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Enum)]
    public class DirectionAttribute : Attribute
    {
        public DirectionAttribute(MessageDirection direction)
        {
            Direction = direction;
        }

        public MessageDirection Direction { get; }
    }
}
