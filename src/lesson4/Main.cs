using System;
using System.Collections.Generic;
using System.Linq;

namespace Concept.Linq.Lesson4 {
    class Human {
        public string Name { get; }
        public int Age { get; }
        public Human(string name, int age) => (Name, Age) = (name, age);
    }
    class Main {
        public void Run() {
            List<Human> humans = CreateHumans();
            Show(Query(humans));
        }
        private List<Human> CreateHumans() {
            return new List<Human> {
                new Human("A", 19), new Human("B", 32),
                new Human("C", 10), new Human("D", 36),
                new Human("E", 47), new Human("F", 58),
            };
        }
        private IEnumerable<IGrouping<dynamic,Human>> Query(in List<Human> humans) {
            return from h in humans
                   group h by new { h.Age, h.Name } into g
                   orderby g.Key.Age, g.Key.Name
                   select g;
        }
        private void Show(in IEnumerable<IGrouping<dynamic,Human>> groups) {
            foreach (var g in groups) {
                Console.WriteLine($"Key={g.Key}");
                foreach (var v in g) {
                    Console.WriteLine($"  Name:{v.Name}, Age:{v.Age}");
                }
            }
        }
    }
}
