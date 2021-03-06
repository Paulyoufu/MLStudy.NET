﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MLStudy.Num
{
    public partial class FloatTensor
    {
        public override void DivideLocal(float a)
        {
            TensorOperations.Instance.ApplyLocal(this, p => p / a);
        }

        public override Tensor<float> Divide(float a)
        {
            var result = CreateSameShape();
            TensorOperations.Instance.Apply(this, ref result, p => p / a);
            return result;
        }

        public override void DivideByLocal(float a)
        {
            TensorOperations.Instance.ApplyLocal(this, p => a / p);
        }

        public override Tensor<float> DivideBy(float a)
        {
            var result = CreateSameShape();
            TensorOperations.Instance.Apply(this, ref result, p => a / p);
            return result;
        }

        public override void DivideElementWiseLocal(Tensor<float> a)
        {
            TensorOperations.Instance.ApplyLocal(this, a, (m, n) => m / n);
        }

        public override Tensor<float> DivideElementWise(Tensor<float> a)
        {
            var result = a.CreateSameShape();
            TensorOperations.Instance.Apply(this, a, ref result, (m, n) => m / n);
            return result;
        }
    }
}
