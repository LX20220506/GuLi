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
            base.CreateMap<EduTeacher, EduTeacherDto>() // e表示EduTeacher；dto表示EduTeacherDto
                .ForMember(dto => dto.GmtCreate, // 将EduTeacher的DateTime类型映射为string类型
                opt => opt.MapFrom(
                    e => e.GmtCreate.ToString("yyyy-MM-dd HH:mm:ss")));
            
            base.CreateMap<EduTeacherDto, EduTeacher>()
                .ForMember(e => e.GmtCreate, // 将EduTeacherDto的string类映射为DateTime类型
                opt => opt.MapFrom(
                    dto =>DateTime.Parse(dto.GmtCreate)));
            //base.CreateMap<IEnumerable<EduTeacher>, IEnumerable<EduTeacherDto>>();
        }
    }
}
