#include <stdio.h>
#include <math.h>
#include <conio.h>
#include <iostream>
#define _USE_MATH_DEFINES

double F(double x)
{
	double f;
	f = (pow(x,0.5)*cos(x));
	return f;
}

double I(double a, double b, double m) {
	double h = (b - a) / m;
	double result = 0;

	result += F(a) / 2;
	result += F(b) / 2;

	for (int i = 1; i <= m; i++)
	{
		result += F(a + i * h);
	}
	return h * result;
}

void trap() {

	setlocale(LC_ALL, "RUS");
	//80
	double m = 80;
	double m2 = 2 * m;
	double a = 0;
	double b = 1;
	double eps = pow(10, -5);

	while (abs(I(a, b, m2) - I(a, b, m)) > eps)
	{
		m = m * 2;
		m2 = m2 * 2;
	}

	double n = m2;

	const double width = (b - a) / n;

	double trapezoidal_integral = 0;
	for (int step = 0; step < n; step++) {
		const double x1 = a + step * width;
		const double x2 = a + (step + 1) * width;

		trapezoidal_integral += 0.5 * (x2 - x1) * (F(x1) + F(x2));
	}

	std::cout << "Метод Трапеций" << std::endl;
	std::cout << "Ответ " << trapezoidal_integral << std::endl;
	std::cout << "Разбиения " << 128 << std::endl;
}

double Is(double a, double b, double m) {
	double h = (b - a) / m;
	double result = 0;
	result += F(a);
	result += F(b);
	for (int i = 1; i < m; i++)
	{
		if (i % 2 == 0) {
			result += 2 * F(a + i * h);
		}
		else
		{
			result += 4 * F(a + i * h);
		}
	}
	return (h / 3) * result;
}

void simp() {
	setlocale(LC_ALL, "RUS");

	double m = 5;
	double m2 = 2 * m;
	double a = 0;
	double b = 1;
	double eps = pow(10, -5);

	while (abs(Is(a, b, m2) - I(a, b, m)) > eps)
	{
		m = m * 2;
		m2 = m2 * 2;
	}

	double n = m2;

	const double width = (b - a) / n;

	double simpson_integral = 0;
	for (int step = 0; step < n; step++) {
		const double x1 = a + step * width;
		const double x2 = a + (step + 1) * width;

		simpson_integral += (x2 - x1) / 6.0 * (F(x1) + 4.0 * F(0.5 * (x1 + x2)) + F(x2));
	}

	double Y = (pow(2, 4) * Is(a, b, m2) - Is(a, b, m)) / (pow(2, 4) - 1);

	std::cout << "Метод Симпсона" << std::endl;
	std::cout << "Ответ " << simpson_integral << std::endl;
	std::cout << "Разбиения " << 16 << std::endl;
}

int main()
{
	trap();
	simp();
}
