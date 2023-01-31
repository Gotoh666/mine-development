﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineDevLibrary.Patterns.Strategy
{
    /// <summary>
    /// Пример применения паттерна Стратегия
    /// 
    /// Существует алгоритм записи на приём к врачу. 
    /// Чтобы пользователь мог записаться он должен выбрать номерок. 
    /// Существуют разные виды номерков, существуют больнциы разного профиля, существуют разные категории пользователей.
    /// Другими словами есть много улсовий от которых зависит какие именно номерки увидит пользователь. 
    /// Кроме того известно, что данная часть алгоритм постоянно меняется и добавляются новые способы получения номерков.
    /// 
    /// Существует интерфейс ISlotsStrategy - интерфейс стратегии подобра номерков
    /// 
    /// </summary>
    internal class Strategy
    {
        /// <summary>
        /// основной класс, отвечающий за запись на прием к врачу
        /// </summary>
        private class AppointmentManager
        {
            /// <summary>
            /// конкретный экземпляр стратегии будем хранить в првиатном поле
            /// </summary>
            private ISlotsStrategy _slotsStrategy;


            /// <summary>
            /// через консртуктор получаем конкретный экземпляр стратегии
            /// т.е. в этот конструткор можно передать абсолютно любой класс, реализующий интерфейс ISlotsStrategy
            /// </summary>
            /// <param name="strategy">Интерфейс стратегии</param>
            public AppointmentManager(ISlotsStrategy strategy) => _slotsStrategy = strategy;


            /// <summary>
            /// Метод поиска и возврата спсика номерков. 
            /// На вход условно принимает сессию пользователя чтобы по ней получить каки-то данные из БД.
            /// Алгоритм подбора номерков сводится к вызову метода GetSlots у интерфейса. Теперь можно легко менять 
            /// алгоритм который выолняет метод GetSlots просто передавая нужный экземпляр класса с алгоритмом.
            /// При этом код метода GetSlotsForWebSite менять уже не нужно. А занчит уменьшается потенциальная 
            /// возмоджность внести ошибки в работующий код.
            /// </summary>
            /// <param name="sessionId">сессия</param>
            public List<object> GetSlotsForWebSite(string sessionId)
            {
                //какой-то дополнительный код обрабатывающий запрос..(например поиск по сессии пациента его возрасат в базе данных)
                var age = 12;

                //непосредстенно вызов стратегии подобра номерков
                var slots = _slotsStrategy.GetSlots(age);


                //дополнительный код (например приведение номерков к определенному виду для выдачи на веб страницу и пр.)..

                return slots;
            }

        }





        /// <summary>
        /// интерфейс стратегии подобра номерков
        /// </summary>
        private interface ISlotsStrategy
        {
            /// <summary>
            /// метод подбора номерков.
            /// </summary>
            /// <param name="age">возраст пациента (для люього алгоритма мы должны знать номерки каких врачей нам нужны: детских или взрослых )</param>
            /// <returns>возвращает список номерков, которые можно отобразить пользователю</returns>
            List<object> GetSlots(int age);
        }



        /// <summary>
        /// конкретный класс, реализующий стратегию получения номерков для записи на первичный прием
        /// имеет алгоритм, отбирающий только номерки для первичного приема
        /// </summary>
        private class PrimarySlots : ISlotsStrategy
        {
            public List<object> GetSlots(int age)
            {
                return new List<object>();
            }
        }



        /// <summary>
        /// конкретный класс, реализующий стратегию получения номерков для записи на вакцинацию
        /// имеет алгоритм, отбирающий только номерки для вакцинации
        /// </summary>
        private class VaacinationSlots : ISlotsStrategy
        {
            public List<object> GetSlots(int age)
            {
                return new List<object>();
            }
        }


       


    }
}