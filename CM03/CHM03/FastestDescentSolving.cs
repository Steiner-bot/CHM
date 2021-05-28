using System;
namespace CHM03
{
	public static class FastestDescentSolving
	{
		private static Func<float[], float[], float> tauFunc = 
			(ar, r) => (r[0] * r[0] + r[1] * r[1] + r[2] * r[2]) / (ar[0] * r[0] + ar[1] * r[1] + ar[2] * r[2]);

		private static Func<float[,], float[], float[]> axFunc = 
			(a, x) => new[]
		{
			a[0, 0] * x[0] + a[0, 1] * x[1] + a[0, 2] * x[2],
			a[1, 0] * x[0] + a[1, 1] * x[1] + a[1, 2] * x[2],
			a[2, 0] * x[0] + a[2, 1] * x[1] + a[2, 2] * x[2],
		};
		private static Func<float[,], float[], float[]> arFunc = 
			(a, r) => new[]
		{
			a[0, 0] * r[0] + a[0, 1] * r[1] + a[0, 2] * r[2],
			a[1, 0] * r[0] + a[1, 1] * r[1] + a[1, 2] * r[2],
			a[2, 0] * r[0] + a[2, 1] * r[1] + a[2, 2] * r[2],
		};

		private static Func<float[], float[], float, float[]> xNextFunc = 
			(x, r, tau) => new[]
		{
			x[0] - tau * r[0],
			x[1] - tau * r[1],
			x[2] - tau * r[2]
		};
		private static Func<float[], float[], float[]> rNextFunc =
			(ax, z) => new[]
		{
			ax[0] - z[0],
			ax[1] - z[1],
			ax[2] - z[2]
		};


		private static Func<float[], float> rCheckFunc = 
			r => (float)Math.Sqrt(r[0] * r[0] + r[1] * r[1] + r[2] * r[2]);
		private static Func<float[], float[], float> xCheckFunc = 
			(x, xNext) => (float)Math.Sqrt((x[0] - xNext[0]) * (x[0] - xNext[0]) + (x[1] - xNext[1]) * (x[1] - xNext[1]) + (x[2] - xNext[2]) * (x[2] - xNext[2]));

		public static void Solve(float eps, float[,] a, float[] z, out float[] x, out int iterCount)
		{
			iterCount = 0;

			var nextX = new[] { 0f, 0f, 0f };
			var nextR = new[] { 0f, 0f, 0f };
			do
			{
				nextR = rNextFunc(axFunc(a, nextX), z);
				x = nextX;
				var r = nextR;
				var tau = tauFunc(arFunc(a, r), r);
				nextX = xNextFunc(x, r, tau);
				iterCount++;
			} while (rCheckFunc(nextR) >= eps || xCheckFunc(x, nextX) >= eps);
		}
	}
}
