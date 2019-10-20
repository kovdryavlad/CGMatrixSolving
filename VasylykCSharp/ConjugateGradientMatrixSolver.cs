using System;
using SimpleMatrix;

namespace VasylykCSharp
{
    public class ConjugateGradientMatrixSolver
    {
        public Vector Solve(Matrix A, Vector b, Vector x)
        {
            Vector r = b - A.MultiplyOnVectorColumn(x);
            Vector p = (Vector)r.Clone();
            double r_dot = r*r;

            for (int i = 0; i < b.Length; i++)
            {
                Vector Ap = A.MultiplyOnVectorColumn(p);
                double alpha = r_dot / (p * Ap);

                x = x + alpha * p;
                Vector r_next = r - alpha * Ap;

                //stop condition
                if (All(r_next, value => Math.Abs(value) < 1e-6))
                    break;

                r = r_next;
                double r_dot_next = r*r;

                double beta = r_dot_next / r_dot;
                p = r + beta * p;

                //next iteration
                r_dot = r_dot_next;
            }

            return x;
        }

        //returns predicate status for all elements of Vetor
        bool All(Vector v, Predicate<double> predicate)
        {
            bool result = false;
         
            for (int i = 0; i < v.Length; i++)
            {
                if (!predicate(v[i]))
                    break;

                if (i == v.Length - 1)
                    result = true;
            }


            return result;
        }

    }
}