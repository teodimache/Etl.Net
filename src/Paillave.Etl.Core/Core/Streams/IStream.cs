﻿using Paillave.RxPush.Core;
using System;
using System.Collections.Generic;

namespace Paillave.Etl.Core.Streams
{
    public interface IStream<T>
    {
        IPushObservable<T> Observable { get; }
        IExecutionContext ExecutionContext { get; }
        string Name { get; }
        string SourceNodeName { get; }
    }
}