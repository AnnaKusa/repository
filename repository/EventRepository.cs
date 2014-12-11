using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace repository
{
    public class EventRepository: IRepositoryEvent
    {
        private LocalReportingEntities context;

        public EventRepository(LocalReportingEntities context)
        {
            this.context = context;
        }

        public IEnumerable<Event> GetEvents()
        {
            return context.Event.ToList();
        }

        public void AddEvent(Event Event)
        {
            context.Event.Add(Event);
        }

        public Event GetEventById(int id)
        {
            return context.Event.Find(id);
        }

        public void DeleteEvent(int id)
        {
            context.Event.Remove(GetEventById(id));
        }

        public void UpdateEvent(Event Event)
        {
            context.Entry(Event).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
