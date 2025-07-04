﻿using SchoolExam.Application.DTOs.ClassRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Application.Interfaces.Services
{
    public interface IClassRoomService
    {
        public ICollection<ClassRoomResponseDTO> GetAll(); 
        public Task<ClassRoomResponseDTO> GetById(int id);
        public Task<bool> Add(ClassRoomCreateDTO addDTO);
        public Task<bool> Update(ClassRoomUpdateDTO addDTO);
        public Task<bool> Delete(int id);
    }
}
