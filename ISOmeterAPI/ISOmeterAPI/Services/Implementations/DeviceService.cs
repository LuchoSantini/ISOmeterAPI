using ISOmeterAPI.Context;
using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.DeviceDTOs;
using ISOmeterAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace ISOmeterAPI.Services.Implementations
{
    public class DeviceService : IDeviceService
    {
        private readonly ISOmeterContext _context;

        public DeviceService(ISOmeterContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Device>> GetAllDevices()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task<Device> GetDeviceById(int id)
        {
            var deviceToReturn = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id.Equals(id));

            return deviceToReturn;
        }
        public bool AddDevice(AddDeviceDTO addDeviceDTO)
        {
            var existingDevice = _context.Devices
                .FirstOrDefault(p => p.Id == addDeviceDTO.Id);

            var existingUser = _context.Users
                .FirstOrDefault(u => u.Id == addDeviceDTO.UserId);

            if (existingDevice == null && addDeviceDTO.Id != 0 && existingUser != null)
            {
                Device newDevice = new Device
                {
                    Id = addDeviceDTO.Id,
                    Name = addDeviceDTO.Name,
                    Model = addDeviceDTO.Model,
                    RoomId = null,
                    UserId = addDeviceDTO.UserId,
                    Status = true
                };

                _context.Devices.Add(newDevice);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditDevice(int id, EditDeviceDTO editDeviceDTO)
        {
            var deviceToEdit = _context.Devices
                .FirstOrDefault(d => d.Id == id);

            if (deviceToEdit != null)
            {
                deviceToEdit.Name = editDeviceDTO.Name;
                deviceToEdit.Model = editDeviceDTO.Model;
                deviceToEdit.RoomId = editDeviceDTO.RoomId; // Por si el dispositivo cambió de habitación
                //deviceToEdit.Status = editDeviceDTO.Status; // Baja lógica

                _context.Devices.Update(deviceToEdit);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void ChangeDeviceStatus(int id, StatusDeviceDTO statusDeviceDTO)
        { 
            var deviceToChangeStatus = _context.Devices.FirstOrDefault(d => d.Id == id);

            if (deviceToChangeStatus != null)
            {
                deviceToChangeStatus.Status = statusDeviceDTO.Status;
                _context.Devices.Update(deviceToChangeStatus);
            }

            _context.SaveChanges();
        }
    }
}