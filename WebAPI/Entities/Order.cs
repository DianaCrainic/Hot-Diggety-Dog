
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebAPI.Data;

namespace WebAPI.Entities
{
    public class Order : BaseEntity
    {
        public DateTime Timestamp { get; set; }
        public double Total { get; set; }

        [ForeignKey("Operator")]
        public Guid OperatorId { set; get; }


        [ForeignKey("User")]
        public Guid UserId { set; get; }


        [JsonIgnore]
        [InverseProperty("ClientOrders")]
        public User User { get; set; }
        [JsonIgnore]
        [InverseProperty("OperatorOrders")]
        public User Operator { get; set; }
    }
}
