using System;
using System.Collections.Generic;
using System.Linq;

public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new();

    public int Length => _people.Count;

    // Add a person to the queue with a number of turns
    public void AddPerson(string name, int turns)
    {
        _people.Enqueue(new Person(name, turns));
    }

    // Get the next person in line
    public Person GetNextPerson()
    {
        if (_people.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        Person person = _people.Dequeue();

        // Handle finite turns
        if (person.Turns > 0)
        {
            person.Turns--;
            if (person.Turns > 0)
                _people.Enqueue(person); // still has turns left
        }
        else
        {
            // Infinite turns: always put back
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return string.Join(", ", _people.Select(p => $"{p.Name}({p.Turns})"));
    }
}
