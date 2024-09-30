﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ISOmeterAPI.Data.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public Room Room { get; set; }
        public int? RoomId { get; set; }
        public int UserId { get; set; }
        public ICollection<DeviceHistory> DeviceHistory { get; set; } = new List<DeviceHistory>();
        public bool Status { get; set; } // Baja lógica
    }
}
