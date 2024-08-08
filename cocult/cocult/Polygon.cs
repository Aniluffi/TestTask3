using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocult
{
    class Polygon : Figure
    {

        /// <summary>
        /// поле для хранения x вершины
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// поле для хранения y вершины
        /// </summary>
        public int Y { get; set; }

       /// <summary>
       /// поле для хранения колличества вершин
       /// </summary>
        public static int NumVertex { get; set; }
        /// <summary>
        /// двуступенчатый массив для хранения всех вершин
        /// </summary>
        static int[,] polygonVertex;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="n">колличество вершин</param>
        public Polygon(int n)
        {
            NumVertex = n + 1;
            polygonVertex = new int[NumVertex, 2];
        }

        /// <summary>
        /// метод для ввода вершин
        /// </summary>
        public void Input()
        {
            int[,] array = polygonVertex;

            for (int i = 0; i < polygonVertex.GetLength(0) - 1; i++)
            {
                Console.WriteLine($"Ввод данных вершины {i}");
                Console.WriteLine($"Ввод X{i}");
                polygonVertex[i, 0] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Ввод Y{i}");
                polygonVertex[i, 1] = Convert.ToInt32(Console.ReadLine());
            }

            polygonVertex[NumVertex -1, 0] = array[0, 0];
            polygonVertex[NumVertex - 1, 1] = array[0, 1];
        }

        /// <summary>
        /// метод вычисления периметра многоугольника
        /// </summary>
        /// <returns>возращает периметр многоугольника</returns>
        public override double P()
        {
            double p = 0;

            for(int i = 0; i < polygonVertex.GetLength(0)-1; i++)
            {
                p += Math.Pow(polygonVertex[i+1,1] - polygonVertex[i,1],1) + Math.Pow(polygonVertex[i + 1,0 ] - polygonVertex[i, 0], 2);   
            }

            return Math.Sqrt(p);
        }

        /// <summary>
        /// метод вычисления площадь многоугольника
        /// </summary>
        /// <returns>возращает площадь многоугольника</returns>
        public override double S()
        {
            double num1 = 0;
            double num2 = 0;

            for (int i = 0; i < polygonVertex.GetLength(0)-1; i++)
            {
                num1 += polygonVertex[i,0 ] * polygonVertex[i + 1,1 ];
                num2 += polygonVertex[i,1 ] * polygonVertex[i + 1, 0];
            }

            return Math.Abs(num1 - num2) / 2;
        }

        /// <summary>
        /// метод для вывода информации о многоугольнике
        /// </summary>
        public override void OutputInf()
        {
            Console.WriteLine($"Многоугольник ");
            for (int i = 0; i < polygonVertex.GetLength(0); i++)
            {
                Console.WriteLine($"Вершина {i}; ({polygonVertex[i, 0]};{polygonVertex[i,1]})");
            }
        }
    }
}
