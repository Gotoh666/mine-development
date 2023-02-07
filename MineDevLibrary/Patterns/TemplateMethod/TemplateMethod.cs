using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineDevLibrary.Patterns.TemplateMethod
{
    /// <summary>
    /// пример применения паттерна Шаблонный метод
    /// 
    /// Существует алгоритм записи на приём к врачу. 
    /// Чтобы пользователь мог записаться он должен выбрать номерок. 
    /// Существуют разные виды номерков, существуют больнциы разного профиля, существуют разные категории пользователей.
    /// Другими словами есть много улсовий от которых зависит какие именно номерки увидит пользователь. 
    /// Кроме того известно, что данная часть алгоритм постоянно меняется и добавляются новые способы получения номерков.
    /// 
    /// Существует абстрактный класс SlotsBase - базовый абстрактный класс реализующий общий алгоритм подобра номерков
    /// 
    /// </summary>
    public class TemplateMethod
    {
        /// <summary>
        /// абстрактный класс, содержащий общий алгоритм для выдачи номерков
        /// </summary>
        public abstract class SlotsBase
        {
            //основной метод с общим алгоритмом выдачи номерков
            // алгоритм следующий:
            // 1) Получаем данные сессиии
            // 2) По данным сессии ищем дополнительную информацию (в данном случае данные пациента)
            // 3) Получаем номерки на основе данных о пациента
            // 4) трансформируем номерки для отображения
            public List<object> GetSlotsForWebSite(string sessionId)
            {
                var sessionData = GetSessionData(sessionId);

                var patient = GetPatientFromdDb(sessionData);

                //этот метод является абстрактным и должен быть реализован конкретным классом 
                var slots = GetSlots(patient);

                return ModifySlotsForView(slots);
            }

            //заглушка для имитации получения сессии
            private object GetSessionData(string sessionId) { return new object(); }
            //заглушка для имитации получения данных пациента
            private object GetPatientFromdDb(object sessionData) { return new object(); }
            //заглушка для имитации модификации номерков
            private List<object> ModifySlotsForView(List<object> slots) { return new List<object>(); }

            //метод получения номерков
            public abstract List<object> GetSlots(object patient);

        }





        /// <summary>
        /// конкрнетный класс для получения номерков на первичный прием
        /// в классе реализуются методы получения и модификации номерков специальным для записи на первичный прием образом
        /// </summary>
        public class PrimarySlots : SlotsBase
        {
            public override List<object> GetSlots(object patient)
            {
                throw new NotImplementedException();
            }

            public override List<object> ModifySlotsForView(List<object> slots)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// конкрнетный класс для получения номерков на вакцинацию 
        /// в классе реализуются методы получения и модификации номерков специальным для записи на вакцинацию образом
        /// </summary>
        public class VaacinationSlots : SlotsBase
        {
            public override List<object> GetSlots(object patient)
            {
                throw new NotImplementedException();
            }

            public override List<object> ModifySlotsForView(List<object> slots)
            {
                throw new NotImplementedException();
            }
        }
    }
}
