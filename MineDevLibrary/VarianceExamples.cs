using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineDevLibrary
{
    /// <summary>
    /// примеры визуализирующие вариантности
    /// ковариантность - перенос от предка к потомку (возможность использовать потомка там где требуется предок)
    /// контрвариантность - перенос от потомка к предку (возможность исопльзовтаь предка там где нужен потомок) 
    /// инвариантность - наследование не переносится (можно использовать только то что требуется)
    /// </summary>
    internal class VarianceExamples
    {
        //иерархия наследования
        //Instrument -> Guitar
        private class Instrument { }
        private class Guitar  : Instrument{ }

        //вариантность - это перенос не между прямыми типами, а от типов к производным (т.е. нгапример к ообобщениям) 
        //ниже два листа и есть производные типы
        private List<Instrument> instruments= new List<Instrument>();
        private List<Guitar> guitars= new List<Guitar>();

        //ковариантность позволила бы передать сюда гиатры List<Guitar> (ну лист инвариантен)
        void CoVariance(List<Instrument> instruments) { }

        public void Example()
        {
           // CoVariance(guitars); - ошибка
        }
    }




}
