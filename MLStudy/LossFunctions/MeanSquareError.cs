﻿/*
 * Description:使用最小二乘的损失函数
 * Author:Yunxiao An
 * Date:2018.11.19
 */

using MLStudy.Abstraction;
using System;

namespace MLStudy
{
    /// <summary>
    /// 使用最小二乘的损失函数
    /// </summary>
    public sealed class MeanSquareError: LossFunction
    {
        /// <summary>
        /// 训练前的准备工作，检查并确定所需Tensor的结构并分配好内存
        /// </summary>
        /// <param name="y">样本标签</param>
        /// <param name="yHat">输出标签</param>
        public override void PrepareTrain(TensorOld y, TensorOld yHat)
        {
            TensorOld.CheckShape(y, yHat);

            ForwardOutput = y.GetSameShape();
            BackwardOutput = y.GetSameShape();
        }

        /// <summary>
        /// 计算Loss和Loss对yHat的导数（梯度）
        /// </summary>
        /// <param name="y"></param>
        /// <param name="yHat"></param>
        public override void Compute(TensorOld y, TensorOld yHat)
        {
            //只记录了平方误差，使用GetLoss可获取均方误差
            Functions.SquareError(y, yHat, ForwardOutput);
            Derivatives.MeanSquareError(y, yHat, BackwardOutput);
        }

        /// <summary>
        /// 根据预测值和真实值返回Loss
        /// </summary>
        /// <param name="y">真实值</param>
        /// <param name="yHat">预测值</param>
        /// <returns>Loss</returns>
        public override double GetLoss(TensorOld y, TensorOld yHat)
        {
            return Functions.MeanSquareError(y, yHat);
        }

        public override double GetAccuracy()
        {
            return Math.Sqrt(ForwardOutput.Mean());
        }

        public override double GetAccuracy(TensorOld y, TensorOld yHat)
        {
            var mse = Functions.MeanSquareError(y, yHat);
            return Math.Sqrt(mse);
        }
    }
}
