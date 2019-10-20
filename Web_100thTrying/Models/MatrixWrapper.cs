using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleMatrix;

namespace Web_100thTrying.Models
{
    public class MatrixWrapper
    {
        public Matrix matrix;
        public double[] b;
        public double[] x0;
        public double[] result;
        public bool have_result;

        public int n;
        public MatrixWrapper(Matrix A, double[] b, double[] x0)
        {
            matrix = A;
            this.b = b;
            this.x0 = x0;
            n = matrix.Rows;
            have_result = false;
        }
    }
}
