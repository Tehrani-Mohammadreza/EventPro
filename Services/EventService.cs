using EventEasePro.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class EventService
{
    private ConcurrentDictionary<int, Event> _events = new ConcurrentDictionary<int, Event>();
    private int _currentId = 1;
    private readonly object _idLock = new object();

    public ValueTask<List<Event>> GetEventsAsync()
    {
        return new ValueTask<List<Event>>(_events.Values.ToList());
    }

    public ValueTask<Event> GetEventAsync(int id)
    {
        _events.TryGetValue(id, out var ev);
        return new ValueTask<Event>(ev);
    }

    public ValueTask AddEventAsync(Event newEvent)
    {
        lock (_idLock)
        {
            newEvent.Id = _currentId++;
        }
        _events[newEvent.Id] = newEvent;
        return ValueTask.CompletedTask;
    }

    public ValueTask UpdateEventAsync(Event updatedEvent)
    {
        if (_events.ContainsKey(updatedEvent.Id))
        {
            _events[updatedEvent.Id] = updatedEvent;
        }
        return ValueTask.CompletedTask;
    }

    public ValueTask DeleteEventAsync(int id)
    {
        _events.TryRemove(id, out _);
        return ValueTask.CompletedTask;
    }
}
