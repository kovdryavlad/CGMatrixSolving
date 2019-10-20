using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_100thTrying.Models;
using SimpleMatrix;
using VasylykCSharp;

namespace Web_100thTrying.Controllers
{
    public class CGController : Controller
    {
        [HttpGet]
        public IActionResult Index(int n = 2)
        {
            Matrix matrix = new Matrix(n, n);
            MatrixWrapper matrixWrapper = new MatrixWrapper(matrix, new double[n], new double[n]);

            return View(matrixWrapper);
        }

        [HttpGet]
        public IActionResult Example1()
        {
            int n = 2;
            Matrix matrix = new Matrix(n, n, new double[] {

                 2, -1,
                -1,  2

            });

            double[] b = new double[] { 1, 0 };
            double[] x0 = new double[n];

            MatrixWrapper mw = new MatrixWrapper(matrix, b, x0);
            return View("Index", mw);
        }

        [HttpGet]
        public IActionResult Example2()
        {
            int n = 3;
            Matrix matrix = new Matrix(n, n, new double[] {

                 4,    -1,     1,
                -1,     4,    -2,
                 1,    -2,     4,

            });

            double[] b = new double[] { 12, -1, 5 };
            double[] x0 = new double[n];

            MatrixWrapper mw = new MatrixWrapper(matrix, b, x0);
            return View("Index", mw);
        }

        [HttpPost]
        public IActionResult Index(double[] numbers, double[] b, int n)
        {
            Matrix m = new Matrix(n, n, numbers);
            ConjugateGradientMatrixSolver solver = new ConjugateGradientMatrixSolver();
            Vector v = solver.Solve(m, new Vector(b), new Vector(new double[n]));

            MatrixWrapper matrixWrapper = new MatrixWrapper(m, new double[n], new double[n]);
            matrixWrapper.have_result = true;
            matrixWrapper.result = v.GetCloneOfData();
            matrixWrapper.b = b;

            return View(matrixWrapper);

        }


    }
}