﻿using MLStudy.Deep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MLStudy.Tests.Deep
{
    public class SoftmaxTests
    {
        [Fact]
        public void FunctionTest()
        {
            var data = new double[] { 10, 8, -4, 9, -2, 5, 3, 6 };
            var tensor = new Tensor(data);
            var output = MLStudy.Deep.Softmax.Function(data);
            var tensorOut = MLStudy.Deep.Softmax.Function(tensor);

            Assert.True(output.Sum() > 0.9999);
            Assert.True(tensorOut.Sum() > 0.9999);

            var max = output.Max();
            var min = output.Min();
            Assert.Equal(max, output[0]);
            Assert.Equal(min, output[2]);
        }

        [Fact]
        public void DerivativeTest()
        {
            var output = new Tensor(new double[] { 0.05, 0.15, 0.7, 0.1});
            var expected = new Tensor(new double[,]
            { { 0.0475, -0.0075, -0.035, -0.005} ,
              { -0.0075, 0.1275, -0.105, -0.015},
              { -0.035, -0.105, 0.21, -0.07},
              { -0.005, -0.015, -0.07, 0.09 } });
            var actual = MLStudy.Deep.Softmax.DerivativeByOutput(output);
            MyAssert.ApproximatelyEqual(expected, actual);
        }

        [Fact]
        public void ForwadBackwardTest()
        {
            var input = new Tensor(new double[] { 7, 9, 1, -1, 2, -7, 2, 4, 7, 8, 4, -1 }, 3, 4);
            var y = new Tensor(new double[] { 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 }, 3, 4); //第1个样本正确，第2，3个样本错误
            var soft = new MLStudy.Deep.Softmax();
            var output = soft.Forward(input);
            var error = Tensor.DivideElementWise(y, output) * -1;
            var actual = soft.Backward(error);
            var expected = output - y; //推导出来的结果，因为要把softmax和损失函数分离，所以实际应用时要分别计算

            //存在精度问题，有些值无法完全相等
            MyAssert.ApproximatelyEqual(expected, actual);
        }
    }
}