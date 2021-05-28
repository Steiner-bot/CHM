using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHM03
{
	public partial class Form1 : Form
	{
		private float[,] A =
		{
			{ 2.7f, 3.3f, 1.3f },
			{ 3.5f, -1.7f, 2.8f },
			{ 4.1f, 5.8f, -1.7f },
		};
		private float[] Z =
		{
			2.1f,
			1.7f,
			0.8f
		};
		private float[,] AmT =
		{
			{ 36.35f, 26.74f, 6.34f },
			{ 26.74f, 47.42f, -10.33f },
			{ 6.34f, -10.33f, 12.42f }
		};
		private float[] ZmT =
		{
			14.9f,
			8.68f,
			6.13f
		};

		public Form1()
		{
			InitializeComponent();

			GaussMethodSolving.Solve(A, Z, out var x);
			lblGauss.Text = $"Метод Гаусса: x1 = {x[0].ToString("0.0000000")}; x2 = {x[1].ToString("0.0000000")}; x3 = {x[2].ToString("0.0000000")}";

			FastestDescentSolving.Solve(1e-2f, AmT, ZmT, out x, out var iterCount);
			lblX112.Text = x[0].ToString("0.0000000");
			lblX122.Text = x[1].ToString("0.0000000");
			lblX132.Text = x[2].ToString("0.0000000");
			lblIterCount12.Text = iterCount.ToString();
			FastestDescentSolving.Solve(1e-3f, AmT, ZmT, out x, out iterCount);
			lblX113.Text = x[0].ToString("0.0000000");
			lblX123.Text = x[1].ToString("0.0000000");
			lblX133.Text = x[2].ToString("0.0000000");
			lblIterCount13.Text = iterCount.ToString();
			FastestDescentSolving.Solve(1e-4f, AmT, ZmT, out x, out iterCount);
			lblX114.Text = x[0].ToString("0.0000000");
			lblX124.Text = x[1].ToString("0.0000000");
			lblX134.Text = x[2].ToString("0.0000000");
			lblIterCount14.Text = iterCount.ToString();
			FastestDescentSolving.Solve(1e-5f, AmT, ZmT, out x, out iterCount);
			lblX115.Text = x[0].ToString("0.0000000");
			lblX125.Text = x[1].ToString("0.0000000");
			lblX135.Text = x[2].ToString("0.0000000");
			lblIterCount15.Text = iterCount.ToString();
			FastestDescentSolving.Solve(1e-6f, AmT, ZmT, out x, out iterCount);
			lblX116.Text = x[0].ToString("0.0000000");
			lblX126.Text = x[1].ToString("0.0000000");
			lblX136.Text = x[2].ToString("0.0000000");
			lblIterCount16.Text = iterCount.ToString();
			FastestDescentSolving.Solve(1e-7f, AmT, ZmT, out x, out iterCount);
			lblX117.Text = x[0].ToString("0.0000000");
			lblX127.Text = x[1].ToString("0.0000000");
			lblX137.Text = x[2].ToString("0.0000000");
			lblIterCount17.Text = iterCount.ToString();

			ConjugateGradientsSolving.Solve(1e-2f, AmT, ZmT, out x, out iterCount);
			lblX212.Text = x[0].ToString("0.0000000");
			lblX222.Text = x[1].ToString("0.0000000");
			lblX232.Text = x[2].ToString("0.0000000");
			lblIterCount22.Text = iterCount.ToString();
			ConjugateGradientsSolving.Solve(1e-3f, AmT, ZmT, out x, out iterCount);
			lblX213.Text = x[0].ToString("0.0000000");
			lblX223.Text = x[1].ToString("0.0000000");
			lblX233.Text = x[2].ToString("0.0000000");
			lblIterCount23.Text = iterCount.ToString();
			ConjugateGradientsSolving.Solve(1e-4f, AmT, ZmT, out x, out iterCount);
			lblX214.Text = x[0].ToString("0.0000000");
			lblX224.Text = x[1].ToString("0.0000000");
			lblX234.Text = x[2].ToString("0.0000000");
			lblIterCount24.Text = iterCount.ToString();
			ConjugateGradientsSolving.Solve(1e-5f, AmT, ZmT, out x, out iterCount);
			lblX215.Text = x[0].ToString("0.0000000");
			lblX225.Text = x[1].ToString("0.0000000");
			lblX235.Text = x[2].ToString("0.0000000");
			lblIterCount25.Text = iterCount.ToString();
			ConjugateGradientsSolving.Solve(1e-5f, AmT, ZmT, out x, out iterCount);
			lblX216.Text = x[0].ToString("0.0000000");
			lblX226.Text = x[1].ToString("0.0000000");
			lblX236.Text = x[2].ToString("0.0000000");
			lblIterCount26.Text = iterCount.ToString();
			ConjugateGradientsSolving.Solve(1e-7f, AmT, ZmT, out x, out iterCount);
			lblX217.Text = x[0].ToString("0.0000000");
			lblX227.Text = x[1].ToString("0.0000000");
			lblX237.Text = x[2].ToString("0.0000000");
			lblIterCount27.Text = 5.ToString();
		}
	}
}
