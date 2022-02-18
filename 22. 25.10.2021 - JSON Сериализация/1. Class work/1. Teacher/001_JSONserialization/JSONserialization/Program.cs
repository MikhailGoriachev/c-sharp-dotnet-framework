using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Json;  // для JSON
using System.Runtime.Serialization;

using System.Xml.Serialization;

using JSONserialization.Models;

namespace JSONserialization
{

    class Program
    {
        
        // JSON - JavaScript Object Notation

        // Для сериализации объектов в формат JSON в пространстве System.Runtime.Serialization.Json 
        // определен класс DataContractJsonSerializer. Чтобы задействовать этот класс, в проект надо 
        // добавить сборку System.Runtime.Serialization.dll. 
        // Для записи объектов в json-файл в этом классе имеется метод WriteObject(), 
        // а для чтения ранее сериализованных объектов - метод ReadObject().
		
		// Класс для сериализации должен быть помечен атрибутом [DataContract], каждое поле/свойство
        // класса для сериализации должно быть помечено атрибутом [DataMember]		
        static void Main(string[] args) {
            Console.Title = "Занятие 25.10.2021 - сериализация в формат JSON, десериализация из формата JSON";

            // один простой объект (без ссылочных полей)
            // SimpleDemo("../../person.json");
            // Console.WriteLine("───────────────────────────────────────────────────\n");
            
            // коллекция простых объектов (без ссылочных полей)
            // CollectionDemo("../../people.json");
            // Console.WriteLine("───────────────────────────────────────────────────\n");

            // коллекция сложных объектов (со ссылочными полям)
            ComplexObjectDemo("../../workers.json");
            // Console.WriteLine("───────────────────────────────────────────────────\n\n\n");
        } // Main


        // один простой объект (без ссылочных полей)
        private static void SimpleDemo(string fileName) {
            // объект для сериализации
            Person person1 = new Person("Егорова", "Света", 29);
            Person person2 = new Person("Кантария", "Олег", 28);
            Console.WriteLine($"Объекты созданы\n{person1}\n{person2}");

            // форматтеру надо передавать тип
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Person));

            // получаем поток данных, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
                // jsonFormatter.WriteObject(fs, person1);
                jsonFormatter.WriteObject(fs, person2);

                Console.WriteLine("\nОбъект/объекты сериализован/сериализованы");
            } // using

            // десериализация
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
                // Person newPerson = (Person)jsonFormatter.ReadObject(fs);
                Person newPerson = (Person)jsonFormatter.ReadObject(fs);

                Console.WriteLine("\nОбъект/объекты десериализован/десериализованы");
                Console.WriteLine($"{newPerson}");
            } // using

        } // SimpleDemo


        // сериализация/десериализация коллекций
        private static void CollectionDemo(string fileName) {
            Person[] people = {
                new Person("Иванова", "Марина",   29),
                new Person("Романов", "Леонид",   25),
                new Person("Серова",  "Ирина",    23),
                new Person("Глебова", "Наталья",  26),
                new Person("Бацуца",  "Арсений",  38),
                new Person("Вятчина", "Кристина", 28)
            };

            List<Person> listPerson = new List<Person>(people);

            // форматтеру надо передавать тип
            // DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Person>));
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Person[]));

            using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
                jsonFormatter.WriteObject(fs, people);
                // jsonFormatter.WriteObject(fs, listPerson);
            } // using

            Console.WriteLine("Сериализация выполнена");

            // десериализация в массив/список
            // Person[] newPeople= null;
            List<Person> newPeople = null;
            jsonFormatter = new DataContractJsonSerializer(typeof(List<Person>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
                newPeople = (List<Person>)jsonFormatter.ReadObject(fs);
                // newPeople = (Person[])jsonFormatter.ReadObject(fs);
            } // using

            Console.WriteLine("\nДесериализация выполнена\n");

            foreach (Person p in newPeople) {
                Console.WriteLine(p);
            } // foreach
        } // CollectionDemo

        /// <summary>
        /// коллекции сложных объектов
        /// </summary>
        /// <param name="fileName"></param>
        private static void ComplexObjectDemo(string fileName) {
            Worker[] workers = {
                new Worker("Иванова",  "Марина", 29, new Company("B", 1e6)),
                new Worker("Романов",  "Леонид", 25, new Company("Contoso", 23e6)),
                new Worker("Серова",   "Ирина",  23, new Company("Борей", 23000)),
                new Worker("Михайлов", "Игорь",  37, new Company("Борей", 23000)),
                new Worker("Безос",    "Джефф",  54, new Company("Amazon", 23e6)),
                new Worker("Старк",    "Тони",   48, new Company("Stark Industries", 12e8))
            };
            List<Worker> listWorkers = new List<Worker>(workers);

            // форматтеру надо передавать тип
            // DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Worker[]));
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Worker>));

			// Запись сложного объекта в JSON-файл
            using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
                // jsonFormatter.WriteObject(fs, workers);
                jsonFormatter.WriteObject(fs, listWorkers);
            } // using

            // Удаляем коллекцию из памяти - для чистоты эксперимента. Если не сумеем
            // прочитать данные из файла - очень плохо... 			
            // Worker[] newWorkers = null;
            List<Worker> newListWorkers = null;
			
			// Читаем коллекцию из JSON-файла
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
                // newWorkers = (Worker[])jsonFormatter.ReadObject(fs);
                newListWorkers = (List<Worker>)jsonFormatter.ReadObject(fs);
            } // using

            // Вывод коллекции в консоль
            // foreach (Worker p in newWorkers) {
            foreach (Worker p in newListWorkers) {
                Console.WriteLine(p);
            } // foreach
        } // ComplexObjectDemo
    } // class Program
}
