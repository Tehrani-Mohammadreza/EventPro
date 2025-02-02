using EventEasePro.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class EventService
{
    private ConcurrentDictionary<int, Event> _events = new ConcurrentDictionary<int, Event>();
    private int _currentId = 1;

    public Task<List<Event>> GetEventsAsync()
    {
        return Task.FromResult(_events.Values.ToList());
    }

    public Task<Event> GetEventAsync(int id)
    {
        _events.TryGetValue(id, out var ev);
        return Task.FromResult(ev);
    }

    public Task AddEventAsync(Event newEvent)
    {
        newEvent.Id = _currentId++;
        _events[newEvent.Id] = newEvent;
        return Task.CompletedTask;
    }

    public Task UpdateEventAsync(Event updatedEvent)
    {
        if (_events.ContainsKey(updatedEvent.Id))
        {
            _events[updatedEvent.Id] = updatedEvent;
        }
        return Task.CompletedTask;
    }

    public Task DeleteEventAsync(int id)
    {
        _events.TryRemove(id, out _);
        return Task.CompletedTask;
    }
}

