﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MLStudy
{
    public partial class TensorOld
    {
        /// <summary>
        /// 当前Tensor的每个元素减去d，结果保存在当前Tensor中
        /// </summary>
        /// <param name="d">要减去的数值</param>
        /// <returns>当前Tensor</returns>
        public TensorOld Minus(double d)
        {
            Apply(a => a - d);
            return this;
        }

        /// <summary>
        /// 用d减去当前Tensor的每个元素，结果保存在当前Tensor中
        /// </summary>
        /// <param name="d">被减数</param>
        /// <returns>当前Tensor</returns>
        public TensorOld MinusBy(double d)
        {
            Apply(a => d - a);
            return this;
        }

        /// <summary>
        /// 当前Tensor和t中相应的元素相见，结果保存在当前Tensor中
        /// </summary>
        /// <param name="t">被减去的Tensor</param>
        /// <returns>当前Tensor</returns>
        public TensorOld Minus(TensorOld t)
        {
            if (t.ElementCount == 1)
                return Minus(t.GetValue());

            CheckShape(shape, t.shape);

            Minus(this, t, this);
            return this;
        }

        /// <summary>
        /// t的每个元素减去d，结果返回为新的Tensor
        /// </summary>
        /// <param name="t">被减数</param>
        /// <param name="d">减数</param>
        /// <returns>包含结果的新的Tensor</returns>
        public static TensorOld Minus(TensorOld t, double d)
        {
            var result = t.GetSameShape();
            Minus(t, d, result);
            return result;
        }

        /// <summary>
        /// 用d减去t的每个元素减去d，结果返回为新的Tensor
        /// </summary>
        /// <param name="d">被减数</param>
        /// <param name="t">减数</param>
        /// <returns>包含结果的新的Tensor</returns>
        public static TensorOld Minus(double d, TensorOld t)
        {
            return t.Clone().MinusBy(d);
        }

        /// <summary>
        /// 两个Tensor对应元素相减，结果返回为新的Tensor，要求两个Tensor结构相同.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TensorOld Minus(TensorOld a, TensorOld b)
        {
            if (a.ElementCount == 1)
                return Minus(a.GetValue(), b);
            if (b.ElementCount == 1)
                return Minus(a, b.GetValue());

            CheckShape(a, b);
            var result = a.GetSameShape();
            Minus(a, b, result);
            return result;
        }

        /// <summary>
        /// Tensor减去d，结果存入result
        /// </summary>
        /// <param name="t">被减数</param>
        /// <param name="d">减数</param>
        /// <param name="result">结果</param>
        public static void Minus(TensorOld t, double d, TensorOld result)
        {
            Apply(t, result, a => a - d);
        }

        /// <summary>
        /// a和b相减，结果写入result参数
        /// 必要的时候在调用这个方法前进行Tensor结构一致性检查
        /// </summary>
        /// <param name="a">被减数</param>
        /// <param name="b">减数</param>
        /// <param name="result">结果</param>
        public static void Minus(TensorOld a, TensorOld b, TensorOld result)
        {
            Apply(a, b, result, (x, y) => x - y);
        }

        public static TensorOld operator -(TensorOld t, double d)
        {
            return Minus(t, d);
        }

        public static TensorOld operator -(double d, TensorOld t)
        {
            return Minus(d, t);
        }

        public static TensorOld operator -(TensorOld a, TensorOld b)
        {
            return Minus(a, b);
        }
    }
}
