using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class SerializableQueue<T>
{
    [SerializeField] private List<T> _objectsList;
    private Queue<T> _objectsQueue = new Queue<T>();

    public bool Empty()
    {
        return _objectsQueue.Count == 0;
    }
    
    public T Dequeue()
    {
        if (!Empty())
            return _objectsQueue.Dequeue();
        else
            throw new InvalidOperationException();
    }

    public void UpdateQueue()
    {
        foreach (var element in _objectsList)
            _objectsQueue.Enqueue(element);
    }
}
