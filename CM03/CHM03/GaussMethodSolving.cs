namespace CHM03
{
	public static class GaussMethodSolving
	{
		public static void Solve(float[,] a, float[] z, out float[] x)
		{
			x = new float[3];
			var t = new float[a.GetLength(0), a.GetLength(1) + 1];
			for (var i = 0; i < a.GetLength(0); i++)
				for (var j = 0; j < a.GetLength(1); j++)
					t[i, j] = a[i, j];
			for (var i = 0; i < z.Length; i++)
				t[i, a.GetLength(1)] = z[i];
			SubtractRow(t, 2, 0, 0);
			SubtractRow(t, 1, 0, 0);
			SubtractRow(t, 2, 1, 1);
			x[2] = t[2, 3] / t[2, 2];
			SubtractRow(t, 1, 2, 2);
			x[1] = t[1, 3] / t[1, 1];
			SubtractRow(t, 0, 1, 1);
			SubtractRow(t, 0, 2, 2);
			x[0] = t[0, 3] / t[0, 0];
		}

		private static void SubtractRow(float[,] system, int rowIndex1, int rowIndex2, int columnIndexToZero)
		{
			var multiply = system[rowIndex1, columnIndexToZero] / system[rowIndex2, columnIndexToZero];
			for (var j = 0; j < system.GetLength(1); j++)
				system[rowIndex1, j] -= system[rowIndex2, j] * multiply;
			system[rowIndex1, columnIndexToZero] = 0;
		}
	}
}
