﻿using System;

namespace BoOl.Application.Models.CustomServices
{
    public class CustomServiceListItemDto
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}
