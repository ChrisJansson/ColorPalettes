﻿using System;
using System.Linq;
using ColorPalettes;
using NUnit.Framework;
using FluentAssertions;

namespace Tests
{
    [TestFixture]
    public class Matrix3Tests
    {
        [Test]
        public void Multiplying_vector_with_identity_matrix_should_return_vector()
        {
            var matrix = Matrix3.Identity;
            var vector = new Vector3(1, 2, 3);

            var newVector = matrix * vector;
            newVector.ShouldBeEquivalentTo(vector);
        }

        [Test]
        public void Multiplying_vector_with_matrix_should_return_correct_vector()
        {
            var matrix = new Matrix3(new double[,]
                {
                    {1, 2, 3},
                    {11, 22, 33},
                    {111, 222, 333}
                });

            var vector = new Vector3(1, 2, 3);

            var result = matrix * vector;

            result.X.Should().Be(14);
            result.Y.Should().Be(154);
            result.Z.Should().Be(1554);
        }

        [Test]
        public void Cannot_construct_matrix_with_array_that_is_not_3x3()
        {
            var dimensions = from rows in Enumerable.Range(0, 10)
                             from columns in Enumerable.Range(0, 10)
                             where rows != 3 && columns != 3
                             select new {rows, columns};

            foreach (var dimension in dimensions)
            {
                var dimension1 = dimension;
                Action act = () => new Matrix3(new double[dimension1.rows,dimension1.columns]);

                act.ShouldThrow<Exception>();
            }
        }

        [Test]
        public void Transposes_matrix_correctly()
        {
            var matrix = new Matrix3(new double[,]
                {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                });

            var expectedTranspose = new Matrix3(new double[,]
                {
                    {1, 4, 7},
                    {2, 5, 8},
                    {3, 6, 9}
                });

            var transposed = matrix.Transposed();

            AssertMatricesAreEqual(expectedTranspose, transposed);
        }

        [Test]
        public void Are_equal_returns_false_for_matrices_that_are_not_equal()
        {
            var left = new Matrix3(new double[,]
                {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                });

            var right = new Matrix3(new double[,]
                {
                    {1, 4, 7},
                    {2, 5, 8},
                    {3, 6, 9}
                });

            left.Should().NotBe(right);
        }

        [Test]
        public void Are_equal_returns_true_for_matrices_that_are_equal()
        {
            var left = new Matrix3(new double[,]
                {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                });

            var right = new Matrix3(new double[,]
                {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                });

            left.Should().Be(right);
        }

        private void AssertMatricesAreEqual(Matrix3 expected, Matrix3 actual)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var expectedValue = expected[i, j];
                    actual[i, j].Should().Be(expectedValue);
                }
            }
        }
    }
}