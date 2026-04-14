// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NET

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using Xunit;

#pragma warning disable SA1302 // Interface names should begin with I
#pragma warning disable SA1403 // File may only contain a single namespace

public class AssemblyLoadContextTests : IDisposable
{
    private readonly AssemblyLoadContext loadContext = new AssemblyLoadContext("TestContext", isCollectible: true);

    public void Dispose()
    {
        this.loadContext.Unload();
    }

    private MessagePackSerializerOptions CreateSerializerOptions()
    {
        // Avoid default options as it will use source generated formatter which works in this scenario.
        return new MessagePackSerializerOptions(
            CompositeResolver.Create(
                BuiltinResolver.Instance,
                AttributeFormatterResolver.Instance,
                DynamicEnumResolver.Instance,
                DynamicGenericResolver.Instance,
                DynamicUnionResolver.Instance,
                DynamicObjectResolver.Instance,
                PrimitiveObjectResolver.Instance));
    }
}

#endif
