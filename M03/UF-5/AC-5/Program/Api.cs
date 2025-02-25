using System;
using System.Collections.Generic;

public class Api<T>
{
    private List<T> elementos;
    public Api()
    {
        elementos = new List<T>();
    }

    // Agregar
    public void AgregarElemento(T elemento)
    {
        elementos.Add(elemento);
    }
    // Eliminar
    public void EliminarElemento(int indice)
    {
        if (indice >= 0 && indice < elementos.Count)
        {
            elementos.RemoveAt(indice);
        }
        else
        {
            Console.WriteLine("Índice fuera de rango");
        }
    }

    // Obtener
    public T ObtenerElemento(int indice)
    {
        if (indice >= 0 && indice < elementos.Count)
        {
            return elementos[indice];
        }
        else
        {
            Console.WriteLine("índice fuera de rango");
            return elementos[0];
        }
    }

    // Mostrar
    public void MostrarElementos()
    {
        foreach (var elemento in elementos)
        {
            Console.WriteLine(elemento.ToString());
        }
    }

    // Actualizar
    public void ActualizarElemento(int indice, T elemento)
    {
        if (indice >= 0 && indice < elementos.Count)
        {
            elementos[indice] = elemento;
            Console.WriteLine("Elemento actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Índice fuera de rango");
        }
    }

    // Buscar
    public List<T> BuscarElementos(Func<T, bool> condicion)
    {
        var resultados = new List<T>();
        foreach (var elemento in elementos)
        {
            if (condicion(elemento))
            {
                resultados.Add(elemento);
            }
        }
        return resultados;
    }
}