using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    interface ITicketService
    {
        IQueryable<Ticket> GetAll();
        Ticket Add(Ticket item);
        Ticket Update(Ticket item);

        void Delete(Ticket item);
        Ticket Get(int id);
    }
}
