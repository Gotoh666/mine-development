using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineDevLibrary
{


    /// <summary>
    /// типичная простая реализация паттерна с исопльзованием Yield 
    /// </summary>
    internal class CustomCollectionWithYield : IEnumerable<int>
    {
        //основа коллекции 
        private readonly List<int> _list;

        //принимаем лист в конструкторе нашей коллекции
        public CustomCollectionWithYield(List<int> list) { _list = list; }

        //возвращаем итератор
        public IEnumerator<int> GetEnumerator()
        {
            foreach(var e in _list)
            {
                yield return e;
            }
        }

        //так как IEnumerator<T> наследует IEnumerator, необходимо реализовать и метод из IEnumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }



    /// <summary>
    /// типичная простая реализация паттерна без исопльзования Yield 
    /// здесь мы сами реализовали IEnumerator вместо использования Yield
    /// </summary>
    internal class CustomCollection : IEnumerable<int>
    {
        //основа коллекции 
        private readonly List<int> _list;

        //принимаем лист в конструкторе нашей коллекции
        public CustomCollection(List<int> list) { _list = list; }

        //возвращаем собственный итератор
        public IEnumerator<int> GetEnumerator()
        {
            return new CustomCollectionEnumerator(_list);
        }

        //так как IEnumerator<T> наследует IEnumerator, необходимо реализовать и метод из IEnumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }





        // релаизация итератора 
        private class CustomCollectionEnumerator : IEnumerator<int>
        {
            //каждый итератор независим и возвращает новый экземпляр, так что ему нужен свой экземпляр коллекции для перечисления
            private readonly List<int> _list;

            //сохраням позицию (так как перечисление начинается с вызова метода MoveNext нужно установить индекс в -1, тогда первый вызов MoveNext вернет элемент с индексом 0)
            private int _index = -1;

            //устанавливаем коллекцию для экземпляра итератора
            public CustomCollectionEnumerator(List<int> list)
            {
                _list = list;
            }

            //свойство, которое возвращает текущий элемент
            public int Current {
             get
             {
                  if (_index == -1 || _index >= _list.Count) throw new ArgumentException();
                 
                  return _list[_index];
             }
            }

            //помним, что зависим от необобщенного интерфейса IEnumerator, поэтому реализуем и его метод
            object IEnumerator.Current => Current;

            //метод для перехода к следующему элементу
            public bool MoveNext()
            {
                if(_index<_list.Count-1) 
                {
                    _index++;
                    return true;
                }
                return false;
            }

            //мы не работаем с неуправляемыми ресурсами и нам не нужно реализовывать Dispose
            public void Dispose()
            {
            }

            
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }


    
}
