using System;
using System.ComponentModel.DataAnnotations;

namespace FastO.Core
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
