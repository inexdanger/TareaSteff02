namespace BlazorApp6;

public class ColaCircular<T>
{
    private T[] elementos;
    private int frente, final, tamaño;

    public ColaCircular(int capacidad)
    {
        elementos = new T[capacidad];
        tamaño = capacidad;
        frente = final = -1;
    }

    public bool EstaVacia() => frente == -1;

    public bool EstaLlena() => (final + 1) % tamaño == frente;

    public void Encolar(T elemento)
    {
        if (EstaLlena()) return;
        if (EstaVacia()) frente = 0;
        final = (final + 1) % tamaño;
        elementos[final] = elemento;
    }

    public T? Desencolar()
    {
        if (EstaVacia()) return default;
        T elemento = elementos[frente];
        if (frente == final) frente = final = -1;
        else frente = (frente + 1) % tamaño;
        return elemento;
    }

    public List<T> ObtenerElementos()
    {
        List<T> lista = new();
        if (EstaVacia()) return lista;
        int i = frente;
        while (true)
        {
            lista.Add(elementos[i]);
            if (i == final) break;
            i = (i + 1) % tamaño;
        }
        return lista;
    }
}
