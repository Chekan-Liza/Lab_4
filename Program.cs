using System;
using System.Collections;
using System.Collections.Generic;
namespace Laba_4
{
    public class Node<T> //представляет простейший список однотипных объектов.
        //List<t> может хранить только объекты типа T.
    {
        public Node(T data)//Связный список - набор связанных узлов, каждый из которых хранит собственно данные и ссылку на следующий узел.
        {   Data = data;    }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class List<T> : IEnumerable<T> //Односвязный список
    /*Благодаря такой реализации мы можем перебирать объекты в цикле foreach
     Интерфейс IEnumerable имеет метод, возвращающий ссылку на другой интерфейс - перечислитель:*/
    {
        Node<T> head; //первый элемент
        Node<T> tail; // последний элемент
        int count; // количество элементов в списке
        public void Add(T data)//Добавление в список
        {   Node<T> node = new Node<T>(data);
            if (head == null)
            { head = node; }
            else
            { tail.Next = node;}
            tail = node;
            count++;
        }
        public bool Remove(T data)//Удаление первого элемента
        {   Node<T> current = head;
            while (current != null)
            {   if (current.Data.Equals(data))
                {
                    {   head = head.Next; //Устан. значение head 
                        if (head == null) //Если после удаления список пуст, сбрасываем tail
                        { tail = null;}
                    }
                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public void Clear() //Очистка списка
        {   head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(T data) //Метод для поиска элементов
        {   Node<T> current = head;
            while (current != null)
            {   if (current.Data.Equals(data))
                { return true;}
                current = current.Next;
            }
            return false;
        }
        public void AddBegin(T data) //Добавление в начало
        {   Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
            { tail = head;}
            count++;
        }
        IEnumerator IEnumerable.GetEnumerator() //Реализация интерфейса IEnumerable
        {   return ((IEnumerable)this).GetEnumerator(); }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {   Node<T> current = head;
            while (current != null)
            {   yield return current.Data;
                current = current.Next;
            }
        }
        public static List<T> operator --(List<T> list) //Удаление первого//ПЕРЕГРУЗКА
        {   foreach (var item in list)
            {  
                {   list.Remove(item);
                    break; }
            }
            return list;
        }
        public static List<T> operator +(List<T> list, T data) //Добавление элемента в начало//ПЕРЕГРУЗКА
        {   list.AddBegin(data); 
            return list;
        }
        public static List<T> operator *(List<T> list_1, List<T> list_2) //Объединение двух списков
        {
                foreach (T item in list_1)
                { list_2=list_2+item;}
                return list_2;
        }
        public static bool operator !=(List<T> list_1, List<T> list_2) //Проверка на неравенство//ПЕРЕГРУЗКА
        {   if (list_1.count == list_2.count)
            {   foreach (T item in list_1)
                {   if (!list_2.Contains(item))
                    {   return true; }
                }
                return false;
            }
            else
            { return true; }
        }
        public static bool operator ==(List<T> list_1, List<T> list_2)//Перегрузка парой
        {   if (list_1 != list_2)
            {   return false; }
            else
            {   return true;}
        }
        public class Owner //Вложенный OWNER
        {   private string id;
            private string name;
            private string org;
            public Owner(string id, string name, string org)
            {   this.id = id;
                this.name = name;
                this.org = org;
            }
            public string ID
            { get { return id; } }
            public string Name
            { get { return name; } }
            public string Org
            { get { return org; } }
        }
        public class Date //Вложенный DATE
        {   private string _DateOfCreation;
            public string DateOfCreation
            {   get { return _DateOfCreation; } }
            public Date(string _DateOfCreation)
            {   this._DateOfCreation = _DateOfCreation; }
        }
    }
    public static class ListExtension
    {
        public static string NumCap(this List<string> list) //Подсчет количества слов, нач. с заглавной буквы в списке
        { int count = 0;
            foreach (var item in list)
                if (item[0] == item.ToUpper()[0])
                { count++; }
            string s1 = count.ToString();
            return s1;
        }
        public static string maxWordLength(this List<string> list) //Поиск самого длинного слова в списке
        {   int max = 0;
            string _str = "";
            foreach (var item in list)
                if (item.Length > max)
                {   max = item.Length;
                    _str = item; }
            return _str;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {   List<string> List_1 = new List<string>();
            List<string> List_2 = new List<string>();
            List<string> List_3 = new List<string>();

            List_1.Add("1) apple");
            List_1.Add("2) banana");
            List_1.Add("3) love");
            List_1.Add("4) nice");

            List_2.Add("Hero");
            List_2.Add("commander");
            List_2.Add("Egoist");
            List_2.Add("devil");

            List_3.Add("Hero");
            List_3.Add("commander");
            List_3.Add("Egoist");
            List_3.Add("devil");

            Console.WriteLine("Элементы списка List_1: ");
            foreach (var item in List_1)
            {   Console.Write(item+". "); }
            Console.WriteLine("\nЭлементы списка List_2: ");
            foreach (var item in List_2)
            { Console.Write(item + ". "); }
            Console.WriteLine("\nЭлементы списка List_3: ");
            foreach (var item in List_3)
            { Console.Write(item + ". "); }

            Console.WriteLine("\nУдаление первого элемента из списка List_1:");
            List_1 = --List_1;

            foreach (var item in List_1)
            { Console.Write(item + ". "); }

            Console.WriteLine("\nВставка элемента в начало списка List_1:");
            List_1 = List_1 + "1) HELLO";

            foreach (var item in List_1)
            { Console.Write(item + ". "); }

            Console.WriteLine("\nПроверка на равенство списков List_1 и List_2:");
            if (List_1 == List_2)
            {   Console.WriteLine("Списки List_1 и List_2 равны"); }
            else
            {   Console.WriteLine("Списки List_1 и List_2 не равны");}

            Console.WriteLine("\nПроверка на равенство списков List_3 и List_2:");
            if (List_3 != List_2)
            {   Console.WriteLine("Списки List_3 и List_2 не равны");}
            else
            {   Console.WriteLine("Списки List_3 и List_2 равны"); }

            Console.WriteLine("\nКоличесвто слов в списке List_3 (с заглавной):");
            Console.WriteLine(List_3.NumCap()); 

            List<string>.Owner owner = new List<string>.Owner("1234", "Chekan", "BSTU");
            Console.WriteLine($"\nВладелец: ID: {owner.ID}, фамилия: {owner.Name}, университет: {owner.Org}");
            List<string>.Date date = new List<string>.Date("01.10.2020");
            Console.WriteLine($"Дата создания: {date.DateOfCreation}");

            Console.WriteLine("\nОбъединение списков List_1 и List_2:");
            List_1 = List_1*List_2;

            foreach (var item in List_2)
            { Console.Write(item + ". "); }

            Console.WriteLine("\nСамое длинное слово в списке List_3:");
            Console.WriteLine(List_3.maxWordLength());
        }
    }
}