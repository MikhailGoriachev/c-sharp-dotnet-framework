/*Быстрая сотрировка QuickSort*/
using System;
namespace QuickSort
{
	class MainClass
	{
		public static void sorting(double[] arr, long first, long last)
		{
			double p = arr [(last - first) / 2 + first];
			double temp;
			long i = first, j = last;
				while(i <= j) {
				while (arr [i] < p && i <= last)
					++i;
				while (arr [j] > p && j >= first)
					--j;
					if(i <= j) {
					temp = arr [i];
					arr [i] = arr [j];
					arr [j] = temp;
					++i; --j;
					}
				}
			if (j > first)
				sorting (arr, first, j);
			if (i < last)
				sorting (arr, i, last);
		}
		public static void Main (string[] args)
		{ 
			double[] arr = new double[10];
			//заполняем массив случайными числами
			Random rd = new Random();
			for(int i = 0; i < arr.Length; ++i) {
				arr [i] = rd.Next (0, 10);
			}
			Console.WriteLine ("Отсортированный массив: ");
			foreach(double x in arr) {
				System.Console.Write (x + " ");
			}
		    sorting(arr, 0, arr.Length - 1);
			System.Console.WriteLine("\n\n Первый отсортированный элемент массива :");
			foreach(double x in arr) {
				System.Console.Write(x + " ");
				System.Console.WriteLine("\n\n Нажмите пожалуйста ENTER");
				System.Console.ReadLine();
			}
		}
	}
}