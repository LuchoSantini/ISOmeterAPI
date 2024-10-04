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
            return await _context.Devices
                .Where(x => x.Status == true)
                .ToListAsync();
        }

        public async Task<Device> GetDeviceById(int id)
        {
            var deviceToReturn = await _context.Devices
                .Where(x => x.Status != true)
                .FirstOrDefaultAsync(d => d.Id.Equals(id));

            return deviceToReturn;
        }
        public bool AddDevice(AddDeviceDTO addDeviceDTO)
        {
            var existingDevice = _context.Devices
                .FirstOrDefault(p => p.UniversalId == addDeviceDTO.UniversalId);

            //var existingUser = _context.Users
            //    .FirstOrDefault(u => u.Id == addDeviceDTO.UserId);

            if (existingDevice == null && addDeviceDTO.UniversalId != 0)
            {
                Device newDevice = new Device
                {
                    UniversalId = addDeviceDTO.UniversalId,
                    Name = addDeviceDTO.Name,
                    Model = addDeviceDTO.Model,
                    Description = addDeviceDTO.Description,
                    UserId = 2, // Solo hay un usuario, si se agrega autenticación tomarlo de las claims
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
                .FirstOrDefault(d => d.UniversalId == id);

            if (deviceToEdit != null)
            {
                deviceToEdit.UniversalId = editDeviceDTO.UniversalId;
                deviceToEdit.Name = editDeviceDTO.Name;
                deviceToEdit.Model = editDeviceDTO.Model;
                deviceToEdit.Description = editDeviceDTO.Description;

                //deviceToEdit.RoomId = editDeviceDTO.RoomId; // Por si el dispositivo cambió de habitación
                //deviceToEdit.Status = editDeviceDTO.Status; // Baja lógica

                _context.Devices.Update(deviceToEdit);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void ChangeDeviceStatus(int universalId, StatusDeviceDTO statusDeviceDTO)
        { 
            var deviceToChangeStatus = _context.Devices.FirstOrDefault(d => d.UniversalId == universalId);

            if (deviceToChangeStatus != null)
            {
                deviceToChangeStatus.Status = statusDeviceDTO.Status;
                _context.Devices.Update(deviceToChangeStatus);
            }

            _context.SaveChanges();
        }
    }
}