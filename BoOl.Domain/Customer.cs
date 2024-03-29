﻿using System;
using System.Collections.Generic;

namespace BoOl.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public double? Discount { get; set; }

        public List<Product> Products { get; set; }
    }
}
