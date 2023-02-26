using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineDevLibrary
{

    /// <summary>
    /// Класс иллюстрирует работу с итератором yield.
    /// Методы: 
    /// CreateEnumerable(int count) - создаем итератор, принимает на вход длину генерируемой коллекции 
    /// CreateEnumerableWithEnergyCheck(int count) - создает итератор, умеюбщий вовремя проверять аргумент
    /// UseForeach() - итерирует с помощью стандартного цикла foreach
    /// UseCreateEnumerable() - итерирует "ручным образом" явно вызывая методы итератора, визуализирует поток выполнения
    /// UseWithCheck() - итерирует с проверкой аргумента "ручным образом" явно вызывая методы итератора, визуализирует поток выполнения
    /// </summary>
    public class YieldExample
    {
        public static void UseForeach()
        {
            foreach (var b in CreateEnumerable(3))
            {
                Console.WriteLine("Fetching Current: " + b);
            }
        }

        public static void UseCreateEnumerable()
        {
            IEnumerable<int> iterable = CreateEnumerable(3);
            IEnumerator<int> iterator = iterable.GetEnumerator();
            Console.WriteLine("Statring to iterate");

            while (true)
            {
                Console.WriteLine("Colling MoveNext()");

                var result = iterator.MoveNext();
                Console.WriteLine("MoveNext: " + result);

                if (!result)
                {
                    break;
                }

                Console.WriteLine("Fetching Current: " + iterator.Current);

            }
        }

        public static void UseWithCheck()
        {
            IEnumerable<int> iterable = CreateEnumerableWithEnergyCheck(0);
            IEnumerator<int> iterator = iterable.GetEnumerator();
            Console.WriteLine("Statring to iterate");

            while (true)
            {
                Console.WriteLine("Colling MoveNext()");

                var result = iterator.MoveNext();
                Console.WriteLine("MoveNext: " + result);

                if (!result)
                {
                    break;
                }

                Console.WriteLine("Fetching Current: " + iterator.Current);

            }
        }




        private static IEnumerable<int> CreateEnumerable(int count)
        {
            Console.WriteLine("Start of CreateEnumerable()");
            for(var i = 0; i< count; i++)
            {
                Console.WriteLine("Before yield");
                yield return i;
                Console.WriteLine("After yield");
            }
            Console.WriteLine("After for");

            //можно объявлять сколько угодно много yield return и все они будут последовательно выполняться
            yield return -1;

            Console.WriteLine("End Start of CreateEnumerable()");
        }


        /// <summary>
        /// так как код в итераторе выполняется только после вызова MoveNext
        /// невозможно вовремя проверить предоставленные аргументы на корреткность
        /// Этот меод обертка предоставляет "энергичную проверку" - способ проверить аргумент вовремя
        /// </summary>
        private static IEnumerable<int> CreateEnumerableWithEnergyCheck(int count)
        {
            if(count == 0)
            {
                throw new Exception("Count isnt`t be 0");
            }
            return CreateEnumerable(count);
        }

    }
}
