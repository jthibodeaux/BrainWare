﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace CoreWebAppMVC.EFCore
{
    public partial class Company
    {
        public Company()
        {
            Orders = new HashSet<Order>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}