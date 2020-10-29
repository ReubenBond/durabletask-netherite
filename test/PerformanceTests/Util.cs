﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace PerformanceTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Http;

    class Util
    {
        internal static string MakeTestName(HttpRequest req)
        {
            string benchmarkname = req.Path.Value.Remove(0, 1);
            string where = Environment.MachineName.Substring(0, 2);
            string time = DateTime.UtcNow.ToString("o");
#if DEBUG
            string config = "dbg";
#else
            string config = "rel";
#endif
            return string.Format($"{benchmarkname}-{where}-{config}-{time}");
        }
    }
}
