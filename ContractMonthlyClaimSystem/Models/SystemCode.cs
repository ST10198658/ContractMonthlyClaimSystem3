﻿using System.ComponentModel.DataAnnotations;

namespace ContractMonthlyClaimSystem.Models
{
    public class SystemCode
    {
        [Key]
        
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}