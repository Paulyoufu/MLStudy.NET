﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MLStudy.Num
{
    public partial class FloatTensor
    {
        public override void MinusLocal(float a)
        {
            TensorOperations.Instance.ApplyLocal(this, p => p - a);
        }

        public override Tensor<float> Minus(float a)
        {
            var result = CreateSameShape();
            TensorOperations.Instance.Apply(this, ref result, p => p - a);
            return result;
        }

        public override void MunusByLocal(float a)
        {
            TensorOperations.Instance.ApplyLocal(this, p => a - p);
        }

        public override Tensor<float> MinusBy(float a)
        {
            var result = CreateSameShape();
            TensorOperations.Instance.Apply(this, ref result, p => a - p);
            return result;
        }

        public override void MinusLocal(Tensor<float> a)
        {
            TensorOperations.Instance.ApplyLocal(this, a, (m, n) => m - n);
        }

        public override Tensor<float> Minus(Tensor<float> a)
        {
            var result = CreateSameShape();
            TensorOperations.Instance.Apply(this, a, ref result, (m, n) => m - n);
            return result;
        }
    }
}
