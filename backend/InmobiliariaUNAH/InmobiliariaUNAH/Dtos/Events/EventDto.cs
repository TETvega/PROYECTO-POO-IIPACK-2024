using InmobiliariaUNAH.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Dtos.Events
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public virtual UserEntity User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public decimal CostWhitoutDiscount { get; set; }
        public decimal CostDiscount { get; set; }
    }
}
