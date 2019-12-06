using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalWebApp.Entities;
using HospitalWebApp.Models;

namespace HospitalWebApp.Mappings
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OutPatient, OPViewModel>()
                .ForMember(dest => dest.PatientName, o => o.MapFrom(src => src.Patient.Name))
                .ForMember(dest => dest.OPEntryDate, o => o.MapFrom(src => src.Date))
                .ForMember(dest => dest.DoctorName, o => o.MapFrom(src => src.Doctor.DoctorName));

        }
    }
}
