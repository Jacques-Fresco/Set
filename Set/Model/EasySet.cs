using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set.Model
{
    public class EasySet<T> : IEnumerable
    {
        private List<T> items = new List<T>();
        public int Count => items.Count;
        public EasySet() { }
        public EasySet(T data)
        {
            items.Add(data);
        }
        public EasySet(IEnumerable<T> items) 
        {
            this.items = items.ToList();
        }
        public void Add(T item)
        {
            if (items.Contains(item)) return;

            /*foreach(T i in items)
            {
                if(i.Equals(item))
                {
                    return;
                }
            }*/

            items.Add(item);
        }
        public void Remove(T item)
        {
            items.Remove(item);
        }

        public EasySet<T> Union(EasySet<T> set)
        {
            //return new EasySet<T>(items.Union(set.items)); // с помощью linq (она лучше, так как оптимизирована внутри самого linq)

            EasySet<T> result = new EasySet<T>();

            foreach (T item in items) // Добавляем в коллекцию все элементы из первой
            {
                result.Add(item);
            }

            foreach (T item in set.items) // Добавляем в коллекцию те элементы, которых не было в впервой
            {
                result.Add(item); // проверка на наличие элемента производится в Add
            }

            return result;
        }
        public EasySet<T> Intersection(EasySet<T> set)
        {
            //return new EasySet<T>(items.Intersect(set.items)); // с помощью linq (она лучше, так как оптимизирована внутри самого linq)
            EasySet<T> result = new EasySet<T>();

            // Для оптимизации
            // A = 1 2 5; B = 1 2 3 7 5;
            // Если начинать перебирать с B, то => [1]1 + [2]2 + [3]3 + [7]3 + [5]3 = 12 проходов
            // Если начинать перебирать с A, то => [1]1 + [2]2 + [5]5 = 8 проходов

            {
                EasySet<T> big;
                EasySet<T> small;
                if (Count >= set.Count)
                {
                    big = this;
                    small = set;
                }
                else
                {
                    big = set;
                    small = this;
                }
            }

            foreach (T itemOne in items) // Добавляем в коллекцию все элементы из первой
            {
                foreach (T itemTwo in set.items)
                {
                    if (itemOne.Equals(itemTwo))
                    {
                        result.Add(itemOne);
                        break;
                    }
                }
            }

            return result;
        }
        public EasySet<T> Difference(EasySet<T> set)
        {
            EasySet<T> result = new EasySet<T>(items);

            foreach(T item in set.items)
            {
                result.Remove(item);
            }

            return result;
        }
        public bool Subset(EasySet<T> set)
        {
            // все элементы подмножества должны содержаться внутри базового множества
            //return items.All(i => set.items.Contains(i)); // Если хотя бы один false? то всё false

            foreach(T item1 in items)
            {
                bool equals = false;
                foreach(T item2 in set.items)
                {
                    if(item1.Equals(item2))
                    {
                        equals = true;
                        break;
                    }
                }
                if (!equals) return false;
            }

            return true;
        }
        public EasySet<T> SymmetricDifference(EasySet<T> set)
        {
            // ищем две разности, а потом их просто объединяем, в дальнейшем передавая полученное значение в качестве параметра в конструктор
            //return new EasySet<T>(items.Except(set.items).Union(set.items.Except(items)));

            EasySet<T> result = new EasySet<T>();

            foreach (T item1 in items)
            {
                bool flag = false;
                foreach(T item2 in set.items)
                {
                    if(item1.Equals(item2))
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag) result.Add(item1);
            }

            foreach (T item1 in set.items)
            {
                bool flag = false;
                foreach (T item2 in items)
                {
                    if (item1.Equals(item2))
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag) result.Add(item1);
            }

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
