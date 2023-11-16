﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pequeño_programa_en_C_.Program;


namespace Pequeño_programa_en_C_
{
    internal class Program
    {
        //Establece la prioridad de los elementos
        public enum Prioridad:int
        {
            Alta=0,
            Media=1,
            Baja=2,
        }
        static void Main(string[] args)
        {   
            string ElementoAgrado;//Se encargar de almacenar el valor agg
            Boolean Bol = false;//Se encarga de finalizar el bucles

            //Crea la variable de la "Cola" para Rellenar o agregar elementos a la cola
            Queue<string> Cola = new Queue<string>();

            //Agrega elementos a la cola
            do
            {

                Console.Write("Agregar a cola: ");
                ElementoAgrado = Console.ReadLine();

                Cola.Enqueue(ElementoAgrado);
                Console.Write("Desea finalizar?True/false: ");
                Bol = Convert.ToBoolean(Console.ReadLine());

            } while (Bol == false);

            //Muestra los elemtos de la cola
            foreach(string ElementosCola in Cola)
            {
                Console.WriteLine(ElementosCola);
            }
            
            //Crea la cola de prioridad
            PriorityQueue<string> ColasDePrioridad = new PriorityQueue<string>();
            ColasDePrioridad.Enqueue("chao", 1);
            ColasDePrioridad.Enqueue("Hola", 0);
            ColasDePrioridad.Enqueue("Hola2", 0);

            ColasDePrioridad.Imprimir();

            Console.Write("Presione una tecla para finalizar...");
            Console.ReadKey(true);
        }
        public class PriorityQueue<T>
        {
            /*
             El constructor PriorityQueue() crea una instancia de la clase.
            Dentro del constructor, se crea un nuevo SortedList<int, Queue<T>> para almacenar los elementos y sus prioridades
             */
            private readonly SortedList<int, Queue<T>> _queues = new SortedList<int, Queue<T>>();
            /*
             El método Enqueue(T item, int priority) agrega un nuevo elemento a la cola con una prioridad específica.
            Primero, verifica si ya existe una cola en el SortedList<int, Queue<T>> con la prioridad especificada.
            Si no existe, se crea una nueva cola y se agrega al SortedList<int, Queue<T>>. Luego, el elemento se agrega a la cola
             */
            public void Enqueue(T item, int priority)
            {
                if (!_queues.TryGetValue(priority, out Queue<T> queue))
                {
                    queue = new Queue<T>();
                    _queues.Add(priority, queue);
                }

                queue.Enqueue(item);
            }
            /*
             El método Dequeue() elimina y devuelve el elemento con la prioridad más alta en la cola.
            La cola con la prioridad más alta se encuentra al inicio del SortedList<int, Queue<T>>.
            Si no hay ningún elemento en la cola, se lanza una excepción InvalidOperationException.
             */

            public T Dequeue()
            {
                foreach (KeyValuePair<int, Queue<T>> keyValuePair in _queues)
                {
                    if (keyValuePair.Value.Count > 0)
                    {
                        return keyValuePair.Value.Dequeue();
                    }
                }

                throw new InvalidOperationException("La cola esta vacia");
            }
            //El método Imprimir() recorre en iteración el SortedList<int, Queue<T>> y imprime en la consola todos los elemtos.
           public void Imprimir()
            {
                foreach (KeyValuePair<int, Queue<T>> keyValuePair in _queues)
                {
                    Console.WriteLine($"Prioridad {keyValuePair.Key}:");

                    foreach (T item in keyValuePair.Value)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
