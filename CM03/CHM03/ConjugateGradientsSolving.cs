using System;

namespace CHM03
{
	public static class ConjugateGradientsSolving
	{
		private static Func<float[,], float[], float[], float[], float> tauFunc = 
			(a, ap, r, p) => (r[0] * p[0] + r[1] * p[1] + r[2] * p[2]) / (ap[0] * p[0] + ap[1] * p[1] + ap[2] * p[2]);
		private static Func<float[], float[], float[], float> bettaFunc = 
			(arNext, ap, p) => (arNext[0] * p[0] + arNext[1] * p[1] + arNext[2] * p[2]) / (ap[0] * p[0] + ap[1] * p[1] + ap[2] * p[2]);

		private static Func<float[,], float[], float[]> apFunc = 
			(a, p) => new []
		{
			a[0, 0] * p[0] + a[0, 1] * p[1] + a[0, 2] * p[2],
			a[1, 0] * p[0] + a[1, 1] * p[1] + a[1, 2] * p[2],
			a[2, 0] * p[0] + a[2, 1] * p[1] + a[2, 2] * p[2],
		};
		private static Func<float[,], float[], float[]> axNextFunc = 
			(a, xNext) => new[]
		{
			a[0, 0] * xNext[0] + a[0, 1] * xNext[1] + a[0, 2] * xNext[2],
			a[1, 0] * xNext[0] + a[1, 1] * xNext[1] + a[1, 2] * xNext[2],
			a[2, 0] * xNext[0] + a[2, 1] * xNext[1] + a[2, 2] * xNext[2],
		};
		private static Func<float[,], float[], float[]> arNextFunc = 
			(a, rNext) => new[]
		{
			a[0, 0] * rNext[0] + a[0, 1] * rNext[1] + a[0, 2] * rNext[2],
			a[1, 0] * rNext[0] + a[1, 1] * rNext[1] + a[1, 2] * rNext[2],
			a[2, 0] * rNext[0] + a[2, 1] * rNext[1] + a[2, 2] * rNext[2],
		};

		private static Func<float[], float[], float, float[]> xNextFunc = 
			(x, p, tau) => new[]
		{
			x[0] - tau * p[0],
			x[1] - tau * p[1],
			x[2] - tau * p[2]
		};
		private static Func<float[], float[], float, float[]> pNextFunc = 
			(rNext, p, betta) => new[]
		{
			rNext[0] - betta * p[0],
			rNext[1] - betta * p[1],
			rNext[2] - betta * p[2]
		};
		private static Func<float[], float[], float[]> rNextFunc =
			(axNext, z) => new[]
		{
			axNext[0] - z[0],
			axNext[1] - z[1],
			axNext[2] - z[2]
		};

		private static Func<float[], float> rCheckFunc = 
			r => (float) Math.Sqrt(r[0] * r[0] + r[1] * r[1] + r[2] * r[2]);
		private static Func<float[], float[], float> xCheckFunc = 
			(x, xNext) => (float)Math.Sqrt((x[0] - xNext[0]) * (x[0] - xNext[0]) + (x[1] - xNext[1]) * (x[1] - xNext[1]) + (x[2] - xNext[2]) * (x[2] - xNext[2]));

		public static void Solve(float eps, float[,] a, float[] z, out float[] x, out int iterCount)
		{
			x = new float[3];
			iterCount = 0;

			var xNext = new[] { 0f, 0f, 0f };
			var rNext = rNextFunc(axNextFunc(a, xNext), z);
			var pNext = rNext;

			do
			{
				x = xNext;
				var r = rNext;
				var p = pNext;

				var ap = apFunc(a, p);
				var tau = tauFunc(a, ap, r, p);
				xNext = xNextFunc(x, p, tau);
				rNext = rNextFunc(axNextFunc(a, xNext), z);
				var betta = bettaFunc(arNextFunc(a, rNext), ap, p);
				pNext = pNextFunc(rNext, p, betta);
				iterCount++;
			}
			while (rCheckFunc(rNext) >= eps || xCheckFunc(x, xNext) >= eps);
			x = xNext;
		}
	}
}
