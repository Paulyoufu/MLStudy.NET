﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MLStudy.Num
{
    //Add
    public partial class FloatTensor
    {
        public override void AddLocal(float a)
        {
            TensorOperations.Instance.ApplyLocal(this, p => p + a);
        }

        public override Tensor<float> Add(float a)
        {
            var result = CreateSameShape();
            TensorOperations.Instance.Apply(this, ref result, p => p + a);
            return result;
        }

        public override void AddLocal(Tensor<float> a)
        {
            TensorOperations.Instance.ApplyLocal(this, a, (m, n) => m + n);
        }

        public override Tensor<float> Add(Tensor<float> a)
        {
            var result = CreateSameShape();
            TensorOperations.Instance.Apply(this, a, ref result, (m, n) => m + n);
            return result;
        }
    }
}
