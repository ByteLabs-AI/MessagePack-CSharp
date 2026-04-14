// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if !UNITY_2018_3_OR_NEWER

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MessagePack.Tests
{
    public class DynamicObjectFallbackTest
    {

        [Fact]
        public void FallbackObjectType()
        {
            var data = new DynamicObjectFallbackTestContainer
            {
                MyProperty = 3,
                MoreObject = 10,
            };

            var bytes = MessagePackSerializer.Serialize(data);

            dynamic obj = MessagePackSerializer.Deserialize<object>(bytes);

            object v = obj[1];

            v.GetType().Is(typeof(int));
        }

        [Theory]
        [InlineData((bool)true)]
        [InlineData((byte)1)]
        [InlineData((sbyte)1)]
        [InlineData((short)-4)]
        [InlineData((ushort)4)]
        [InlineData((int)3)]
        [InlineData((UInt32)4)]
        [InlineData((long)2)]
        [InlineData((UInt64)6)]
        [InlineData((float)1f)]
        [InlineData((double)12)]
        [InlineData("hogehoge")]
        public void SerializePrimitiveObjectShouldKeepType<T>(T value)
        {
            var bin = MessagePackSerializer.Serialize<object>(value);
            var v = MessagePackSerializer.Deserialize<object>(bin);

            v.GetType().Is(typeof(T));
            v.ToString().Is(value.ToString());
        }

        [MessagePackObject]
        public class DynamicObjectFallbackTestContainer
        {
            [Key(0)]
            public int MyProperty { get; set; }

            [Key(1)]
            public object MoreObject { get; set; }
        }
    }
}

#endif
