﻿using ISOmeterAPI.Data.Entities;
using ISOmeterAPI.Data.Models.DeviceDTOs;

namespace ISOmeterAPI.Services.Interfaces
{
    public interface IDeviceService
    {
        public Task<IEnumerable<Device>> GetAllDevices();
        public Task<Device> GetDeviceById(int id);
        public bool AddDevice(AddDeviceDTO addDeviceDTO);
        public bool EditDevice(int id, EditDeviceDTO editDeviceDTO);
        public void ChangeDeviceStatus(int id, StatusDeviceDTO statusDeviceDTO);
    }
}
