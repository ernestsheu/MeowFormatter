// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT


namespace Microsoft.LanguageServer.Protocol {

    using System;

    public static class Validators
    {
        public static bool HasType(Type[] types, Type type)
        {
            return types.Contains(type);
        }

        public static bool InIntegerRange(long value)
        {
            return value >= int.MinValue && value <= int.MaxValue;
        }

        public static bool InUIntegerRange(long value)
        {
            return value >= uint.MinValue && value <= uint.MaxValue;
        }

        public static long? validUInteger(long? value){
            if(value == null){
                return null;
            }

            if (Validators.InUIntegerRange((long)value))
            {
                return value;
            }
            throw new ArgumentOutOfRangeException("value", value, "Value is not in the range of LSP uinteger");
        }

        public static long validUInteger(long value){
            if (Validators.InUIntegerRange(value))
            {
                return value;
            }
            throw new ArgumentOutOfRangeException("value", value, "Value is not in the range of LSP uinteger");
        }
    }
}
