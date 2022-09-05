using AutoMapper;
using glkt.EF;
using glkt.Model.DTO.Edu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glkt.Common.Utils.AutoMapper
{
    public class CustomAutoMapperProfile : Profile
    {
        public CustomAutoMapperProfile()
        {
            base.CreateMap<EduTeacher, EduTeacherDto>();
            base.CreateMap<EduTeacherDto, EduTeacher>();
            //base.CreateMap<IEnumerable<EduTeacher>, IEnumerable<EduTeacherDto>>();
        }
    }
}
