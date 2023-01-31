using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineDevLibrary
{
    public class Delegates
    {
        //тип делегата
        delegate void StringProcessor(string input);

        //использование делегата
        public static void SimpleDelegateUse()
        {
            Person jon = new Person();
            StringProcessor jonsVoice;
            jonsVoice = new StringProcessor(Say);
            jonsVoice += jon.Say;

            jonsVoice("Lol");
        }

        
        class Person
        {
            public void Say(string message)
            {
                Console.WriteLine(message);
            }
        }

        private static void Say(string message)
        {
            Console.WriteLine("Static " + message);
        }
    }
}
