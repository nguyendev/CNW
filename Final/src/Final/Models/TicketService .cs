using Final.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class TicketService : ITicketService
    {

        //        private readonly ApplicationDbContext _context;
        //        public TicketService(ApplicationDbContext context)
        //        {
        //            _context = context;
        //        }

        //        public Ticket Add(Ticket item)
        //        {
        //            _context.Tickets.Add(item);
        //            _context.SaveChanges();
        //            return item;
        //        }

        //        public void Delete(Ticket item)
        //        {
        //            throw new NotImplementedException();
        //        }

        //        public Ticket Get(int id)
        //        {
        //            return _context.Tickets.FirstOrDefault(x => x.Id == id && x.Status == 1);
        //        }

        //        public IQueryable<Ticket> GetAll()
        //        {
        //            return _context.Tickets.Where(x => x.Status == 1);
        //        }

        //        public Ticket Update(Ticket item)
        //        {
        //            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //            _context.SaveChanges();
        //            return item;
        //        }
        //    }
        //}
        public Ticket Add(Ticket item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Ticket item)
        {
            throw new NotImplementedException();
        }

        public Ticket Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public Ticket Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
