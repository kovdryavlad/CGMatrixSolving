using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMatrix;

namespace VasylykCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Example3();
        }

        static void Example1() {
            ConjugateGradientMatrixSolver solver = new ConjugateGradientMatrixSolver();
            Matrix A = new Matrix(3, 3, new double[] {

                 4,    -1,     1,
                -1,     4,    -2,
                 1,    -2,     4,

            });

            Vector b = new Vector(new double[] { 12, -1, 5 });
            Vector x = new Vector(new double[] { 0, 0, 0 });


            Vector res = solver.Solve(A, b, x);
        }

        static void Example2()
        {
            ConjugateGradientMatrixSolver solver = new ConjugateGradientMatrixSolver();
            Matrix A = new Matrix(2, 2, new double[] {

                 2,    -1,
                -1,     2

            });

            Vector b = new Vector(new double[] { 1, 0});
            Vector x = new Vector(new double[] { 0, 0 });


            Vector res = solver.Solve(A, b, x);
        }

        //From Wiki
        static void Example3()
        {
            ConjugateGradientMatrixSolver solver = new ConjugateGradientMatrixSolver();
            Matrix A = new Matrix(2, 2, new double[] {

                 4,     1,
                 1,     3

            });

            Vector b = new Vector(new double[] { 1, 2 });
            Vector x = new Vector(new double[] { 2, 1 });


            Vector res = solver.Solve(A, b, x);
        }
    }
}
/*

    class ConjugateGradientMatrixSolver:
    @staticmethod
    def Solve(A, b, x):
        f_abs = lambda x: abs(x)

        r = b - A.dot(x)
        p = r
        r_dot = r.dot(r)
        
        for i in range(0, len(b)):
            Ap = A.dot(p)
            alpha = r_dot / (p.dot(Ap))

            x = x + alpha*p
            r_next = r - alpha*Ap

            if(all(f_abs(r_next) < 1e-6)):
                break

            r = r_next
            r_dot_next = r.dot(r);

            beta = r_dot_next / r_dot
            p = r + beta*p;

            #next iteration
            r_dot = r_dot_next
        return x
 
     
     
*/
