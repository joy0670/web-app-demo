using MongoDB.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Data
{
    public class EndWip
    {
        [Key]
        public Guid Id { get; set; }

        public string Value { get; set; }
        public Date Timestamp { get; set; }

    }
}
