﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MLStudy.Abstraction
{
    public interface IOptimizable
    {
        void UseOptimizer(IOptimizer optimizer);
        void Optimize();
    }
}
