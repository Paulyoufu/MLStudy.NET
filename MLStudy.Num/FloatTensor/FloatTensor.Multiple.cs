﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MLStudy.Num
{
    public partial class FloatTensor
    {
        public override void MultipleLocal(float a)
        {
            TensorOperations.Instance.ApplyLocal(this, p => a * p);
        }

        public override Tensor<float> Multiple(float a)
        {
            var result = CreateSameShape();
            TensorOperations.Instance.Apply(this, ref result, p => a * p);
            return result;
        }

        public override Tensor<float> Multiple(Tensor<float> a)
        {
            var result = Tensor.Empty(Shape[0], a.Shape[1]);
            TensorOperations.Instance.Multiple(this, a, ref result);
            return result;
        }

        public override void MultipleElementWiseLocal(Tensor<float> a)
        {
            TensorOperations.Instance.ApplyLocal(this, a, (m, n) => m * n);
        }

        public override Tensor<float> MultipleElementWise(Tensor<float> a)
        {
            var result = a.CreateSameShape();
            TensorOperations.Instance.Apply(this, a, ref result, (m, n) => m * n);
            return result;
        }
    }
}
