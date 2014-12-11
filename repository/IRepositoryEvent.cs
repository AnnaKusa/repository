using System;
using System.Collections.Generic;

namespace repository
{
    public interface IRepositoryEvent : IDisposable
    {
        IEnumerable<Event> GetEvents();
        Event GetEventById(int id);
        void AddEvent(Event ev);
        void DeleteEvent(int id);
        void UpdateEvent(Event ev);
        void Save();
    }
}
